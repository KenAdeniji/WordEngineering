<%@ WebService Language="C#" Class="ConcatenateTableColumnsWebService" %>

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
///	2020-04-06T13:33:00	Created.
/// 2020-04-06T13:33:00	https://stackoverflow.com/questions/13761337/how-to-concatenate-all-columns-in-a-select-with-sql-server
///	2020-04-06T13:33:00	https://docs.microsoft.com/en-us/sql/t-sql/functions/concat-ws-transact-sql?view=sql-server-ver15
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ConcatenateTableColumnsWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		bool	unionClause,
		String	whereClause
	)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryFormat,
				unionClause ? " UNION " : "",
				whereClause
			),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
		SELECT Dated, CONCAT_WS(' | ', Word, Commentary) AS DatabaseInfo FROM WordEngineering..HisWord {1}
		{0}
		SELECT Dated, Commentary AS DatabaseInfo FROM WordEngineering..CaseBasedReasoning {1}
		ORDER By Dated DESC		
	";
	public const string QueryFormat2 = 
@"
USE WordEngineering
DECLARE @s VARCHAR(500)

SELECT @S =  ISNULL( @S+ ')' +'+'',''+ ','') + c.name FROM 
       sys.all_columns c join sys.tables  t 
       ON  c.object_id = t.object_id
WHERE t.name = 'HisWord'

sp_executesql ('SELECT CONCAT_WS(' | ', @s) AS DatabaseInfo FROM HisWord)
";
}
