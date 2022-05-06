using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int PagesCount { get; set; }
        public bool Exist { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
