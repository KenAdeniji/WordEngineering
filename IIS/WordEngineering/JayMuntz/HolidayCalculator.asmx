<%@ WebService Language="C#" Class="HolidayCalculatorWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.ProcessLogic;

using JayMuntzCom;
	
///<summary>
///	2018-02-10	Created.	https://www.codeproject.com/Articles/11666/Dynamic-Holiday-Date-Calculator
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HolidayCalculatorWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(DateTime dated)
    {
		String	serverMapPath = System.Web.HttpContext.Current.Server.MapPath("");
		String	xmlConfigurationFilename = Path.Combine( serverMapPath, @"HolidayCalculator.xml" );

		HolidayCalculator holidayCalculator = new JayMuntzCom.HolidayCalculator
		(
			dated,
			xmlConfigurationFilename
		);
	
		string json = JsonConvert.SerializeObject(holidayCalculator.OrderedHolidays, Formatting.Indented);
		return json;
	}
}
