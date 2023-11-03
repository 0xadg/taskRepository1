using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RPM_Coursework
{
    class Client
    {
        public Socket clSocket;
        private NetworkStream networkStream;
        private BackgroundWorker listener;
        private IPEndPoint server;

        public bool Connected => clSocket != null ? clSocket.Connected : false;
        public IPAddress ServerIP => Connected ? server.Address : IPAddress.None;
        public int ServerPort => Connected ? server.Port : -1;

        public string Name { get; set; }

        #region Конструкторы
        public Client(IPEndPoint server)
        {
            this.server = server;
        }
        public Client(IPAddress serverIP, int serverPort)
        {
            this.server = new IPEndPoint(serverIP, serverPort);
        }
        #endregion

        #region Закрытые методы

        private void StartReceiving (object sender, DoWorkEventArgs e)
        {
            
            while (this.clSocket.Connected)
            {
                byte[] buffer = new byte[4];
                int readBytes = networkStream.Read(buffer, 0, 4);
                if (readBytes == 0) break;
                MessageType mt = (MessageType)BitConverter.ToInt32(buffer, 0);

                buffer = new byte[4];
                readBytes = networkStream.Read(buffer, 0, 4);
                if (readBytes == 0)
                    break;
                int senderEPSize = BitConverter.ToInt32(buffer, 0);

                buffer = new byte[senderEPSize];
                readBytes = networkStream.Read(buffer, 0, senderEPSize);
                if (readBytes == 0)
                    break;
                
                IPEndPoint senderEP = Utility.CreateIPEndPoint(Encoding.ASCII.GetString(buffer));

                buffer = new byte[4];
                readBytes = networkStream.Read(buffer, 0, 4);
                if (readBytes == 0)
                    break;
                int senderNameSize = BitConverter.ToInt32(buffer, 0);

                buffer = new byte[senderNameSize];
                readBytes = networkStream.Read(buffer, 0, senderNameSize);
                if (readBytes == 0)
                    break;
                string senderName = Encoding.Unicode.GetString(buffer);

                buffer = new byte[4];
                readBytes = networkStream.Read(buffer, 0, 4);
                if (readBytes == 0)
                    break;
                int epArrSize = BitConverter.ToInt32(buffer, 0);
                IPEndPoint[] targets = new IPEndPoint[epArrSize];

                for(int i = 0; i < epArrSize; i++)
                {
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
                readBytes = this.networkStream.Read(buffer, 0, 4);
                if (readBytes == 0)
                    break;
                int contentSize = BitConverter.ToInt32(buffer, 0);

                buffer = new byte[4];
                readBytes = this.networkStream.Read(buffer, 0, 4);
                if (readBytes == 0)
                    break;
                MessageContentType ct = (MessageContentType)BitConverter.ToInt32(buffer, 0);

                buffer = new byte[contentSize];
                readBytes = this.networkStream.Read(buffer, 0, contentSize);
                if (readBytes == 0)
                    break;

                Message msg = new Message(targets, mt, buffer);
                msg.ContentType = ct;
                msg.SenderEndPoint = senderEP;
                msg.SenderName = senderName;

                OnMessageReceived(new MessageEventArgs(msg));
            }
            OnServerDead(new ServerEventArgs(clSocket));
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

        private void sender_DoWork(object sender, DoWorkEventArgs e)
        {
            Message msg = (Message)e.Argument;
            e.Result = SendMessageToServer(msg);
        }

        private bool SendMessageToServer(Message msg)
        {
            try
            {
                byte[] buffer = new byte[4];
                buffer = BitConverter.GetBytes((int)msg.Type);
                networkStream.Write(buffer, 0, 4);
                networkStream.Flush();

                // total amount of targets
                buffer = new byte[4];
                buffer = BitConverter.GetBytes(msg.TargetsEndPoints.Length);
                networkStream.Write(buffer, 0, 4);
                networkStream.Flush();

                // sending each target individually
                foreach(IPEndPoint ep in msg.TargetsEndPoints)
                {
                    string epString = ep.ToString();
                    /// tbh there's no need to use post-converted since
                    /// there're only ascii chars --> 1char = 1byte
                    buffer = new byte[epString.Length];
                    networkStream.Write(BitConverter.GetBytes(epString.Length), 0, 4);
                    networkStream.Flush();
                    networkStream.Write(Encoding.UTF8.GetBytes(epString), 0, epString.Length);
                    networkStream.Flush();
                }

                buffer = new byte[4];
                buffer = BitConverter.GetBytes((int)msg.ContentType);
                networkStream.Write(buffer, 0, 4);
                networkStream.Flush();

                buffer = msg.RetrieveRaw();
                networkStream.Write(BitConverter.GetBytes(buffer.Length), 0, 4);
                networkStream.Flush();
                networkStream.Write(buffer, 0, buffer.Length);
                networkStream.Flush();

                return true;
            }
            catch
            {
                return false;
            }

            
        }

        #endregion

        #region Открытые методы

        public void ConnectToServer()
        {
            BackgroundWorker connector = new BackgroundWorker();
            connector.DoWork += connector_DoWork;
            connector.RunWorkerCompleted += connector_RunWorkerCompleted;
            connector.RunWorkerAsync();
        }

        private void connector_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
        {
            if (!((bool)e.Result))
                OnConnectFailed(new EventArgs());
            else
                OnConnectSuccessful(new EventArgs());

            ((BackgroundWorker)sender).Dispose();
            GC.Collect();
        }

        private void connector_DoWork (object sender, DoWorkEventArgs e)
        {
            try
            {
                clSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clSocket.Connect(server);
                e.Result = true;
                networkStream = new NetworkStream(clSocket);
                listener = new BackgroundWorker();
                listener.WorkerSupportsCancellation = true;
                listener.DoWork += new DoWorkEventHandler(StartReceiving);
                listener.RunWorkerAsync();

                Message msg = new Message(new IPEndPoint[] { new IPEndPoint(IPAddress.Broadcast, 5555) }, MessageType.ConnectMessage, Encoding.UTF8.GetBytes(Name));
                msg.ContentType = MessageContentType.Text;
                SendMessage(msg);
            }
            catch
            {
                e.Result = false;
            }
        }

        public bool Disconnect()
        {
            if (clSocket != null && clSocket.Connected)
            {
                try
                {
                    clSocket.Shutdown(SocketShutdown.Both);
                    clSocket.Close();
                    listener.CancelAsync();
                    OnClientDisconnect(new ClientEventArgs(clSocket));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public void SendMessage(Message msg)
        {
            if(clSocket == null || !clSocket.Connected)
            {
                OnMessageFailed(new EventArgs());
                return;
            }
            BackgroundWorker sender = new BackgroundWorker();
            sender.DoWork += new DoWorkEventHandler(sender_DoWork);
            sender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(sender_RunWorkerCompleted);
            sender.WorkerSupportsCancellation = true;
            sender.RunWorkerAsync(msg);
        }


        #endregion

        #region Собыбтия
        /// <summary>
        /// Событие получения сообщения
        /// </summary>
        public event OnMessageReceivedEventHandler MessageReceived;
        /// <summary>
        /// Обработчик события получения сообщения
        /// </summary>
        /// <param name="e">Аргументы событыия</param>
        protected virtual void OnMessageReceived(MessageEventArgs e)
        {
            if (MessageReceived != null)
            {
                Control target = MessageReceived.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(MessageReceived, new object[] { this, e });
                else
                    MessageReceived(this, e);
            }
        }

        /// <summary>
        /// Событие успешной отправки сообщения
        /// </summary>
        public event OnMessageSentEventHandler MessageSent;
        /// <summary>
        /// Пред-обработчик события получения сообщения
        /// </summary>
        /// <param name="e">Аргументы события</param>
        protected virtual void OnMessageSent(EventArgs e)
        {
            if (MessageSent != null)
            {
                Control target = MessageSent.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(MessageSent, new object[] { this, e });
                else
                    MessageSent(this, e);
            }
        }

        /// <summary>
        /// Событие неудачной отправки сообщения
        /// </summary>
        public event OnMessageSendingFailedEventHandler MessageFailed;
        /// <summary>
        /// Пред-обработчик события неудачной отправки сообщения
        /// </summary>
        /// <param name="e">Аргументы события</param>
        protected virtual void OnMessageFailed(EventArgs e)
        {
            if (MessageFailed != null)
            {
                Control target = MessageFailed.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(MessageFailed, new object[] { this, e });
                else
                    MessageFailed(this, e);
            }
        }

        /// <summary>
        /// Событие отключения от сервера
        /// </summary>
        public event OnClientDisconnectedEventHandler ClientDisconnect;
        /// <summary>
        /// Пред-обработчик отключения от сервера
        /// </summary>
        /// <param name="e">Аргументы события</param>
        protected virtual void OnClientDisconnect(ClientEventArgs e)
        {
            if (ClientDisconnect != null)
            {
                Control target = ClientDisconnect.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(ClientDisconnect, new object[] { this, e });
                else
                    ClientDisconnect(this, e);
            }
        }

        /// <summary>
        /// Событие успешного подключения к серверу
        /// </summary>
        public event OnConnectSuccessfulEventHandler ConnectSuccessful;
        /// <summary>
        /// Пред-обработчик события успешного подключения к серверу
        /// </summary>
        /// <param name="e">Аргументы события</param>
        protected virtual void OnConnectSuccessful(EventArgs e)
        {
            if (ConnectSuccessful != null)
            {
                Control target = ConnectSuccessful.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(ConnectSuccessful, new object[] { this, e });
                else
                    ConnectSuccessful(this, e);
            }
        }

        /// <summary>
        /// Событие неудачного подключения к серверу
        /// </summary>
        public event OnConnectFailedEventHandler ConnectFailed;
        /// <summary>
        /// Пред-обработчик события неудачного подключения к серверу
        /// </summary>
        /// <param name="e">Аргументы события</param>
        protected virtual void OnConnectFailed(EventArgs e)
        {
            if (ConnectFailed != null)
            {
                Control target = ConnectFailed.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(ConnectFailed, new object[] { this, e });
                else
                    ConnectFailed(this, e);
            }
        }

        public event OnServerDeadEventHandler ServerDead;

        protected virtual void OnServerDead(ServerEventArgs e)
        {
            if (ServerDead != null)
            {
                Control target = ServerDead.Target as Control;
                if (target != null && target.InvokeRequired)
                    target.Invoke(ServerDead, new object[] { this, e });
                else
                    ServerDead(this, e);
            }
        }

        
        #endregion


    }
}
