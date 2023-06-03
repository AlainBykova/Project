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
    public class LocationService
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly string authorizationToken;

        public LocationService(string apiUrl, string authorizationToken)
        {
            httpClient = new HttpClient();
            this.apiUrl = apiUrl;
            this.authorizationToken = authorizationToken;
        }

        // весь список локации (для поиска)
        public async Task<List<Location>> GetLocationInfoApi(string searchString)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // проверка на успешный запрос апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Location> allLocations = ParseResponseLocation.InfoLocation(responseBody);

                // фильтры
                List<Location> filteredLocations = allLocations.FindAll(location => (location.Name.Contains(searchString)));
                return filteredLocations;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }


        public async Task<Location> GetLocationByIdApi(int loc_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // проверка на успешный запрос апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Location> allLocation = ParseResponseLocation.InfoLocation(responseBody);

                // фильтры
                Location location = allLocation.SingleOrDefault(location => (location.Id == loc_id));
                return location;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // Создание нового location и возврат его id
        public async Task<int> CreateNewLocationApi(Location location)
        {
            loc iWannaSleep = new() {
                name = location.Name,
                height = location.Height,
                width = location.Width,
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(iWannaSleep);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return ParseResponseLocation.OnlyIdLocation(responseBody);
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // Удаление через id
        public async void DeleteLocationApi(int loc_id)
        {
            string url_del = apiUrl + "/" + loc_id;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.DeleteAsync(url_del);

            // Проверка статуса ответа
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
    }
    // описание класса
    public class Location
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Id { get; set; }
        public string Created { get; set; }
    }
    public class loc
    {
        public string name { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}

