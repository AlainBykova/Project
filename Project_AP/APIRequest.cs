using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Project_AP;

namespace Project_AP
{
    internal class RequestService
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly string authorizationToken;

        public RequestService(string apiUrl, string authorizationToken)
        {
            httpClient = new HttpClient();
            this.apiUrl = apiUrl;
            this.authorizationToken = authorizationToken;
        }

        // данные о запросах через Id пользователя
        public async Task<List<Request>> GetRequestApi(int user_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка на успешный запрос к апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Request> allRequests = ParseResponseRequest.InfoRequest(responseBody);

                // Фильтры
                List<Request> filteredRequest = allRequests.FindAll(request => (request.User == user_id));
                return filteredRequest;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }

        // Получение данных о конкретном запросе по его id
        public async Task<Request> GetRequestByIdApi(int request_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка на успешный запрос к апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Request> allRequests = ParseResponseRequest.InfoRequest(responseBody);

                // Фильтры
                Request filteredRequest = allRequests.SingleOrDefault(request => (request.Id == request_id));
                return filteredRequest;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");

            }
        }
    }

    public class Request
    {
        public int User { get; set; }
        public int Location { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string Taken_date { get; set; }
        public string Return_date { get; set; }
        public int Issued_by { get; set; }
        public int Hardware { get; set; }
        public int Stock { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
        public string Created { get; set; }
    }
}

