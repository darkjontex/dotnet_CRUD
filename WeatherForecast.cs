using System;

namespace CrudExample
{
    public class WeatherForecast
    {
        public int Id { get;set; }
        
        public string Cidade { get; set; }

        public int TemperaturaC { get; set; }

        public int TemperatureF => 32 + (int)(TemperaturaC / 0.5556);

        public DateTime Data { get; set; }        
        
    }
}
