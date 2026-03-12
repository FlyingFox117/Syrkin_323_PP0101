using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Debug.WriteLine("Консоль работает");
            using (var loginForm = new form_Login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    if (AppState.CurrentUser.role == "admin")
                    {
                        Application.Run(new form_Admin()); //Запуск формы админа главной
                    }
                    else
                    {
                        Application.Run(new form_Menu()); //Запуск формы ученика главной
                    }
                }
            }
        }
    }
}
