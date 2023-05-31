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
    }

