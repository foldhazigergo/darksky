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
            Temperature = "";
            ApparentTemperature = "";
            AtmosphericPressure = "";
            WindSpeed = "";
            Humidity = "";
            UVIndex = "";
            MessengerInstance.Register<GenericMessage<Weather>>(this, Notify);
        }

        public void Notify(GenericMessage<Weather> genericMessageWeather)
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
