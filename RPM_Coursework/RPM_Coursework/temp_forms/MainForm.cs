using I_SWEAR_THIS_IS_THE_FINAL_FUCKING_VERSION_OF_THIS_SHIT.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.ListViewItem;

namespace I_SWEAR_THIS_IS_THE_FINAL_FUCKING_VERSION_OF_THIS_SHIT
{
    public partial class MainForm : Form
    {
        Server server;
        Client client;
        Socket pingSocket;
        IPAddress currentIP;

        bool privateSend = false;
        bool useDefault = true;
        bool saveImages = false;
        string saveDir = AppDomain.CurrentDomain.BaseDirectory;
        string username = "DefaultUsername";
        int port;
        string[] imageExtensions = new string[4] { "jpg", "jpeg", "png", "gif"}; 

        public MainForm ()
        {
            InitializeComponent();
            pingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // using non-existent address to get our local endpoint address
            pingSocket.Connect("8.8.8.8", 65530);
            currentIP = ((IPEndPoint)pingSocket.LocalEndPoint).Address;
            ipAddressLabel.Text = $"{currentIP}";
            clientsListView.Items.Clear();
            отключитьсяОтСервераToolStripMenuItem.Enabled = false;

            LoadSettings();
        }

        private void SetupClient(IPAddress target, int port)
        {
            client = new Client(new IPEndPoint(target, port));
            client.Name = username;
            client.MessageReceived += new OnMessageReceivedEventHandler(Client_MessageReceived);

            client.ConnectSuccessful += (o, e) =>
            {
                MessageBox.Show("Подключение установлено!");
                sendFileButton.Enabled = true;
                sendMessageButton.Enabled = true;
                messageTextBox.Enabled = true;
                отключитьсяОтСервераToolStripMenuItem.Enabled = true;
            };
            client.ClientDisconnect += (o, e) =>
            {
                MessageBox.Show("Произошло отключение!");
                sendFileButton.Enabled = false;
                sendMessageButton.Enabled = false;
                messageTextBox.Enabled = false;
                отключитьсяОтСервераToolStripMenuItem.Enabled = false;
                clientsListView.Items.Clear();
            };

            client.ConnectToServer();

            clientsListView.Items.Clear();
        }

