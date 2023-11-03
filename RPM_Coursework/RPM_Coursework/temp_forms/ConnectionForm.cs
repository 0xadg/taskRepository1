using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace I_SWEAR_THIS_IS_THE_FINAL_FUCKING_VERSION_OF_THIS_SHIT.Forms
{

    public partial class ConnectionForm : Form
    {
        public IPAddress IP;
        public int port;
        bool isCreatingAServer;
        public ConnectionForm (bool createMode)
        {
            InitializeComponent();
            isCreatingAServer = createMode;
            if(createMode)
            {
                ipAddressTextBox.Visible = false;
                label1.Visible = false;
                this.Text = "Создание сервера";
            }
        }

        private void inputFiltering (object sender, KeyPressEventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (t.Text.Length >= 5 && e.KeyChar != '\b') e.KeyChar = '\0';
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == '\b')) e.KeyChar = '\0';
        }

        private void cancelButton_Click (object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void confirmButton_Click (object sender, EventArgs e)
        {
            try
            {
                if (isCreatingAServer) IP = IPAddress.None;
                if(!IPAddress.TryParse(ipAddressTextBox.Text, out IP)) throw new Exception("IP-адрес неверного формата");
                if (!int.TryParse(portTextBox.Text, out port)) throw new Exception("Порт неверного формата");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
                
        }

        private void mainFields_TextChanged (object sender, EventArgs e)
        {
            confirmButton.Enabled = ipAddressTextBox.Text.Length > 0 && portTextBox.Text.Length > 0;
        }
    }
}
