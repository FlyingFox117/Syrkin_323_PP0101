using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponyville_School
{
    //Класс логирования для создания логов в виде текстовых файлов
    //Логи хранятся в папке logs корневой папки проекта
    public static class Logger
    {
        private static string lgPath;

        static Logger()
        {
            string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            string filename = $"log_{DateTime.Now:dd-MM-yyyy_HH_mm_ss}.txt";

            lgPath = Path.Combine(logDir, filename);
            Write("Инициализация журнала...");
        }

        public static void Write(string message) //Создание строки
        {
            string line = $"Время: [{DateTime.Now:HH:mm:ss}] -- '{message}'";
            File.AppendAllText(lgPath, line + Environment.NewLine);
        }

        public static void Success(string message)
        {
            Write(message + " -- УСПЕШНОЕ ВЫПОЛНЕНИЕ");
        }

        public static void Failure(string message)
        {
            Write(message + " -- НЕУСПЕШНОЕ ВЫПОЛНЕНИЕ");
        }

        public static void SupabaseLog(string sender, bool succesful, string error, string answer)
        {
            if (succesful)
            {
                Write(" --- Выполнение функции ---");
                Write("{func}:" + sender + " выполнилась со статусом {OK}!");
                Write("{answer}: " + answer);
            }
            else
            {
                Write(" ---- Выполняется функция ---- ");
                Write("{func}:" + sender + " выполнилась со статусом {ERROR}!");
                Write("{error}: " + error);
            }
        }
    }
}
