using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponyville_School
{
    /*Модель для хранения данных пользователя
    Во время сессии*/
    public class UserData
    {
        public int? id; //Код пользователя. Нужен для извлечения его прогресса из таблицы progress. Хранится в users как PK
        public string name; //Имя пользователя, отображаемое в профиле
        public string role; //Роль пользователя, позволяет разделять формы при авторизации на меню курсов для учеников и панель для администратора
        public int? level; //Текущий уровень пользователя. Позволяет выстраивать рейтинги внутри учебных групп
        public DateTime? last_online; //Последний онлайн. Обновляется только при условии что во время онлайна было выполнено задание. Используется для реализации ежедневных заданий
        public bool? available; //Доступ к выполнению заданий. Проверка доступа происходит на стороне Supabase
    }

    public class UserResults
    {
        public int id { get; set; } //ID выполненного задания
        public string course { get; set; } //Название курса
        public string name { get; set; } //Название задания
        public int score { get; set; }
        public DateTime passed_at { get; set; }
    }
}
