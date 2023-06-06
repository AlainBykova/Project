using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Project_AP;
using System.Text.Json.Serialization;

namespace Project_AP
{
    public class HardwareService
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly string authorizationToken;

        public HardwareService(string apiUrl, string authorizationToken)
        {
            httpClient = new HttpClient();
            this.apiUrl = apiUrl;
            this.authorizationToken = authorizationToken;
        }
        // Список всего оборудования (для поиска)
        public async Task<List<Hardware>> GetHardwareInfoApi(string searchString)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка на успешный запрос апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Hardware> allHardware = ParseResponseHardware.InfoAllHardware(responseBody);

                // фильтр
                List<Hardware> filteredHardware = allHardware.FindAll(hardware => (hardware.name.Contains(searchString)));
                return filteredHardware;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        public async Task<List<Hardware>> GetAllHardwareInfoApi()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка на успешный запрос апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Hardware> allHardware = ParseResponseHardware.InfoAllHardware(responseBody);
                return allHardware;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }

        // поиск конкретного оборудования по его id
        public async Task<Hardware> GetHardwareByIdApi(int hardware_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка успешного запроса апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Hardware hardware = ParseResponseHardware.InfoHardware(responseBody, hardware_id);

                return hardware;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // поиск конкретного оборудования по его id (укороченная версия)
        public async Task<Hardware> GetHardwareNameByIdApi(int hardware_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка успешного запроса апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Hardware> allHardware = ParseResponseHardware.InfoAllHardware(responseBody);

                // фильтр
                Hardware filteredHardware = allHardware.SingleOrDefault(hardware => (hardware.id == hardware_id));
                return filteredHardware;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // Создание нового hardware и возврат его id
        public async Task<int> CreateNewHardwareApi(HardwareJson hard)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(hard, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }
            );
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return ParseResponseHardware.OnlyIdHardware(responseBody);
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // Удаление через id
        public async void DeleteHardwareApi(int hard_id)
        {
            string url_del = apiUrl + "/" + hard_id;
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
    public class Hardware
    {
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string image_link { get; set; }
        public int id { get; set; }
        public string created { get; set; }
        public Dictionary<string, int> specifications { get; set; }
        public List<Location> location { get; set; }
        public List<Rack> rack { get; set; }
        public List<Stock> stock { get; set; }
    }
    public class HardwareJson{
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("type")]
        public string type { get; set; }
        [JsonPropertyName("description")]
        public string description { get; set; }
        [JsonPropertyName("image_link")]
        public string image_link { get; set; }
        [JsonPropertyName("specifications")]
        public Dictionary<string, int> specifications { get; set; }

    }
}
