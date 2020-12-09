using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Collections.ObjectModel;

//using Newtonsoft.Json;

using System.Net;

namespace InformationInTransit.ProcessLogic
{
    ///	<summary>
	///	2015-06-24	http://blog.anthonybaker.me/2013/05/how-to-consume-json-rest-api-in-net.html
	///				http://json2csharp.com
	///				http://stackoverflow.com/questions/26766861/how-to-get-a-specific-part-of-the-data-from-a-rest-webservice-responce
	///	</summary>
	public static class OpenWeatherMapOrg
    {
		public const string WeatherForecastFormat = 
			"Latitude: {0}<br>Longitude: {1}<br>Sunrise: {2}<br>Sunset: {3}<br>" +
			"Weather Main: {4}<br>Weather Description: {5}<br>" +
			"Temperature: {6}<br>Humidity: {7}<br>Pressure: {8}<br>" +
			"Minimum Temperature: {9}<br>Maximum Temperature: {10}<br>" +
			"Wind Speed: {11}<br>Wind Degree: {12}";
        public static void Main(string[] argv)
        {
			//RetrieveWeatherForecast(argv[0]);
        }

		/*
		public static string RetrieveWeatherForecast(string location)
		{
			var url = "http://api.openweathermap.org/data/2.5/weather?q=" + location + "&mode=json";
			var syncClient = new WebClient();
			var content = syncClient.DownloadString(url);
			
			dynamic obj = JsonConvert.DeserializeObject(content);

			System.Console.WriteLine(content);
			System.Console.WriteLine(obj.coord.lon + "  " + obj.coord.lat);
			string formatted = String.Format
			(
				WeatherForecastFormat,
				obj.coord.lat,
				obj.coord.lon
			);
			System.Console.WriteLine(formatted);
			return formatted;
		}
		*/
		
public class OpenWeatherMapClass
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public int humidity { get; set; }
        public double pressure { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double gust { get; set; }
        public int deg { get; set; }
    }



    public class Clouds
    {
        public int all { get; set; }
    }

    public class Root
    {
        public Coord coord { get; set; }
        public Sys sys { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Dictionary<string,double> rain { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
    }
}
