using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using gov.weather.www;

namespace WordEngineering
{
    /// <summary>
    /// http://weather.gov/forecasts/xml/DWMLgen/wsdl/ndfdXML.wsdl
    /// </summary>
    public partial class WeatherForecast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var weather = new gov.weather.www.ndfdXML();
            var result = weather.LatLonListZipCode("80130");
            var denWeather =
                weather.GmlTimeSeries(
                    "39.5432,-104.939",
                    DateTime.Parse("12/31/09"),
                    DateTime.Parse("01/02/10"),
                    WebTest.gov.weather.www.compTypeType.Between,
                    WebTest.gov.weather.www.featureTypeType.Forecast_Gml2AllWx,
                    "maxt,mint,wx");
            Response.Write(denWeather);
        }
    }
}