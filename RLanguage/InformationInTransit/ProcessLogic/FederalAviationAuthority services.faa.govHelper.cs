using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Web;

using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace InformationInTransit.ProcessLogic
{
    ///<remarks>
    ///	2015-06-21	http://services.faa.gov
	///				http://services.faa.gov/docs/services/airport
	///				http://services.faa.gov/airport/status/SFO?format=application/xml
	///	2015-06-22	http://www.codediesel.com/data/international-airport-codes-download/	
    ///</remarks
    public static partial class FederalAviationAuthorityFAAHelper
    {
        public static void Main(string[] argv)
        {
			AirportStatusContainer airportStatus = new AirportStatusContainer();
			airportStatus.Request("SFO");
			System.Console.WriteLine(airportStatus);
        }

        public class AirportStatusContainer
        {
            public String Delay { get; set; }
			public String IATA { get; set; }
			public String Name { get; set; }
			public String State { get; set; }
			
			public String Visibility { get; set; }
			public String Weather { get; set; }

			public String Temp { get; set; }
			public String Wind { get; set; }

			public String ICAO { get; set; }
			public String City { get; set; }
			
            public override string ToString()
            {
                return String.Format
                (
                    Rendering,
					Delay,
                    IATA,
					State,
					Name,
					Visibility,
					Weather,
					Temp,
					Wind,
					ICAO,
					City
                );
            }

            ///<remarks>
            ///	airportCode. Required. The three letter airport code for which you wish to retrieve data, e.g., "IAD"
            ///</remarks>
            public void Request
            (
                string	airportCode
            )
            {
                String url = String.Format
                (
                    REQUEST_URL_FORMAT,
                    airportCode
                );
				try
				{
					XDocument xDocument = XDocument.Load(url);
					System.Console.WriteLine(xDocument);
					Delay = xDocument.Descendants("Delay").FirstOrDefault().Value;
					IATA = xDocument.Descendants("IATA").FirstOrDefault().Value;
					Name = xDocument.Descendants("Name").FirstOrDefault().Value;
					State = xDocument.Descendants("State").FirstOrDefault().Value;
					
					XElement weatherMajor = xDocument.Descendants("Weather").FirstOrDefault();
					Visibility = weatherMajor.Descendants("Visibility").FirstOrDefault().Value;
					Weather = weatherMajor.Descendants("Weather").FirstOrDefault().Value;
					Temp = weatherMajor.Descendants("Temp").FirstOrDefault().Value;
					Wind = weatherMajor.Descendants("Wind").FirstOrDefault().Value;
					
					ICAO = xDocument.Descendants("ICAO").FirstOrDefault().Value;
					City = xDocument.Descendants("City").FirstOrDefault().Value;
				}
				catch (Exception ex)
				{
				}	
            }

            public const string Rendering = "Delay: {0}<br> IATA: {1}<br> State: {2}<br> Name: {3} <br>" + 
				"Visibility: {4}<br> Weather: {5}<br> Temp: {6}<br> Wind: {7}<br>" +
				"ICAO: {8}<br> City: {9}<br>";
            public const string REQUEST_URL_FORMAT = "http://services.faa.gov/airport/status/{0}?format=application/xml";
        }
    }
}
