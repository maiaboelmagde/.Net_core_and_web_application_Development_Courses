using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Reflection.Metadata.BlobBuilder;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BooksDetailsViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<BookDetails> books= new List<BookDetails>();
        public MainPage()
        {
            this.InitializeComponent();

            #region Adding Dummy booksInfo to the list

            books.Add(new BookDetails
            {
                Title = "Echo",
                Description = "A mysterious sound leads to a thrilling discovery.",
                Auther = "Lena Hart",
                NumOfPapers = 210,
                PublishDate = new DateTime(2020, 5, 12),
                ImagePath = "/Assets/EchoBook.jpeg"
            });

            books.Add(new BookDetails
            {
                Title = "Dust",
                Description = "A post-apocalyptic journey through a forgotten world.",
                Auther = "Riley Stone",
                NumOfPapers = 298,
                PublishDate = new DateTime(2018, 8, 23),
                ImagePath = "/Assets/DustBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Glow",
                Description = "A sci-fi adventure filled with light and shadows.",
                Auther = "Kai Moore",
                NumOfPapers = 340,
                PublishDate = new DateTime(2021, 3, 19),
                ImagePath = "/Assets/GlowBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Mist",
                Description = "A fantasy tale shrouded in fog and mystery.",
                Auther = "Nora Blake",
                NumOfPapers = 185,
                PublishDate = new DateTime(2017, 11, 5),
                ImagePath = "/Assets/MistBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Ash",
                Description = "A gripping story of survival after fire.",
                Auther = "Jude West",
                NumOfPapers = 222,
                PublishDate = new DateTime(2019, 1, 30),
                ImagePath = "/Assets/AshBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Echo",
                Description = "A mysterious sound leads to a thrilling discovery.",
                Auther = "Lena Hart",
                NumOfPapers = 210,
                PublishDate = new DateTime(2020, 5, 12),
                ImagePath = "/Assets/EchoBook.jpeg"
            });

            books.Add(new BookDetails
            {
                Title = "Dust",
                Description = "A post-apocalyptic journey through a forgotten world.",
                Auther = "Riley Stone",
                NumOfPapers = 298,
                PublishDate = new DateTime(2018, 8, 23),
                ImagePath = "/Assets/DustBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Glow",
                Description = "A sci-fi adventure filled with light and shadows.",
                Auther = "Kai Moore",
                NumOfPapers = 340,
                PublishDate = new DateTime(2021, 3, 19),
                ImagePath = "/Assets/GlowBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Mist",
                Description = "A fantasy tale shrouded in fog and mystery.",
                Auther = "Nora Blake",
                NumOfPapers = 185,
                PublishDate = new DateTime(2017, 11, 5),
                ImagePath = "/Assets/MistBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Ash",
                Description = "A gripping story of survival after fire.",
                Auther = "Jude West",
                NumOfPapers = 222,
                PublishDate = new DateTime(2019, 1, 30),
                ImagePath = "/Assets/AshBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Echo",
                Description = "A mysterious sound leads to a thrilling discovery.",
                Auther = "Lena Hart",
                NumOfPapers = 210,
                PublishDate = new DateTime(2020, 5, 12),
                ImagePath = "/Assets/EchoBook.jpeg"
            });

            books.Add(new BookDetails
            {
                Title = "Dust",
                Description = "A post-apocalyptic journey through a forgotten world.",
                Auther = "Riley Stone",
                NumOfPapers = 298,
                PublishDate = new DateTime(2018, 8, 23),
                ImagePath = "/Assets/DustBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Glow",
                Description = "A sci-fi adventure filled with light and shadows.",
                Auther = "Kai Moore",
                NumOfPapers = 340,
                PublishDate = new DateTime(2021, 3, 19),
                ImagePath = "/Assets/GlowBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Mist",
                Description = "A fantasy tale shrouded in fog and mystery.",
                Auther = "Nora Blake",
                NumOfPapers = 185,
                PublishDate = new DateTime(2017, 11, 5),
                ImagePath = "/Assets/MistBook.jpg"
            });

            books.Add(new BookDetails
            {
                Title = "Ash",
                Description = "A gripping story of survival after fire.",
                Auther = "Jude West",
                NumOfPapers = 222,
                PublishDate = new DateTime(2019, 1, 30),
                ImagePath = "/Assets/AshBook.jpg"
            });

            #endregion

            BooksListView.ItemsSource = books;
            BooksListView.SelectedItem = books[0];
        }
    }
}
