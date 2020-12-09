<%@ WebService Language="C#" Class="WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMovingWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Linq;

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

///<summary>
///	2006-10-28T09:23:22	Wrote to the Roman empire asking to release Paul, and yet she just wasn't moving.
///	2019-12-09			Created.
///	2019-12-09T17:38:00	https://stackoverflow.com/questions/23527545/linq-query-any-of-the-properties-contains-string
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMovingWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String query)
    {
		Collection<WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMoving>
			WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMovings = 
			WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMoving.WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMovings;
		
			var type = WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMovings.GetType().GetGenericArguments()[0];
			var properties = type.GetProperties();
			var result = WroteToTheRomanEmpireAskingToReleasePaulAndYetSheJustWasntMovings.Where(x => properties
            .Any(p =>
            {
                var value = p.GetValue(x);
                return value != null && value.ToString().Contains(query, StringComparison.CurrentCultureIgnoreCase);
            }));
			
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
}	
