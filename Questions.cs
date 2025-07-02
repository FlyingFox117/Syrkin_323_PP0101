using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponyville_School
{
    /* Данные классы созданы для формирования карточек с заданиями с ответами
     Каждая карточка вопроса содержит массив ответов, состоящий из трёх объектов класса Answer*/
    public class Questions
    {
        public int id { get; set; } //id Вопроса
        public int task_id { get; set; } //id Задания
        public string text { get; set; } //Текст вопроса
        public int correct_answer_id { get; set; } //id Верного ответа
        public List<Answer> answers { get; set; } //Список ответов на вопрос
    }

    public class Answer
    {
        public int id { get; set; } //id ответа
        public int question_id { get; set; } //id Вопроса
        public string text { get; set; } //Текст ответа
    }
}
