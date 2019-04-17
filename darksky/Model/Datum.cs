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
        public double ApparentTemperatureMin { get; set; }
        public double ApparentTemperatureMax { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public double WindSpeed { get; set; }
        public double UVIndex { get; set; }

        public Datum()
        {
            ImagePath = "../Images/DefaultImage.png";
        }
    }
}
