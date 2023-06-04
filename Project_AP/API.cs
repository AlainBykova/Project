using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
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
            Hardware hardware = new();
            try
            {
                hardware = await hardwareService.GetHardwareByIdApi(hardware_id);
                List<Stock> stocks = await stockService.GetStockInfoUsingHardwareIdApi(hardware_id);
                if(stocks == null)
                {
                    hardware.stock = null;
                    hardware.rack = null;
                    hardware.location = null;
                    return hardware;
                }
                hardware.stock = new List<Stock>();
                hardware.rack = new List<Rack>();
                hardware.location = new List<Location>();
                List<int> countRackId = new();
                List<int> countLocId = new();
                foreach(Stock st in stocks)
                {
                    hardware.stock.Add(st);
                    Rack rack = await rackService.GetRackByIdApi(st.rack);
                    if(rack == null)
                    {
                        return hardware;
                    }
                    if (countRackId.Contains(rack.id) == false)
                    {
                        hardware.rack.Add(rack);
                        countRackId.Add(rack.id);
                    }
                    
                    Location location = await locationService.GetLocationByIdApi(rack.location);
                    if(location == null)
                    {
                        return hardware;
                    }
                    if(countLocId.Contains(location.id) == false)
                    {
                        hardware.location.Add(location);
                        countLocId.Add(location.id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            return hardware;
        }
        // поиск конкретного оборудования по id stock
        public async Task<List<Hardware>> GetHardwareByRackIdApi(int rack_id)
        {
            string apiUrl = "https://helow19274.ru/aip/api/hardware";
            string apiUrl1 = "https://helow19274.ru/aip/api/stocks";

            string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";

            HardwareService hardwareService = new(apiUrl, authorizationToken);
            StockService stockService = new(apiUrl1, authorizationToken);

            List<Hardware> allHardware = new();
            // Проверка успешного запроса апи
            try
            {
                //Rack rack = await rackService.GetRackByIdApi(rack_id);
                List<Stock> stocks = await stockService.GetStockInfoUsingRackIdApi(rack_id);
                
                foreach(Stock item in stocks)
                {
                    Hardware hardware = await hardwareService.GetHardwareNameByIdApi(item.hardware);
                    hardware.stock.Add(item);
                    allHardware.Add(hardware);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            return allHardware;
        }
        public async Task<List<Hardware>> GetHardwareByLocationIdApi(int loc_id)
        {
            string apiUrl = "https://helow19274.ru/aip/api/hardware";
            string apiUrl1 = "https://helow19274.ru/aip/api/stocks";
            string apiUrl2 = "https://helow19274.ru/aip/api/rack";

            string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";

            HardwareService hardwareService = new(apiUrl, authorizationToken);
            StockService stockService = new(apiUrl1, authorizationToken);
            RackService rackService = new(apiUrl2, authorizationToken);

            List<Hardware> allHardware = new();
            // Проверка успешного запроса апи
            try
            {
                List<Rack> racks = await rackService.GetRackByLocationIdApi(loc_id);
                foreach(Rack rack in racks)
                {
                    List<Stock> stocks = await stockService.GetStockInfoUsingRackIdApi(rack.id);

                    foreach (Stock item in stocks)
                    {
                        Hardware hardware = await hardwareService.GetHardwareNameByIdApi(item.hardware);
                        hardware.stock = new List<Stock>();
                        hardware.rack = new List<Rack>();
                        hardware.stock.Add(item);
                        hardware.rack.Add(rack);
                        allHardware.Add(hardware);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            return allHardware;
        }
        public async Task<Hardware> GetHardwareByStockIdApi(int loc_id)
        {
            string apiUrl = "https://helow19274.ru/aip/api/hardware";
            string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";

            HardwareService hardwareService = new(apiUrl, authorizationToken);
           Hardware hardware = new();
            // Проверка успешного запроса апи
            try
            {
                hardware = await hardwareService.GetHardwareNameByIdApi(loc_id);
                hardware.stock = new List<Stock>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            return hardware;
        }
        public async Task<List<Stock>> GetStocksForRackList(List<Rack> racks)
        {
            string apiUrl2 = "https://helow19274.ru/aip/api/stocks";
            string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";
            StockService stockService = new(apiUrl2, authorizationToken);
            List<Stock> stocks = new();
            try
            {
                foreach(Rack item in racks)
                {
                    List<Stock> stock = new();
                    stock = await stockService.GetStockInfoUsingRackIdApi(item.id);
                    foreach(Stock st in stock)
                    {
                        stocks.Add(st);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            return stocks;
        }
        public async void DeleteAllLocationInfo(int loc_id)
        {
            string apiUrl2 = "https://helow19274.ru/aip/api/stocks";
            string apiUrl3 = "https://helow19274.ru/aip/api/rack";
            string apiUrl4 = "https://helow19274.ru/aip/api/location";
            string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";

            StockService stockService = new(apiUrl2, authorizationToken);
            RackService rackService = new(apiUrl3, authorizationToken);
            LocationService locationService = new(apiUrl4, authorizationToken);
            try
            {
                List<Rack> racks = await rackService.GetRackByLocationIdApi(loc_id);
            foreach(Rack rack in racks)
            {
                List<Stock> stocks = await stockService.GetStockInfoUsingRackIdApi(rack.id);
                foreach(Stock stock in stocks)
                {
                    stockService.DeleteStockApi(stock.id);
                }
                rackService.DeleteRackApi(rack.id);
            }
            locationService.DeleteLocationApi(loc_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        public async void DeleteAllHardwareInfo(int loc_id)
        {
            string apiUrl2 = "https://helow19274.ru/aip/api/hardware";
            string apiUrl3 = "https://helow19274.ru/aip/api/stocks";
            string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";

            StockService stockService = new(apiUrl3, authorizationToken);
            HardwareService hardService = new(apiUrl2, authorizationToken);
            try
            {
                List<Stock> stocks = await stockService.GetStockInfoUsingHardwareIdApi(loc_id);
            foreach (Stock stock in stocks)
            {
                stockService.DeleteStockApi(stock.id);
            }
            hardService.DeleteHardwareApi(loc_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
