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
                List<Hardware> filteredHardware = allHardware.FindAll(hardware => (hardware.Name.Contains(searchString)));
                return filteredHardware;
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
                List<Hardware> allHardware = ParseResponseHardware.InfoHardware(responseBody);

                // фильтр
                Hardware hardware = allHardware.SingleOrDefault(hardware => (hardware.Id == hardware_id));
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
                Hardware hardware = allHardware.SingleOrDefault(hardware => (hardware.Id == hardware_id));
                return hardware;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // Создание нового hardware и возврат его id
        public async Task<int> CreateNewLocationApi(Hardware hard)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(hard);
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
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Image_link { get; set; }
        public int Id { get; set; }
        public string Created { get; set; }
        public List<string> Specifications { get; set; }
        public int Location { get; set; }
        public int Location_Name { get; set; }
        public int Location_Width { get; set; }
        public int Location_Height { get; set; }
        public int Rack { get; set; }
        public int Rack_Width { get; set; }
        public int Rack_Height { get; set; }
        public int Rack_X { get; set; }
        public int Rack_Y { get; set; }
        public int Stock { get; set; }
        public int Rack_position { get; set; }
        public int Count { get; set; }
    }
}