        private void создатьСерверToolStripMenuItem_Click (object sender, EventArgs e)
        {
            if (useDefault)
            {
                ConnectionForm cform = new ConnectionForm(true);
                if (cform.ShowDialog() == DialogResult.OK)
                {
                    port = cform.port;
                }
                else return;
            }
            
            server = new Server(currentIP, port);
            SetupClient(currentIP, port);
            chatTextBox.SelectionColor = Color.Green;
            chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Bold);
            chatTextBox.AppendText($"Сервер запущен ");
            chatTextBox.SelectionColor = Color.Orange;
            chatTextBox.AppendText($"[{currentIP}:{port}] !\r\n");
            chatTextBox.SelectionColor = Color.Black;
            chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Regular);
        }

        private void DisconnectCl()
        {
            if (client == null || !client.Connected) return;
            if (server != null) server.Shutdown();
            clientsListView.Items.Clear();
            client.Disconnect();
        }

        private void LoadSettings()
        {
            port = Properties.Settings.Default.defaultPort;
            useDefault = Properties.Settings.Default.alwaysAskPort;
            username = Properties.Settings.Default.userName;
            saveDir = Properties.Settings.Default.fileSaveDir;
        }

        private void UpdateClientList(string data)
        {
            clientsListView.Items.Clear();
            string[] items = data.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string subitem in items)
            {
                string[] subitems = subitem.Split(':');
                clientsListView.Items.Add(new ListViewItem(subitems));
            }
        }

        private void Client_MessageReceived (object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            switch(msg.Type)
            {
                case MessageType.DefaultMessage:
                    switch(msg.ContentType)
                    {
                        case MessageContentType.Text:
                            if (!msg.TargetsEndPoints.ToList().Exists(x => x.Address.Equals(IPAddress.Broadcast)))
                            {
                                chatTextBox.SelectionColor = Color.Green;
                                chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Bold);
                                chatTextBox.AppendText(msg.SenderName);
                                chatTextBox.SelectionColor = Color.Orange;
                                chatTextBox.AppendText($" [{msg.SenderEndPoint.Address}] ");
                                chatTextBox.SelectionColor = Color.Green;
                                chatTextBox.AppendText("--> Вам: ");
                            }
                            else
                            {
                                chatTextBox.SelectionColor = Color.Green;
                                chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Bold);
                                chatTextBox.AppendText(msg.SenderName);
                                chatTextBox.SelectionColor = Color.Orange;
                                chatTextBox.AppendText($" [{msg.SenderEndPoint.Address}]: ");
                            }
                            chatTextBox.SelectionColor = Color.Black;
                            chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Regular);
                            chatTextBox.AppendText(msg.RetrieveText() + "\r\n");

                            break;
                        case MessageContentType.File:
                            List<byte> content = e.Message.RetrieveDocument().ToList();
                            int size = BitConverter.ToInt32(content.Take(4).ToArray());
                            // полируем строку
                            string fName = Encoding.UTF8.GetString(content.Skip(4).Take(size).ToArray()).Trim().Replace("\0", string.Empty);
                            content.RemoveRange(0, 4 + size);
                            // сохраняем в отдельном потоке
                            Task.Run(() => File.WriteAllBytes($"{saveDir}/{fName}", content.ToArray()));

                            chatTextBox.SelectionColor = Color.Green;
                            chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Bold);
                            chatTextBox.AppendText(msg.SenderName);
                            chatTextBox.SelectionColor = Color.Orange;
                            chatTextBox.AppendText($" [{msg.SenderEndPoint.Address}]: ");
                            chatTextBox.SelectionColor = Color.Black;
                            chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Regular);
                            chatTextBox.AppendText("отправил файл ");
                            chatTextBox.SelectionColor = Color.Blue;
                            chatTextBox.AppendText($"{fName}\r\n");
                            break;
                        case MessageContentType.Image:

                            chatTextBox.SelectionColor = Color.Green;
                            chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Bold);
                            chatTextBox.AppendText(msg.SenderName);
                            chatTextBox.SelectionColor = Color.Orange;
                            chatTextBox.AppendText($" [{msg.SenderEndPoint.Address}]: ");
                            chatTextBox.SelectionColor = Color.Black;
                            chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Regular);
                            chatTextBox.AppendText("отправил изображение:\r\n");

                            Bitmap bmp = msg.RetrieveImage();
                            object oldContent = Clipboard.GetDataObject();
                            Clipboard.SetDataObject(bmp);
                            Format format = DataFormats.GetFormat(DataFormats.Bitmap);
                            chatTextBox.Paste(format);
                            chatTextBox.AppendText("\r\n");
                            Clipboard.SetDataObject(oldContent);
                            break;
                    }
                    break;
                case MessageType.ConnectInformMessage:
                    chatTextBox.SelectionColor = Color.Green;
                    chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Bold);
                    chatTextBox.AppendText($"{msg.RetrieveText()} подключился.\r\n");
                    break;
                case MessageType.DisconnectInformMessage:
                    chatTextBox.SelectionColor = Color.DarkRed;
                    chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Bold);
                    chatTextBox.AppendText($"{msg.RetrieveText()} отключился.\r\n");
                    break;
                case MessageType.ClientListMessage:
                    UpdateClientList(msg.RetrieveText());
                    break;
                case MessageType.ServerShutdownMessage:
                    chatTextBox.SelectionColor = Color.DarkRed;
                    chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Bold);
                    chatTextBox.AppendText($"Сервер отключился.\r\n");
                    sendFileButton.Enabled = false;
                    sendMessageButton.Enabled = false;
                    messageTextBox.Enabled = false;
                    break;
                default:
                    chatTextBox.AppendText($"Получено сообщение: {msg.Type}");
                    break;
            }
        }

        private void подключитьсяКСерверуToolStripMenuItem_Click (object sender, EventArgs e)
        {
            ConnectionForm cform = new ConnectionForm(false);
            
            if(cform.ShowDialog() == DialogResult.OK)
            {
                SetupClient(cform.IP, cform.port);
            }
            cform.Dispose();
        }

        private void sendMessageButton_Click (object sender, EventArgs e)
        {
            if (client == null || messageTextBox.Text.Trim().Length == 0) return;

            chatTextBox.SelectionColor = Color.DarkBlue;
            chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Bold);
            chatTextBox.AppendText($"Вы: ");
            chatTextBox.SelectionFont = new Font(chatTextBox.Font, FontStyle.Regular);
            chatTextBox.SelectionColor = Color.Black;
            chatTextBox.AppendText(messageTextBox.Text + "\r\n");

            IPEndPoint[] targets;
            if(privateSend)
            {
                targets = new IPEndPoint[clientsListView.SelectedItems.Count];
                for(int i = 0; i < clientsListView.SelectedItems.Count; i++)
                {
                    var subItems = clientsListView.SelectedItems[i].SubItems;
                    targets[i] = new IPEndPoint(IPAddress.Parse(subItems[1].Text), int.Parse(subItems[2].Text));
                }
            }    
            else
            {
                targets = new IPEndPoint[] { new IPEndPoint(IPAddress.Broadcast, 1) };
            }
            Message msg = new Message(targets, MessageType.DefaultMessage, Encoding.UTF8.GetBytes(messageTextBox.Text));
            msg.ContentType = MessageContentType.Text;
            client.SendMessage(msg);
            messageTextBox.Text = "";
            messageTextBox.Focus();

            
        }

        private void messageTextBox_KeyDown (object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                sendMessageButton_Click(sender, new EventArgs());
                e.Handled = true;
            }
        }

        private void отключитьсяОтСервераToolStripMenuItem_Click (object sender, EventArgs e)
        {
            DisconnectCl();
        }

        private void MainForm_FormClosing (object sender, FormClosingEventArgs e)
        {
            DisconnectCl();
        }

        private void sendFileButton_Click (object sender, EventArgs e)
        {
            try
            {
                if (fileSelectDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(fileSelectDialog.FileName);
                    if (fi.Length > 512000) throw new Exception("Файл слишком большой");
                    List<byte> data = new List<byte>(File.ReadAllBytes(fileSelectDialog.FileName));

                    string fileName = fileSelectDialog.FileName.Split("\\").Last();
                    string fileExtension = fileName.Split(".").Last();

                    IPEndPoint[] targets;
                    if (privateSend)
                    {
                        targets = new IPEndPoint[clientsListView.SelectedItems.Count];
                        for (int i = 0; i < clientsListView.SelectedItems.Count; i++)
                        {
                            var subItems = clientsListView.SelectedItems[i].SubItems;
                            targets[i] = new IPEndPoint(IPAddress.Parse(subItems[1].Text), int.Parse(subItems[2].Text));
                        }
                    }
                    else
                    {
                        targets = new IPEndPoint[] { new IPEndPoint(IPAddress.Broadcast, 1) };
                    }

                    Message msg;
                    if (imageExtensions.Contains(fileExtension))
                    {
                        byte[] byteFilename = Encoding.UTF8.GetBytes(fileName);
                        msg = new Message(targets, MessageType.DefaultMessage, data.ToArray());
                        msg.ContentType = MessageContentType.Image;
                    }
                    else
                    {
                        byte[] byteFilename = Encoding.UTF8.GetBytes(fileName);

                        data.InsertRange(0, byteFilename);
                        data.InsertRange(0, BitConverter.GetBytes(byteFilename.Length));

                        msg = new Message(targets, MessageType.DefaultMessage, data.ToArray());
                        msg.ContentType = MessageContentType.File;
                    }
                    client.SendMessage(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clientsListView_SelectedIndexChanged (object sender, EventArgs e)
        {
            privateSend = clientsListView.SelectedItems.Count > 0 && clientsListView.Items.Count > 0;
            sendStatusLabel.Text = "Отправка " + (privateSend ? "выбранным" : "всем");
        }

        private void messageTextBox_TextChanged (object sender, EventArgs e)
        {
            sendMessageButton.Enabled = messageTextBox.Text.Trim().Length > 0;
        }

        private void chatTextBox_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.Modifiers.HasFlag(Keys.Control) && e.KeyCode == Keys.C)
                return;
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                return;
            e.SuppressKeyPress = true;
        }

        private void поискСерверовToolStripMenuItem_Click (object sender, EventArgs e)
        {
            ServerBrowserForm sbf = new ServerBrowserForm();
            if(sbf.ShowDialog() == DialogResult.OK)
            {
                SetupClient(sbf.IP, sbf.Port);
            }
            sbf.Dispose();
        }

        private void resetSelectionButton_Click (object sender, EventArgs e)
        {
            clientsListView.SelectedIndices.Clear();
        }

        private void настройкиToolStripMenuItem_Click_1 (object sender, EventArgs e)
        {
            SettingsForm sform = new SettingsForm();
            if (sform.ShowDialog() == DialogResult.OK)
            {
                LoadSettings();
            }
            sform.Dispose();
        }
    }
}
