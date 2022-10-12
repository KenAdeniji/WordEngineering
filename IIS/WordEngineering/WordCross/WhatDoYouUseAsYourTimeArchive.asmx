<%@ WebService Language="C#" Class="WhatDoYouUseAsYourTimeWebService" %>
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

using System.Linq;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.ProcessLogic;

///<summary>
///		2022-10-10	What do you use as your time?
///		2022-10-11	Created.
///		2022-10-11T21:52:00	http://stackoverflow.com/questions/3264845/how-to-take-all-array-elements-except-last-element-in-c-sharp
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatDoYouUseAsYourTimeWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		int	minimumGroupHavingCount
	)
    {
        String columnCountReference = "";
		
		String columnDeclaration = "";
		String[] columnDeclarations;
				
		String columnName = "";
		String columnTableView = "";
		String columnType = "";
		
		char[] charSeparators = new char[] { '.' };
		
		int columnDeclarationsLength = -1;
		
		StringBuilder sb = new StringBuilder();
		
		for (int i = 0; i < jaggedArray2.Length; i++)
        {
			columnDeclaration = jaggedArray2[i][ColumnRankDeclaration];
			
			//columnDeclarations = columnDeclaration.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
			columnDeclarations = columnDeclaration.Split(charSeparators);
			
			columnDeclarationsLength = columnDeclarations.Length;
			
			columnTableView = String.Join(".", columnDeclarations.Take(columnDeclarationsLength - 1));
			columnName = columnDeclarations[ columnDeclarationsLength - 1 ];
			
			columnType = "";
			if ( jaggedArray2[i].Length > 1 )
			{
				columnType = jaggedArray2[i][ColumnRankType];
			}
			
			switch (columnType)
			{
				case "":
					columnCountReference = String.Format( columnCountReferenceFormatDefault, columnDeclaration );
					break;
				case "DateTime":
					columnCountReference = String.Format( columnCountReferenceFormatDateTime, columnDeclaration );
					break;
			}
			
			if (sb.Length > 0)
			{
				sb.Append(" UNION ");
			}	
			
			sb.AppendFormat
			(
				SelectQuery,
				minimumGroupHavingCount,
				columnDeclaration,
				columnCountReference,
				columnTableView	
			);
        }

		sb.Append(" ORDER BY ColumnCount DESC ");
		
		DataTable DataTable = (DataTable) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(DataTable, Formatting.Indented);
		return json;
	}
	
	public const String SelectQuery = @"
		SELECT 
			'{1}' AS ColumnName,
			CONVERT(VARCHAR, {1}) AS ColumnValue,
			{2} AS ColumnCount
		FROM {3}
		GROUP BY {1}
		HAVING {2} >= {0}
	";
	
	String[][] jaggedArray2 = new String[][]
	{
		new String[] { "WordEngineering..HisWord.ContactID" },
		new String[] { "WordEngineering..HisWord.Dated" },		
		
		new String[] { "WordEngineering..Remember.ContactID" },		
		new String[] { "WordEngineering..Remember.DatedFrom", "DateTime" },
		new String[] { "WordEngineering..Remember.DatedUntil", "DateTime" },		
		
		new String[] { "WordEngineering..APass.ContactID" },		
		new String[] { "WordEngineering..APass.DatedFrom", "DateTime" },
		new String[] { "WordEngineering..APass.DatedIntermission", "DateTime" },	
		new String[] { "WordEngineering..APass.DatedUntil", "DateTime" }		
		
	};

	int ColumnRankDeclaration = 0;	
	int ColumnRankType = 1;	
	
	String columnCountReferenceFormatDefault = " COUNT ( {0} ) ";
	String columnCountReferenceFormatDateTime = " COUNT ( CONVERT(Date, {0}) )";
}
