using ZuumTask2.Server.Models;

namespace ZuumTask2.Server.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherDataAsync(string city, string country);
    }
}
