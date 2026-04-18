<%@ WebService Language="C#" Class="FeatureHighlightItsStrengthAndWeaknessWebService" %>

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

using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	http://csharpdeveloper.wordpress.com/2019/08/18/sql-servers-sp_executesql-does-not-protect-you-from-sql-injection
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class FeatureHighlightItsStrengthAndWeaknessWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		dynamic resultInfo = DataCommand.DatabaseCommand
		(
			"EXEC WordEngineering..usp_20260415T0543FeatureHighlightItsStrengthAndWeakness",
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultInfo, Formatting.Indented);
		return json;
    }
}
