using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class BookTake
    {
        public int BookTakeId { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool? Returned { get; set; }
        public bool? Accepted { get; set; }

        public Book Book { get; set; }
        public Reader Reader { get; set; }
    }
}
