using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ponyville_School
{
    /* Экземпляр класса Supabase, хранящий данные для связью с БД
    на протяжении работы с программой, в текущей сессии */
    public class SupabaseClient
    {
        private readonly RestClient client;

        private static string BaseURL = ConfigurationManager.AppSettings["SupabaseUrl"];
        private static string APIkey = ConfigurationManager.AppSettings["SupabaseKey"];

        public SupabaseClient()
        {
            client = new RestClient(BaseURL); //Инициализация клиента RestRequest
            AppState.CurrentUser = new UserData(); //Текущий пользователь программы
        } //Инициализация клиента SupabaseClient

        private RestRequest CreateRequest(string endpoint, Method method = Method.Post) //Структура запроса к Supabase
        {
            var request = new RestRequest(endpoint, method);
            request.AddHeader("apikey", APIkey);
            request.AddHeader("Authorization", $"Bearer {APIkey}");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Prefer", "return=minimal");
            return request;
        }

        public async Task<bool> RegisterUser(string login, string password, string name)
        {
            var request = CreateRequest("/rest/v1/rpc/register_user");
            request.AddJsonBody(new
            {
                p_login = login,
                p_password = password,
                p_name = name
            });

            var response = await client.ExecuteAsync(request);

            var raw = JObject.Parse(response.Content);

            if (response.IsSuccessful)
            {
                CreateLog("register_user с данными (" + name + ", " + login + ", " + password + ")",
                    response.IsSuccessful,
                    response.ErrorMessage,
                    response.Content);
                return true;
            }
            CreateLog("register_user с данными (" + name + ", " + login + ", " + password + ")",
                response.IsSuccessful,
                response.ErrorMessage,
                response.Content);
            return false;
        } //Регистрация нового пользователя

        public async Task<bool> AuthenticateUser(string login, string password) //Авторизация
        {
            var request = CreateRequest("/rest/v1/rpc/auth_user"); //Путь к функции 
            request.AddJsonBody(new { login, password }); //Добавление тела запроса
            var response = await client.ExecuteAsync(request); //Ответ от серверной части

            var rawJson = JObject.Parse(response.Content); 
            //Преобразование полученного необработанного json в JObject программы

            if (rawJson["id"] != null && rawJson["id"].Type != JTokenType.Null) //Проверка полученного ID
            {
                CreateLog("auth_user с данными (" + login + ", " + password + ")",
                    response.IsSuccessful,
                    response.ErrorMessage,
                    response.Content);
                AppState.CurrentUser = rawJson.ToObject<UserData>(); //Создание пользователя
                if (AppState.CurrentUser.available == null) 
                    //Если Supabase в available возвращает - null, пользователь новый
                {
                    AppState.CurrentUser.available = true; //Открываем ему доступ к заданиям
                }
                return true; //Запуск форм
            }
            else
            {
                CreateLog("auth_user с данными (" + login + ", " + password + ")",
                    response.IsSuccessful,
                    response.ErrorMessage,
                    response.Content);
                return false; //Ошибка
            }
        }

        public async Task<bool> GetCourseData(int course_id, int? p_user_id)
        {
            try
            {
                var request = CreateRequest("/rest/v1/rpc/get_course_data");
                request.AddJsonBody(new {course_id, p_user_id});
                var response = await client.ExecuteAsync(request);

                if (!response.IsSuccessful || string.IsNullOrWhiteSpace(response.Content))
                {
                    CreateLog("get_course_data с данными (" + course_id + ", " + p_user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);
                    return false;
                }
                CreateLog("get_course_data с данными (" + course_id + ", " + p_user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);

                var rawJson = JArray.Parse(response.Content);

                var tasks = rawJson.ToObject<List<Task>>();
                
                AppState.Tasks = tasks.ToArray(); //Создание списка заданий

                return true; //Запуск курса
            }
            catch (Exception)
            {
                return false; //Ошибка
            }
        } //Получение данных курса

        public async Task<List<Questions>> GetPracticeData(int task_id)
        {
            var request = CreateRequest("/rest/v1/rpc/get_practice_data");
            request.AddJsonBody(new { task_id });
            var response = await client.ExecuteAsync(request);

            try
            {
                var questions = JsonConvert.DeserializeObject<List<Questions>>(response.Content);
                CreateLog("get_practice_data с данными (" + task_id + ")",
                    response.IsSuccessful,
                    response.ErrorMessage,
                    response.Content);
                return questions;
            }
            catch
            {
                MessageBox.Show("Задания не найдены!", "Задания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateLog("get_practice_data с данными (" + task_id + ")",
                    response.IsSuccessful,
                    response.ErrorMessage,
                    response.Content);
                return null;
            }
        } //Получение заданий

        public async Task<bool> ResultSubmit(int? user, int task, int score, int course)
        {
            var request = CreateRequest("/rest/v1/rpc/submit_result");
            request.AddJsonBody(new
            {
                p_user_id = user,
                p_task_id = task,
                p_score = score,
                p_course_id = course
            });
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                CreateLog("submit_result с данными (" + user + ", " + task + ", " + score + ", " + course + ")",
                    response.IsSuccessful, response.ErrorMessage, response.Content);
                return true;
            }
            else
            {
                CreateLog("submit_result с данными (" + user + ", " + task + ", " + score + ", " + course + ")",
                    response.IsSuccessful, response.ErrorMessage, response.Content);
                return false;
            }
        } //Отправка результата в базу данных

        public async Task<bool> GetUserProgress(int? user_id) //Получение данных по прогрессу
        {
            try
            {
                var request = CreateRequest("/rest/v1/rpc/get_user_progress");
                request.AddJsonBody(new { p_user_id = user_id });

                var response = await client.ExecuteAsync(request);

                if (!response.IsSuccessful || string.IsNullOrWhiteSpace(response.Content))
                {
                    CreateLog("get_user_progress с данными (" + user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);
                    return false;
                }

                var progressArray = JArray.Parse(response.Content);

                var progressList = progressArray.ToObject<List<CourseProgress>>();

                AppState.CoursesProgress = progressList.ToArray();

                CreateLog("get_user_progress с данными (" + user_id + ")", response.IsSuccessful, "", response.Content);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки прогресса курсов: " + ex.Message);
                return false;
            }
        }
        public async Task<List<UserResults>> GetUserResults(int? p_user_id)
        {
            var request = CreateRequest("/rest/v1/rpc/get_user_results");
            request.AddJsonBody(new { p_user_id });

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrWhiteSpace(response.Content))
            {
                CreateLog("get_user_results с данными (" + p_user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);
                return new List<UserResults>();
            }
            CreateLog("get_user_results с данными (" + p_user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);
            return JsonConvert.DeserializeObject<List<UserResults>>(response.Content);
        }

        private void CreateLog(string sender, bool succesful, string error, string answer)
        {
            if (succesful)
            {
                Debug.WriteLine(" ---- Выполняется функция ---- ");
                Debug.WriteLine("{func}:" + sender + " выполнилась со статусом {OK}!");
                Debug.WriteLine("{answer}: " + answer);
            }
            else
            {
                Debug.WriteLine(" ---- Выполняется функция ---- ");
                Debug.WriteLine("{func}:" + sender + " выполнилась со статусом {ERROR}!");
                Debug.WriteLine("{error}: " + error);
            }
        }
    }
}
