using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darksky
{
    public class ImageHandler
    {
        private static ImageHandler instance;

        private ImageHandler() { }

        public static ImageHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImageHandler();
                }
                return instance;
            }
        }

        public string GetImagePath(string icon)
        {
            string path = "../Images/DefaultImage.png";
            switch (icon)
            {
                case "clear-day":
                    path = "../Images/WeatherIcons/clear.png";
                    break;
                case "clear-night":
                    path = "../Images/WeatherIcons/clearnight.png";
                    break;
                case "rain":
                    path = "../Images/WeatherIcons/rain01.png";
                    break;
                case "snow":
                    path = "../Images/WeatherIcons/snow.png";
                    break;
                case "sleet":
                    path = "../Images/WeatherIcons/sleet.png";
                    break;
                case "wind":
                    path = "../Images/WeatherIcons/windy.png";
                    break;
                case "fog":
                    path = "../Images/WeatherIcons/fog.png";
                    break;
                case "cloudy":
                    path = "../Images/WeatherIcons/cloudy.png";
                    break;
                case "partly-cloudy-day":
                    path = "../Images/WeatherIcons/partlycloudy.png";
                    break;
                case "partly-cloudy-night":
                    path = "../Images/WeatherIcons/partlycloudynight.png";
                    break;
                default:
                    path = "../Images/DefaultImage.png";
                    break;
            }

            return path;
        }

        public string GetImagePathForecast(string icon)
        {
            string path = "../Images/DefaultImage.png";
            switch (icon)
            {
                case "clear-day":
                case "clear-night":
                    path = "../Images/WeatherIcons/clear.png";
                    break;
                case "rain":
                    path = "../Images/WeatherIcons/rain01.png";
                    break;
                case "snow":
                    path = "../Images/WeatherIcons/snow.png";
                    break;
                case "sleet":
                    path = "../Images/WeatherIcons/sleet.png";
                    break;
                case "wind":
                    path = "../Images/WeatherIcons/windy.png";
                    break;
                case "fog":
                    path = "../Images/WeatherIcons/fog.png";
                    break;
                case "cloudy":
                    path = "../Images/WeatherIcons/cloudy.png";
                    break;
                case "partly-cloudy-day":
                case "partly-cloudy-night":
                    path = "../Images/WeatherIcons/partlycloudy.png";
                    break;
                default:
                    path = "../Images/DefaultImage.png";
                    break;
            }

            return path;
        }
    }
}
