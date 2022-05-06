using LibraryApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class BookElement : UserControl
    {
        LibraryBase library = new LibraryBase();
        Book Book;
        public BookElement(Book book)
        {
            InitializeComponent();

            bookName.Text = book.BookName;
            string[] names = library.Authors.Find(book.AuthorId).Name.Split(' ');
            if (names.Length >= 3)
            {
                authorF.Text = names[2];
                authorNO.Text = names[0] + " " + names[1];
            }
            else
            {
                authorF.Text = names[0];
            }

            string title = library.Genres.Find(book.GenreId).Title;
            if (title == "Классика")
                bookImage.Image = Resources._2022_02_15_22_48_53;
            if (title == "Фантастика")
                bookImage.Image = Resources._2022_02_15_23_02_48;
            if (title == "Философия")
                bookImage.Image = Resources._2022_02_15_23_03_41;
            if (title == "Поэзия")
                bookImage.Image = Resources._2022_02_15_23_04_18;

            Book = book;
        }

        private void BookElement_Click(object sender, EventArgs e)
        {
            TakeBookForm form = new TakeBookForm(Book);
            form.ShowDialog();
        }
    }
}
