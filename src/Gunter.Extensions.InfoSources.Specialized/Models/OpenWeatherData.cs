﻿namespace Gunter.Extensions.InfoSources.Specialized.Models
{
    public class OpenWeatherData
    {
        public double Temperature { get; set; } = 0;
        public double Pressure { get; set; } = 0;
        public int Humidity { get; set; } = 0;

        public double MinTemp { get; set; } = 0;
        public double MaxTemp { get; set; } = 0;

        public double SeaLevel { get; set; } = 0;
        public double GroundLevel { get; set; } = 0;

        public double RainProbability { get; set; } = 0;

        public static OpenWeatherData? FromOpenWeatherResponseModel(OpenWeatherResponseModel.RootObject model)
        => model is null ? null : new OpenWeatherData
        {
            Temperature = model.main.temp,
            GroundLevel = model.main.grnd_level,
            Humidity = model.main.humidity,
            MaxTemp = model.main.temp_max,
            MinTemp = model.main.temp_min,
            Pressure = model.main.pressure,
            SeaLevel = model.main.sea_level,
            RainProbability = model.rain.rain
        };
    }

    public class OpenWeatherResponseModel
    {
        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public Main main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public int humidity { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double sea_level { get; set; }
            public double grnd_level { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }

        public class Rain
        {
            public double rain { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public double message { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class RootObject
        {
            public Coord coord { get; set; }
            public List<Weather> weather { get; set; }
            public string @base { get; set; }
            public Main main { get; set; }
            public Wind wind { get; set; }
            public Rain rain { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }
    }
}
