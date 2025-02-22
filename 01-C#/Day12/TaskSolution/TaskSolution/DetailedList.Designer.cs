namespace TaskSolution
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
            this.TitleID = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.TextBox();
            this.Price = new System.Windows.Forms.NumericUpDown();
            this.Savebutton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleID
            // 
            this.TitleID.AutoSize = true;
            this.TitleID.Location = new System.Drawing.Point(60, 65);
            this.TitleID.Name = "TitleID";
            this.TitleID.Size = new System.Drawing.Size(46, 17);
            this.TitleID.TabIndex = 0;
            this.TitleID.Text = "TitleID";
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(63, 113);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(120, 24);
            this.Title.TabIndex = 1;
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(63, 182);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(120, 24);
            this.Price.TabIndex = 2;
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(63, 308);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(120, 35);
            this.Savebutton.TabIndex = 5;
            this.Savebutton.Text = "Save";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(485, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(290, 404);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Reload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DetailedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.TitleID);
            this.Name = "DetailedList";
            this.Text = "DetailedList";
            this.Load += new System.EventHandler(this.DetailedList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleID;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.NumericUpDown Price;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
    }
}