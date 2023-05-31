using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<Hardware>> GetHardwareInfoApi(string searchString)
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
                List<Hardware> allHardware = ParseHardwareResponse(responseBody);

                // Filter the users based on the search string
                List<Hardware> filteredHardware = allHardware.FindAll(hardware => (hardware.Name.Contains(searchString)));

                return filteredHardware;
            }
            else
            {
                // Handle the case when the API request fails
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }

        private static List<Hardware> ParseHardwareResponse(string responseBody)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            dynamic responseJson = JsonConvert.DeserializeObject(responseBody, settings);

            List<Hardware> hardwares = new();

            foreach (dynamic hdJson in responseJson)
            {
                string name = hdJson.name;
                string description = hdJson.description;
                string created = hdJson.created;
                string image_link = hdJson.image_link;
                int id = hdJson.id;
                string type = hdJson.type;

                Hardware hardware = new()
                {
                    Name = name,
                    Created = created,
                    Description = description,
                    Type = type,
                    Image_link = image_link,
                    Id = id,
                };

                hardwares.Add(hardware);
            }

            return hardwares;
        }

        public async Task<Hardware> GetHardwareByIdApi(int hardware_id)
        {
            // Set the authorization header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));

            // Make the API request to retrieve all users
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Hardware> allHardware = ParseHardwareResponse(responseBody);

                Hardware hardware = allHardware.SingleOrDefault(hardware => (hardware.Id == hardware_id));

                return hardware;
            }
            else
            {
                // Handle the case when the API request fails
                throw new Exception($"API request failed with status code: {response.StatusCode}");

            }
        }
    }

    public class Hardware
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Image_link { get; set; }
        public int Id { get; set; }
        public string Created { get; set; }
        public List<string> Specifications { get; set; }
    }
}
