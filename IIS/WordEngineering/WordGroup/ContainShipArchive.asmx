<%@ WebService Language="C#" Class="ContainShipWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2021-02-28T14:06:00 ... Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ContainShipWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	query		
	)
    {
		DateTime dated = DateTime.MinValue;
		
		bool isDate = DateTime.TryParse(query, out dated);
		
		String whereClause = "";
		
		if (isDate)
		{
			whereClause += String.Format
			(
				" OR '{0}' BETWEEN ISNULL(DatedFrom, '0001-01-01') AND ISNULL(DatedUntil, '9999-12-31') ",
				dated
			);
		}
		else
		{
			whereClause += String.Format
			(
				" OR Titled LIKE '%{0}%' OR dbo.functionContactName(ContactID) LIKE '%{0}%' ",
				query
			);
		}
		
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				SQLSelectStatement,
				whereClause
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const String SQLSelectStatement = @"
		SELECT 
			DatedFrom,
			DatedUntil,
			dbo.functionContactName(ContactID) AS Named,
			Titled			
		FROM
			WordEngineering..ContainShip
		WHERE
			1 <> 1 {0}
		ORDER BY
			DatedUntil DESC,
			DatedFrom DESC,
			ContactID
	";
}
