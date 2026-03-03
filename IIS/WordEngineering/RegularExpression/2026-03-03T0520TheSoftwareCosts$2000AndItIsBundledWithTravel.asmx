<%@ WebService Language="C#" Class="OnJustThatOneColumnWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OnJustThatOneColumnWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }

	public const String QueryStatement = @"
		SELECT 
			Dated,
			Word,
			REGEXP_SUBSTR(Word, '\d+') AS Valued, 
			Commentary,
			DATEADD(DAY, - CONVERT(INT, REGEXP_SUBSTR(Word, '\d+')), Dated) AS DatedFrom,
			DATEADD(DAY, CONVERT(INT, REGEXP_SUBSTR(Word, '\d+')), Dated) AS DatedUntil
		FROM HisWord 
		WHERE REGEXP_SUBSTR(Word, '\d+') IS NOT NULL AND CONVERT(INT, REGEXP_SUBSTR(Word, '\d+')) < 20000
		ORDER by Dated DESC
	";	
}
