<%@ WebService Language="C#" Class="WhoWhatWhenWhereWhyWebService" %>

using System;
using System.Data;
using System.Numerics;
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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2021-11-20T07:16:00 Created. https://stackoverflow.com/questions/28153610/using-sql-is-not-null-in-a-select-statement
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhoWhatWhenWhereWhyWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String bibleWord
	)
    {
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(QueryStatement, bibleWord),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = @"
SELECT *
FROM ComparingYourWordAsYourDeed..WhoWhatWhenWhereWhy_View
WHERE Combined LIKE '%{0}%'
ORDER BY Dated
	";
}
