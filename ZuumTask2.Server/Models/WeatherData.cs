namespace ZuumTask2.Server.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Temperature { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
