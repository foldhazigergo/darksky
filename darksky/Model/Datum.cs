using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darksky.Model
{
    public class Datum
    {
        public string ImagePath { get; set; }
        public string DayName { get; set; }
        public double Time { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }

        public string Temperature
        {
            get
            {
                return TemperatureMin + " - " + TemperatureMax;
            }
        }
        public string ApparentTemperatureMin { get; set; }
        public string ApparentTemperatureMax { get; set; }
        public string ApparentTemperature
        {
            get
            {
                return ApparentTemperatureMin + " - " + ApparentTemperatureMax;
            }
        }

        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public string WindSpeed { get; set; }
        public string UvIndex { get; set; }

        public Datum()
        {
            ImagePath = "../Images/DefaultImage.png";
        }
    }
}
