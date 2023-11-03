namespace RPM_Coursework.Forms
{
    partial class ChatForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ipDescrLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ipAddressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.главнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьСерверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подключитьсяКСерверуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьсяОтСервераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискСерверовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsListView = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addressColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.portColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chatTextBox = new System.Windows.Forms.RichTextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.sendFileButton = new System.Windows.Forms.Button();
            this.sendStatusLabel = new System.Windows.Forms.Label();
            this.resetSelectionButton = new System.Windows.Forms.Button();
            this.fileSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ipDescrLabel,
            this.ipAddressLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(879, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ipDescrLabel
            // 
            this.ipDescrLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipDescrLabel.Name = "ipDescrLabel";
            this.ipDescrLabel.Size = new System.Drawing.Size(61, 17);
            this.ipDescrLabel.Text = "IP-адрес:";
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(62, 17);
            this.ipAddressLabel.Text = "127.0.0.1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.главнаяToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(879, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // главнаяToolStripMenuItem
            // 
            this.главнаяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьСерверToolStripMenuItem,
            this.подключитьсяКСерверуToolStripMenuItem,
            this.отключитьсяОтСервераToolStripMenuItem,
            this.поискСерверовToolStripMenuItem});
            this.главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            this.главнаяToolStripMenuItem.Size = new System.Drawing.Size(63, 22);
            this.главнаяToolStripMenuItem.Text = "Главная";
            // 
            // создатьСерверToolStripMenuItem
            // 
            this.создатьСерверToolStripMenuItem.Name = "создатьСерверToolStripMenuItem";
            this.создатьСерверToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.создатьСерверToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.создатьСерверToolStripMenuItem.Text = "Создать сервер";
            this.создатьСерверToolStripMenuItem.Click += new System.EventHandler(this.создатьСерверToolStripMenuItem_Click);
            // 
            // подключитьсяКСерверуToolStripMenuItem
            // 
            this.подключитьсяКСерверуToolStripMenuItem.Name = "подключитьсяКСерверуToolStripMenuItem";
            this.подключитьсяКСерверуToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.подключитьсяКСерверуToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.подключитьсяКСерверуToolStripMenuItem.Text = "Подключиться к серверу";
            this.подключитьсяКСерверуToolStripMenuItem.Click += new System.EventHandler(this.подключитьсяКСерверуToolStripMenuItem_Click);
            // 
            // отключитьсяОтСервераToolStripMenuItem
            // 
            this.отключитьсяОтСервераToolStripMenuItem.Name = "отключитьсяОтСервераToolStripMenuItem";
            this.отключитьсяОтСервераToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.отключитьсяОтСервераToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.отключитьсяОтСервераToolStripMenuItem.Text = "Отключиться от сервера";
            this.отключитьсяОтСервераToolStripMenuItem.Click += new System.EventHandler(this.отключитьсяОтСервераToolStripMenuItem_Click);
            // 
            // поискСерверовToolStripMenuItem
            // 
            this.поискСерверовToolStripMenuItem.Name = "поискСерверовToolStripMenuItem";
            this.поискСерверовToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.поискСерверовToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.поискСерверовToolStripMenuItem.Text = "Поиск серверов";
            this.поискСерверовToolStripMenuItem.Click += new System.EventHandler(this.поискСерверовToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click_1);
            // 
            // clientsListView
            // 
            this.clientsListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.clientsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.addressColumn,
            this.portColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.clientsListView, 2);
            this.clientsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientsListView.GridLines = true;
            this.clientsListView.HideSelection = false;
            this.clientsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.clientsListView.Location = new System.Drawing.Point(2, 2);
            this.clientsListView.Margin = new System.Windows.Forms.Padding(2);
            this.clientsListView.Name = "clientsListView";
            this.clientsListView.Size = new System.Drawing.Size(315, 336);
            this.clientsListView.TabIndex = 4;
            this.clientsListView.UseCompatibleStateImageBehavior = false;
            this.clientsListView.View = System.Windows.Forms.View.Details;
            this.clientsListView.SelectedIndexChanged += new System.EventHandler(this.clientsListView_SelectedIndexChanged);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Имя";
            this.nameColumn.Width = 100;
            // 
            // addressColumn
            // 
            this.addressColumn.Text = "IP-адрес";
            this.addressColumn.Width = 120;
            // 
            // portColumn
            // 
            this.portColumn.Text = "Порт";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.21614F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.78386F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.Controls.Add(this.clientsListView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chatTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.messageTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.sendMessageButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.sendFileButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.sendStatusLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.resetSelectionButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(879, 375);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // chatTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.chatTextBox, 3);
            this.chatTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.chatTextBox.Location = new System.Drawing.Point(321, 2);
            this.chatTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(556, 336);
            this.chatTextBox.TabIndex = 5;
            this.chatTextBox.Text = "";
            this.chatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatTextBox_KeyDown);
            // 
            // messageTextBox
            // 
            this.messageTextBox.AcceptsReturn = true;
            this.messageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTextBox.Enabled = false;
            this.messageTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.messageTextBox.Location = new System.Drawing.Point(321, 342);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(338, 26);
            this.messageTextBox.TabIndex = 6;
            this.messageTextBox.TextChanged += new System.EventHandler(this.messageTextBox_TextChanged);
            this.messageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageTextBox_KeyDown);
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendMessageButton.Enabled = false;
            this.sendMessageButton.Location = new System.Drawing.Point(663, 342);
            this.sendMessageButton.Margin = new System.Windows.Forms.Padding(2);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(83, 31);
            this.sendMessageButton.TabIndex = 7;
            this.sendMessageButton.Text = "Отправить";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // sendFileButton
            // 
            this.sendFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendFileButton.Enabled = false;
            this.sendFileButton.Location = new System.Drawing.Point(750, 342);
            this.sendFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.sendFileButton.Name = "sendFileButton";
            this.sendFileButton.Size = new System.Drawing.Size(127, 31);
            this.sendFileButton.TabIndex = 8;
            this.sendFileButton.Text = "Файл";
            this.sendFileButton.UseVisualStyleBackColor = true;
            this.sendFileButton.Click += new System.EventHandler(this.sendFileButton_Click);
            // 
            // sendStatusLabel
            // 
            this.sendStatusLabel.AutoSize = true;
            this.sendStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendStatusLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.sendStatusLabel.Location = new System.Drawing.Point(2, 340);
            this.sendStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sendStatusLabel.Name = "sendStatusLabel";
            this.sendStatusLabel.Size = new System.Drawing.Size(236, 35);
            this.sendStatusLabel.TabIndex = 9;
            this.sendStatusLabel.Text = "Отправка всем";
            this.sendStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetSelectionButton
            // 
            this.resetSelectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetSelectionButton.Location = new System.Drawing.Point(242, 342);
            this.resetSelectionButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetSelectionButton.Name = "resetSelectionButton";
            this.resetSelectionButton.Size = new System.Drawing.Size(75, 31);
            this.resetSelectionButton.TabIndex = 10;
            this.resetSelectionButton.Text = "Сбросить";
            this.resetSelectionButton.UseVisualStyleBackColor = true;
            this.resetSelectionButton.Click += new System.EventHandler(this.resetSelectionButton_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 421);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(812, 400);
            this.Name = "ChatForm";
            this.Text = "Чат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ipDescrLabel;
        private System.Windows.Forms.ToolStripStatusLabel ipAddressLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem главнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьСерверToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подключитьсяКСерверуToolStripMenuItem;
        private System.Windows.Forms.ListView clientsListView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox chatTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.Button sendFileButton;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader addressColumn;
        private System.Windows.Forms.ToolStripMenuItem отключитьсяОтСервераToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader portColumn;
        private System.Windows.Forms.OpenFileDialog fileSelectDialog;
        private System.Windows.Forms.Label sendStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem поискСерверовToolStripMenuItem;
        private System.Windows.Forms.Button resetSelectionButton;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    }
}