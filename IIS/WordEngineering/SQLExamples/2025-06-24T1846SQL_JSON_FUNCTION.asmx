<%@ WebService Language="C#" Class="SQL_JSON_Function" %>

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
///	2025-06-24T18:46:00...2025-06-25T00:25:00 Created. http://learn.microsoft.com/en-us/sql/t-sql/functions/json-query-transact-sql?view=sql-server-ver17
///	2012-06-25T12:03:00	Mortensen.Jorn@microsoft.com
///	2023-03-13T23:43:11	http://en.wikipedia.org/wiki/C_Sharp_4.0
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SQL_JSON_Function : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	SQL_JSON_Function,
		String	expression,
		String	path
	)
    {
 		dynamic resultSet = DataCommand.DatabaseCommand
		(
			String.Format
			(
				"SELECT {0}('{1}', '{2}')", 
				SQL_JSON_Function,
				expression,
				path
			),
			System.Data.CommandType.Text,
			DataCommand.ResultType.Scalar
		);

		if (SQL_JSON_Function == "JSON_VALUE")
		{
			resultSet = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		}

		return resultSet;
	}
}
