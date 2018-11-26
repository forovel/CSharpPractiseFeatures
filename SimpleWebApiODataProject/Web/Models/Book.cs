using System.Collections.Generic;

namespace Web.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public ICollection<BookChapter> Chapters { get; set; }

        public Book()
        {
            Chapters = new List<BookChapter>();
        }
    }
}
