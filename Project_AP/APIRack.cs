using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<Rack>> GetRackInfoApi(int loc_id)
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
                List<Rack> allLocations = ParseRackResponse(responseBody);

                // Filter the users based on the search string
                List<Rack> filteredLocations = allLocations.FindAll(rack => (rack.Location == loc_id));

                return filteredLocations;
            }
            else
            {
                // Handle the case when the API request fails
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }

        private static List<Rack> ParseRackResponse(string responseBody)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            dynamic responseJson = JsonConvert.DeserializeObject(responseBody, settings);

            List<Rack> racks = new();

            foreach (dynamic locJson in responseJson)
            {
                int location = locJson.location;
                int width = locJson.width;
                int height = locJson.height;
                int x = locJson.x;
                int y = locJson.y;
                int id = locJson.id;

                Rack rack = new()
                {
                    Location = location,
                    X = x,
                    Y = y,
                    Width = width,
                    Height = height,
                    Id = id,
                };

                racks.Add(rack);
            }

            return racks;
        }
    }


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

