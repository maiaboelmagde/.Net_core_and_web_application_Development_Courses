namespace WinFormsApp
{
    partial class DetailedList
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
            listBox1 = new ListBox();
            TitletextBox = new TextBox();
            TitleIDLabel = new Label();
            label2 = new Label();
            label3 = new Label();
            typeTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            RoyaltyTextBox = new TextBox();
            label7 = new Label();
            label8 = new Label();
            NoticeTextBox = new TextBox();
            label9 = new Label();
            PublisherComboBox = new ComboBox();
            PriceNumericUpDown = new NumericUpDown();
            salesNumericUpDown = new NumericUpDown();
            AdvanceNumericUpDown = new NumericUpDown();
            saveButton = new Button();
            pubDateTime = new DateTimePicker();
            label = new Label();
            ((System.ComponentModel.ISupportInitialize)PriceNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)salesNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AdvanceNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(578, 24);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(210, 404);
            listBox1.TabIndex = 0;
            // 
            // TitletextBox
            // 
            TitletextBox.Location = new Point(84, 84);
            TitletextBox.Name = "TitletextBox";
            TitletextBox.Size = new Size(464, 27);
            TitletextBox.TabIndex = 1;
            // 
            // TitleIDLabel
            // 
            TitleIDLabel.AutoSize = true;
            TitleIDLabel.Location = new Point(101, 50);
            TitleIDLabel.Name = "TitleIDLabel";
            TitleIDLabel.Size = new Size(53, 20);
            TitleIDLabel.TabIndex = 2;
            TitleIDLabel.Text = "TitleID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 87);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 3;
            label2.Text = "Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 120);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 5;
            label3.Text = "Type";
            // 
            // typeTextBox
            // 
            typeTextBox.Location = new Point(84, 118);
            typeTextBox.Name = "typeTextBox";
            typeTextBox.Size = new Size(464, 27);
            typeTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 185);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 7;
            label4.Text = "Advance";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 152);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 9;
            label5.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 220);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 11;
            label6.Text = "Royalty";
            // 
            // RoyaltyTextBox
            // 
            RoyaltyTextBox.Location = new Point(84, 220);
            RoyaltyTextBox.Name = "RoyaltyTextBox";
            RoyaltyTextBox.Size = new Size(464, 27);
            RoyaltyTextBox.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 255);
            label7.Name = "label7";
            label7.Size = new Size(69, 20);
            label7.TabIndex = 13;
            label7.Text = "Ytd_sales";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 292);
            label8.Name = "label8";
            label8.Size = new Size(53, 20);
            label8.TabIndex = 15;
            label8.Text = "Notice";
            // 
            // NoticeTextBox
            // 
            NoticeTextBox.Location = new Point(84, 289);
            NoticeTextBox.Name = "NoticeTextBox";
            NoticeTextBox.Size = new Size(464, 27);
            NoticeTextBox.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 328);
            label9.Name = "label9";
            label9.Size = new Size(69, 20);
            label9.TabIndex = 20;
            label9.Text = "Publisher";
            // 
            // PublisherComboBox
            // 
            PublisherComboBox.FormattingEnabled = true;
            PublisherComboBox.Location = new Point(84, 322);
            PublisherComboBox.Name = "PublisherComboBox";
            PublisherComboBox.Size = new Size(464, 28);
            PublisherComboBox.TabIndex = 21;
            // 
            // PriceNumericUpDown
            // 
            PriceNumericUpDown.Location = new Point(84, 152);
            PriceNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            PriceNumericUpDown.Name = "PriceNumericUpDown";
            PriceNumericUpDown.Size = new Size(464, 27);
            PriceNumericUpDown.TabIndex = 22;
            // 
            // salesNumericUpDown
            // 
            salesNumericUpDown.Location = new Point(87, 253);
            salesNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            salesNumericUpDown.Name = "salesNumericUpDown";
            salesNumericUpDown.Size = new Size(464, 27);
            salesNumericUpDown.TabIndex = 23;
            // 
            // AdvanceNumericUpDown
            // 
            AdvanceNumericUpDown.Location = new Point(84, 187);
            AdvanceNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            AdvanceNumericUpDown.Name = "AdvanceNumericUpDown";
            AdvanceNumericUpDown.Size = new Size(464, 27);
            AdvanceNumericUpDown.TabIndex = 24;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(417, 399);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 25;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // pubDateTime
            // 
            pubDateTime.Location = new Point(84, 367);
            pubDateTime.Name = "pubDateTime";
            pubDateTime.Size = new Size(250, 27);
            pubDateTime.TabIndex = 26;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(14, 372);
            label.Name = "label";
            label.Size = new Size(67, 20);
            label.TabIndex = 27;
            label.Text = "pubDate";
            // 
            // DetailedList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label);
            Controls.Add(pubDateTime);
            Controls.Add(saveButton);
            Controls.Add(AdvanceNumericUpDown);
            Controls.Add(salesNumericUpDown);
            Controls.Add(PriceNumericUpDown);
            Controls.Add(PublisherComboBox);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(NoticeTextBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(RoyaltyTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(typeTextBox);
            Controls.Add(label2);
            Controls.Add(TitleIDLabel);
            Controls.Add(TitletextBox);
            Controls.Add(listBox1);
            Name = "DetailedList";
            Text = "DetailedList";
            Load += DetailedList_Load;
            ((System.ComponentModel.ISupportInitialize)PriceNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)salesNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AdvanceNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox TitletextBox;
        private Label TitleIDLabel;
        private Label label2;
        private Label label3;
        private TextBox typeTextBox;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox RoyaltyTextBox;
        private Label label7;
        private Label label8;
        private TextBox NoticeTextBox;
        private Label label9;
        private ComboBox PublisherComboBox;
        private NumericUpDown PriceNumericUpDown;
        private NumericUpDown salesNumericUpDown;
        private NumericUpDown AdvanceNumericUpDown;
        private Button saveButton;
        private DateTimePicker pubDateTime;
        private Label label;
    }
}