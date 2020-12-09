<%@ WebService Language="C#" Class="LivedBeyondTheWildernessWebService" %>
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
using System.Linq;

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

///<summary>
///	2019-08-13 20:04:58.880	This is the event, in their lives.
///	2019-08-16	Created.
///	2019-08-16	https://stackoverflow.com/questions/14080103/cast-an-object-array-to-an-integer-array
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class LivedBeyondTheWildernessWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string QueryDated
	(
		String		minor,
		String		actor,
		String		commentary,
		bool		biblicalCalendar,
		DateTime	dated
	)
    {
		String		datePart;
		String		dateSpan;

		if (biblicalCalendar)
		{
			datePart	=	"Day";
			dateSpan	=	"360 * CONVERT(INT, commentary)";
		}
		else
		{
			datePart	=	"Year";
			dateSpan	=	"CONVERT(INT, commentary)";
		}
		
		string	computedColumns = String.Format
		(
			"DATEADD({0}, -{1}, '{2}') AS DatedFrom, DATEADD({0}, {1}, '{2}') AS DatedUntil",
			datePart,
			dateSpan,
			dated
		);	

		StringBuilder whereClause = new StringBuilder();
		
		whereClause.Append(SQLBuild.WhereClause(minor,"minor"," and "," or "));
		whereClause.Append(SQLBuild.WhereClause(actor,"actor"," and "," or "));
		whereClause.Append(SQLBuild.WhereClause(commentary,"commentary"," and "," or "));

		String 	sqlStatement = String.Format
		(
			@"SELECT DISTINCT {0} FROM WordEngineering..ActToGod 
				WHERE Major = 'This is the event, in their lives.'
				{1}
			",
			computedColumns,
			whereClause.ToString()
		);	
	
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		String	json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string QueryMenu(String columnName)
    {
		string computedColumn = columnName;
		if (columnName == "commentary")
		{
			computedColumn = "CONVERT(INT, commentary) AS commentary";
		}
	
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			String.Format
			(
				@"SELECT DISTINCT {0} FROM WordEngineering..ActToGod 
					WHERE Major = 'This is the event, in their lives.' 
					ORDER BY {1}
				",
				computedColumn,
				columnName
			),	
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		object[] options = DataTableHelper.ConvertDataTableToArray(dataTable, columnName);
		
		string json = null;

		if (columnName == "commentary")
		{
			json = JsonConvert.SerializeObject(options.Cast<int>().ToArray(), Formatting.Indented);
		}
		else
		{
			json = JsonConvert.SerializeObject(options.Cast<string>().ToArray(), Formatting.Indented);
		}
		
		return json;
	}
}
