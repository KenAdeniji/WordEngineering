<%@ WebService Language="C#" Class="Isaiah35v3_7WebService" %>

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

using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

/*
select current_user();
show databases;
SELECT * FROM bible.key_english;
SELECT TABLE_NAME FROM information_schema.TABLES ORDER BY TABLE_NAME;
call `bible`.`usp_wordMatchFetch`('Jesus Thomas', null );
*/
///<summary>
///	2021-04-24T17:49:00 Created.
/// DRIVER={MySQL ODBC 8.0 ANSI Driver};SERVER=adriel;DATABASE=bible;UID=;PASSWORD=;OPTION=3;
/// Driver={SQL Server};Server=(local);Database=WordEngineering;Trusted_Connection=Yes;
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class Isaiah35v3_7WebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String information_schema
	(
		string connectionString
	)
    {
		DataSet dataSet = new DataSet();
		DataTable dataTable;
		foreach (String schemaSelect in QueryFormatinformation_schemaSelect)
		{
			dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				schemaSelect,
				connectionString,			
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			dataSet.Tables.Add(dataTable);
		}
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }

	public readonly string[] QueryFormatinformation_schemaSelect = new String[]
	{
		"SELECT * FROM information_schema.TABLES ORDER BY TABLE_NAME",
		"SELECT * FROM information_schema.VIEWS",
		//"SELECT * FROM information_schema.STATISTICS",
		//"SELECT * FROM information_schema.TRIGGERS"
		"SELECT * FROM information_schema.COLUMNS"
	};
}
