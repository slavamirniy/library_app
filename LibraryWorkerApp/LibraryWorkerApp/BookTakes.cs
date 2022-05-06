namespace LibraryWorkerApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookTakes
    {
        [Key]
        public int BookTakeId { get; set; }

        public int BookId { get; set; }

        public int ReaderId { get; set; }

        public DateTime TakeDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool? Returned { get; set; }

        public bool? Accepted { get; set; }

        public virtual Books Books { get; set; }

        public virtual Readers Readers { get; set; }
    }
}
