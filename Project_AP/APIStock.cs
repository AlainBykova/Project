﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Project_AP;

namespace Project_AP
{
    public class StockService
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private readonly string authorizationToken;

        public StockService(string apiUrl, string authorizationToken)
        {
            httpClient = new HttpClient();
            this.apiUrl = apiUrl;
            this.authorizationToken = authorizationToken;
        }
        // Получение данных о Stock через id hardware
        public async Task<Stock> GetStockInfoUsingHardwareIdApi(int hardware_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // проверка на успешный запрос апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List <Stock> allStocks = ParseResponseStock.InfoStock(responseBody);

                // фильтры
                Stock filteredStock = allStocks.SingleOrDefault(stock => (stock.Hardware == hardware_id));
                return filteredStock;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // Получение данных о Stock через его id
        public async Task<Stock> GetStockByIdApi(int stock_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка успешного запроса к апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Stock> allStocks = ParseResponseStock.InfoStock(responseBody);
                // Фильтры
                Stock stock = allStocks.SingleOrDefault(stock => (stock.Id == stock_id));
                return stock;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        // Получение данных о stock через id rack
        public async Task<List<Stock>> GetStockInfoUsingRackIdApi(int rack_id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authorizationToken)));
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Проверка на успешный запрос к апи
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Stock> allStocks = ParseResponseStock.InfoStock(responseBody);

                // Фильтры
                List<Stock> filteredStock = allStocks.FindAll(stock => (stock.Hardware == rack_id));
                return filteredStock;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
    }

    // Описание класса
    public class Stock
    {
        public int Hardware { get; set; }
        public int Rack { get; set; }
        public int Rack_position { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
