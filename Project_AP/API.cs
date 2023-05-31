using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_AP;

namespace Project_AP
{
    internal class API
    {
        public async Task<Hardware> GetAllInfoHardware(int hardware_id)
        {
            string apiUrl1 = "https://helow19274.ru/aip/api/hardware";
            string apiUrl2 = "https://helow19274.ru/aip/api/stocks";
            string apiUrl3 = "https://helow19274.ru/aip/api/rack";
            string apiUrl4 = "https://helow19274.ru/aip/api/location";

            string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";

            HardwareService hardwareService = new(apiUrl1, authorizationToken);
            StockService stockService = new(apiUrl2, authorizationToken);
            RackService rackService = new(apiUrl3, authorizationToken);
            LocationService locationService = new(apiUrl4, authorizationToken);

            try
            {
                Hardware hardware = await hardwareService.GetHardwareByIdApi(hardware_id);
                Stock stock = await stockService.GetStockInfoUsingHardwareIdApi(hardware_id);
                if(stock == null)
                {
                    hardware.Stock = -1;
                    hardware.Rack = -1;
                    hardware.Location = -1;
                    return hardware;
                }
                hardware.Stock = stock.Id;
                hardware.Rack_position = stock.Rack_position;
                Rack rack = await rackService.GetRackByIdApi(stock.Rack);
                if(rack == null)
                {
                    hardware.Rack = -1;
                    hardware.Location = -1;
                    return hardware;
                }
                hardware.Rack = rack.Id;
                Location location = await locationService.GetLocationByIdApi(rack.Location);
                if(location == null)
                {
                    hardware.Location = -1;
                    return hardware;
                }
                hardware.Location = location.Id;
                return hardware;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            return null;
        }
    }
}
