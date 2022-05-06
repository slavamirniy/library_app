using System;
using System.Data.Entity;
using System.Linq;

namespace LibraryApp
{
    public class LibraryBase : DbContext
    {
        public LibraryBase()
            : base("name=LibraryBase")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<BookTake> BookTakes { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}