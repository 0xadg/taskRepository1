using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPM_Coursework.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            userNameTextBox.Text = Properties.Settings.Default.userName;
            defaultPortTextBox.Text = Properties.Settings.Default.defaultPort.ToString();
            manualEntryCheckBox.Checked = Properties.Settings.Default.alwaysAskPort;
            folderBrowserDialog1.SelectedPath = pathTextBox.Text = Properties.Settings.Default.fileSaveDir;
        }

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.fileSaveDir = pathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.userName = userNameTextBox.Text;
            Properties.Settings.Default.defaultPort = int.Parse(defaultPortTextBox.Text);
            Properties.Settings.Default.alwaysAskPort = manualEntryCheckBox.Checked;
            Properties.Settings.Default.fileSaveDir = folderBrowserDialog1.SelectedPath;

            Properties.Settings.Default.Save();
        }

        private void confirmButton_Click(object sender, EventArgs e) => SaveSettings();
    }
}
