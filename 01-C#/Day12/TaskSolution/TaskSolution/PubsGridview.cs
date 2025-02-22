using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TaskSolution.ConnectionHelper;

namespace TaskSolution
{
    public partial class PubsGridview : Form
    {
        SqlDataAdapter _adapter;
        DataTable _dataTable;
        SqlCommand _command;
        public PubsGridview()
        {
            InitializeComponent();
        }



        private void PubsGridview_Load(object sender, EventArgs e)
        {
            _command = new SqlCommand("SELECT * FROM titles INNER JOIN publishers ON publishers.pub_id = titles.pub_id", sqlCN);
            _adapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();

            if (sqlCN.State == ConnectionState.Closed)
            {
                sqlCN.Open();
            }


            SqlCommand updateCommand = new SqlCommand(
                "UPDATE titles SET title = @title, type = @type, pub_id = @pub_id, price = @price, advance = @advance, royalty = @royalty, ytd_sales = @ytd_sales, notes = @notes, pubdate = @pubdate WHERE title_id = @title_id",
                sqlCN
            );

            updateCommand.Parameters.Add("@title", SqlDbType.VarChar, 255, "title");
            updateCommand.Parameters.Add("@type", SqlDbType.VarChar, 50, "type");
            updateCommand.Parameters.Add("@pub_id", SqlDbType.VarChar, 4, "pub_id");
            updateCommand.Parameters.Add("@price", SqlDbType.Money, 8, "price");
            updateCommand.Parameters.Add("@advance", SqlDbType.Money, 8, "advance");
            updateCommand.Parameters.Add("@royalty", SqlDbType.Int, 4, "royalty");
            updateCommand.Parameters.Add("@ytd_sales", SqlDbType.Int, 4, "ytd_sales");
            updateCommand.Parameters.Add("@notes", SqlDbType.VarChar, 255, "notes");
            updateCommand.Parameters.Add("@pubdate", SqlDbType.DateTime, 8, "pubdate");
            updateCommand.Parameters.Add("@title_id", SqlDbType.VarChar, 6, "title_id");

            _adapter.UpdateCommand = updateCommand;

            SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO titles (title_id, title, type, pub_id, price, advance, royalty, ytd_sales, notes, pubdate) VALUES (@title_id, @title, @type, @pub_id, @price, @advance, @royalty, @ytd_sales, @notes, @pubdate)",
                sqlCN
            );

            insertCommand.Parameters.Add("@title_id", SqlDbType.VarChar, 6, "title_id");
            insertCommand.Parameters.Add("@title", SqlDbType.VarChar, 255, "title");
            insertCommand.Parameters.Add("@type", SqlDbType.VarChar, 50, "type");
            insertCommand.Parameters.Add("@pub_id", SqlDbType.VarChar, 4, "pub_id");
            insertCommand.Parameters.Add("@price", SqlDbType.Money, 8, "price");
            insertCommand.Parameters.Add("@advance", SqlDbType.Money, 8, "advance");
            insertCommand.Parameters.Add("@royalty", SqlDbType.Int, 4, "royalty");
            insertCommand.Parameters.Add("@ytd_sales", SqlDbType.Int, 4, "ytd_sales");
            insertCommand.Parameters.Add("@notes", SqlDbType.VarChar, 255, "notes");
            insertCommand.Parameters.Add("@pubdate", SqlDbType.DateTime, 8, "pubdate");

            _adapter.InsertCommand = insertCommand;

            SqlCommand deleteCommand = new SqlCommand(
                "DELETE FROM titles WHERE title_id = @title_id",
                sqlCN
            );

            deleteCommand.Parameters.Add("@title_id", SqlDbType.VarChar, 6, "title_id");

            _adapter.DeleteCommand = deleteCommand;
        }





        private void SaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dataTable.GetChanges() != null) 
                {
                    _adapter.Update(_dataTable);
                    _dataTable.AcceptChanges(); 
                    MessageBox.Show("Updated successfully ............");
                }
                else
                {
                    MessageBox.Show("No changes detected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Changes ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadData_Click(object sender, EventArgs e)
        {
            _dataTable.Clear();
            _adapter.Fill(_dataTable);
            PrdsGridView.DataSource = _dataTable;
        }

        private void DeleteSelectedRow_Click(object sender, EventArgs e)
        {
            if (PrdsGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in PrdsGridView.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        PrdsGridView.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Selected row.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
    }
}
