using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryWorkerApp
{
    public partial class LibraryEdit : Form
    {
        LibraryBase library = new LibraryBase();
        public LibraryEdit()
        {
            InitializeComponent();
            ShowAuthors();
            ShowBooks();
            ShowGenres();
            ShowRequests();
        }

        // Обновить авторов
        private void ShowAuthors()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox5.Items.Clear();
            // Заполняем авторов
            List<Authors> authors = library.Authors.ToList();
            foreach (Authors author in authors)
            {
                comboBox1.Items.Add(author.Name);
                comboBox2.Items.Add(author.Name);
                comboBox5.Items.Add(author.Name);
            }
        }

        // Обновить жанры
        private void ShowGenres()
        {
            comboBox4.Items.Clear();
            comboBox3.Items.Clear();
            List<Genres> genres = library.Genres.ToList();
            foreach (Genres genre in genres)
            {
                comboBox3.Items.Add(genre.Title);
                comboBox4.Items.Add(genre.Title);
            }
        }

        // Отобразить книги
        private void ShowBooks()
        {
            // Очищаем список книг
            listView1.Items.Clear();

            string author = comboBox1.Text;
            string title = textBox1.Text;

            // Ищем книги по указанным фильтрам
            IQueryable<Books> books = library.Books.Where(book => book.Authors.Name.Contains(author) && book.BookName.Contains(title));
            // Заполняем список книг
            foreach (Books book in books)
            {
                string status;
                if (book.Exist) status = "Есть";
                else status = "Нет";
                listView1.Items.Add(new ListViewItem(new string[] { book.BookId.ToString(), library.Authors.Find(book.AuthorId).Name, book.BookName, status }));
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            ShowBooks();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ShowBooks();
        }

        // Выбор книги для редактирования
        int selectedBookId = -1; // Переменная, где хранится id выбранной книги для редактирования
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если не выбрана ни одна книга, то ничего не делать
            if (listView1.SelectedItems.Count == 0) return;

            // Определяем код выбранной книги
            int id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            selectedBookId = id;
            // Находим выбранную книгу в базе
            Books book = library.Books.Find(id);

            // Заполняем поля в поле редактирования книги
            comboBox2.Text = library.Authors.Find(book.AuthorId).Name;
            textBox2.Text = book.BookName;
            comboBox3.Text = library.Genres.Find(book.GenreId).Title;
            numericUpDown1.Value = book.Year;
            numericUpDown2.Value = book.PagesCount;
            richTextBox1.Text = book.Description;
        }

        // Редактирование книги
        private void button1_Click(object sender, EventArgs e)
        {
            if(selectedBookId == -1)
            {
                MessageBox.Show("Книга не выбрана");
                return;
            }
            
            string author = comboBox2.Text;
            string name = textBox2.Text;
            string genre = comboBox3.Text;
            int year = Convert.ToInt32( numericUpDown1.Value );
            int pages = Convert.ToInt32( numericUpDown2.Value );
            string description = richTextBox1.Text;
            int id = Convert.ToInt32(selectedBookId);

            // Если указанный автор не существует, вывести ошибку
            if(library.Authors.Where(a => a.Name == author).Count() == 0)
            {
                MessageBox.Show("Указанный автор не найден");
                return;
            }

            // Если указанный жанр не существует, вывести ошибку
            if(library.Genres.Where(g => g.Title == genre).Count() == 0)
            {
                MessageBox.Show("Указанный жанр не найден");
                return;
            }

            // Если название или описание пусто, вывести ошибку
            if(name == "" || description == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            // Находим редактируемую книгу в базе
            Books book = library.Books.Find(id);
            book.BookName = name;
            book.Description = description;
            book.Year = year;
            book.PagesCount = pages;
            book.AuthorId = library.Authors.Where(a => a.Name == author).First().AuthorId;
            book.GenreId = library.Genres.Where(a => a.Title == genre).First().GenreId;
            // Сохраняю изменения
            library.SaveChanges();

            MessageBox.Show("Книга успешно обновлена!");
            ShowBooks();
        }

        // Добавление книги
        private void button2_Click(object sender, EventArgs e)
        {
            string author = comboBox5.Text;
            string name = textBox3.Text;
            string genre = comboBox4.Text;
            int year = Convert.ToInt32(numericUpDown4.Value);
            int pages = Convert.ToInt32(numericUpDown3.Value);
            string description = richTextBox2.Text;

            // Если указанный автор не существует, вывести ошибку
            if (library.Authors.Where(a => a.Name == author).Count() == 0)
            {
                MessageBox.Show("Указанный автор не найден");
                return;
            }

            // Если указанный жанр не существует, вывести ошибку
            if (library.Genres.Where(g => g.Title == genre).Count() == 0)
            {
                MessageBox.Show("Указанный жанр не найден");
                return;
            }

            // Если название или описание пусто, вывести ошибку
            if (name == "" || description == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            // Создаем новую книгу
            Books book = new Books();
            book.BookName = name;
            book.Description = description;
            book.Year = year;
            book.PagesCount = pages;
            book.AuthorId = library.Authors.Where(a => a.Name == author).First().AuthorId;
            book.GenreId = library.Genres.Where(a => a.Title == genre).First().GenreId;
            book.Exist = true;

            // Добавялем книгу и сохраняем базу
            library.Books.Add(book);
            library.SaveChanges();

            MessageBox.Show("Книга добавлена!");

            // Очищаем поля
            comboBox5.Text = "";
            textBox3.Text = "";
            comboBox4.Text = "";
            numericUpDown4.Value = 0;
            numericUpDown3.Value = 1; ;
            richTextBox2.Text = "";

            // Обновляем список книг
            ShowBooks();
        }

        // Добавление автора
        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text;
            int born = Convert.ToInt32( numericUpDown6.Value );
            int died = Convert.ToInt32(numericUpDown5.Value);
            string description = richTextBox3.Text;

            // Если название или описание пусто, вывести ошибку
            if (name == "" || description == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            // Если такой автор существует, вывести ошибку
            if(library.Authors.Where(a => a.Name == name).Count() != 0)
            {
                MessageBox.Show("Автор с таким именем уже существует!");
                return;
            }

            // Создаем нового автора
            Authors author = new Authors();
            author.Name = name;
            author.Description = description;
            author.BornYear = born;
            author.DiedYear = died;

            // Добавляем автора в базу и сохраняем
            library.Authors.Add(author);
            library.SaveChanges();

            MessageBox.Show("Автор успешно добавлен!");

            textBox4.Text = "";
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            richTextBox3.Text = "";

            ShowAuthors();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        // Добавление жанра
        private void button4_Click(object sender, EventArgs e)
        {
            string title = textBox5.Text;

            // Если название пусто, вывести ошибку
            if(title == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            // Если такой жанр уже есть, вывести ошибку
            if(library.Genres.Where(a => a.Title == title).Count() != 0)
            {
                MessageBox.Show("Такой жанр уже существует!");
                return;
            }

            // Создаем новый жанр
            Genres genre = new Genres();
            genre.Title = title;

            // Добавляем жанр в базу и сохраняем
            library.Genres.Add(genre);
            library.SaveChanges();

            MessageBox.Show("Жанр успешно добавлен!");

            // Очищаем поля
            textBox5.Text = "";

            // Обновляем жанры
            ShowGenres();
        }

        // Отобразить запросы на книги
        private void ShowRequests()
        {
            listView2.Items.Clear();

            List<BookTakes> bookTakes = new List<BookTakes>();

            // Если фильтр не выбран, то отобразить все запросы
            if (comboBox6.Text == "")
                bookTakes = library.BookTakes.ToList();
            // Новые - это запросы, у которых не заполнено поле Accepted
            if (comboBox6.Text == "Новые")
                bookTakes = library.BookTakes.Where(take => take.Accepted.HasValue == false).ToList();
            // Одобренные - это запросы, у которых Accepted = true
            if (comboBox6.Text == "Одобренные")
                bookTakes = library.BookTakes.Where(take => take.Accepted.Value == true && take.Returned.Value == false).ToList();
            // Просроченные - это запросы, у которых Accepted = true, а дата возврата меньше текущей даты
            if (comboBox6.Text == "Просроченные")
                bookTakes = library.BookTakes.Where(take => take.Returned.Value == false && take.ReturnDate < DateTime.Now).ToList();
            // Закрытые - это запросы, у которых Returned = true
            if (comboBox6.Text == "Закрытые")
                bookTakes = library.BookTakes.Where(take => take.Returned.Value == true).ToList();

            if (bookTakes.Count == 0) return;

            foreach (BookTakes take in bookTakes)
            {
                string status = "Отклонена";
                if (take.Accepted.HasValue == false) status = "Новая";
                if (take.Accepted.HasValue && take.Accepted.Value == true) status = "Одобренная";
                if (take.Returned.HasValue && take.Returned.Value == false && take.ReturnDate < DateTime.Now) status = "Просроченная";
                if (take.Returned.HasValue && take.Returned.Value == true) status = "Закрытая";
                listView2.Items.Add(new ListViewItem(new string[] { take.BookTakeId.ToString(), take.ReaderId.ToString(), library.Books.Find(take.BookId).BookName, status }));
            }

            selectedBookId = -1;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowRequests();
        }

        // Выбор запроса в списке
        int selectedRequestId;
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если не выбран ни один запрос, то ничего не делать
            if (listView2.SelectedItems.Count == 0) return;

            // Определяем код выбранного запроса
            int id = Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text);
            selectedRequestId = id;

            BookTakes take = library.BookTakes.Find(id);
            string name = library.Readers.Find(take.ReaderId).Name;
            string contact = library.Readers.Find(take.ReaderId).Contact;
            string title = library.Books.Find(take.BookId).BookName;
            string dateTake = take.TakeDate.ToString("dd.MM.yy");
            string returnDate = take.ReturnDate.ToString("dd.MM.yy");
            string exist = "Нет в наличии";
            string status = (listView2.SelectedItems[0].SubItems[3].Text);
            if (library.Books.Find(take.BookId).Exist == true)
                exist = "Есть в наличии";

            label22.Text = $"Имя: {name}\n Контакт: {contact}\n Книга: {title}\n Взята: {dateTake}\n Возврат: {returnDate}\n{exist}";

            button7.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = false;

            if(status == "Новая")
            {
                button7.Enabled = true;
                button6.Enabled = true;
            }

            if (exist == "Нет в наличии")
                button6.Enabled = false;

            if (status == "Одобренная" || status == "Просроченная")
                button5.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BookTakes take = library.BookTakes.Find(selectedRequestId);
            take.Accepted = false;

            library.SaveChanges();

            ShowRequests();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BookTakes take = library.BookTakes.Find(selectedRequestId);
            Books book = library.Books.Find(take.BookId);

            take.Accepted = true;
            take.Returned = false;

            book.Exist = false;

            library.SaveChanges();

            ShowRequests();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BookTakes take = library.BookTakes.Find(selectedRequestId);
            Books book = library.Books.Find(take.BookId);

            take.Returned = true;

            book.Exist = true;

            library.SaveChanges();

            ShowRequests();
        }
    }
}
