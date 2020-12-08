<%@ WebService Language="C#" Class="DepositACodeWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-01-06	DepositACode.asmx Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DepositACodeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public void Insert
	(
		String email,
		String codeTitle,
		String codeProgram,
		String codeType,
		String schemaData
	)
    {
		codeProgram = codeProgram.Replace("'", "''");
		string insertStatement = String.Format
		(
			InsertFormat,
			email,
			codeTitle,
			codeProgram,
			codeType,
			schemaData
		);
		DataCommand.DatabaseCommand
		(
			insertStatement,
			CommandType.Text,
			DataCommand.ResultType.NonQuery
		);
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Select
	(
		String query
	)
    {
		query = query.Replace("'", "''");
		string selectStatement = String.Format(SelectFormat, query);
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			selectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const string InsertFormat = @"
		INSERT DepositACode..Deposit
		(
			Email,
			CodeTitle,
			CodeProgram,
			CodeType,
			SchemaData
		)
		VALUES
		(
			'{0}', '{1}', '{2}', '{3}', '{4}'
		)
	";

	public const string SelectFormat = @"
		SELECT CodeTitle, CodeProgram FROM DepositACode..Deposit
		WHERE
			Email LIKE '%{0}%' OR
			CodeTitle LIKE '%{0}%' OR
			CodeProgram LIKE '%{0}%' OR
			CodeType LIKE '%{0}%' OR
			SchemaData LIKE '%{0}%'
		ORDER BY DepositID ASC	
	";
	
}
