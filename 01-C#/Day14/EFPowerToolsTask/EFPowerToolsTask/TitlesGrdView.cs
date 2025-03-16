using System.Data;
using System.Security.Policy;
using EFPowerToolsTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {

        pubsContext context;
        public Form1()
        {
            InitializeComponent();
            context = new pubsContext();
            this.FormClosed += (sender, e) => context?.Dispose();
        }




        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            context.Titles.Load();
            context.Publishers.Load();
            dataGridView.DataSource = context.Titles.Local.ToBindingList();

            dataGridView.Columns["PubId"].ReadOnly = true;
            dataGridView.Columns["Pub"].Visible = false;

            DataGridViewComboBoxColumn PublishersCol = new DataGridViewComboBoxColumn();
            PublishersCol.DataSource = context.Publishers.Local.ToBindingList();
            PublishersCol.DisplayMember = "PubName";
            PublishersCol.ValueMember = "PubId";
            PublishersCol.HeaderText = "Publisher";
            PublishersCol.DataPropertyName = "PubId";
            dataGridView.Columns.Add(PublishersCol);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.EndEdit();
            context?.SaveChanges();
            dataGridView.Refresh();

        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var titlesToRemove = new List<Title>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    if (row.DataBoundItem is Title title)
                    {
                        titlesToRemove.Add(title);
                    }
                }

                if (titlesToRemove.Count > 0)
                {
                    DialogResult confirmDelete = MessageBox.Show(
                        "Are you sure you want to delete the selected titles?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmDelete == DialogResult.Yes)
                    {
                        foreach (var title in titlesToRemove)
                        {
                            context.Titles.Remove(title);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
