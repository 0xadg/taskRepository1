namespace RPM_Coursework.Forms
{
    partial class ConnectionForm
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
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.formCloseButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.helpTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.portTextBox.Location = new System.Drawing.Point(97, 37);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(158, 26);
            this.portTextBox.TabIndex = 2;
            this.portTextBox.TextChanged += new System.EventHandler(this.mainFields_TextChanged);
            this.portTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputFiltering);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP адрес:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порт:";
            // 
            // confirmButton
            // 
            this.confirmButton.Enabled = false;
            this.confirmButton.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.confirmButton.Location = new System.Drawing.Point(11, 67);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(244, 29);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Подключиться";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.formTitleLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.formTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(173, 31);
            this.formTitleLabel.TabIndex = 6;
            this.formTitleLabel.Text = "Подключение";
            // 
            // formCloseButton
            // 
            this.formCloseButton.Location = new System.Drawing.Point(0, 0);
            this.formCloseButton.Name = "formCloseButton";
            this.formCloseButton.Size = new System.Drawing.Size(75, 23);
            this.formCloseButton.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cancelButton.Location = new System.Drawing.Point(259, 67);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(168, 29);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // helpTooltip
            // 
            this.helpTooltip.IsBalloon = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ipAddressTextBox.Location = new System.Drawing.Point(97, 7);
            this.ipAddressTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipAddressTextBox.MaxLength = 15;
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(330, 26);
            this.ipAddressTextBox.TextChanged += new System.EventHandler(this.mainFields_TextChanged);
            this.ipAddressTextBox.TabIndex = 5;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 105);
            this.Controls.Add(this.ipAddressTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionForm";
            this.Text = "Подключение к серверу";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip helpTooltip;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button formCloseButton;
        private System.Windows.Forms.TextBox ipAddressTextBox;
    }
}