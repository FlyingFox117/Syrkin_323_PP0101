using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponyville_School
{
    public partial class form_Login : Form
    {
        public form_Login()
        {
            InitializeComponent();
            AppState.Supabase = new SupabaseClient();
        }

        private async void bt_Enter_ClickAsync(object sender, EventArgs e)
        {
            bt_Enter.Enabled = false;
            string login = box_Login.Text;
            string password = box_Password.Text;

            if (login == "" || password == "") //Проверка заполненности полей
            {
                MessageBox.Show("Ошибка авторизации, заполни недостающие поля");
                return;
            }

            bool loginSuccess = await AppState.Supabase.AuthenticateUser(login, password); //Обращение к методу класса SupabaseClient

            if (loginSuccess)
            {
                if (AppState.CurrentUser.role == "admin")
                {
                    MessageBox.Show("Добро пожаловать в программу! Вы теперь администратор!");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Добро пожаловать в школу, " + AppState.CurrentUser.name);
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            bt_Enter.Enabled = true;
        }
    }
}