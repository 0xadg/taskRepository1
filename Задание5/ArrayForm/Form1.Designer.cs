namespace ArrayForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dividerField = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.upperRandomBound = new System.Windows.Forms.NumericUpDown();
            this.lowerRandomBound = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.randomFillButton = new System.Windows.Forms.RadioButton();
            this.manualFillButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.arrayLengthField = new System.Windows.Forms.NumericUpDown();
            this.calculateButton = new System.Windows.Forms.Button();
            this.baseArrayGrid = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.resultArrayGrid = new System.Windows.Forms.DataGridView();
            this.arrayFillButton = new System.Windows.Forms.Button();
            this.removedIndexesBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dividerField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperRandomBound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerRandomBound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrayLengthField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseArrayGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultArrayGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dividerField);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.upperRandomBound);
            this.groupBox1.Controls.Add(this.lowerRandomBound);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.randomFillButton);
            this.groupBox1.Controls.Add(this.manualFillButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.arrayLengthField);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры массива";
            // 
            // dividerField
            // 
            this.dividerField.Location = new System.Drawing.Point(180, 41);
            this.dividerField.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.dividerField.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.dividerField.Name = "dividerField";
            this.dividerField.Size = new System.Drawing.Size(120, 23);
            this.dividerField.TabIndex = 2;
            this.dividerField.ValueChanged += new System.EventHandler(this.DividerField_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Делитель:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(264, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = ")";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(180, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "до";
            // 
            // upperRandomBound
            // 
            this.upperRandomBound.Location = new System.Drawing.Point(204, 114);
            this.upperRandomBound.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upperRandomBound.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.upperRandomBound.Name = "upperRandomBound";
            this.upperRandomBound.Size = new System.Drawing.Size(60, 23);
            this.upperRandomBound.TabIndex = 6;
            this.upperRandomBound.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lowerRandomBound
            // 
            this.lowerRandomBound.Location = new System.Drawing.Point(120, 114);
            this.lowerRandomBound.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.lowerRandomBound.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.lowerRandomBound.Name = "lowerRandomBound";
            this.lowerRandomBound.Size = new System.Drawing.Size(60, 23);
            this.lowerRandomBound.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(95, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "(от ";
            // 
            // randomFillButton
            // 
            this.randomFillButton.AutoSize = true;
            this.randomFillButton.Checked = true;
            this.randomFillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.randomFillButton.Location = new System.Drawing.Point(10, 115);
            this.randomFillButton.Name = "randomFillButton";
            this.randomFillButton.Size = new System.Drawing.Size(91, 20);
            this.randomFillButton.TabIndex = 4;
            this.randomFillButton.TabStop = true;
            this.randomFillButton.Text = "Случайно";
            this.randomFillButton.UseVisualStyleBackColor = true;
            this.randomFillButton.CheckedChanged += new System.EventHandler(this.RandomFillButton_CheckedChanged);
            // 
            // manualFillButton
            // 
            this.manualFillButton.AutoSize = true;
            this.manualFillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.manualFillButton.Location = new System.Drawing.Point(10, 90);
            this.manualFillButton.Name = "manualFillButton";
            this.manualFillButton.Size = new System.Drawing.Size(85, 20);
            this.manualFillButton.TabIndex = 3;
            this.manualFillButton.Text = "Вручную";
            this.manualFillButton.UseVisualStyleBackColor = true;
            this.manualFillButton.CheckedChanged += new System.EventHandler(this.ManualFillButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Способ заполнения:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Размер массива:";
            // 
            // arrayLengthField
            // 
            this.arrayLengthField.Location = new System.Drawing.Point(10, 41);
            this.arrayLengthField.Name = "arrayLengthField";
            this.arrayLengthField.Size = new System.Drawing.Size(120, 23);
            this.arrayLengthField.TabIndex = 1;
            this.arrayLengthField.ValueChanged += new System.EventHandler(this.ArrayLengthField_ValueChanged);
            // 
            // calculateButton
            // 
            this.calculateButton.Enabled = false;
            this.calculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculateButton.Location = new System.Drawing.Point(377, 94);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(179, 70);
            this.calculateButton.TabIndex = 8;
            this.calculateButton.Text = "Рассчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // baseArrayGrid
            // 
            this.baseArrayGrid.AllowUserToAddRows = false;
            this.baseArrayGrid.AllowUserToDeleteRows = false;
            this.baseArrayGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.baseArrayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.baseArrayGrid.Location = new System.Drawing.Point(10, 191);
            this.baseArrayGrid.Name = "baseArrayGrid";
            this.baseArrayGrid.RowHeadersWidth = 15;
            this.baseArrayGrid.RowTemplate.Height = 25;
            this.baseArrayGrid.Size = new System.Drawing.Size(546, 82);
            this.baseArrayGrid.TabIndex = 9;
            this.baseArrayGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.BaseArrayGrid_EditingControlShowing);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(10, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Исходный массив:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(10, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Итоговый массив:";
            // 
            // resultArrayGrid
            // 
            this.resultArrayGrid.AllowUserToAddRows = false;
            this.resultArrayGrid.AllowUserToDeleteRows = false;
            this.resultArrayGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultArrayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultArrayGrid.Location = new System.Drawing.Point(10, 296);
            this.resultArrayGrid.Name = "resultArrayGrid";
            this.resultArrayGrid.ReadOnly = true;
            this.resultArrayGrid.RowHeadersWidth = 15;
            this.resultArrayGrid.RowTemplate.Height = 25;
            this.resultArrayGrid.Size = new System.Drawing.Size(395, 82);
            this.resultArrayGrid.TabIndex = 10;
            // 
            // arrayFillButton
            // 
            this.arrayFillButton.Enabled = false;
            this.arrayFillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arrayFillButton.Location = new System.Drawing.Point(377, 17);
            this.arrayFillButton.Name = "arrayFillButton";
            this.arrayFillButton.Size = new System.Drawing.Size(179, 70);
            this.arrayFillButton.TabIndex = 7;
            this.arrayFillButton.Text = "Сгенерировать массив";
            this.arrayFillButton.UseVisualStyleBackColor = true;
            this.arrayFillButton.Click += new System.EventHandler(this.ArrayFillButton_Click);
            // 
            // removedIndexesBox
            // 
            this.removedIndexesBox.FormattingEnabled = true;
            this.removedIndexesBox.Location = new System.Drawing.Point(411, 296);
            this.removedIndexesBox.Name = "removedIndexesBox";
            this.removedIndexesBox.Size = new System.Drawing.Size(145, 82);
            this.removedIndexesBox.TabIndex = 11;
            this.removedIndexesBox.SelectedValueChanged += new System.EventHandler(this.RemovedIndexesBox_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(411, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Удаленные индексы:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 388);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.removedIndexesBox);
            this.Controls.Add(this.arrayFillButton);
            this.Controls.Add(this.resultArrayGrid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.baseArrayGrid);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Обработка одномерных массивов";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dividerField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperRandomBound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerRandomBound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrayLengthField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseArrayGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultArrayGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton manualFillButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown arrayLengthField;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.NumericUpDown lowerRandomBound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton randomFillButton;
        private System.Windows.Forms.DataGridView baseArrayGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown upperRandomBound;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView resultArrayGrid;
        private System.Windows.Forms.Button arrayFillButton;
        private System.Windows.Forms.NumericUpDown dividerField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox removedIndexesBox;
        private System.Windows.Forms.Label label9;
    }
}

