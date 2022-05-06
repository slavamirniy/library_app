using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LibraryWorkerApp
{
    public partial class LibraryBase : DbContext
    {
        public LibraryBase()
            : base("name=LibraryBase")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BookTakes> BookTakes { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Readers> Readers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
