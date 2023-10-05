<%@ WebService Language="C#" Class="IWantATenThousandDayIWillConceiveWebService" %>
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
using InformationInTransit.ProcessLogic;
///<summary>
///	2021-06-19T09:11:00 Created. https://stackoverflow.com/questions/43732599/function-to-count-string-occurrences-in-sql-server
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IWantATenThousandDayIWillConceiveWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String word,
		String filename
	)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				SQLStatement,
				word,
				filename
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	public const string SQLStatement = 
	@"
		SELECT
			(
			SELECT TOP 1
			LEN(Code) - LEN
				(
					REPLACE(Code,'{0}','')
				)
				/ DATALENGTH('{0}')
			FROM WordEngineering..Software
			WHERE Code LIKE '%{0}%' AND Filename LIKE '%{1}%' 
				AND Code IS NOT NULL AND Filename IS NOT NULL
				AND TRIM(Code) <> '' AND DATALENGTH('{0}') <> 0
			)
			AS Occurrences,
			CONVERT
			(
				VARCHAR,
				(
					SELECT COUNT(*)
					FROM WordEngineering..Software
					WHERE Code LIKE '%{0}%' AND Filename LIKE '%{1}%'
				)	
			) 
			+ ' / ' +
			CONVERT
			(
				VARCHAR,
				(
					SELECT COUNT(*)
					FROM WordEngineering..Software
					WHERE Filename LIKE '%{1}%'
				)	
			) 
			AS Probability
	";	
}
