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
    public partial class DetailedList : Form
    {
        public DetailedList()
        {
            InitializeComponent();
        }


        SqlDataAdapter _adapter;
        DataTable _dataTable;
        SqlCommand _command;
        BindingSource _bindingSource;
        private void DetailedList_Load(object sender, EventArgs e)
        {
            _command = new SqlCommand("SELECT * FROM titles INNER JOIN publishers ON publishers.pub_id = titles.pub_id", sqlCN);
            _adapter = new SqlDataAdapter(_command);
            _dataTable = new DataTable();
            _bindingSource = new BindingSource(_dataTable, "");

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


            _adapter.Fill(_dataTable);

            listBox1.DataSource = _dataTable;
            listBox1.DisplayMember = "pub_name";
            listBox1.ValueMember = "title_id";


            BindingNavigator bindingNavigator = new BindingNavigator(_bindingSource);
            this.Controls.Add(bindingNavigator);
            /*
            TitleID.DataBindings.Add("Text", _bindingSource, "title_id");
            Title.DataBindings.Add("Text", _bindingSource, "title");
            Price.DataBindings.Add("Value", _bindingSource, "Price");
            */

            Binding titleIdBinding = new Binding("Text", _bindingSource, "title_id", true, DataSourceUpdateMode.OnPropertyChanged);
            titleIdBinding.Format += (s, e1) => { e1.Value = e1.Value == DBNull.Value ? "N/A" : e1.Value; };
            TitleID.DataBindings.Add(titleIdBinding);

            Binding titleBinding = new Binding("Text", _bindingSource, "title", true, DataSourceUpdateMode.OnPropertyChanged);
            titleBinding.Format += (s, e2) => { e2.Value = e2.Value == DBNull.Value ? "Untitled" : e2.Value; };
            titleBinding.Parse += (s, e2) => { e2.Value = string.IsNullOrEmpty(e2.Value?.ToString()) ? DBNull.Value : e2.Value; };
            Title.DataBindings.Add(titleBinding);

            Binding priceBinding = new Binding("Value", _bindingSource, "price", true, DataSourceUpdateMode.OnPropertyChanged);
            priceBinding.Format += (s, e3) => { e3.Value = e3.Value == DBNull.Value ? 0.0m : e3.Value; };
            priceBinding.Parse += (s, e3) =>
            {
                if (string.IsNullOrEmpty(e3.Value?.ToString()))
                {
                    e3.Value = DBNull.Value;
                }
                else
                {
                    decimal price;
                    if (decimal.TryParse(e3.Value.ToString(), out price))
                    {
                        e3.Value = price;
                    }
                    else
                    {
                        e3.Value = DBNull.Value;
                    }
                }
            };
            Price.DataBindings.Add(priceBinding);




            _bindingSource.PositionChanged += (s, e4) => SyncListBoxWithBindingNavigator();
            bindingNavigator.AddNewItem.Click += (s, e5) => AddNewRecord();


        }


        private void Savebutton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate(); 
                _bindingSource.EndEdit(); 

                if (_dataTable.GetChanges() != null)
                {
                    _adapter.Update(_dataTable);
                    _dataTable.AcceptChanges();
                    MessageBox.Show("Updated successfully.");
                }
                else
                {
                    MessageBox.Show("No changes detected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) 
            {
                string selectedPubId = listBox1.SelectedValue.ToString();

                int index = _dataTable.Rows.IndexOf(_dataTable.Select($"title_id = '{selectedPubId}'").SingleOrDefault());

                if (index != -1)
                {
                    _bindingSource.Position = index;
                }
            }
        }

        private void SyncListBoxWithBindingNavigator()
        {
            if (_bindingSource.Current != null)
            {
                DataRowView currentRow = (DataRowView)_bindingSource.Current;
                string currentTitleId = currentRow["title_id"].ToString();

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    DataRowView row = (DataRowView)listBox1.Items[i];
                    if (row["title_id"].ToString() == currentTitleId)
                    {
                        listBox1.SelectedIndex = i;
                        break;
                    }
                }
            }
        }


        private void AddNewRecord()
        {
            try
            {
                DataRow newRow = _dataTable.NewRow();

                newRow["title_id"] = GenerateUniqueTitleId(); 
                newRow["title"] = "New Title";
                newRow["type"] = "Unknown";
                newRow["pub_id"] = "0877";
                newRow["price"] = 0.0m;
                newRow["advance"] = 0.0m;
                newRow["royalty"] = 0;
                newRow["ytd_sales"] = 0;
                newRow["notes"] = "";
                newRow["pubdate"] = DateTime.Now;

                _dataTable.Rows.Add(newRow);

                _bindingSource.Position = _dataTable.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding new record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string GenerateUniqueTitleId()
        {
            return "T" + (_dataTable.Rows.Count + 1).ToString("D3"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dataTable.Clear();
            _adapter.Fill(_dataTable);
            listBox1.DataSource = _dataTable;
        }
    }
}
