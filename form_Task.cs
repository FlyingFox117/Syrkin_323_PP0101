using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponyville_School
{
    public partial class form_Task : Form
    {
        private bool finished = false; //Ключ к выполнению задания
        private int SelectedTask = 0, result = 0; //id выбранного задания и подсчёт баллов
        Timer Wait = new Timer(); //Таймер
        List<Questions> questions; //Список вопросов на задание
        public form_Task(int ID)
        {
            InitializeComponent();
            this.Text = AppState.Tasks[ID].title; //Название формы в соответствии с заданием
            SelectedTask = ID; //Выбранное задание по ID
            Wait.Interval = 10000; //10 секунд ожидания для разблокировки задания
            Wait.Tick += Wait_Tick;
            Wait.Start();
        } //Инициализация класса
        private void Wait_Tick(object sender, EventArgs e)
        {
            bt_Continue.Enabled = true;
            Wait.Stop();
        } //Метод таймера для разблокировки задания

        private void form_Task_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Exit = MessageBox.Show("Ты точно хочешь прекратить выполнение этого задания? Ты сможешь вернуться и пройти позже", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Exit == DialogResult.Yes)
            {
                if (video_Theory.URL != "")
                {
                    video_Theory.Ctlcontrols.pause();
                    File.Delete(video_Theory.URL);
                }
                this.DialogResult = DialogResult.OK; //Возврат на форму выбора задания
            }
            else
                e.Cancel = true; //Отмена закрытия
        } //Закрытие формы задания

        private async void form_Task_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppState.Tasks[SelectedTask].text)) //Загрузка текста задания
            {
                box_Theory.Text = AppState.Tasks[SelectedTask].text;
                lb_TaskQuestion.Text = "Прочитай историю и выполни тестовую часть на следующей странице";
                box_Theory.Visible = true;
            }
            else if (!string.IsNullOrEmpty(AppState.Tasks[SelectedTask].video)) //Загрузка видео задания
            {
                lb_TaskQuestion.Text = "Просмотри видео и выполни тестовую часть на следующей странице";
                string video = await SetVideo(AppState.Tasks[SelectedTask].video);
                if (video != null)
                {
                    video_Theory.URL = video;
                }
                video_Theory.uiMode = "mini";
                video_Theory.Show();
                video_Theory.Ctlcontrols.play();
            }
        } //Загрузка теории

        private async Task<string> SetVideo(string url)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"lesson_{Guid.NewGuid()}.mp4");
            using (WebClient client = new WebClient())
            {
                try
                {
                    await client.DownloadFileTaskAsync(new Uri(url), tempFile); //Скачивание видео как временный файл
                    return tempFile;
                }
                catch
                {
                    MessageBox.Show("Ошибка загрузки видео для урока. Обратитесь к учителю", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        } //Метод подгрузки видео с облачного хранилища

        //Ниже - методы управления практической частью
        private async void bt_Continue_Click(object sender, EventArgs e)
        {
            DialogResult Continue = MessageBox.Show("Ты уверен, что хочешь начать выполнение задания? Вернуться к практике будет невозможно!", "Практика", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Continue == DialogResult.Yes)
            {
                bt_Continue.Enabled = false;
                questions = await AppState.Supabase.GetPracticeData(AppState.Tasks[SelectedTask].id); //Получение списка заданий и ответов из БД
                panel_Practice.Controls.Clear(); //Отчиска панели с заданиями
                int yOffset = 25; //Отступ от верхней границы
                int question_number = 0;
                foreach (var question in questions) //Перебор всех вопросов из списка
                {
                    question_number++;
                    Panel card = GenerateQuestionCard(question, question_number); //Генерация карточек
                    card.Location = new Point(10, yOffset); //Установка положения на форме
                    panel_Practice.Controls.Add(card); //Добавление карточки на панель
                    yOffset += card.Height + 10; //Увеличение отступа
                }
                Button finish = new Button
                {
                    Width = 211,
                    Height = 47,
                    AutoSize = false,
                    Text = "Завершить",
                    Location = new Point(620, yOffset),
                };
                finish.Click += Finish_Click;
                panel_Practice.Controls.Add(finish);
                panel_Practice.Show();
            }
        } //Переход к практике

        private void Finish_Click(object sender, EventArgs e)
        {
            if (finished != true) //Проверка, закончено ли задание или нет
            {
                Button finish = sender as Button;
                if (finish.Text != "Закончить задание")
                {
                    DialogResult Finish = MessageBox.Show("Завершить задание и узнать результат?", "Практика", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Finish == DialogResult.Yes)
                    {
                        result = CalculateScore();
                        int total = questions.Count();
                        if (result == total)
                            MessageBox.Show("Поздравляем! Все ответы верные!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (result >= total / 2)
                            MessageBox.Show($"Неплохо! Ты набрал {result} из {total}.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"Ты набрал {result} из {total}. Попробуйте пройти снова!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    AppState.Supabase.ResultSubmit(AppState.CurrentUser.id, AppState.Tasks[SelectedTask].id, result, AppState.SelectedCourse);
                    this.Close();
                    AppState.CurrentUser.available = false;
                    MessageBox.Show("Твой лимит задач на сегодня закончился! Возращайся завтра");
                }
            }
            else
            {
                this.Close(); //Закрытие формы
                //Отправка данных в Supabase
            }    
        } //Закончить тестовую часть

        private Panel GenerateQuestionCard(Questions question, int number)
        {
            try
            {
                Panel cardPanel = new Panel
                {
                    Width = 750,
                    Height = 150,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(15),
                    AutoSize = false,
                };

                // Текст вопроса
                Label lblQuestion = new Label
                {
                    Text = $"Вопрос №{number}: {question.text}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = false,
                    Width = cardPanel.Width - 20,
                    Height = 40
                };
                cardPanel.Controls.Add(lblQuestion);

                int radioY = 55;
                foreach (var answer in question.answers) //Генерация трёх ответов на вопрос
                {
                    RadioButton rb = new RadioButton
                    {
                        Text = answer.text,
                        Tag = answer.id,
                        Location = new Point(20, radioY),
                        Width = cardPanel.Width - 40,
                        AutoSize = true
                    };

                    radioY += 25;
                    cardPanel.Controls.Add(rb);
                }
                cardPanel.Tag = question; //Установка тегов под карты для проверки вопроса

                return cardPanel; //Созданная карта
            }
            catch
            {
                MessageBox.Show("Ошибка генерации данных");
                return null;
            }
        } //Генерация карточек с вопросами

        private int CalculateScore()
        {
            int score = 0; //Кол-во баллов

            foreach (Control control in panel_Practice.Controls) //Перебор всех элементов управления
            {
                if (control is Panel questionPanel && questionPanel.Tag is Questions question) //Проверка исключительно панелей вопросов
                {
                    foreach (Control child in questionPanel.Controls) //Перебор всех элементов управления карточки
                    {
                        if (child is RadioButton rb && rb.Checked) //Проверка исключительно выбранных пунктов
                        {
                            if (rb.Tag != null && rb.Tag.ToString() == question.correct_answer_id.ToString()) //Проверка правильности выбранного пункта
                            {
                                questionPanel.ForeColor = Color.Green;
                                score++;
                            }
                            else
                            {
                                questionPanel.ForeColor = Color.Red;
                            }
                            foreach (var ctrl in questionPanel.Controls)
                            {
                                if (ctrl is RadioButton r)
                                {
                                    r.Enabled = false; //Блокирование изменений
                                }
                            }
                            break;
                        }
                    }
                }
                if (control is Button finish) //Изменение кнопки завершить
                {
                    finish.Text = "Закончить задание";
                }
            }
            return score;
        } //Подсчёт результата
    }
}
