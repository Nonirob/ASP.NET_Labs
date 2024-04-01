using Lab9.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab9.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = "dec76bbaf8f2ecf4ef1fde9d63f75f62";
        }

        public async Task<IViewComponentResult> InvokeAsync(string region)
        {
            string standardRegion = "Kiev";
            string apiUrl;
            if (string.IsNullOrEmpty(region))
            {
                apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={standardRegion}&appid={_apiKey}";
            }
            else
            {
                apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={region}&appid={_apiKey}";
            }

            var response = await _httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return Content("Something went wrong...");
            }
            
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            var weather = JsonConvert.DeserializeObject<Weather>(content);
            Console.WriteLine(weather);
            return View(weather);
        }
    }
}