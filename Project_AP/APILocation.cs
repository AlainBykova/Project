using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

            public async Task<List<Location>> GetLocationInfoApi(string searchString)
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
                    List<Location> allLocations = ParseLocationResponse(responseBody);

                    // Filter the users based on the search string
                    List<Location> filteredLocations = allLocations.FindAll(location => (location.Name.Contains(searchString)));

                    return filteredLocations;
                }
                else
                {
                    // Handle the case when the API request fails
                    throw new Exception($"API request failed with status code: {response.StatusCode}");
                }
            }

            private static List<Location> ParseLocationResponse(string responseBody)
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                dynamic responseJson = JsonConvert.DeserializeObject(responseBody, settings);

                List<Location> locations = new();

                foreach (dynamic locJson in responseJson)
                {
                    string name = locJson.name;
                    int width = locJson.width;
                    int height = locJson.height;
                    string created = locJson.created;
                    int id = locJson.id;

                    Location location = new()
                    {
                        Name = name,
                        Created = created,
                        Width = width,
                        Height = height,
                        Id = id,
                    };

                    locations.Add(location);
                }

                return locations;
            }

            public async Task<Location> GetLocationByIdApi()
            {
                // Set the authorization header
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));

                // Make the API request to retrieve all users
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    dynamic locJson = JsonConvert.DeserializeObject(responseBody, settings);

                    string name = locJson.name;
                    int width = locJson.width;
                    int height = locJson.height;
                    string created = locJson.created;
                    int id = locJson.id;

                    Location location = new()
                    {
                        Name = name,
                        Created = created,
                        Width = width,
                        Height = height,
                        Id = id,
                    };

                    return location;
                }
                else
                {
                    // Handle the case when the API request fails
                    throw new Exception($"API request failed with status code: {response.StatusCode}");

                }
            }
        }

        public class Location
        {
            public string Name { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Id { get; set; }
            public string Created { get; set; }
        }
    }

