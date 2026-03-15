using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ponyville_School
{
    public partial class form_Login : Form
    {
        public form_Login()
        {
            InitializeComponent();
            AppState.Supabase = new SupabaseClient();
        }

        private async void bt_Enter_Click(object sender, EventArgs e)
        {
            bt_Enter.Enabled = false;
            string login = box_Login.Text;
            string password = box_Password.Text;

            if (login == "" || password == "") //Проверка заполненности полей
            {
                MessageBox.Show("Ошибка авторизации, заполни недостающие поля");
                bt_Enter.Enabled = true;
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
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string folder = Path.Combine(appData, "Ponyville School");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string tokenPath = Path.Combine(folder, "session.dat");
                Guid token = Guid.NewGuid();
                string tokenGuid = token.ToString();
                File.WriteAllText(tokenPath, tokenGuid);
                await AppState.Supabase.CreateToken(token, AppState.CurrentUser.id);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            bt_Enter.Enabled = true;
        } //Вход

        private void password_show_MouseHover(object sender, EventArgs e)
        {
            password_show.BackgroundImage = Ponyville_School.Properties.Resources.Пароль;
            box_Password.PasswordChar = '\0';
        } //Показать пароль

        private void password_show_MouseLeave(object sender, EventArgs e)
        {
            password_show.BackgroundImage = Ponyville_School.Properties.Resources.Без_пароля;
            box_Password.PasswordChar = '*';
        } //Скрыть пароль

        private void bt_Reg_Click(object sender, EventArgs e)
        {
            panel_Registration.Visible = true;
        } //Переход на регистрацию

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            panel_Registration.Visible = false;
        } //Переход на авторизацию

        private async void bt_CreateUser_Click(object sender, EventArgs e)
        {
            bt_CreateUser.Enabled = false;
            string Login = box_RegLogin.Text, Name = box_RegName.Text, Pass = box_RegPass.Text, Pass2 = box_RegRPass.Text;

            if (Login == "" || Name == "" || Pass == "" || Pass2 == "") //Проверка заполненности
            {
                MessageBox.Show("Заполни все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                bt_CreateUser.Enabled = true;
                return;
            }
            if (Pass.Length <= 7) //Проверка длины пароля
            {
                MessageBox.Show("Пароль не может быть короче 8 символов!");
                bt_CreateUser.Enabled = true;
                return;
            }
            if (Pass != Pass2) //Проверка совпадения паролей
            {
                MessageBox.Show("Пароли не совпадают, проверь ещё раз");
                bt_CreateUser.Enabled = true;
                return;
            }
            if (RegCheck(Login)) //Недопустимые символы логина
            {
                MessageBox.Show("Твой логин содержит недопустимые символы");
                bt_CreateUser.Enabled = true;
                return;
            }
            if (RegCheck(Pass)) //Недопустимые символы пароля
            {
                MessageBox.Show("Твой пароль содержит недопустимые символы");
                bt_CreateUser.Enabled = true;
                return;
            }

            var result = await AppState.Supabase.RegisterUser(Login, Pass, Name);

            if (!result) //Неуспешная регистрация: Supabase вернул ошибку
            {
                MessageBox.Show("Произошла ошибка при регистрации");
                bt_CreateUser.Enabled = true;
                return;
            }

            MessageBox.Show("Аккаунт успешно создан! Добро пожаловать в школу Дружбы!");
            panel_Registration.Visible = false;
            bt_CreateUser.Enabled = true;
            //Отчистка полей окна регистрации
            box_RegLogin.Text = "";
            box_RegName.Text = "";
            box_RegPass.Text = "";
            box_RegRPass.Text = "";
            box_Login.Text = Login;
            box_Password.Text = Pass;
        } //Регистрация

        private bool RegCheck(string input)
        {
            return Regex.IsMatch(input, @"\p{Cs}");
        } //Проверка на недопустимые символы

        private async void form_Login_Load(object sender, EventArgs e)
        {
            string appData = 
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "Ponyville School");
            string tokenPath = Path.Combine(folder, "session.dat");
            if (File.Exists(tokenPath))
            {
                string token = File.ReadAllText(tokenPath);
                bool valid = await AppState.Supabase.CheckToken(token);
                if (valid)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        } //Проверка авторизации
    }
}