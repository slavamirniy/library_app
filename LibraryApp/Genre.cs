using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Title { get; set; }

        public List<Book> Books { get; set; }
    }
}
