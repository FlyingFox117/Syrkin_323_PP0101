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

        private static string BaseURL = "https://phntjkxxmszbsvfnlvnh.supabase.co";
        private static string APIkey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InBobnRqa3h4bXN6YnN2Zm5sdm5oIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjM2NjgzMDAsImV4cCI6MjA3OTI0NDMwMH0.TGM-bcU1-5Xwztdj0zL_gahoTI-XanCIlvz032fAlu8";

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
                Logger.SupabaseLog("register_user с данными (" + name + ", " + login + ", " + password + ")",
                    response.IsSuccessful,
                    response.ErrorMessage,
                    response.Content);
                return true;
            }
            Logger.SupabaseLog("register_user с данными (" + name + ", " + login + ", " + password + ")",
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
                Logger.SupabaseLog("auth_user с данными (" + login + ", " + password + ")",
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
                Logger.SupabaseLog("auth_user с данными (" + login + ", " + password + ")",
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
                    Logger.SupabaseLog("get_course_data с данными (" + course_id + ", " + p_user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);
                    return false;
                }
                Logger.SupabaseLog("get_course_data с данными (" + course_id + ", " + p_user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);

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
                Logger.SupabaseLog("get_practice_data с данными (" + task_id + ")",
                    response.IsSuccessful,
                    response.ErrorMessage,
                    response.Content);
                return questions;
            }
            catch
            {
                MessageBox.Show("Задания не найдены!", "Задания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.SupabaseLog("get_practice_data с данными (" + task_id + ")",
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
                Logger.SupabaseLog("submit_result с данными (" + user + ", " + task + ", " + score + ", " + course + ")",
                    response.IsSuccessful, response.ErrorMessage, response.Content);
                return true;
            }
            else
            {
                Logger.SupabaseLog("submit_result с данными (" + user + ", " + task + ", " + score + ", " + course + ")",
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
                    Logger.SupabaseLog("get_user_progress с данными (" + user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);
                    return false;
                }

                var progressArray = JArray.Parse(response.Content);

                var progressList = progressArray.ToObject<List<CourseProgress>>();

                AppState.CoursesProgress = progressList.ToArray();

                Logger.SupabaseLog("get_user_progress с данными (" + user_id + ")", response.IsSuccessful, "", response.Content);

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
                Logger.SupabaseLog("get_user_results с данными (" + p_user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);
                return new List<UserResults>();
            }
            Logger.SupabaseLog("get_user_results с данными (" + p_user_id + ")", response.IsSuccessful, response.ErrorMessage, response.Content);
            return JsonConvert.DeserializeObject<List<UserResults>>(response.Content);
        } //Получение списка выполненных заданий пльзователя

        public async Task<bool> CheckToken(string token) //Проверка действительности токена
        {
            var request = CreateRequest("/rest/v1/rpc/check_token");
            request.AddJsonBody(new 
            { p_token = token });
            var response = await client.ExecuteAsync(request);
            var rawJson = JObject.Parse(response.Content);
            if (rawJson["id"] != null && rawJson["id"].Type != JTokenType.Null)
            {
                Logger.SupabaseLog("check_token с данными (" + token + ")",
                   response.IsSuccessful,
                   response.ErrorMessage,
                   response.Content);
                AppState.CurrentUser = rawJson.ToObject<UserData>();
                if (AppState.CurrentUser.available == null)
                {
                    AppState.CurrentUser.available = true;
                }
                return true;
            }
            else
            {
                Logger.SupabaseLog("check_token с данными (" + token + ")",
                    response.IsSuccessful, response.ErrorMessage, response.Content);
                return false;
            }
        }

        public async Task<bool> CreateToken(Guid token, int? user_id) //Создание токена для автоматической авторизации
        {
            var request = CreateRequest("/rest/v1/rpc/create_token");
            request.AddJsonBody( new
            {
                    p_token = token,
                    p_user_id = user_id
            });
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Logger.SupabaseLog("create_token с данными (" + token + ", " + user_id + ")",
                    response.IsSuccessful, response.ErrorMessage, response.Content);
                return true;
            }
            else
            {
                Logger.SupabaseLog("create_token с данными (" + token + ", " + user_id + ")",
                    response.IsSuccessful, response.ErrorMessage, response.Content);
                return false;
            }
        }

        public async Task<bool> DeleteToken(string token) //Удаление токена для автоматической авторизации
        {
            var request = CreateRequest("/rest/v1/rpc/delete_token");
            request.AddJsonBody(new
            {
                p_token = token
            });
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Logger.SupabaseLog("delete_token с данными (" + token + ")",
                    response.IsSuccessful, response.ErrorMessage, response.Content);
                return true;
            }
            else
            {
                Logger.SupabaseLog("delete_token с данными (" + token + ")",
                    response.IsSuccessful, response.ErrorMessage, response.Content);
                return false;
            }
        }
    }
}
