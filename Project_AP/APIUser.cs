using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Project_AP;

namespace Project_AP
{
    public class UserService
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly string authorizationToken;

        public UserService(string apiUrl, string authorizationToken)
        {
            httpClient = new HttpClient();
            this.apiUrl = apiUrl;
            this.authorizationToken = authorizationToken;
        }
        // Данные про пользователей для поиска
        public async Task<List<User>> GetUsersNameApi(string searchString)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка на успешный запрос апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<User> allUsers = ParseResponseUser.InfoUser(responseBody);

                // Фильтры
                List<User> filteredUsers = allUsers.FindAll(user => (user.first_name.Contains(searchString) | user.last_name.Contains(searchString)));
                return filteredUsers;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // Поиск информации по конкретному пользователю через апи
        public async Task<User> GetUserByIdApi()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка на успешный запрос к апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                dynamic responseJson = JsonConvert.DeserializeObject(responseBody, settings);
                
                string f_name = responseJson.first_name;
                string l_name = responseJson.last_name;
                string patronymic = responseJson.patronymic;
                string image_link = responseJson.image_link;
                string email = responseJson.email;
                string phone = responseJson.phone;
                int id = responseJson.id;
                string type = responseJson.type;
                string created = responseJson.created;

                User user = new()
                {
                    first_name = f_name,
                    last_name = l_name,
                    patronymic = patronymic,
                    type = type,
                    image_link = image_link,
                    email = email,
                    phone = phone,
                    id = id,
                    created = created
                 };
                return user;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
    }

    public class User
    {
        public bool active { get; set; }
        public string type { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patronymic { get; set; }
        public string image_link { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string card_id { get; set; }
        public string card_key { get; set; }
        public int id { get; set; }
        public string created { get; set; }
    }
}
