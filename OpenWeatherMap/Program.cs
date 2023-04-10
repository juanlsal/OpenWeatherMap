using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace OpenWeatherMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Enter a zip code to find out the temperature!");
            int zipCode = int.Parse(Console.ReadLine());

            string key = System.IO.File.ReadAllText("appsettings.json");
            string APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            var geoCoderURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid={APIkey}";
            var geoResponse = client.GetStringAsync(geoCoderURL).Result;

            var temp = double.Parse(JObject.Parse(geoResponse)["main"]["temp"].ToString());
            var low = double.Parse(JObject.Parse(geoResponse)["main"]["temp_min"].ToString());
            var high = double.Parse(JObject.Parse(geoResponse)["main"]["temp_max"].ToString());
            var city = JObject.Parse(geoResponse)["name"].ToString();
            Console.WriteLine($"The temperature in {city} is {temp} fahrenheit");
            Console.WriteLine($"It will be a low of {low} and a high of {high}");

        }
    }
}