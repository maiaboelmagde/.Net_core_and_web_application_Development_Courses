namespace TaskSolution
{
    partial class PubsGridview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PubsGridview));
            this.PrdsGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LoadData = new System.Windows.Forms.ToolStripButton();
            this.SaveChanges = new System.Windows.Forms.ToolStripButton();
            this.DeleteSelectedRow = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.PrdsGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrdsGridView
            // 
            this.PrdsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PrdsGridView.Location = new System.Drawing.Point(12, 30);
            this.PrdsGridView.Name = "PrdsGridView";
            this.PrdsGridView.RowHeadersWidth = 51;
            this.PrdsGridView.RowTemplate.Height = 26;
            this.PrdsGridView.Size = new System.Drawing.Size(776, 408);
            this.PrdsGridView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadData,
            this.SaveChanges,
            this.DeleteSelectedRow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LoadData
            // 
            this.LoadData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadData.Image = ((System.Drawing.Image)(resources.GetObject("LoadData.Image")));
            this.LoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadData.Name = "LoadData";
            this.LoadData.Size = new System.Drawing.Size(29, 24);
            this.LoadData.Text = "LoadData";
            this.LoadData.Click += new System.EventHandler(this.LoadData_Click);
            // 
            // SaveChanges
            // 
            this.SaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("SaveChanges.Image")));
            this.SaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(29, 24);
            this.SaveChanges.Text = "SaveChanges";
            this.SaveChanges.Click += new System.EventHandler(this.SaveChanges_Click);
            // 
            // DeleteSelectedRow
            // 
            this.DeleteSelectedRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteSelectedRow.Image = global::TaskSolution.Properties.Resources.deleteIcon;
            this.DeleteSelectedRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteSelectedRow.Name = "DeleteSelectedRow";
            this.DeleteSelectedRow.Size = new System.Drawing.Size(29, 24);
            this.DeleteSelectedRow.Text = "DeleteSelectedRow";
            this.DeleteSelectedRow.ToolTipText = "DeleteSelectedRow";
            this.DeleteSelectedRow.Click += new System.EventHandler(this.DeleteSelectedRow_Click);
            // 
            // PubsGridview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PrdsGridView);
            this.Name = "PubsGridview";
            this.Text = "GridView";
            this.Load += new System.EventHandler(this.PubsGridview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PrdsGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PrdsGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton LoadData;
        private System.Windows.Forms.ToolStripButton SaveChanges;
        private System.Windows.Forms.ToolStripButton DeleteSelectedRow;
    }
}

