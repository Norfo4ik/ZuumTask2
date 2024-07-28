using Microsoft.EntityFrameworkCore;
using ZuumTask2.Server.Data;
using ZuumTask2.Server.Services;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        // Configure the DbContext to use SQL Server
        services.AddDbContext<WeatherDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Register the weather service and HTTP client
        services.AddHttpClient<IWeatherService, WeatherService>();
        services.AddScoped<IWeatherService, WeatherService>();

        // Register the background service for periodic updates
        services.AddHostedService<WeatherUpdateService>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("https://localhost:5173", "https://localhost:5266", "https://localhost:5266/api/weather/history")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod().
                                  AllowCredentials());

        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {        
        app.UseRouting();
        app.UseCors("AllowSpecificOrigin");
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
