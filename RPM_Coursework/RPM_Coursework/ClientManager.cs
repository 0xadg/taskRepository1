using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RPM_Coursework
{
    class ClientManager
    {
        private Socket socket;
        private string clientName;
        NetworkStream networkStream;
        private BackgroundWorker listener;
        private Semaphore semaphore = new Semaphore(1, 1);
        public string ID = Guid.NewGuid().ToString();
        public IPAddress IP
        {
            get => socket != null ? ((IPEndPoint)socket.RemoteEndPoint).Address : IPAddress.None;
        }
        public int Port
        {
            get => socket != null ? ((IPEndPoint)socket.RemoteEndPoint).Port : -1;
        }
        public bool Connected
        {
            get => socket != null ? socket.Connected : false;
        }
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }

        public ClientManager (Socket clientSocket)
        {
            socket = clientSocket;
            networkStream = new NetworkStream(socket);
            listener = new BackgroundWorker();
            listener.DoWork += new DoWorkEventHandler(StartReceiving);
            listener.RunWorkerAsync();
        }

        #region Закрытые методы
        
        /// <summary>
        /// Метод прослушивания входящих сообщений
        /// </summary>
        /// <param name="sender">Источник</param>
        /// <param name="e">Аргументы</param>
        private void StartReceiving(object sender, DoWorkEventArgs e)
        {
            while(socket.Connected)
            {
                // Тип сообщения
                byte[] buffer = new byte[4];
                int readBytes = networkStream.Read(buffer, 0, 4);
                if (readBytes == 0) break;
                MessageType mt = (MessageType)BitConverter.ToInt32(buffer, 0);

                // Размер массива адресов получателей
                buffer = new byte[4];
                readBytes = networkStream.Read(buffer, 0, 4);
                if (readBytes == 0)
                    break;
                int epArrSize = BitConverter.ToInt32(buffer, 0);

                IPEndPoint[] targets = new IPEndPoint[epArrSize];

                for (int i = 0; i < epArrSize; i++)
                {
                    // seq reading our addresses
                    buffer = new byte[4];
                    readBytes = networkStream.Read(buffer, 0, 4);
                    if (readBytes == 0)
                        break;
                    int epSize = BitConverter.ToInt32(buffer, 0);

                    buffer = new byte[epSize];
                    readBytes = networkStream.Read(buffer, 0, epSize);
                    if (readBytes == 0)
                        break;
                    targets[i] = Utility.CreateIPEndPoint(Encoding.UTF8.GetString(buffer));
                }

                buffer = new byte[4];
                readBytes = networkStream.Read(buffer, 0, 4);
                if (readBytes == 0)
                    break;
                MessageContentType ct = (MessageContentType)BitConverter.ToInt32(buffer, 0);

                // Размер контента
                buffer = new byte[4];
                readBytes = networkStream.Read(buffer, 0, 4);
                if (readBytes == 0)
                    break;
                int contentSize = BitConverter.ToInt32(buffer, 0);

                buffer = new byte[contentSize];
                readBytes = networkStream.Read(buffer, 0, contentSize);
                if (readBytes == 0)
                    break;

                Message msg = new Message(targets, mt, buffer);
                msg.ContentType = ct;
                msg.SenderEndPoint = new IPEndPoint(IP, Port);
                if (msg.Type == MessageType.ConnectMessage)
                    msg.SenderName = msg.RetrieveText();
                else
                    msg.SenderName = clientName;
                OnMessageReceived(new MessageEventArgs(msg));
            }
            OnDisconnected(new ClientEventArgs(socket));
            Disconnect();
        }

        private void sender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && ((bool)e.Result))
                this.OnMessageSent(new EventArgs());
            else
                this.OnMessageFailed(new EventArgs());

            ((BackgroundWorker)sender).Dispose();
            GC.Collect();
        }
        
        /// <summary>
        /// Метод завершения работы отправщика
        /// </summary>
        /// <param name="sender">Источник</param>
        /// <param name="e">Аргументы</param>
        private void sender_DoWork(object sender, DoWorkEventArgs e)
        {
            Message msg = (Message)e.Argument;
            e.Result = SendMessageToClient(msg);
        }

        /// <summary>
        /// Метод отправки сообщения на клиент
        /// </summary>
        /// <param name="msg">Сообщение</param>
        /// <returns>Успешно ли было отправлено сообщение</returns>
        private bool SendMessageToClient(Message msg)
            {
            try
            {
                semaphore.WaitOne();
                // Тип сообщения
                byte[] buffer = new byte[4];
                buffer = BitConverter.GetBytes((int)msg.Type);
                networkStream.Write(buffer, 0, 4);
                networkStream.Flush();

                // Адрес отправителя

                byte[] senderIPBuffer = Encoding.ASCII.GetBytes(msg.SenderEndPoint.ToString());
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(senderIPBuffer.Length);
                networkStream.Write(buffer, 0, 4);
                networkStream.Flush();
                networkStream.Write(senderIPBuffer, 0, senderIPBuffer.Length);
                networkStream.Flush();


                // Имя отправителя
                byte[] senderNameBuffer = Encoding.Unicode.GetBytes(msg.SenderName.ToString());
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(senderNameBuffer.Length);
                networkStream.Write(buffer, 0, 4);
                networkStream.Flush();
                networkStream.Write(senderNameBuffer, 0, senderNameBuffer.Length);
                networkStream.Flush();

                buffer = new byte[4];
                buffer = BitConverter.GetBytes(msg.TargetsEndPoints.Length);
                networkStream.Write(buffer, 0, 4);
                networkStream.Flush();

                foreach (IPEndPoint ep in msg.TargetsEndPoints)
                {
                    string epString = ep.ToString();
                    buffer = new byte[epString.Length];
                    networkStream.Write(BitConverter.GetBytes(epString.Length), 0, 4);
                    networkStream.Flush();
                    networkStream.Write(Encoding.UTF8.GetBytes(epString), 0, epString.Length);
                    networkStream.Flush();
                }

                // Содержимое сообщения
                byte[] contentBuffer = msg.RetrieveRaw();
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(contentBuffer.Length);
                networkStream.Write(buffer, 0, 4);
                networkStream.Flush();

                buffer = new byte[4];
                buffer = BitConverter.GetBytes((int)msg.ContentType);
                networkStream.Write(buffer, 0, 4);
                networkStream.Flush();

                networkStream.Write(contentBuffer, 0, contentBuffer.Length);
                networkStream.Flush();

                semaphore.Release();
                return true;
            }
            catch
            {
                semaphore.Release();
                return false;
            }
        }
        
        #endregion

        #region Открытые методы
        /// <summary>
        /// Метод отправки сообщения на клиент
        /// </summary>
        /// <param name="msg">Сообщение</param>
        public void SendMessage(Message msg)
        {
            if (socket != null && socket.Connected)
            {
                BackgroundWorker sender = new BackgroundWorker();
                sender.DoWork += new DoWorkEventHandler(sender_DoWork);
                sender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(sender_RunWorkerCompleted);
                sender.RunWorkerAsync(msg);
            }
            else OnMessageFailed(new EventArgs());
        }

        /// <summary>
        /// Метод отключения от сервера
        /// </summary>
        /// <returns>Успешно ли прошло отключение</returns>
        public bool Disconnect()
        {
            if (socket != null && socket.Connected)
            {
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else return true;
        }

        #endregion

        #region События

        /// <summary>
        /// Событие получения сообщения
        /// </summary>
        public event OnMessageReceivedEventHandler MessageReceived;
        /// <summary>
        /// Пред-обработчик события получения сообщения
        /// </summary>
        /// <param name="e">Аргументы</param>
        protected virtual void OnMessageReceived (MessageEventArgs e)
        {
            if (MessageReceived != null)
                MessageReceived(this, e);
        }
        /// <summary>
        /// Событие отправки сообщения
        /// </summary>
        public event OnMessageSentEventHandler MessageSent;
        /// <summary>
        /// Пред-обработчик события отправки сообщения
        /// </summary>
        /// <param name="e">Аргументы</param>
        protected virtual void OnMessageSent (EventArgs e)
        {
            MessageSent?.Invoke(this, e);
        }
        /// <summary>
        /// Событие неудачной отправки сообщения
        /// </summary>
        public event OnMessageSendingFailedEventHandler MessageFailed;
        /// <summary>
        /// Пред-обработчик события неулачной отправки сообщения
        /// </summary>
        /// <param name="e">Аргументы</param>
        protected virtual void OnMessageFailed(EventArgs e)
        {
            MessageFailed?.Invoke(this, e);
        }
        /// <summary>
        /// Событие отключения клиента
        /// </summary>
        public event OnDisconnectEventHandler Disconnected;
        /// <summary>
        /// Пред-обработчик события отключения клиента
        /// </summary>
        /// <param name="e">Аргументы</param>
        protected virtual void OnDisconnected(ClientEventArgs e)
        {
            Disconnected?.Invoke(this, e);
        }
        
        #endregion
    }
}
