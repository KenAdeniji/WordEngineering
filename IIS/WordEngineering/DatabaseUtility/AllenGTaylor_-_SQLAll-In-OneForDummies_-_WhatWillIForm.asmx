<%@ WebService Language="C#" Class="WhatWillIFormWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2023-06-27T16:06:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatWillIFormWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryColumns
	(
		String	connectionString,
		String 	tableName
	)
    {
		return
		(
			JsonConvert.SerializeObject
			(
				(DataTable) DataCommand.DatabaseCommand
				(
					String.Format
					(
						SQLStatementColumnsFormat,
						tableName
					),	
					connectionString,
					CommandType.Text,
					DataCommand.ResultType.DataTable,
					null
				),
				Formatting.Indented
			)
		);
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryTables
	(
		String	connectionString
	)
    {
		return
		(
			JsonConvert.SerializeObject
			(
				(DataTable) DataCommand.DatabaseCommand
				(
					SQLStatementTables,
					connectionString,
					CommandType.Text,
					DataCommand.ResultType.DataTable,
					null
				),
				Formatting.Indented
			)
		);
    }	
	
	public const String SQLStatementColumnsFormat = 
		@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' ORDER BY COLUMN_NAME";
	public const String SQLStatementTables = "SELECT * FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME";
}

