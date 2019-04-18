using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace darksky.Converters
{
    public class ApparentTemperatureToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Properties.Resources.FeelsLike + ": - °C";

            int intValue = (int)Math.Round((double)value);
            return Properties.Resources.FeelsLike + ": " + intValue.ToString() + " °C";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
