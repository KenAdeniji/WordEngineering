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
    ///	2015-06-16	http://weblogs.asp.net/scottgu/using-linq-to-xml-and-how-to-build-a-custom-rss-feed-reader-with-it
    ///</remarks
    public static partial class EarthToolsHelper
    {
        public static void Main(string[] argv)
        {
        }

        public class ElevationHeightAboveSeaLevelContainer
        {
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }
            public decimal Meters { get; set; }
            public decimal Feet { get; set; }

            public override string ToString()
            {
                return String.Format
                (
                    Rendering,
                    Meters,
                    Feet
                );
            }

            ///<remarks>
            ///	2015-06-16	http://www.codedisqus.com/0mxgeUUkgj/how-to-call-a-webservice-that-wasnt-developed-in-net.html
            ///	Elevation/Height Above Sea Level
            ///</remarks>
            public void Request
            (
                decimal latitude,
                decimal longitude
            )
            {
                String url = String.Format
                (
                    REQUEST_URL_FORMAT,
                    "height",
                    latitude,
                    longitude
                );
                XDocument xDocument = XDocument.Load(url);
         
                //var latitude = xDocument.Descendants("latitude").FirstOrDefault().Value;
                //var longitude = xDocument.Descendants("longitude").FirstOrDefault().Value;
                
                Meters = System.Convert.ToDecimal(xDocument.Descendants("meters").FirstOrDefault().Value);
                Feet = System.Convert.ToDecimal(xDocument.Descendants("feet").FirstOrDefault().Value);
            }

            public const string Rendering = "Meters: {0} Feet: {1}";
            public const string REQUEST_URL_FORMAT = "http://www.earthtools.org/{0}/{1}/{2}";
        }
        
        public class SunriseAndSunsetTimesContainer
        {
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }
            public int DateDay { get; set; }
            public int DateMonth { get; set; }
            public int DateTimezone { get; set; }
            public string DateDaylightSavingTimeDST { get; set; }
            
            public string MorningSunrise { get; set; }
            public string MorningTwilightCivil { get; set; }
            public string MorningTwilightNautical { get; set; }
            public string MorningTwilightAstronomical { get; set; }

            public string EveningSunset { get; set; }
            public string EveningTwilightCivil { get; set; }
            public string EveningTwilightNautical { get; set; }
            public string EveningTwilightAstronomical { get; set; }

            public override string ToString()
            {
                return String.Format
                (
                    Rendering,

                    MorningSunrise,
                    MorningTwilightCivil,
                    MorningTwilightNautical,
                    MorningTwilightAstronomical,

                    EveningSunset,
                    EveningTwilightCivil,
                    EveningTwilightNautical,
                    EveningTwilightAstronomical
                );
            }

            public void Request
            (
                decimal latitude,
                decimal longitude,
                int dateDay,
                int dateMonth,
                int dateTimezone,
                int dateDaylightSavingTimeDST
            )
            {
                String url = String.Format
                (
                    REQUEST_URL_FORMAT,
                    "sun",
                    latitude,
                    longitude,
                    dateDay,
                    dateMonth,
                    dateTimezone,
                    dateDaylightSavingTimeDST
                );
                XDocument xDocument = XDocument.Load(url);
                //var latitude = xDocument.Descendants("latitude").FirstOrDefault().Value;
                //var longitude = xDocument.Descendants("longitude").FirstOrDefault().Value;

                var morning = xDocument.Descendants("morning");
                MorningSunrise = morning.Descendants("sunrise").FirstOrDefault().Value;
                var morningTwilight = morning.Descendants("twilight");
                MorningTwilightCivil = morningTwilight.Descendants("civil").FirstOrDefault().Value;
                MorningTwilightNautical = morningTwilight.Descendants("nautical").FirstOrDefault().Value;
                MorningTwilightAstronomical = morningTwilight.Descendants("astronomical").FirstOrDefault().Value;

                var evening = xDocument.Descendants("evening");
                EveningSunset = evening.Descendants("sunset").FirstOrDefault().Value;
                var eveningTwilight = evening.Descendants("twilight");
                EveningTwilightCivil = eveningTwilight.Descendants("civil").FirstOrDefault().Value;
                EveningTwilightNautical = eveningTwilight.Descendants("nautical").FirstOrDefault().Value;
                EveningTwilightAstronomical = eveningTwilight.Descendants("astronomical").FirstOrDefault().Value;
            }

            public const string Rendering =
"Morning Sunrise: {0} Twilight Civil: {1} Nautical: {2} Astronomical: {3} <br>" +
"Evening Sunset: {4} Twilight Civil: {5} Nautical: {6} Astronomical: {7}";

            public const string REQUEST_URL_FORMAT = "http://www.earthtools.org/{0}/{1}/{2}/{3}/{4}/{5}/{6}";
        }

        public class TimeZoneContainer
        {
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }

            public string Offset { get; set; }
            public string Suffix { get; set; }
            public string LocalTime { get; set; }
            public string IsoTime { get; set; }
            public string UtcTime { get; set; }
            public string DaylightSavingTimeDST { get; set; }

            public override string ToString()
            {
                return String.Format
                (
                    Rendering,
                    Offset,
                    Suffix,
                    LocalTime,
                    IsoTime,
                    UtcTime,
                    DaylightSavingTimeDST
                );
            }

            public void Request
            (
                decimal latitude,
                decimal longitude
            )
            {
                String url = String.Format
                (
                    REQUEST_URL_FORMAT,
                    "timezone",
                    latitude,
                    longitude
                );
                XDocument xDocument = XDocument.Load(url);
                //var latitude = xDocument.Descendants("latitude").FirstOrDefault().Value;
                //var longitude = xDocument.Descendants("longitude").FirstOrDefault().Value;
                Offset = xDocument.Descendants("offset").FirstOrDefault().Value;
                Suffix = xDocument.Descendants("suffix").FirstOrDefault().Value;
                LocalTime = xDocument.Descendants("localtime").FirstOrDefault().Value;
                IsoTime = xDocument.Descendants("isotime").FirstOrDefault().Value;
                UtcTime = xDocument.Descendants("utctime").FirstOrDefault().Value;
                DaylightSavingTimeDST = xDocument.Descendants("dst").FirstOrDefault().Value;
            }

            public const string Rendering = "Offset: {0} Suffix: {1}<br>" +
                "LocalTime: {2} IsoTime: {3} UtcTime: {4}<br>" +
                "Daylight Saving Time (DST): {5}";
            public const string REQUEST_URL_FORMAT = "http://www.earthtools.org/{0}/{1}/{2}";
        }
    }
}
