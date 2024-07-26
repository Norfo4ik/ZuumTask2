using Microsoft.AspNetCore.Mvc;
using ZuumTask2.Server.Services;
using ZuumTask2.Server.Data;


namespace ZuumTask2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly WeatherDbContext _context;

        public WeatherController(IWeatherService weatherService, WeatherDbContext context)
        {
            _weatherService = weatherService;
            _context = context;
        }

        [HttpGet("{city}/{country}")]
        public async Task<IActionResult> GetWeather(string city, string country)
        {
            var weatherData = await _weatherService.GetWeatherDataAsync(city, country);
            _context.WeatherData.Add(weatherData);
            await _context.SaveChangesAsync();
            return Ok(weatherData);
        }

        [HttpGet("history")]
        public IActionResult GetWeatherHistory()
        {
            var data = _context.WeatherData.ToList();
            return Ok(data);
        }
    }
}
