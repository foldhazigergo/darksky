using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darksky.Model
{
    public class Location
    {
        private string _CityName;
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }

        private string _Latitude;
        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        private string _Longitude;
        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        public Location(string cityName = "", string latitude = "", string longitude = "")
        {
            CityName = cityName;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
