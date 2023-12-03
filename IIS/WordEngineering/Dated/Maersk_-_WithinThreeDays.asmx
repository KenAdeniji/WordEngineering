<%@ WebService Language="C#" Class="MaerskWithinThreeDaysWebService" %>

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

/*
WordToSearchFor? ColumnToSearch? SearchTable? Dated? DatedColumnToReference? ReferenceTables? CalendarTimeSpan? Day, Month, Year? 
Date From (terminus a quo) 	
Date To (terminus ad quem) 	
*/	

///<summary>
///	2023-11-30T14:53:00...2023-11-30T19:15:00 Created.
///	Within three days.
///	Paseo Padre Parkway overhead bridge walking towards the North East a Maersk truck on Highway 880 North.
///	WordToSearchFor? ColumnToSearch? SearchTable? Dated? DatedColumnToReference? ReferenceTables? CalendarTimeSpan? Day, Month, Year? At the intersection of Creekwood Drive and Siward Drive, North East, Creekwood Terrace, Service Experts car vehicle. Albertsons Lucky, Charter Square. 3 males. I asked, Are you Filipino? No, I am Hawaiian. Filipino, Mexican, Hawaiian. At the intersection of Fremont Boulevard and Paseo Padre Parkway, South East. AmericaWest car vehicle.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MaerskWithinThreeDaysWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		String		tableName,
		String		columnName,
		String		datePart,
		DateTime	dated,
		int			difference
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
			
			sb.AppendFormat
			(
				QueryStatementFormat,
				tableNameCurrent,
				datePart,
				dated,
				columnName,
				difference
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
		SELECT	*
		FROM 	{0}
		WHERE
			ABS
			(
				DATEDIFF
				(
					{1},
					'{2}',
					{3}
				)
			)
			<= {4}	
		ORDER BY {3} DESC	
		;
	";
}
