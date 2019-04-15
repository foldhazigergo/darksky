using darksky.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace darksky.ViewModel
{
    public class WeatherViewModel : ViewModelBase
    {
        //../Images/WeatherIcons/partlycloudy.png"
        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set
            {
                _ImagePath = value;
                RaisePropertyChanged("ImagePath");
            }
        }

        private string _Temperature;
        public string Temperature
        {
            get { return _Temperature; }
            set
            {
                _Temperature = value;
                RaisePropertyChanged("Temperature");
            }
        }

        private string _ApparentTemperature;
        public string ApparentTemperature
        {
            get { return _ApparentTemperature; }
            set
            {
                _ApparentTemperature = value;
                RaisePropertyChanged("ApparentTemperature");
            }
        }

        private string _AtmosphericPressure;
        public string AtmosphericPressure
        {
            get { return _AtmosphericPressure; }
            set
            {
                _AtmosphericPressure = value;
                RaisePropertyChanged("AtmosphericPressure");
            }
        }

        private string _WindSpeed;
        public string WindSpeed
        {
            get { return _WindSpeed; }
            set
            {
                _WindSpeed = value;
                RaisePropertyChanged("WindSpeed");
            }
        }

        private string _Humidity;
        public string Humidity
        {
            get { return _Humidity; }
            set
            {
                _Humidity = value;
                RaisePropertyChanged("Humidity");
            }
        }

        private string _UVIndex;
        public string UVIndex
        {
            get { return _UVIndex; }
            set
            {
                _UVIndex = value;
                RaisePropertyChanged("UVIndex");
            }
        }

        public WeatherViewModel()
        {
            ImagePath = "../Images/DefaultImage.png";
            Temperature = "-";
            ApparentTemperature = "-";
            AtmosphericPressure = "-";
            WindSpeed = "-";
            Humidity = "-";
            UVIndex = "-";
            MessengerInstance.Register<GenericMessage<Weather>>(this, Notify);
        }

        public void Notify(GenericMessage<Weather> genericMessageWeather)
        {
            Weather weather = genericMessageWeather.Content;
            //ImagePath = weather.icon.... +logic
            if (weather == null || weather.currently == null)
                return;

            UpdateCurrentImagePath(weather.currently.Icon);
            Temperature = weather.currently.Temperature;
            ApparentTemperature = weather.currently.ApparentTemperature;
            AtmosphericPressure = weather.currently.Pressure;
            WindSpeed = weather.currently.WindSpeed;
            Humidity = weather.currently.Humidity;
            UVIndex = weather.currently.UvIndex;
        }

        private void UpdateCurrentImagePath(string icon)
        {
            if (icon == null || icon == "")
            {
                ImagePath = "../Images/DefaultImage.png";
                return;
            }

            switch (icon)
            {
                case "clear-day":
                    ImagePath = "../Images/WeatherIcons/clear.png";
                    break;
                case "clear-night":
                    ImagePath = "../Images/WeatherIcons/clearnight.png";
                    break;
                case "rain":
                    ImagePath = "../Images/WeatherIcons/rain01.png";
                    break;
                case "snow":
                    ImagePath = "../Images/WeatherIcons/snow.png";
                    break;
                case "sleet":
                    ImagePath = "../Images/WeatherIcons/sleet.png";
                    break;
                case "wind":
                    ImagePath = "../Images/WeatherIcons/windy.png";
                    break;
                case "fog":
                    ImagePath = "../Images/WeatherIcons/fog.png";
                    break;
                case "cloudy":
                    ImagePath = "../Images/WeatherIcons/cloudy.png";
                    break;
                case "partly-cloudy-day":
                    ImagePath = "../Images/WeatherIcons/partlycloudy.png";
                    break;
                case "partly-cloudy-night":
                    ImagePath = "../Images/WeatherIcons/partlycloudynight.png";
                    break;
                default:
                    ImagePath = "../Images/DefaultImage.png";
                    break;
            }
        }
    }
}
