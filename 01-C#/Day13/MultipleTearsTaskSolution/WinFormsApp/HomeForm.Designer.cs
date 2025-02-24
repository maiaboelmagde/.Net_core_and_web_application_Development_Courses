namespace WinFormsApp
{
    partial class HomeForm
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
            GridView = new Button();
            DetailedList = new Button();
            SuspendLayout();
            // 
            // GridView
            // 
            GridView.Location = new Point(150, 66);
            GridView.Name = "GridView";
            GridView.Size = new Size(486, 100);
            GridView.TabIndex = 0;
            GridView.Text = "GridView Page";
            GridView.UseVisualStyleBackColor = true;
            GridView.Click += GridView_Click;
            // 
            // DetailedList
            // 
            DetailedList.Location = new Point(150, 215);
            DetailedList.Name = "DetailedList";
            DetailedList.Size = new Size(486, 100);
            DetailedList.TabIndex = 1;
            DetailedList.Text = "DetailedList Page";
            DetailedList.UseVisualStyleBackColor = true;
            DetailedList.Click += DetailedList_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DetailedList);
            Controls.Add(GridView);
            Name = "HomeForm";
            Text = "HomeForm";
            ResumeLayout(false);
        }

        #endregion

        private Button GridView;
        private Button DetailedList;
    }
}