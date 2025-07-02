using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponyville_School
{
    /* Экземпляп класса Supabase, хранящий данные для связью с БД
    на протяжении работы с программой, в текущей сессии */
    public class SupabaseClient
    {
        private readonly RestClient client;

        private const string BaseURL = "https://lwdjfmhupdqvrhmcbgva.supabase.co";
        private const string APIkey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imx3ZGpmbWh1cGRxdnJobWNiZ3ZhIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTEwMjQyMDcsImV4cCI6MjA2NjYwMDIwN30.sZ0RHv03NKcdsP47aVDqm7WmTeFNwA1u6CkfyPb9RtI";

        public SupabaseClient()
        {
            client = new RestClient(BaseURL); //Инициализация клиента RestRequest
            AppState.CurrentUser = new UserData(); //Текущий пользователь программы
        } //Инициализация клиента

        private RestRequest CreateRequest(string endpoint, Method method = Method.Post) //Структура запроса к Supabase
        {
            var request = new RestRequest(endpoint, method);
            request.AddHeader("apikey", APIkey);
            request.AddHeader("Authorization", $"Bearer {APIkey}");
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        public async Task<bool> AuthenticateUser(string login, string password) //Авторизация
        {
            var request = CreateRequest("/rest/v1/rpc/auth_user"); //Путь к функции 
            request.AddJsonBody(new { login, password }); //Добавление тела запроса
            var response = await client.ExecuteAsync(request); //Ответ от серверной части

            var rawJson = JObject.Parse(response.Content); //Преобразование полученного необработанного json в JObject программы

            if (rawJson["id"] != null && rawJson["id"].Type != JTokenType.Null) //Проверка полученного ID
            {
                AppState.CurrentUser = rawJson.ToObject<UserData>(); //Создание пользователя
                return true; //Запуск форм
            }
            else
                return false; //Ошибка
        }

        public async Task<bool> GetCourseData(string course, int? user_id)
        {
            try
            {
                var request = CreateRequest("/rest/v1/rpc/get_course_data");
                request.AddJsonBody(new { course, user_id });
                var response = await client.ExecuteAsync(request);

                var rawJson = JObject.Parse(response.Content);
                if (rawJson["progress"] == null || rawJson["assignments"].Type == JTokenType.Null)
                {
                    return false;
                }

                int progress = rawJson["progress"].Value<int>();
                var tasks = rawJson["assignments"].ToObject<List<Task>>();
                
                AppState.CurrentUser.CourseProgress = progress; //Установка прогресса по курсу выбранного пользователем
                AppState.Tasks = tasks.ToArray(); //Создание списка заданий

                return true; //Запуск курса
            }
            catch (System.NullReferenceException)
            {
                return false; //Ошибка
            }
        } //Получение данных курса

        public async Task<List<Questions>> GetPracticeData(int Task)
        {
            var request = CreateRequest("/rest/v1/rpc/get_task_data");
            request.AddJsonBody(new { task_id = Task });
            var response = await client.ExecuteAsync(request);

            var questions = JsonConvert.DeserializeObject <List<Questions>>(response.Content);
            return questions;
        } //Получение заданий

        public async void ResultSubmit(int? user, int task, int score, string coursename)
        {
            var request = CreateRequest("/rest/v1/rpc/submit_task_result");
            request.AddJsonBody(new
            {
                p_user_id = user,
                p_task_id = task,
                p_score = score,
                p_course_name = coursename
            });
            await client.ExecuteAsync(request);
        } //Отправка результата в базу данных
    }
}
