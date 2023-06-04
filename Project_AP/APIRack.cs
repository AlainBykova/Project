using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Project_AP;

namespace Project_AP
{
    public class RackService
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly string authorizationToken;

        public RackService(string apiUrl, string authorizationToken)
        {
            httpClient = new HttpClient();
            this.apiUrl = apiUrl;
            this.authorizationToken = authorizationToken;
        }
        // Получить данные о rack через id location
        public async Task<List<Rack>> GetRackByLocationIdApi(int loc_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка успешного запрока апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Rack> allLocations = ParseResponseRack.InfoRack(responseBody);
                // Фильтры
                List<Rack> filteredLocations = allLocations.FindAll(rack => (rack.location == loc_id));
                return filteredLocations;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }

        // Получить данные о rack по его id
        public async Task<Rack> GetRackByIdApi(int rack_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка на успешный запрос апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Rack> allRacks = ParseResponseRack.InfoRack(responseBody);
                // Фильтр
                Rack rack = allRacks.SingleOrDefault(rack => (rack.id == rack_id));
                return rack;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");

            }
        }
        // Создать новый rack и вернуть его id
        public async Task<int> CreateNewRackApi(Rack rack)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(rack);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return ParseResponseRack.OnlyIdRack(responseBody);
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // Удалить rack по его id
        public async void DeleteRackApi(int rack_id)
        {
            string url_del = apiUrl + "/" + rack_id;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.DeleteAsync(url_del);

            // Проверка статуса ответа
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
    }

    // Описание класса
    public class Rack
    {
        public int location { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}

