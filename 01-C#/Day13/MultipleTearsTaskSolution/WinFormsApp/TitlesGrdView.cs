using System.Data;
using BLL;
using BLL.Entities;
using BLL.EntityList;
using BLL.EntityManager;
using Microsoft.Data.SqlClient;
namespace WinFormsApp
{
    public partial class Form1 : Form
    {

        TitlesList lst = new();
        BindingSource TitlesBindingSource = new();


        PublisherList publishers = new PublisherList();
        BindingSource publishersBindingSource = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.Columns.Clear();

                lst = TitleManager.SelectALLTitles();
                TitlesBindingSource = new BindingSource(lst, "");
                dataGridView.DataSource = TitlesBindingSource;

                dataGridView.Columns["pub_name"].Visible = false;
                dataGridView.Columns["pub_id"].ReadOnly = true;
                dataGridView.Columns["title_id"].ReadOnly = true;
                dataGridView.Columns["State"].ReadOnly = true;



                DataGridViewComboBoxColumn PublishersCol = new DataGridViewComboBoxColumn();
                publishers = PublisherManager.GetAllPublishers();
                publishersBindingSource = new BindingSource(publishers, "");
                PublishersCol.DataSource = publishersBindingSource;
                PublishersCol.DisplayMember = "pub_name";
                PublishersCol.ValueMember = "pub_id";
                PublishersCol.HeaderText = "Publisher";
                PublishersCol.DataPropertyName = "pub_id";
                dataGridView.Columns.Add(PublishersCol);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Some thing went wrong while Loading data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var TitlesToInsert = lst.Where(P => P.State == EntityState.Added).ToList();
                var TitlesToUpdate = lst.Where(P => P.State == EntityState.Modified).ToList();
                var TitleToDelete = lst.Where(p => p.State == EntityState.Deleted).ToList();
                int count = 0;
                foreach (Title t in TitlesToInsert)
                    count += TitleManager.InsertTitle(t, lst.Count()) ? 1 : 0;

                foreach (Title t in TitlesToUpdate)
                    count += TitleManager.UpdateTitle(t) ? 1 : 0;

                foreach (Title t in TitleToDelete)
                    count += TitleManager.DeleteTitle(t) ? 1 : 0;

                MessageBox.Show($"Saves succcessfully, and {count} Rows Effected ...", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some thing went wrong while Save changes !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadToolStripMenuItem_Click(sender, e);
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    if (dataGridView.CurrentRow == row)
                    {
                        BindingContext[dataGridView.DataSource].Position = 0; // Move to the first row.
                    }

                    if (row.Cells["title_id"].Value is not null)
                    {
                        string selectedTitleId = row.Cells["title_id"].Value.ToString();
                        var title = lst.FirstOrDefault(t => t.title_id == selectedTitleId);
                        if (title != null)
                        {
                            title.State = EntityState.Deleted;
                        }
                    }

                    row.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("No Selected row.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
