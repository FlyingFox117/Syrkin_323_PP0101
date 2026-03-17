using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Ponyville_School
{
    //Класс логирования для создания логов в виде текстовых файлов
    //Логи хранятся в папке logs корневой папки проекта
    public static class Logger
    {
        private static string lgPath;
        private static string LogLevel;

        static Logger()
        {
            string logDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ponyville School", "logs");
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
            string filename = $"log_{DateTime.Now:dd-MM-yyyy_HH_mm_ss}.txt";
            lgPath = Path.Combine(logDir, filename);
            LogLevel = ConfigurationManager.AppSettings["LogLevel"];
            string version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unknown";
            WriteLog("Инициализация журнала...", 0, "Logger");
            WriteLog($"Версия программы: {version}", 0, "Logger");
        }

        public static void WriteLog(string message, int level, string sender) //Создание строки
        {
            if (int.Parse(LogLevel) >= level) //Проверка уровня логирования
            {
                string line = $"[INFO] | [{sender}] | Время: [{DateTime.Now:HH:mm:ss}] -- '{message}'";
                File.AppendAllText(lgPath, line + Environment.NewLine);
            }
        }

        public static void Write(string message)
        {
            string line = $"[MESSAGE] | Время: [{DateTime.Now:HH:mm:ss}] -- '{message}'";
            File.AppendAllText(lgPath, line + Environment.NewLine);
        }

        public static void SupabaseLog(string sender, bool succesful, string error, string answer)
        {
            if (int.Parse(LogLevel) >= 1)
            {
                if (succesful)
                {
                    Write(" --- Выполнение функции ---");
                    Write("[FUNC] -- " + sender + " выполнилась со статусом {OK}!");
                    Write("[ANSWER]: " + answer);
                }
                else
                {
                    Write(" ---- Выполняется функция ---- ");
                    Write("[FUNC]:" + sender + " выполнилась со статусом {ERROR}!");
                    Write("[ANSWER]: " + error);
                }
            }
        }
    }
}
