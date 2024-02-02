<%@ WebService Language="C#" Class="NowWhoWereWithYouWhenYouWereWithMeWebService" %>

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data.SqlClient;
using System.Text;	

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2024-02-02T12:15:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class NowWhoWereWithYouWhenYouWereWithMeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		string	word
	)
    {
		DataTable tableOrViewSchema = NowWhoWereWithYouWhenYouWereWithMe.QuerySchema
		(
			DatabaseConnectionString,
			"RobertRouseVizBible..People"
		);
		
		StringBuilder whereClause = NowWhoWereWithYouWhenYouWereWithMe.WhereClause
		(
			tableOrViewSchema,
			word
		);
		
		return whereClause.ToString();
		
		//string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		//return json;
    }
	
	const String DatabaseConnectionString = "Data Source=(local);Database=RobertRouseVizBible;Integrated Security=true;";
}
