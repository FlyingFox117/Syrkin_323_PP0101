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
using AutoUpdaterDotNET;
using System.Security.Principal;
using System.Configuration;
using System.Web.Configuration;

namespace Ponyville_School
{
    public partial class form_Menu : Form
    {
        private int currentIndex = 0; //Индекс выбранного задания
        public form_Menu()
        {
            InitializeComponent();
        }
        private async void form_Menu_Load(object sender, EventArgs e)
        {
            if ( await LoadUserProgress()) //Ожидание ответа от Supabase
            {
                PictureBox[] courseButtons = new PictureBox[] {
                bt_Honesty, bt_Generosity, bt_Loyalty, bt_Kindness, bt_Laughter, bt_Magic }; //Массив кнопок

                int[] courseTags = new int[] {
                0, 1, 2, 3, 4, 5}; //Массив ID курсов

                for (int i = 0; i < courseButtons.Length; i++)
                {
                    courseButtons[i].Tag = courseTags[i]; //Определение курса, на который наведена мышь
                    courseButtons[i].Click += CourseButton_Click; //Метод выбора
                    courseButtons[i].MouseEnter += CourseButton_MouseEnter; //Подсветка прогресса
                    courseButtons[i].MouseLeave += CourseButton_MouseLeave; //Скрытие прогресса
                }
            }
            panel_Upper.BackColor = Color.FromArgb(212, 162, 233);
            bt_Profile.BackColor = Color.FromArgb(212, 162, 233);
            CheckForUpdates();
            MessageBox.Show("Обновлений нет");
        }
        private async Task<bool> LoadUserProgress()
        {
            bool GetTasks = await AppState.Supabase.GetUserProgress(AppState.CurrentUser.id);
            if (!GetTasks)
            {
                return false;
            }
            if ((bool)AppState.CurrentUser.available)
            {
                label_Message.Text = "Тебе доступно новое задание на сегодня, " + AppState.CurrentUser.name + "!";
                return true;
            }
            else
            {
                label_Message.Text = "Ты выполнил все доступные задания сегодня. Приходи завтра!";
                return true;
            }
        } //Подгрузка прогресса пользователя, берётся из Supabase
        private string GetCourseDescription(int course) //Показать прогресс выбранного курса
        {
            if (AppState.CoursesProgress[course].task_count == 0)
            {
                return "Пока тут пусто";
            }
            double progress = ((double)AppState.CoursesProgress[course].progress / (double)AppState.CoursesProgress[course].task_count) * 100;
            return "Выполнено: " + progress + "%";
        }
        private void GetCourseData(int course)
        {
            switch (course)
            {
                case 0:
                    label_CourseName.Text = "Уроки Честности";
                    label_CourseDescription.Text = "Честность — умение быть правдивым, как Эпплджек...";
                    picture_Character.Image = Ponyville_School.Properties.Resources.applejack_course;
                    panel_Course.BackColor = Color.FromArgb(242, 110, 48);
                    break;
                case 1:
                    label_CourseName.Text = "Основы Щедрости";
                    label_CourseDescription.Text = "Щедрость — делиться лучшим с другими, как Рарити...";
                    picture_Character.Image = Ponyville_School.Properties.Resources.rarity_course;
                    panel_Course.BackColor = Color.FromArgb(88,34, 121);
                    break;
                case 2:
                    label_CourseName.Text = "Устав Верности";
                    label_CourseDescription.Text = "Верность — быть рядом с друзьями в трудную минуту, как Радуга...";
                    picture_Character.Image = Ponyville_School.Properties.Resources.rainbow_course;
                    panel_Course.BackColor = Color.FromArgb(37, 164, 247);
                    break;
                case 3:
                    label_CourseName.Text = "Курс Доброты";
                    label_CourseDescription.Text = "Доброта — помогать и заботиться о других, как Флаттершай...";
                    picture_Character.Image = Ponyville_School.Properties.Resources.fluttershy_course;
                    panel_Course.BackColor = Color.FromArgb(240, 128, 175);
                    break;
                case 4:
                    label_CourseName.Text = "Праздник Радости";
                    label_CourseDescription.Text = "Радость — находить позитив в любом дне, как Пинки Пай...";
                    picture_Character.Image = Ponyville_School.Properties.Resources.pinkie_course;
                    panel_Course.BackColor = Color.FromArgb(237, 69, 141);
                    break;
                case 5:
                    label_CourseName.Text = "Книга Гармонии";
                    label_CourseDescription.Text = "Гармония — соединение всех элементов в одно целое.";
                    picture_Character.Image = Ponyville_School.Properties.Resources.twilight_course;
                    panel_Course.BackColor = Color.FromArgb(167, 107, 194);
                    break;
                default:
                    label_CourseName.Text = "Пусто!";
                    label_CourseDescription.Text = "Это что, курс ничего что-ли?";
                    break;
            }
        } //Подстановка описания и изображения, берётся из локальных ресурсов
        private void CourseButton_MouseEnter(object sender, EventArgs e) //Метод отображения прогресса курса
        {
            PictureBox selected = sender as PictureBox;
            int course = (int)selected.Tag;

            selected.Width = 225;
            selected.Height = 135;
            label_Progress.Text = GetCourseDescription(course);
            panel_Course.Visible = true;
            panel_Course.BringToFront();
            panel_Course.Location = new Point(selected.Location.X + 23, selected.Bottom - 30);
        }
        private void CourseButton_Click(object sender, EventArgs e) //Показ информации и кнопки "Начать"
        {
            PictureBox selected = sender as PictureBox;
            if (AppState.SelectedCourse == (int)selected.Tag + 1)
            {
                bt_CourseStart_Click(sender, e);
                return;
            }
            int course = (int)selected.Tag;
            AppState.SelectedCourse = course + 1;
            GetCourseData(course);
        }
        private void CourseButton_MouseLeave(object sender, EventArgs e) //Метод скрытия описания курса
        {
            PictureBox selected = sender as PictureBox;
            selected.Width = 220;
            selected.Height = 130;
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
        private async void bt_Start_Click(object sender, EventArgs e)
        {
            form_Task Task = new form_Task(currentIndex);
            this.Hide();
            if (Task.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                await LoadUserProgress(); //Обновление статуса задач и прогресса
                EnableTask();
            }
        } //Запуск выбранного задания
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
            lb_Description.Text = currentTask.description; //Установка описания задания
            LoadImage(pb_Task, currentTask.image_url); //Загрузка изображения по ссылке
            EnableTask();
        } //Отображение задания
        private void EnableTask()
        {
            bt_Start.Enabled = false;
            ShowTaskScore(AppState.SelectedCourse, currentIndex);
            if ((bool)AppState.CurrentUser.available) //Если пользователь может выполнять задачи, делаем доступной кнопку
            {
                bt_Start.Enabled = AppState.Tasks[currentIndex].available; //Активация кнопки старт, если задание доступно
                if (bt_Start.Enabled)
                {
                    if (AppState.Tasks[currentIndex].result > 0)
                    {
                        bt_Start.Text = "Перепройти"; //Если прогресс позволяет
                    }
                    else
                        bt_Start.Text = "Начать"; //Если задание пройдено ранее
                }
                else
                    bt_Start.Text = "Закончи предыдущее задание"; //Подсказка
            }
        } //Обновление статуса задания
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
            currentIndex = 0;
            bt_CourseStart.Text = "Открыть задания";
        } //Возврат к выбору курсов
        private async void bt_CourseStart_Click(object sender, EventArgs e)
        {
            if (AppState.Tasks == null)
            {
                bt_CourseStart.Enabled = false;
                bool Available = await AppState.Supabase.GetCourseData(AppState.SelectedCourse, AppState.CurrentUser.id); //Ожидание подгрузки информации
                if (!Available)
                {
                    MessageBox.Show("Не удалось загрузить задания!"); //Если не удалось загрузить
                    bt_CourseStart.Enabled = true;
                    return;
                }
                int selected = AppState.SelectedCourse - 1; //Выбранный курс (-1 для поиска по id)
                int userProgress = AppState.CoursesProgress[selected].progress; //Получение прогресса пользователя

                foreach (var task in AppState.Tasks)
                {
                    task.available = (task.order <= userProgress + 1); //Проверка доступности задания
                }
                panel_Carousel.Visible = true;
                bt_CourseStart.Text = "Назад";
                ShowTask();
            }
            else
                bt_ReturnToMenu_Click(sender, e);
            bt_CourseStart.Enabled = true;
        } //Отобразить задания курса
        private void bt_Profile_Click(object sender, EventArgs e)
        {
            form_Profile Profile = new form_Profile();
            this.Hide();
            if (Profile.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        } //Открытие профиля
        private void ShowTaskScore(int course, int id)
        {
            switch (course)
            {
                case 1: pb_Score.BackgroundImage = Ponyville_School.Properties.Resources.score_Applejack;
                    break;
                case 2: pb_Score.BackgroundImage = Ponyville_School.Properties.Resources.score_Rarity;
                        break;
                default:
                    break;
            }
            string score = AppState.Tasks[currentIndex].result.ToString();
            lb_Score.Text = score;
            if (score == "")
            {
                lb_Score.Text = "0";
            }            
        } //Показ результата задания
        private void CheckForUpdates()
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/FlyingFox117/Syrkin_323_PP0101/master/update.xml");
        }
    }
}
