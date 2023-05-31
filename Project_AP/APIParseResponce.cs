using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Project_AP;

namespace Project_AP
{
    // для оборудования
    internal class ParseResponseHardware
    {
        // парсинг информации о всем оборудовании для поиска
        public static List<Hardware> InfoAllHardware(string responseBody)
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
                int id = hdJson.id;

                Hardware hardware = new()
                {
                    Name = name,
                    Id = id,
                };

                hardwares.Add(hardware);
            }
            return hardwares;
        }

        // парсинг информации о конкретном оборудовании (вся инфо об одном)
        public static List<Hardware> InfoHardware(string responseBody)
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
    }
    // для location
    internal class ParseResponseLocation
    {
        public static List<Location> InfoLocation(string responseBody)
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
    }
    // для rack
    internal class ParseResponseRack
    {
        public static List<Rack> InfoRack(string responseBody)
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
    // для Stock
    internal class ParseResponseStock
    {
        public static List<Stock> InfoStock(string responseBody)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            dynamic responseJson = JsonConvert.DeserializeObject(responseBody, settings);

            List<Stock> stocks = new();

            foreach (dynamic stJson in responseJson)
            {
                int hardware = stJson.hardware;
                int rack_position = stJson.rack_position;
                int rack = stJson.rack;
                int id = stJson.id;
                int count = stJson.count;

                Stock stock = new()
                {
                    Hardware = hardware,
                    Rack_position = rack_position,
                    Rack = rack,
                    Id = id,
                    Count = count,
                };
                stocks.Add(stock);
            }
            return stocks;
        }
    }
    // для пользователей
    internal class ParseResponseUser
    {
        // парсинг основной инофрмации для поиска
        public static List<User> InfoUser(string responseBody)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            dynamic responseJson = JsonConvert.DeserializeObject(responseBody, settings);

            List<User> users = new();

            foreach (dynamic userJson in responseJson)
            {
                string f_name = userJson.first_name;
                string l_name = userJson.last_name;
                string patronymic = userJson.patronymic;
                int id = userJson.id;
                string type = userJson.type;

                User user = new()
                {
                    First_name = f_name,
                    Last_name = l_name,
                    Patronymic = patronymic,
                    Type = type,
                    Id = id,
                };
                users.Add(user);
            }
            return users;
        }
    }
    // для запросов
    internal class ParseResponseRequest
    {
        public static List<Request> InfoRequest(string responseBody)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            dynamic responseJson = JsonConvert.DeserializeObject(responseBody, settings);

            List<Request> requests = new();

            foreach (dynamic reqJson in responseJson)
            {
                int user = reqJson.user;
                int location = reqJson.location;
                string status = reqJson.status;
                string comment = reqJson.comment;
                string taken_date = reqJson.taken_date;
                string return_date = reqJson.return_date;
                int issued_by = reqJson.issued_by;
                int id = reqJson.id;
                int hardware = reqJson.hardware;
                int stock = reqJson.stock;
                int count = reqJson.count;

                Request request = new()
                {
                    User = user,
                    Location = location,
                    Status = status,
                    Comment = comment,
                    Taken_date = taken_date,
                    Return_date = return_date,
                    Issued_by = issued_by,
                    Hardware = hardware,
                    Stock = stock,
                    Count = count,
                    Id = id,
                };
                requests.Add(request);
            }
            return requests;
        }
    }
}
