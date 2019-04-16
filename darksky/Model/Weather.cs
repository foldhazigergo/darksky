using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darksky.Model
{
    public class Weather
    {
        public string latitude;
        public string longitude;
        public string timezone;
        public Currently currently;
        public Daily daily;
    }
}
