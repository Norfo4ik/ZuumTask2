using ZuumTask2.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ZuumTask2.Server.Data
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<WeatherData> WeatherData { get; set; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }
    }
}