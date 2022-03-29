using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    internal class AccWeatherHelper
    {
        private const string BASE_URL = "http://dataservice.accuweather.com/";
        private const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language={2}";
        private const string CURRENTCONDITION_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        private const string API_KEY = "sVj5EAYAsXeZZhZNuldObDTGjRuQ3GF5";

        public static async Task<List<City>> GetCities(string query)
        {
            var cityList = new List<City>();

            var url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query, "en-us");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                cityList = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cityList;
        }

        public static async Task<CurrentConditions> GetConditions(string cityKey)
        {
            var conditions = new CurrentConditions();

            var url = BASE_URL + string.Format(CURRENTCONDITION_ENDPOINT, cityKey, API_KEY);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                conditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
            }

            return conditions;
        }
    }
}
