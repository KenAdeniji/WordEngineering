<%@ WebService Language="C#" Class="URIViewWebService" %>

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

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2019-01-22	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class URIViewWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string question
	)	
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format(QueryFormat, question),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string QueryFormat =
		"SELECT * FROM URI..MyURI WHERE Title LIKE '%{0}%' OR URI LIKE '%{0}%' OR Commentary LIKE '%{0}%' OR Keyword LIKE '%{0}%' ORDER BY Dated DESC";
}
