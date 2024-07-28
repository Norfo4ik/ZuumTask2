using Microsoft.EntityFrameworkCore;
using ZuumTask2.Server.Data;
using ZuumTask2.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the DbContext to use SQL Server
builder.Services.AddDbContext<WeatherDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the weather service and HTTP client
builder.Services.AddHttpClient<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

// Register the background service for periodic updates
builder.Services.AddHostedService<WeatherUpdateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
