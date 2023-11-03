using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPM_Coursework
{
    class Server
    {
        private List<ClientManager> clients;
        private BackgroundWorker listener;

        private Socket listenerSocket;
        private Socket scanListenerSocket;
        private Socket scanRespondSocket;
        private IPAddress serverIP;
        
        private int serverPort;

        private Task scanRespondTask;
        private CancellationTokenSource cts;
        private CancellationToken ct;

        public Server(IPAddress ip, int port)
        {
            serverIP = ip;
            serverPort = port;
            clients = new List<ClientManager>();

            listener = new BackgroundWorker();
            listener.WorkerSupportsCancellation = true;
            listener.DoWork += StartListening;
            listener.RunWorkerAsync();

            scanListenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            
            scanRespondSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            

            scanListenerSocket.Bind(new IPEndPoint(IPAddress.Any, (int)ScanPorts.ReceivingPort));

            cts = new CancellationTokenSource();
            ct = cts.Token;
            scanRespondTask = new Task(StartListeningForScan, ct);
            scanRespondTask.Start();

        }

        private void StartListeningForScan()
        {
            byte[] buff;
            EndPoint udpSender = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                buff = new byte[1024];
                scanListenerSocket.ReceiveFrom(buff, ref udpSender);
                ((IPEndPoint)udpSender).Port = (int)ScanPorts.ResponsePort;
                scanRespondSocket.SendTo(Encoding.UTF8.GetBytes(serverIP.ToString() + "|" + serverPort.ToString() + "|" + clients.Count.ToString()), udpSender);
            }
        }

        private void StartListening (object sender, DoWorkEventArgs e)
        {
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenerSocket.Bind(new IPEndPoint(serverIP, serverPort));
            listenerSocket.Listen(200);
            while (true)
            {
                try
                {
                    CreateNewClientManager(listenerSocket.Accept());
                }
                catch
                {
                    Shutdown();
                }
            }
        }

        public void Shutdown ()
        {
            Message msg = new Message(new IPEndPoint[] { new IPEndPoint(IPAddress.Broadcast, 1) }, MessageType.ServerShutdownMessage);
            msg.SenderEndPoint = new IPEndPoint(serverIP, serverPort);
            msg.SenderName = "SERVER";
            msg.ContentType = MessageContentType.None;
            BroadcastMessage(msg);
            if(clients != null)
            {
                foreach (ClientManager mgr in clients)
                    mgr.Disconnect();

                listener.CancelAsync();
                listener.Dispose();
                listenerSocket.Close();
                cts.Cancel();
                scanListenerSocket.Close(1);
                scanRespondSocket.Close(1);
            }
        }

        private void CreateNewClientManager(Socket skt)
        {
            ClientManager cm = new ClientManager(skt);
            
            cm.MessageReceived += MessageReceived;
            cm.Disconnected += ClientDisconnected;
            clients.Add(cm);

        }

        private void MessageReceived (object sender, MessageEventArgs e)
        {
            Message msg;
            string mgrID = ((ClientManager)sender).ID;
            switch(e.Message.Type)
            {
                case MessageType.ConnectMessage:
                    SetManagerName(mgrID, e.Message.RetrieveText());
                    
                    msg = new Message(new IPEndPoint[] { new IPEndPoint(IPAddress.Broadcast, 1) }, MessageType.ConnectInformMessage, Encoding.UTF8.GetBytes(e.Message.SenderName));
                    msg.SenderEndPoint = e.Message.SenderEndPoint;
                    msg.SenderName = e.Message.SenderName;
                    msg.ContentType = MessageContentType.Text;
                    BroadcastMessage(msg);

                    SendClientList();
                    break;
                case MessageType.DefaultMessage:
                    List<IPEndPoint> targets = new List<IPEndPoint>(e.Message.TargetsEndPoints);
                    if (targets.Exists(x => x.Address.Equals(IPAddress.Broadcast)))
                    {
                        BroadcastMessage(e.Message);
                    }
                    else
                        SendMessageToTarget(e.Message);
                    break;
            }
        }

        private void SendClientList()
        {
            string cont = "";
            foreach(ClientManager mgr in clients)
            {
                cont += $"{mgr.ClientName}:{mgr.IP}:{mgr.Port};";
            }
            Message msg = new Message(new IPEndPoint[] { new IPEndPoint(IPAddress.Broadcast, 1) }, MessageType.ClientListMessage, Encoding.UTF8.GetBytes(cont));
            msg.SenderEndPoint = new IPEndPoint(serverIP, serverPort);
            msg.SenderName = "SERVER";
            msg.ContentType = MessageContentType.Text;
            BroadcastMessage(msg);
        }

        private string SetManagerName(string managerID, string newName)
        {
            int index = clients.FindIndex(x => x.ID == managerID);
            if (index != -1)
            {
                clients[index].ClientName = newName;
                return newName;
            }
            return "";
        }

        private void BroadcastMessage (Message message)
        {
            foreach(ClientManager mgr in clients)
            {
                if (!(message.SenderEndPoint.Address == mgr.IP && message.SenderEndPoint.Port == mgr.Port))
                    mgr.SendMessage(message);
            }
        }

        private void SendMessageToTarget (Message message)
        {
            foreach(IPEndPoint ep in message.TargetsEndPoints)
            {
                foreach(ClientManager cl in clients)
                {
                    if(cl.IP.Equals(ep.Address) && cl.Port == ep.Port)
                    {
                        cl.SendMessage(message);
                    }
                }
            }
        }

        private void ClientDisconnected (object sender, ClientEventArgs e)
        {
            RemoveClientManager(new IPEndPoint(e.ClientIP, e.ClientPort));
        }

        private bool RemoveClientManager(IPEndPoint ep)
        {
            lock (this)
            {
                int index = clients.FindIndex(x => x.IP == ep.Address && x.Port == ep.Port);
                if (index != -1)
                {
                    string name = clients[index].ClientName;
                    clients.RemoveAt(index);

                    Message msg = new Message(new IPEndPoint[] { new IPEndPoint(IPAddress.Broadcast, 1) }, MessageType.DisconnectInformMessage, Encoding.UTF8.GetBytes(name));
                    msg.SenderName = name;
                    msg.SenderEndPoint = ep;
                    msg.ContentType = MessageContentType.Text;
                    BroadcastMessage(msg);

                    SendClientList();
                    return true;
                }
                return false;
            }
        }


    }
}
