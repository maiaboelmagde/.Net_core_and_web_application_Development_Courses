using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Entities;
using BLL.EntityList;
using BLL.EntityManager;

namespace WinFormsApp
{
    public partial class DetailedList : Form
    {
        public DetailedList()
        {
            InitializeComponent();
        }

        TitlesList titles = new TitlesList();
        BindingSource TitlesBindingSource;


        PublisherList publishers = new PublisherList();
        BindingSource publishersBindingSource;

        BindingNavigator navigator;
        private void DetailedList_Load(object sender, EventArgs e)
        {
            titles = TitleManager.SelectALLTitles();
            TitlesBindingSource = new BindingSource(titles, "");

            publishers = PublisherManager.GetAllPublishers();
            publishersBindingSource = new BindingSource(publishers, "");

            PublisherComboBox.DataSource = publishersBindingSource;
            PublisherComboBox.DisplayMember = "pub_name";
            PublisherComboBox.ValueMember = "pub_id";

            listBox1.DataSource = TitlesBindingSource;
            listBox1.DisplayMember = "title";
            listBox1.ValueMember = "title_id";

            navigator = new BindingNavigator(TitlesBindingSource);

            ToolStripButton deleteButton = new ToolStripButton();
            deleteButton.Text = "Delete";
            deleteButton.Image = SystemIcons.Warning.ToBitmap(); // Replace with actual delete icon
            deleteButton.Click += DeleteButton_Click;
            navigator.Items.Add(deleteButton);
            this.Controls.Add(navigator);

            ToolStripButton insertButton = new ToolStripButton();
            insertButton.Text = "Insert";
            insertButton.Image = SystemIcons.Information.ToBitmap(); // Replace with actual insert icon
            insertButton.Click += InsertButton_Click;
            navigator.Items.Add(insertButton);

            TitleIDLabel.DataBindings.Add("Text", TitlesBindingSource, "title_id", true, DataSourceUpdateMode.OnPropertyChanged);
            TitletextBox.DataBindings.Add("Text", TitlesBindingSource, "title", true, DataSourceUpdateMode.OnPropertyChanged);
            typeTextBox.DataBindings.Add("Text", TitlesBindingSource, "type", true, DataSourceUpdateMode.OnPropertyChanged);
            PriceNumericUpDown.DataBindings.Add("Text", TitlesBindingSource, "price", true, DataSourceUpdateMode.OnPropertyChanged);
            AdvanceNumericUpDown.DataBindings.Add("Text", TitlesBindingSource, "advance", true, DataSourceUpdateMode.OnPropertyChanged);
            RoyaltyTextBox.DataBindings.Add("Text", TitlesBindingSource, "royalty", true, DataSourceUpdateMode.OnPropertyChanged);
            salesNumericUpDown.DataBindings.Add("Text", TitlesBindingSource, "ytd_sales", true, DataSourceUpdateMode.OnPropertyChanged);
            NoticeTextBox.DataBindings.Add("Text", TitlesBindingSource, "notes", true, DataSourceUpdateMode.OnPropertyChanged);
            PublisherComboBox.DataBindings.Add("SelectedValue", TitlesBindingSource, "pub_id", true, DataSourceUpdateMode.OnPropertyChanged);
            pubDateTime.DataBindings.Add("Value", TitlesBindingSource, "pubdate", true, DataSourceUpdateMode.OnPropertyChanged);

            TitlesBindingSource.CurrentItemChanged += TitlesBindingSource_CurrentItemChanged;
        }

        

        private void TitlesBindingSource_CurrentItemChanged(object? sender, EventArgs e)
        {
            if (TitlesBindingSource.Current is Title currentTitle && currentTitle.State == EntityState.UnChanged)
            {
                Title originalTitle = titles.FirstOrDefault(t => t.title_id == currentTitle.title_id);
                if (originalTitle != null && !IsTitleEqual(originalTitle, currentTitle))
                {
                    currentTitle.State = EntityState.Modified;
                }
            }
        }

        private bool IsTitleEqual(Title original, Title current)
        {
            return original.title == current.title &&
                   original.type == current.type &&
                   original.price == current.price &&
                   original.advance == current.advance &&
                   original.royalty == current.royalty &&
                   original.ytd_sales == current.ytd_sales &&
                   original.notes == current.notes &&
                   original.pub_id == current.pub_id &&
                   original.pubdate == current.pubdate;
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var AddedTitlest = titles.Where(t => t.State == EntityState.Added).ToList();
                var ModifiedTitles = titles.Where(t => t.State == EntityState.Modified).ToList();
                var DeleteTitle = titles.Where(t => t.State == EntityState.Deleted).ToList();
                int count = 0;

                //MessageBox.Show($"AddedTitlest count = {AddedTitlest.Count} \n& \n ModifiedTitles count = {ModifiedTitles.Count}{ModifiedTitles[0].title} \n & \n DeleteTitle count = {DeleteTitle.Count}");
                foreach (Title t in AddedTitlest)
                {
                    count += TitleManager.InsertTitle(t, titles.Count) ? 1 : 0;
                    t.State = EntityState.UnChanged;
                }

                foreach (Title t in ModifiedTitles)
                {
                    count += TitleManager.UpdateTitle(t) ? 1 : 0;
                    t.State = EntityState.UnChanged;
                }

                foreach (Title t in DeleteTitle)
                {
                    count += TitleManager.DeleteTitle(t) ? 1 : 0;
                    t.State = EntityState.UnChanged;
                }
                MessageBox.Show($"Saves succcessfully, and {count} Rows Effected ...", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MessageBox.Show("Some thing went wrong while Save changes !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (TitlesBindingSource.Current is Title currentTitle)
            {
                currentTitle.State = EntityState.Deleted;
                HideDeletedTitles();
            }
        }
        private void HideDeletedTitles()
        {
            TitlesBindingSource.DataSource = titles.Where(t => t.State != EntityState.Deleted).ToList();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            Title newTitle = new Title
            {
                title_id = "New Item",
                title = "New Title",
                type = "",
                price = 0,
                advance = 0,
                royalty = 0,
                ytd_sales = 0,
                notes = "",
                pub_id = publishers.FirstOrDefault()?.pub_id, 
                pubdate = DateTime.Now,
                State = EntityState.Added
            };

            titles.Add(newTitle);
            TitlesBindingSource.DataSource = titles; 
            TitlesBindingSource.Position = titles.Count - 1; 

            MessageBox.Show("New Title Added! Fill in details and click Save.", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
