<%@ WebService Language="C#" Class="ReferringToHimAsMyWorkWebService" %>

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
///	2020-11-17	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ReferringToHimAsMyWorkWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	alphabets
	)
    {
		StringBuilder sb = new StringBuilder();
		
		foreach (var ch in alphabets) 
		{
			if (Char.IsLetter(ch) == false)
			{
				continue;
			}	
			if (sb.Length == 0)
			{
				sb.Append(" WHERE ");
			}
			else
			{
				sb.Append(" AND ");
			}
			sb.AppendFormat
			(
				"BibleWord LIKE '%{0}%'",
				ch
			);
		}
		
		string statement = String.Format(SQLStatement, sb.ToString());
		
		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			statement,
			CommandType.Text,
			Repository.ResultSet.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const string SQLStatement = "SELECT * FROM Bible..Exact {0} ORDER BY BibleWord";
}
