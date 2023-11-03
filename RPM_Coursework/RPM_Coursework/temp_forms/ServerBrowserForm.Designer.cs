
namespace I_SWEAR_THIS_IS_THE_FINAL_FUCKING_VERSION_OF_THIS_SHIT.Forms
{
    partial class ServerBrowserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.serversListView = new System.Windows.Forms.ListView();
            this.ipAddrColumn = new System.Windows.Forms.ColumnHeader();
            this.portColumn = new System.Windows.Forms.ColumnHeader();
            this.clientsColumn = new System.Windows.Forms.ColumnHeader();
            this.searchButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serversListView
            // 
            this.serversListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ipAddrColumn,
            this.portColumn,
            this.clientsColumn});
            this.serversListView.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.serversListView.HideSelection = false;
            this.serversListView.Location = new System.Drawing.Point(12, 12);
            this.serversListView.MultiSelect = false;
            this.serversListView.Name = "serversListView";
            this.serversListView.Size = new System.Drawing.Size(547, 332);
            this.serversListView.TabIndex = 0;
            this.serversListView.UseCompatibleStateImageBehavior = false;
            this.serversListView.View = System.Windows.Forms.View.Details;
            this.serversListView.SelectedIndexChanged += new System.EventHandler(this.serversListView_SelectedIndexChanged);
            // 
            // ipAddrColumn
            // 
            this.ipAddrColumn.Text = "IP-адрес";
            this.ipAddrColumn.Width = 160;
            // 
            // portColumn
            // 
            this.portColumn.Text = "Порт";
            this.portColumn.Width = 80;
            // 
            // clientsColumn
            // 
            this.clientsColumn.Text = "Кол-во клиентов";
            this.clientsColumn.Width = 160;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchButton.Location = new System.Drawing.Point(12, 350);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(289, 39);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Просканировать";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.connectButton.Enabled = false;
            this.connectButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectButton.Location = new System.Drawing.Point(307, 350);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(252, 39);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // ServerBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 399);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.serversListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ServerBrowserForm";
            this.Text = "Поиск серверов";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView serversListView;
        private System.Windows.Forms.ColumnHeader ipAddrColumn;
        private System.Windows.Forms.ColumnHeader portColumn;
        private System.Windows.Forms.ColumnHeader clientsColumn;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button connectButton;
    }
}