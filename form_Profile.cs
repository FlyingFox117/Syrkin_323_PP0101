using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Ponyville_School
{
    public partial class form_Profile : Form
    {
        public form_Profile()
        {
            InitializeComponent();
        }

        private void form_Profile_Load(object sender, EventArgs e)
        {
            lb_Email.Text = "todandvixie@yandex.ru";
            lb_Name.Text = AppState.CurrentUser.name;
            lb_ID.Text = "ID: " + AppState.CurrentUser.id.ToString();
            int total = 0;
            foreach (CourseProgress course in AppState.CoursesProgress)
            {
                total = total + course.progress;
            }
            lb_Total.Text = "Общий прогресс: " + total;
            panel_Upper.BackColor = Color.FromArgb(242, 110, 48);
            LoadUserResults();
        } //Загрузка профиля
        private void form_Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK; //Возврат на форму выбора задания
            return;
        } //Закрытие формы
        private void bt_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        } //Назад
        private async void LoadUserResults()
        {
            var results = await AppState.Supabase.GetUserResults(AppState.CurrentUser.id);

            panel_Results.Controls.Clear();

            int y = 10;
            if (results == null)
            {
                return;
            }
            foreach (var res in results)
            {
                Panel card = new Panel();
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Size = new Size(panel_Results.Width - 30, 110);
                card.Location = new Point(10, y);
                card.BackColor = Color.White;
                //Текст результата
                Label lbl2 = new Label();
                lbl2.Text = $"{res.score}";
                lbl2.AutoSize = true;
                lbl2.Font = new Font("Georgia", 16, FontStyle.Bold);
                lbl2.BackColor = Color.White;
                lbl2.Location = new Point(45, 45);
                //Изображение курса
                PictureBox pb = new PictureBox();
                pb.Size = new Size(90, 90);
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.BackgroundImage = Ponyville_School.Properties.Resources.score_Applejack;
                pb.Location = new Point(10, 10);
                //Текст названия
                Label lbl1 = new Label();
                lbl1.Text = $"Уроки Честности\n" +
                           $"{res.name}\n" +
                           $"Дата: {res.passed_at}";
                lbl1.AutoSize = true;
                lbl1.Font = new Font("Georgia", 14, FontStyle.Regular);
                lbl1.Location = new Point(110, 10);

                card.Controls.Add(lbl1);
                card.Controls.Add(lbl2);
                card.Controls.Add(pb);
                panel_Results.Controls.Add(card);

                y += 120;
            }
        } //Генерация карточек
        private async void bt_Exit_Click(object sender, EventArgs e)
        {
            string appData =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "Ponyville School");
            string tokenPath = Path.Combine(folder, "session.dat");
            string token = File.ReadAllText(tokenPath);
            File.Delete(tokenPath);
            await AppState.Supabase.DeleteToken(token);
            Application.Exit();
        } //Выход из приложения
    }
}
