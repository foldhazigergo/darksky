using darksky.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace darksky.BackendService
{
    public class DarkSky
    {
        private static DarkSky instance;

        private DarkSky() { }

        public static DarkSky Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DarkSky();
                    instance.client = new HttpClient();
                    instance.client.DefaultRequestHeaders.Accept.Clear();
                    instance.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return instance;
            }
        }

        private const string API_KEY = "f1be72a5165735c754a9cbf6bbd205a7";

        private HttpClient client;

        public async Task<Weather> GetWeather(Location loc)
        {
            string url = "https://api.darksky.net/forecast/" + API_KEY + "/" + loc.Latitude + "," + loc.Longitude + "?units=si&exclude=[minutely,hourly,alerts,flags]";
            Weather weather = await Get<Weather>(url);
          
            return weather;
        }

        /// <summary>
        /// Gets an object from the specified Url
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="uri">Url to get from</param>
        /// <returns>The object, or default if not succeeded</returns>
        public async Task<T> Get<T>(string uri)
        {
            return await Get<T>(new UriBuilder(uri).Uri);
        }

        public async Task<T> Get<T>(Uri uri)
        {
            try
            {
                Debug.WriteLine("------- GET: " + uri);
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("------- RESPONSE: " + data);
                    var deserializedData = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(data));

                    return deserializedData;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return default(T);
            }
        }
    }
}
