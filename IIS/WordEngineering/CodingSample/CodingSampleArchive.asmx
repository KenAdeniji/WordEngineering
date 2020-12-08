 <%@ WebService Language="C#" Class="CodingSampleWebService" %>
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
///	2019-06-19	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class CodingSampleWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String question)
    {
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			String.Format(SelectQuery, question),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const string SelectQuery = @"
		SELECT * FROM CodingSample..QuestionAndAnswer
		WHERE 
			Language LIKE '%{0}%' 
			OR Code LIKE '%{0}%'
			OR Commentary LIKE '%{0}%'
			OR Uri LIKE '%{0}%'
		ORDER BY Dated DESC
	";	
}
