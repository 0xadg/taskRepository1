using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RPM_Coursework
{

    #region Глобальные перечисления

    public enum ScanPorts
    {
        ReceivingPort = 51000,  // порт сервера, слушающий сканы
        ResponsePort = 51500    // порт, на который отправляется ответ сервера
    }
    

    #endregion

    #region Классы параметров
    /// <summary>
    /// Класс параметров события сообщений
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Полученное сообщение 
        /// </summary>
        public Message Message { get; }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="msg">Сообщение</param>
        public MessageEventArgs (Message msg) => Message = msg;
    }
    /// <summary>
    /// Класс параметров события с сервером
    /// </summary>
    public class ServerEventArgs : EventArgs
    {
        /// <summary>
        /// Сокет, связанный с сервером
        /// </summary>
        private Socket socket;
        /// <summary>
        /// Свойство IP-адреса
        /// </summary>
        public IPAddress ServerIP
        {
            get => ((IPEndPoint)socket.RemoteEndPoint).Address;
        }
        /// <summary>
        /// Свойство порта сервера
        /// </summary>
        public int ServerPort
        {
            get => ((IPEndPoint)socket.RemoteEndPoint).Port;
        }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="skt">Сокет, связанный с сервером</param>
        public ServerEventArgs (Socket skt) => socket = skt;
    }
    /// <summary>
    /// Класс параметров события с клиентом
    /// </summary>
    public class ClientEventArgs : EventArgs
    {
        /// <summary>
        /// Сокет, связанный с клиентом
        /// </summary>
        private Socket socket;
        /// <summary>
        /// Свойство IP-адреса
        /// </summary>
        public IPAddress ClientIP
        {
            get => ((IPEndPoint)socket.RemoteEndPoint).Address;
        }
        /// <summary>
        /// Свойство порта клиента
        /// </summary>
        public int ClientPort
        {
            get => ((IPEndPoint)socket.RemoteEndPoint).Port;
        }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="skt">Сокет, связанный с клиентом</param>
        public ClientEventArgs (Socket skt) => socket = skt;
    }
    #endregion

    #region Вспомогательные классы

    public class Utility
    {
        public static IPEndPoint CreateIPEndPoint(string endPoint)
        {
            string[] ep = endPoint.Split(':');
            if (ep.Length != 2) throw new FormatException("Invalid endpoint format");
            IPAddress ip;
            if (!IPAddress.TryParse(ep[0], out ip))
            {
                throw new FormatException("Invalid ip-adress");
            }
            int port;
            if (!int.TryParse(ep[1], NumberStyles.None, NumberFormatInfo.CurrentInfo, out port))
            {
                throw new FormatException("Invalid port");
            }
            return new IPEndPoint(ip, port);
        }
    }

    #endregion

    #region Общие события
    /// <summary>
    /// Событие получения сообщения
    /// </summary>
    /// <param name="sender">Источник</param>
    /// <param name="e">Параметры</param>
    public delegate void OnMessageReceivedEventHandler (object sender, MessageEventArgs e);
    /// <summary>
    /// Событие отправки сообщения
    /// </summary>
    /// <param name="sender">Источник</param>
    /// <param name="e">Параметры</param>
    public delegate void OnMessageSentEventHandler (object sender, EventArgs e);
    /// <summary>
    /// Событие неудачной отправки сообщения (из-за исключений/недоступности сервера и т.д.)
    /// </summary>
    /// <param name="sender">Источник</param>
    /// <param name="e">Параметры</param>
    public delegate void OnMessageSendingFailedEventHandler (object sender, EventArgs e);
    #endregion

    #region Серверные события

    /// <summary>
    /// Событие, вызывающееся при отключении клиента от сервера
    /// </summary>
    /// <param name="sender">Источник</param>
    /// <param name="e">Параметры</param>
    public delegate void OnClientDisconnectedEventHandler (object sender, ClientEventArgs e);
    #endregion

    #region Клиентские события

    /// <summary>
    /// Событие, вызывающееся при выключении сервера
    /// </summary>
    /// <param name="sender">Источник</param>
    /// <param name="e">Параметры</param>
    public delegate void OnServerDeadEventHandler (object sender, ServerEventArgs e);
    /// <summary>
    /// Событие, вызывающееся при успешном подключении к серверу
    /// </summary>
    /// <param name="sender">Источник</param>
    /// <param name="e">Параметры</param>
    public delegate void OnConnectSuccessfulEventHandler (object sender, EventArgs e);
    /// <summary>
    /// Событие, вызывающееся при неудачном подключении к серверу
    /// </summary>
    /// <param name="sender">Источник</param>
    /// <param name="e">Параметры</param>
    public delegate void OnConnectFailedEventHandler (object sender, EventArgs e);
    /// <summary>
    /// Событие, вызывающееся при отключении от сервера
    /// </summary>
    /// <param name="sender">Источник</param>
    /// <param name="e">Параметры</param>
    public delegate void OnDisconnectEventHandler (object sender, ClientEventArgs e);


    #endregion
}
