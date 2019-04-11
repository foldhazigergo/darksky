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
        // dark sky api key: f1be72a5165735c754a9cbf6bbd205a7
        // must supply in all api calls
        // example call 
        // GET https://api.darksky.net/forecast/f1be72a5165735c754a9cbf6bbd205a7/37.8267,-122.423

        private HttpClient client;

        public DarkSky()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Weather> GetWeather(Location loc)
        {
            //TODO: parse LatLng coordinates from loc here
            var url = "https://api.darksky.net/forecast/f1be72a5165735c754a9cbf6bbd205a7/47.4813602,18.9902207?exclude=[minutely,hourly,daily,alerts,flags]";
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
                    var data = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("------- RES: " + data);
                    var deserializedData = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(data));

                    return deserializedData;
                }
                else
                    return default(T);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return default(T);
            }
        }
    }
}
