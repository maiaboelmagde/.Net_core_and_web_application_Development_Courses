namespace TaskSolution
{
    public delegate string BookFunction(Book b); 

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate,decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;

        }

        public override string ToString()
        {
            return $"Title: {Title}, ISBN: {ISBN}, Authors: {string.Join(", ", Authors)}, " +
               $"Publication Date: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
        }
    }

    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return $"{B.Title}";
        }

        public static string GetAuthors(Book B)
        {
            return $"Authors: {string.Join(", ", B.Authors)}";

        }

        public static string GetPrice(Book B)
        {
            return $"{B.Price}";
        }
    }
    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList,/*Pointer To BookFunciton*/ BookFunction fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    } 
        
internal class Program
    {
        static void Main()
        {
            List<Book> books = new List<Book>
        {
            new Book("123456", "BOOK1", new string[] { "AUTHOR" }, new DateTime(2019, 3, 23), 45.99m),
            new Book("789101", "BOOK2", new string[] { "AUTHOR1", "AUTHOR2" }, new DateTime(1999, 10, 30), 39.99m)
        };


            LibraryEngine.ProcessBooks(books, BookFunctions.GetTitle);

            Func<Book, string> getAuthors = BookFunctions.GetAuthors;
            foreach (var book in books)
            {
                Console.WriteLine(getAuthors(book));
            }

            BookFunction getISBN = delegate (Book b)
            {
                return b.ISBN;
            };

            LibraryEngine.ProcessBooks(books, getISBN);

            Func<Book, string> getPublicationDate = b => b.PublicationDate.ToShortDateString();

            foreach (var book in books)
            {
                Console.WriteLine(getPublicationDate(book));
            }
        }
    }
}
