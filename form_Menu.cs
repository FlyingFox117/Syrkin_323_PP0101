using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ponyville_School
{
    public partial class form_Menu : Form
    {
        private int currentIndex = 0; //Индекс выбранного задания
        public form_Menu()
        {
            InitializeComponent();
        }
        private void form_Menu_Load(object sender, EventArgs e)
        {
            PictureBox[] courseButtons = new PictureBox[] {
                bt_Honesty, bt_Generosity, bt_Loyalty, bt_Kindness, bt_Laughter, bt_Magic }; //Массив кнопок

            string[] courseTags = new string[] {
                "honesty", "generosity", "loyalty", "kindness", "laughter", "magic"}; //Массив имен курсов

            for (int i = 0; i < courseButtons.Length; i++)
            {
                courseButtons[i].Tag = courseTags[i]; //Определение курса, на который наведена мышь
                courseButtons[i].MouseEnter += CourseButton_MouseEnter;
                courseButtons[i].MouseLeave += CourseButton_MouseLeave;
                courseButtons[i].Click += CourseButton_Click;
            }
            if (AppState.CurrentUser.available)
            {
                MessageBox.Show("Тебе доступно новое задание на сегодня!");
            }
            else
            {
                MessageBox.Show("Лимит задач на сегодня исчерпан. Приходи завтра!");
            }
        }
        private string GetCourseDescription(string course) //Метод поиска описания курса по имени
        {
            switch (course)
            {
                case "honesty": return "Честность — умение быть правдивым, как Эпплджек...";
                case "kindness": return "Доброта — помогать и заботиться о других, как Флаттершай...";
                case "loyalty": return "Верность — быть рядом с друзьями в трудную минуту, как Радуга...";
                case "generosity": return "Щедрость — делиться лучшим с другими, как Рарити...";
                case "laughter": return "Радость — находить позитив в любом дне, как Пинки Пай...";
                case "magic": return "Гармония — соединение всех элементов в одно целое.";
                default: return "";
            }
        }
        private void CourseButton_MouseEnter(object sender, EventArgs e) //Метод отображения описания курса
        {
            PictureBox selected = sender as PictureBox;
            string course = selected.Tag.ToString();

            selected.Width = 275;
            selected.Height = 172;
            lbl_Description.Text = GetCourseDescription(course);
            panel_Course.Visible = true;
            panel_Course.BringToFront();
            panel_Course.Location = new Point(selected.Location.X - 5, selected.Bottom + 5);
        }
        private async void CourseButton_Click(object sender, EventArgs e) //Переход к курсу
        {
            PictureBox selected = sender as PictureBox;
            string course = selected.Tag.ToString();
            if (!AppState.CurrentUser.available)
            {
                MessageBox.Show("У тебя кончился лимит заданий на сегодня");
                return;
            }
            bool GetTasks = await AppState.Supabase.GetCourseData(course, AppState.CurrentUser.id); //Обращение к методу класса SupabaseClient

            if (GetTasks)
            {
                if (AppState.CurrentUser.CourseProgress >= AppState.Tasks.Count()) //Проверка на завершенность курса
                {
                    MessageBox.Show("Ты закончил все задания этого курса!");
                }
                else
                    MessageBox.Show(AppState.Tasks[0].title + " твоё доступное задание на сегодня");
                panel_Carousel.Visible = true;
                AppState.SelectedCourse = course;
                ShowTask();
            }
            else
                MessageBox.Show("В этом курсе пока нет заданий");
        }
        private void CourseButton_MouseLeave(object sender, EventArgs e) //Метод скрытия описания курса
        {
            PictureBox selected = sender as PictureBox;
            selected.Width = 270;
            selected.Height = 167;
            panel_Course.Visible = false;
        }

        //Ниже - методы окна выбора заданий
        private void bt_Right_Click(object sender, EventArgs e)
        {
            currentIndex++;
            if (currentIndex >= AppState.Tasks.Count())
            {
                currentIndex = 0;
            }
            ShowTask();
        } //Перелистывание задания вправо

        private void bt_Left_Click(object sender, EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = AppState.Tasks.Count() - 1;
            }
            ShowTask();
        } //Перелистывание задания влево

        private void bt_Start_Click(object sender, EventArgs e)
        {
            form_Task Task = new form_Task(currentIndex);
            this.Hide();
            if (Task.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        } //Запуск теории

        private void ShowTask()
        {
            if (AppState.Tasks == null) //Если заданий нет
            {
                return;
            }
            if (currentIndex < 0 || currentIndex >= AppState.Tasks.Count()) //Проверка исключения несуществующего номера задания
            {
                return;
            }

            var currentTask = AppState.Tasks[currentIndex];
            lb_TaskName.Text = currentTask.title; //Установка названия задания
            LoadImage(pb_Task, currentTask.image_url); //Загрузка изображения по ссылке
            if (AppState.CurrentUser.available) //Если пользователь может выполнять задачи, делаем доступной кнопку
            {
                bt_Start.Enabled = currentTask.available; //Активация кнопки старт, если задание доступно
                if (bt_Start.Enabled)
                {
                    bt_Start.Text = "Начать"; //Если прогресс позволяет
                }
                else
                    bt_Start.Text = "Закончи предыдущее задание"; //Подсказка
            }
        } //Отображение задания

        private async void LoadImage(PictureBox box, string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var data = await client.GetByteArrayAsync(url);
                    using (var stream = new MemoryStream(data))
                    {
                        box.Image = Image.FromStream(stream);
                    }
                }
            }
            catch
            {
                box.Image = null; //Отсутствие изображения
            }
        } //Загрузка превью задания

        private void bt_ReturnToMenu_Click(object sender, EventArgs e)
        {
            panel_Carousel.Hide();
            AppState.Tasks = null;
            pb_Task.Image = null;
            AppState.CurrentUser.CourseProgress = 0;
            currentIndex = 0;
        } //Возврат к выбору курсов
    }
}
