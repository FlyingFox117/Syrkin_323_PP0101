using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponyville_School
{
    /*Модель для хранения данных о всех курсах,
    доступных в программе*/
    public class CourseProgress
    {
        public int course_id { get; set; } //id Курса
        public string title { get; set; } //Название
        public string description { get; set; } //Описание
        public int task_count { get; set; } //Количество задач в курсе
        public int progress { get; set; } //Прогресс курса
    }
}
