<%@ WebService Language="C#" Class="ToLoveISupposeUnknownWebService" %>

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
///		2021-01-09T10:31:00 ...	2021-01-09T12:36:00 Created.
///		2021-01-09T12:28:00		https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-pad-a-number-with-leading-zeros
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToLoveISupposeUnknownWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		DateTime	dated
	)
    {
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				SQLStatementFormat,
				dated.Year,
				dated.Year.ToString("D4").Reverse(),
				dated.Month,
				dated.Month.ToString("D2").Reverse(),
				dated.Day,
				dated.Day.ToString("D2").Reverse()
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const String SQLStatementFormat = @"
		SELECT	Number, ScriptureReference FROM NumberSign WHERE Number = {0}
		UNION
		SELECT	Number, ScriptureReference FROM NumberSign WHERE Number = {1}
		UNION
		SELECT	Number, ScriptureReference FROM NumberSign WHERE Number = {2}
		UNION
		SELECT	Number, ScriptureReference FROM NumberSign WHERE Number = {3}
		UNION
		SELECT	Number, ScriptureReference FROM NumberSign WHERE Number = {4}
		UNION
		SELECT	Number, ScriptureReference FROM NumberSign WHERE Number = {5}
	";
}
