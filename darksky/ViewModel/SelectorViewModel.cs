using darksky.BackendService;
using darksky.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace darksky.ViewModel
{
    public class SelectorViewModel : ViewModelBase
    {
        #region Properties
        private Language _SelectedLanguage;
        public Language SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set
            {
                _SelectedLanguage = value;
                UpdateLanguageSettings(_SelectedLanguage);
            }
        }

        private List<Language> _Languages;
        public List<Language> Languages
        {
            get { return _Languages; }
            set { _Languages = value; }
        }

        private Location _SelectedLocation;
        public Location SelectedLocation
        {
            get { return _SelectedLocation; }
            set
            {
                _SelectedLocation = value;
                GetWeatherForLocationAsync(_SelectedLocation);
                RaisePropertyChanged("SelectedLocation");
            }
        }

        private List<Location> _Locations;
        public List<Location> Locations
        {
            get { return _Locations; }
            set { _Locations = value; }
        }
        #endregion

        public SelectorViewModel()
        {
            Languages = new List<Language>()
            {
                new Language("Magyar", "hu-HU"),
                new Language("English", "en-US")
            };
            SelectedLanguage = Languages.First( lang => lang.Code == ConfigurationManager.AppSettings.Get("DefaultCulture"));


            Locations = new List<Location>
            {
                new Location("Budapest", "47.4813602", "18.9902207"),
                new Location("Luxembourg", "49.8154049", "5.8531438"),
                new Location("Debrecen", "47.5310609", "21.5200997"),
                new Location("Pécs", "46.0778307", "18.1805419"),
                new Location("Vienna", "48.220778", "16.3100205"),
                new Location("Prague", "50.0598058", "14.3255419"),
                new Location("München", "48.155004", "11.4717963"),
                new Location("Amsterdam", "52.3547322", "4.8285837")
            };

            //Set a location to start with in order to trigger backend calls and update the UI when the app starts
            SelectedLocation = new Location();
            SelectedLocation = Locations[0];
        }

        private async void GetWeatherForLocationAsync(Location loc)
        {
            Weather weather = await DarkSky.Instance.GetWeather(loc);
            MessengerInstance.Send<GenericMessage<Weather>>(new GenericMessage<Weather>(weather));
        }

        private void UpdateLanguageSettings(Language language)
        {
            string currentLanguageCode = ConfigurationManager.AppSettings.Get("DefaultCulture");
            if (currentLanguageCode != language.Code)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["DefaultCulture"].Value = language.Code;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show(Properties.Resources.RestartAppForChanges);
            }

        }
    }
}
