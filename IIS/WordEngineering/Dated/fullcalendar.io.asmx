<%@ WebService Language="C#" Class="fullcalendarWebService" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2023-12-11T12:23:00...2023-12-11T12:46:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class fullcalendarWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		DateTime	datedFrom,
		DateTime	datedUntil,
		String		tableName,
		String		datedColumnName,
		String		eventColumnName
	)
    {
		StringBuilder sb = new StringBuilder();

		String[] tableNames = tableName.Split
		(
			SplitSeparator,
			StringSplitOptions.RemoveEmptyEntries
		);
		
		String tableNameCurrent;
		
		for
		(
			int tablesIndex = 0,
				tablesLength = tableNames.Length;
			tablesIndex < tablesLength;
			tablesIndex++	
		)
		{
			tableNameCurrent = tableNames[tablesIndex].Trim();
			
			if (sb.Length > 0)
			{
				sb.Append(" UNION ");
			}
			
			sb.AppendFormat
			(
				QueryStatementFormat,
				datedFrom,
				datedUntil,
				tableNameCurrent,
				datedColumnName,
				eventColumnName
			);	
		}	

		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

	public static readonly char[] SplitSeparator = new Char [] {','};
	public const String QueryStatementFormat = 
	@"
		SELECT	
			{4} title,
			{3} start
			--dateadd(hour, 1, {3}) [end],
			--CAST(0 AS bit) allDay
		FROM 	{2}
		WHERE
			{3} BETWEEN '{0}' AND '{1}'
	";
}
