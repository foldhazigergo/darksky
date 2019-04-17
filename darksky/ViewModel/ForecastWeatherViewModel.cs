using darksky.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darksky.ViewModel
{
    public class ForecastWeatherViewModel : ViewModelBase
    {
        public ObservableCollection<Datum> DaysOfWeek { get; set; }

        public ForecastWeatherViewModel()
        {
            DaysOfWeek = new ObservableCollection<Datum>();

            MessengerInstance.Register<GenericMessage<Weather>>(this, Notify);
        }

        private void Notify(GenericMessage<Weather> genericMessageWeather)
        {
            Weather weather = genericMessageWeather.Content;
            if (weather == null ||
                weather.daily == null ||
                weather.daily.Data == null ||
                weather.daily.Data.Count == 0)
            {
                return;
            }

            DaysOfWeek.Clear();
            for(int i=0; i<7; i++)
            {
                var dayInfo = weather.daily.Data[i];
                DaysOfWeek.Add(new Datum()
                {
                    ImagePath = ImageHandler.Instance.GetImagePathForecast(dayInfo.Icon),
                    Time = dayInfo.Time,
                    TemperatureMin = dayInfo.TemperatureMin,
                    TemperatureMax = dayInfo.TemperatureMax,
                    ApparentTemperatureMin = dayInfo.ApparentTemperatureMin,
                    ApparentTemperatureMax = dayInfo.ApparentTemperatureMax,
                    Humidity = dayInfo.Humidity,
                    Pressure = dayInfo.Pressure,
                    WindSpeed = dayInfo.WindSpeed,
                    UVIndex = dayInfo.UVIndex
                });
            }
        }

        //TODO: change UI language based on location
    }
}
