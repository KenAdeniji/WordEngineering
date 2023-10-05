<%@ WebService Language="C#" Class="ADayToSubmitATimeToLookElsewhereWebService" %>

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

using Newtonsoft.Json;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2022-05-05T12:51:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ADayToSubmitATimeToLookElsewhereWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	selectOption,
		String	logic
	)
    {
		StringBuilder sb = new StringBuilder();
		String[] selectOptions = selectOption.Split(',');
		foreach(String choice in selectOptions)
		{
			if (sb.Length > 0)
			{
				sb.Append( logic );
			}
			sb.AppendFormat
			(
				" Word LIKE '%{0}%' ",
				choice
			);	
		}
		
		string whereClause = " WHERE " + sb.ToString();
		
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(QueryStatement, whereClause),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement =
	@"
		SELECT
			Dated,
			Word,
			Commentary,
			EnglishTranslation
		FROM
			WordEngineering..HisWord
		{0}
		ORDER BY
			Dated DESC
	";
}
