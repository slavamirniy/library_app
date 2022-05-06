using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BornYear { get; set; }
        public int DiedYear { get; set; }

        public List<Book> Books { get; set; }
    }
}
