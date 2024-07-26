using Newtonsoft.Json;
using ZuumTask2.Server.Models;

namespace ZuumTask2.Server.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherData> GetWeatherDataAsync(string city, string country)
        {
            // Assuming we use OpenWeatherMap API
            var apiKey = _configuration["WeatherApiKey"];
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid={apiKey}&units=metric";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve weather data");
            }

            var responseData = await response.Content.ReadAsStringAsync();
            var weatherApiResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(responseData);

            return new WeatherData
            {
                City = city,
                Country = country,
                Temperature = weatherApiResponse.Main.Temp,
                LastUpdated = DateTime.UtcNow
            };
        }
    }

}
