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
    public partial class Login : Form
    {
        LibraryBase library = new LibraryBase();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        // Вход
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            // Ищем пользователя с таким же логином и паролем
            IQueryable<Reader> readers = library.Readers.Where(reader => reader.Login == login && reader.Password == password);
            // Если ничего не найдено, то сообщить об ошибке и выйти
            if(readers.Count() == 0)
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }
            MessageBox.Show("Успешная авторизация");
            // При успешной авторизации создать новую форму читателя
            ReaderForm form = new ReaderForm(readers.First());
            this.Hide();
            // Чтобы форма авторизации закрылась после закрытия формы читателя
            form.FormClosed += (s, a) => this.Close();
            form.Show();
        }

        // Регистрация
        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox4.Text;
            string password = textBox3.Text;
            string name = textBox5.Text;
            string contact = textBox6.Text;

            // Проверка введенных данных
            if(login.Length < 6)
            {
                MessageBox.Show("Логин должен быть больше 5 символов!");
                return;
            }

            if(password.Length < 6)
            {
                MessageBox.Show("Пароль должен быть больше 5 символов!");
                return;
            }

            if(name.Length < 4)
            {
                MessageBox.Show("Имя должно быть больше 3 символов!");
                return;
            }

            if(contact.Length < 6)
            {
                MessageBox.Show("Контакт должен быть больше 5 символов!");
                return;
            }

            // Поиск пользователя с таким же логином
            if(library.Readers.Where(reader => reader.Login == login).Count() != 0)
            {
                MessageBox.Show("Этот логин уже занят!");
                return;
            }

            // Создание нового читателя
            Reader newReader = new Reader();
            newReader.Name = name;
            newReader.Contact = contact;
            newReader.Login = login;
            newReader.Password = password;

            // Добавление нового читателя в базу и сохранение
            library.Readers.Add(newReader);
            library.SaveChanges();

            MessageBox.Show("Вы успешно зарегистрированы!");
            // При успешной регистрации создать новую форму читателя
            ReaderForm form = new ReaderForm(newReader);
            this.Hide();
            // Чтобы форма авторизации закрылась после закрытия формы читателя
            form.FormClosed += (s, a) => this.Close();
            form.Show();
        }
    }
}
