using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace darksky
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            string language = ConfigurationManager.AppSettings.Get("DefaultCulture");
            var culture = new System.Globalization.CultureInfo(language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
