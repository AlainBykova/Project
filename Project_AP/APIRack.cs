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
        public async Task<List<Rack>> GetRackInfoUsingLocationIdApi(int loc_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка успешного запрока апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Rack> allLocations = ParseResponseRack.InfoRack(responseBody);
                // Фильтры
                List<Rack> filteredLocations = allLocations.FindAll(rack => (rack.Location == loc_id));
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
                Rack rack = allRacks.SingleOrDefault(rack => (rack.Id == rack_id));
                return rack;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");

            }
        }
    }

    // Описание класса
    public class Rack
    {
        public int Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}

