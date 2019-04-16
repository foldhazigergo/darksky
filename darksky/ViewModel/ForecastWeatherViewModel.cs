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
                DaysOfWeek.Add(new Datum()
                {
                    ImagePath = ImageHandler.Instance.GetImagePathForecast(weather.daily.Data[i].Icon),
                    DayName = TimeStampToDayName(weather.daily.Data[i].Time),
                    TemperatureMin = weather.daily.Data[i].TemperatureMin,
                    TemperatureMax = weather.daily.Data[i].TemperatureMax,
                    ApparentTemperatureMin = weather.daily.Data[i].ApparentTemperatureMin,
                    ApparentTemperatureMax = weather.daily.Data[i].ApparentTemperatureMax,
                    Humidity = weather.daily.Data[i].Humidity,
                    Pressure = weather.daily.Data[i].Pressure,
                    WindSpeed = weather.daily.Data[i].WindSpeed,
                    UvIndex = weather.daily.Data[i].UvIndex
                });
            }
        }

        //TODO: round celsius values to INT
        // use IValueConverters in the VIEW XAML {Binding xxx, Converter=}
        // use as static resource in xaml
        // converters started, continue with min and max values

        //TODO: use TODAY, TOMORROW and NOW

        //TODO: change UI language based on location

        
        private string TimeStampToDayName(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToString("dddd");
        }
    }
}
