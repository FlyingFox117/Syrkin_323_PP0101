using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponyville_School
{
    /* Статичный центральный класс, хранящий в себе экземпляры остальных объектов
    для обеспечения связи и передачи данных между формами*/
    public static class AppState
    {
        public static SupabaseClient Supabase { get; set; } //Инициализация клиента SupabaseClient для работы с БД

        public static UserData CurrentUser { get; set; } //Инициализация пользователя приложения

        public static Task[] Tasks { get; set; } //Инициализация списка заданий

        public static string SelectedCourse { get; set; } //Выбранный курс

        public static void Reset() //Обнуление данных приложения
        {
            Supabase = null;
            CurrentUser = null;
        }
    }
}