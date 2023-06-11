<%@ WebService Language="C#" Class="AlwaysCountForYouWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2016-11-05	Created.	AlwaysCountForYou.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AlwaysCountForYouWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	datepartMetric,
		int		datepartValue
	)	
    {
		string selectStatement = String.Format
		(
			SelectStatement,
			datepartMetric,
			datepartValue
		);

 		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			selectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = @"
		SELECT * 
		FROM WordEngineering..HisWord
		WHERE DATEPART({0}, dated) = {1}
		ORDER BY Dated DESC
	";
}
