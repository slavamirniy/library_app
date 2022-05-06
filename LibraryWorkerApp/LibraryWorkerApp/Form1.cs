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
    public partial class Form1 : Form
    {
        LibraryBase library = new LibraryBase();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            // Ищем пользователя с таким же логином и паролем
            IQueryable<Workers> workers = library.Workers.Where(worker => worker.Login == login && worker.Password == password);
            // Если ничего не найдено, то сообщить об ошибке и выйти
            if (workers.Count() == 0)
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }
            MessageBox.Show("Успешная авторизация");

            string role = workers.First().Role;

            if(role == "Библиотекарь")
            {
                // При успешной авторизации создать новую форму библиотекаря
                LibraryEdit form = new LibraryEdit();
                this.Hide();
                // Чтобы форма авторизации закрылась после закрытия формы библиотекаря
                form.FormClosed += (s, a) => this.Close();
                form.Show();
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
