using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponyville_School
{
    /*Модель для хранения данных задания
    Во время сессии*/
    public class Task
    {
        public int id { get; set; } //ID задания
        public string title { get; set; } //Название заданий
        public int order { get; set; } //Порядок задач
        public string image_url { get; set; } //Ссылка на изображение
        public string text { get; set; } //Текст задания
        public string video { get; set; } //Видео задания
        public bool available { get; set; } //Доступно для выполнения
    }
}
