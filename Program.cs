using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponyville_School
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Logger.Write("Запуск программы");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var loginForm = new form_Login())
                {
                sw.Stop();
                Logger.Write($"Время запуска: {sw.ElapsedMilliseconds} мс");
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    if (AppState.CurrentUser.role == "admin")
                    {                    
                        Application.Run(new form_Menu()); //Запуск формы админа главной
                        Logger.Write("Пользователь - администратор");
                    }
                    else
                    {
                        Application.Run(new form_Menu()); //Запуск формы ученика главной
                        Logger.Write("Пользователь - ученик");
                    }
                }
            }
        }
    }
}
