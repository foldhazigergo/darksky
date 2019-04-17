using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace darksky.Converters
{
    public class TimeStampToDayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime timestamp = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            timestamp = timestamp.AddSeconds((double)value).ToLocalTime();

            string today = DateTime.Now.ToString("dddd");
            string tomorrow = DateTime.Now.AddDays(1).ToString("dddd");

            if (string.Compare(today,timestamp.ToString("dddd")) == 0)
                return "Today";
            else if(string.Compare(tomorrow, timestamp.ToString("dddd")) == 0)
                return "Tomorrow";
            else
                return timestamp.ToString("dddd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
