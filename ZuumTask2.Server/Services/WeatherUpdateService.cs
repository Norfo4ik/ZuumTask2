using ZuumTask2.Server.Data;

namespace ZuumTask2.Server.Services
{
    public class WeatherUpdateService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<WeatherUpdateService> _logger;
        private readonly string[] _cities = { "Riga,LV", "Daugavpils, LV", "Kyiv,UA", "Kharkiv, UA" };

        public WeatherUpdateService(IServiceProvider services, ILogger<WeatherUpdateService> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var weatherService = scope.ServiceProvider.GetRequiredService<IWeatherService>();
                    var context = scope.ServiceProvider.GetRequiredService<WeatherDbContext>();

                    foreach (var cityCountry in _cities)
                    {
                        var parts = cityCountry.Split(',');
                        var weatherData = await weatherService.GetWeatherDataAsync(parts[0], parts[1]);
                        context.WeatherData.Add(weatherData);
                    }

                    await context.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
