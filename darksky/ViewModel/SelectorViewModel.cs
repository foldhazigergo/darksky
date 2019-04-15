using darksky.BackendService;
using darksky.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace darksky.ViewModel
{
    public class SelectorViewModel : ViewModelBase
    {
        private Location _SelectedLocation;
        public Location SelectedLocation
        {
            get { return _SelectedLocation; }
            set
            {
                _SelectedLocation = value;
                GetWeatherForLocationAsync(SelectedLocation);
                RaisePropertyChanged("SelectedLocation");
            }
        }

        private List<Location> _Locations;
        public List<Location> Locations
        {
            get { return _Locations; }
            set { _Locations = value; }
        }

        public SelectorViewModel()
        {
            Locations = new List<Location>();
            Locations.Add(new Location("Budapest", "47.4813602", "18.9902207"));
            Locations.Add(new Location("Luxembourg", "49.8154049", "5.8531438"));
            Locations.Add(new Location("Debrecen", "47.5310609", "21.5200997"));
            Locations.Add(new Location("Pécs", "46.0778307", "18.1805419"));
            Locations.Add(new Location("Vienna", "48.220778", "16.3100205"));
            Locations.Add(new Location("Prague", "50.0598058", "14.3255419"));
            Locations.Add(new Location("München", "48.155004", "11.4717963"));
            Locations.Add(new Location("Amsterdam", "52.3547322", "4.8285837"));

            SelectedLocation = new Location();
            SelectedLocation = Locations[0];
        }

        private async void GetWeatherForLocationAsync(Location loc)
        {
            Weather weather = await DarkSky.Instance.GetWeather(loc);
            MessengerInstance.Send<GenericMessage<Weather>>(new GenericMessage<Weather>(weather));
        }
    }
}
