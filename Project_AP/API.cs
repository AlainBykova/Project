using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<User>> GetUsersNameApi(string searchString)
        {
            // Set the authorization header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));

            // Make the API request to retrieve all users
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                string responseBody = await response.Content.ReadAsStringAsync();

                // Parse the response and extract the list of users
                List<User> allUsers = ParseUserResponse(responseBody);

                // Filter the users based on the search string
                List<User> filteredUsers = allUsers.FindAll(user => (user.First_name.Contains(searchString) | user.Last_name.Contains(searchString)));

                return filteredUsers;
            }
            else
            {
                // Handle the case when the API request fails
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }

        private static List<User> ParseUserResponse(string responseBody)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            dynamic responseJson = JsonConvert.DeserializeObject(responseBody, settings);

            List<User> users = new();

            foreach (dynamic userJson in responseJson)
            {
                string f_name = userJson.first_name;
                string l_name = userJson.last_name;
                string patronymic = userJson.patronymic;

                User user = new()
                {
                    First_name = f_name,
                    Last_name = l_name,
                    Patronymic = patronymic
                };

                users.Add(user);
            }

            return users;
        }
    }

    public class User
    {
        public bool Active { get; set; }
        public string Type { get; set; }

        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Patronymic { get; set; }
        public string Image_link { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Card_id { get; set; }
        public string Card_key { get; set; }
        public int Id { get; set; }
        public string Created { get; set; }
    }
}
