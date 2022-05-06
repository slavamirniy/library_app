namespace LibraryWorkerApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            BookTakes = new HashSet<BookTakes>();
        }

        [Key]
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        public string BookName { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public int PagesCount { get; set; }

        public int GenreId { get; set; }

        public bool Exist { get; set; }

        public virtual Authors Authors { get; set; }

        public virtual Genres Genres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookTakes> BookTakes { get; set; }
    }
}
