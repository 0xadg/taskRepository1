namespace RPM_Coursework.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.defaultPortTextBox = new System.Windows.Forms.TextBox();
            this.settingsHelpTT = new System.Windows.Forms.ToolTip(this.components);
            this.manualEntryCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя пользователя:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.userNameTextBox.Location = new System.Drawing.Point(147, 22);
            this.userNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(209, 26);
            this.userNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Серверный порт:";
            // 
            // defaultPortTextBox
            // 
            this.defaultPortTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.defaultPortTextBox.Location = new System.Drawing.Point(137, 51);
            this.defaultPortTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.defaultPortTextBox.Name = "defaultPortTextBox";
            this.defaultPortTextBox.Size = new System.Drawing.Size(219, 26);
            this.defaultPortTextBox.TabIndex = 2;
            // 
            // settingsHelpTT
            // 
            this.settingsHelpTT.AutoPopDelay = 9000;
            this.settingsHelpTT.InitialDelay = 100;
            this.settingsHelpTT.ReshowDelay = 100;
            // 
            // manualEntryCheckBox
            // 
            this.manualEntryCheckBox.AutoSize = true;
            this.manualEntryCheckBox.Checked = true;
            this.manualEntryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.manualEntryCheckBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.manualEntryCheckBox.Location = new System.Drawing.Point(15, 80);
            this.manualEntryCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.manualEntryCheckBox.Name = "manualEntryCheckBox";
            this.manualEntryCheckBox.Size = new System.Drawing.Size(273, 23);
            this.manualEntryCheckBox.TabIndex = 3;
            this.manualEntryCheckBox.Text = "Всегда спрашивать порт при создании";
            this.manualEntryCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Папка полученных файлов:";
            // 
            // selectPathButton
            // 
            this.selectPathButton.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.selectPathButton.Location = new System.Drawing.Point(15, 74);
            this.selectPathButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(110, 31);
            this.selectPathButton.TabIndex = 7;
            this.selectPathButton.Text = "Выбрать";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.pathTextBox.Location = new System.Drawing.Point(15, 46);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(390, 26);
            this.pathTextBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.userNameTextBox);
            this.groupBox1.Controls.Add(this.manualEntryCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.defaultPortTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(411, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Общие настройки";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.pathTextBox);
            this.groupBox3.Controls.Add(this.selectPathButton);
            this.groupBox3.Location = new System.Drawing.Point(11, 129);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(411, 109);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Прочие настройки";
            // 
            // confirmButton
            // 
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmButton.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.confirmButton.Location = new System.Drawing.Point(147, 243);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(135, 30);
            this.confirmButton.TabIndex = 9;
            this.confirmButton.Text = "Подтвердить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cancelButton.Location = new System.Drawing.Point(289, 243);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(133, 30);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RPM_Coursework.Properties.Resources.help_icon;
            this.pictureBox2.Location = new System.Drawing.Point(360, 51);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.settingsHelpTT.SetToolTip(this.pictureBox2, "Порт, который будет использоваться при создании сервера");
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(434, 279);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox defaultPortTextBox;
        private System.Windows.Forms.ToolTip settingsHelpTT;
        private System.Windows.Forms.CheckBox manualEntryCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}