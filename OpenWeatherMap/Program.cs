using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace OpenWeatherMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var countryCode = "US";
            int zipCode = 60601;
            var APIKey = "5c4d5f0106f416d779053927067c8b3d";
            var geoCoderURL = $"http://api.openweathermap.org/geo/1.0/zip?zip={zipCode},{countryCode}&appid={APIKey}";
            var georesponse = client.GetAsync(geoCoderURL).Result;
            double latitude = JObject.Parse(georesponse).Latitude;



        }
    }
}