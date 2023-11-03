using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPM_Coursework.Forms
{
    public delegate void OnResponseReceivedHandler(Control control, string message);
    public partial class ServerBrowserForm : Form
    {
        public IPAddress IP { get; private set; }
        public int Port { get; private set; }

        Socket recSocket;
        Socket sendSocket;

        Task receiveTask;
        Task searchTask;
        CancellationTokenSource cts;
        CancellationToken ct;
        OnResponseReceivedHandler OnResponse;

        public ServerBrowserForm()
        {
            InitializeComponent();

            cts = new CancellationTokenSource();
            OnResponse += OnResponseReceived;

            recSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sendSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            recSocket.Bind(new IPEndPoint(IPAddress.Any, (int)ScanPorts.ResponsePort));

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            serversListView.Items.Clear();
            try
            {
                ct = cts.Token;
                searchTask = new Task(StartSearch, ct);
                receiveTask = new Task(StartReceive, ct);
                searchTask.Start();
                receiveTask.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Получено исключение: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cts?.Cancel();
            }
        }

        private void StartSearch()
        {
            sendSocket.SendTo(Encoding.UTF8.GetBytes("hello, is this crusty crabs?"), new IPEndPoint(IPAddress.Broadcast, (int)ScanPorts.ReceivingPort));
        }

        private void StartReceive()
        {
            byte[] buff;
            int recBytes;
            EndPoint udpSender = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                buff = new byte[1024];
                recBytes = recSocket.ReceiveFrom(buff, ref udpSender);

                OnResponse?.Invoke(this, Encoding.UTF8.GetString(buff, 0, recBytes));
            }
        }

        private void OnResponseReceived(Control control, string message)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new OnResponseReceivedHandler(UpdateList), new object[] { this, message });
            }
            else
            {
                UpdateList(this, message);
            }
        }

        private void UpdateList(Control control, string message)
        {
            string[] items = message.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            ListViewItem item = new ListViewItem(items);
            serversListView.Items.Add(item);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            IP = IPAddress.Parse(serversListView.SelectedItems[0].SubItems[0].Text);
            Port = int.Parse(serversListView.SelectedItems[0].SubItems[1].Text);
            sendSocket.Close();
            recSocket.Close();
            sendSocket.Dispose();
            recSocket.Dispose();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void serversListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serversListView.SelectedIndices.Count > 0) connectButton.Enabled = true;
        }
    }
}
