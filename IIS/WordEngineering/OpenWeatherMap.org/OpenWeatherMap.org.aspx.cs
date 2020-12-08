using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json;

using System.Net;

using InformationInTransit.ProcessLogic;

public partial class OpenWeatherMapOrgPage : System.Web.UI.Page
{
    public string City
	{
        get { return city.Text; }
        set { city.Text = value; }
	}

    public string WeatherOutput
	{
        get { return weatherOutput.Text; }
        set { weatherOutput.Text = value; }
	}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            City = "London";
        }
        Processing();
    }
	
	protected void QuerySubmit_Click(Object sender, EventArgs e)
	{
		Processing();
	}
	
	protected void Processing()
	{
		WeatherOutput = RetrieveWeatherForecast(City);
	}
	
	public static string RetrieveWeatherForecast(string location)
	{
		var url = "http://api.openweathermap.org/data/2.5/weather?q=" + location + "&mode=json";
		var syncClient = new WebClient();
		string formatted = "";
		try
		{
			var content = syncClient.DownloadString(url);
			dynamic obj = JsonConvert.DeserializeObject(content);

			formatted = String.Format
			(
				OpenWeatherMapOrg.WeatherForecastFormat,
				obj.coord.lat,
				obj.coord.lon,
				((long)obj.sys.sunrise).FromUnixTime(),
				((long)obj.sys.sunset).FromUnixTime(),
				obj.weather[0].main,
				obj.weather[0].description,
				obj.main.temp,
				obj.main.humidity,
				obj.main.pressure,
				obj.main.temp_min,
				obj.main.temp_max,
				obj.wind.speed,
				obj.wind.deg
			);
		}
		catch (Exception ex)
		{
		}
		return formatted;
	}
	
public class OpenWeatherMap
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
