<%@ WebService Language="C#" Class="ClaireBentleyWebService" %>

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
using System.Data.Odbc;
using System.Data.SqlClient;

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2023-02-26T06:05:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ClaireBentleyWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	initials
	)
    {
		StringBuilder sql = new StringBuilder();
		
		foreach (char initial in initials)
		{
			if (sql.Length == 0)
			{
				sql.Append(" WHERE ");
			}
			else
			{
				sql.Append(" AND ");
			}
			sql.AppendFormat
			(
				WhereOrClause,
				initial
			);
		}

		sql.Insert(0, SelectQuery);
		
		sql.Append(OrderByClause);
		
		DataSet resultSet = (DataSet)DataCommand.DatabaseCommand
		(
			sql.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	String SelectQuery = 
	@" 
		SELECT FirstName, LastName, OtherName, Title, Company, ContactID
		FROM WordEngineering..Contact
	";
	String WhereOrClause = 
	@" 
		(
				LEFT(FirstName, 1) = '{0}' 
			OR	LEFT(LastName, 1) = '{0}' 
			OR	LEFT(OtherName, 1) = '{0}'
			OR	LEFT(Title, 1) = '{0}'
			OR	LEFT(Company, 1) = '{0}'				
		)
	";
	String OrderByClause = @" ORDER BY FirstName, LastName, OtherName";
}
