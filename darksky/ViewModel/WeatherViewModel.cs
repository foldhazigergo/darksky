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
#region Properties
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

        private double _Temperature;
        public double Temperature
        {
            get { return _Temperature; }
            set
            {
                _Temperature = value;
                RaisePropertyChanged("Temperature");
            }
        }

        private double _ApparentTemperature;
        public double ApparentTemperature
        {
            get { return _ApparentTemperature; }
            set
            {
                _ApparentTemperature = value;
                RaisePropertyChanged("ApparentTemperature");
            }
        }

        private double _AtmosphericPressure;
        public double AtmosphericPressure
        {
            get { return _AtmosphericPressure; }
            set
            {
                _AtmosphericPressure = value;
                RaisePropertyChanged("AtmosphericPressure");
            }
        }

        private double _WindSpeed;
        public double WindSpeed
        {
            get { return _WindSpeed; }
            set
            {
                _WindSpeed = value;
                RaisePropertyChanged("WindSpeed");
            }
        }

        private double _Humidity;
        public double Humidity
        {
            get { return _Humidity; }
            set
            {
                _Humidity = value;
                RaisePropertyChanged("Humidity");
            }
        }

        private double _UVIndex;
        public double UVIndex
        {
            get { return _UVIndex; }
            set
            {
                _UVIndex = value;
                RaisePropertyChanged("UVIndex");
            }
        }
#endregion

        public WeatherViewModel()
        {
            ImagePath = "../Images/DefaultImage.png";
            MessengerInstance.Register<GenericMessage<Weather>>(this, WeatherInfoRecieved);
        }

        public void WeatherInfoRecieved(GenericMessage<Weather> genericMessageWeather)
        {
            Weather weather = genericMessageWeather.Content;
            if (weather == null || weather.currently == null)
                return;

            ImagePath = ImageHandler.Instance.GetImagePath(weather.currently.Icon);
            Temperature = weather.currently.Temperature;
            ApparentTemperature = weather.currently.ApparentTemperature;
            AtmosphericPressure = weather.currently.Pressure;
            WindSpeed = weather.currently.WindSpeed;
            Humidity = weather.currently.Humidity;
            UVIndex = weather.currently.UvIndex;
        }
    }
}
