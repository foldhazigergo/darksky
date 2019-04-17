using darksky.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace darksky.Converters
{
    public class ApparentTemperatureMinMaxToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var obj = value as Datum;
            int minTemperature = (int)Math.Round(obj.TemperatureMin);
            int maxTemperature = (int)Math.Round(obj.TemperatureMax);
            return "Feels like: " + minTemperature.ToString() + " °C - " + maxTemperature.ToString() + " °C";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
