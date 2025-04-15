using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDetailsViewer
{
    public class BookDetails
    {
        public string Title {  get; set; }
        public string Description { get; set; }
        public int NumOfPapers {  get; set; }
        public string Auther {  get; set; }
        public string ImagePath {  get; set; }
        public DateTime? PublishDate {  get; set; }
        public override string ToString()
        {
            return this.Title;
        }
    }
}
