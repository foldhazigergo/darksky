using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace darksky.Converters
{
    public class TemperatureToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null || value.ToString() == "")
                return "Temperature: - °C";

            string stringValue = value.ToString();
            double doubleValue = double.Parse(stringValue, CultureInfo.InvariantCulture);
            int intValue = (int)Math.Round(doubleValue);
            return "Temperature: " + intValue.ToString() + " °C";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
