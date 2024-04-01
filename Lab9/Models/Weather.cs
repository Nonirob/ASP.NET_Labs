namespace Lab9.Models
{
    public class Weather
    {
        public string? Name { get; set; }
        public Data? Main { get; set; }
    }

    public class Data
    {
        public double Temp { get; set; }
    }
}

