<%@ WebService Language="C#" Class="WhatIDoWithMyTimeIsHowILetItUseWebService" %>

using System;
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

///<summary>
///	2024-05-07T11:05:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatIDoWithMyTimeIsHowILetItUseWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		DateTime	datedFrom,
		DateTime	datedUntil
	)
    {
		String queryStatement = String.Format
		(
			QueryFormat,
			datedFrom,
			datedUntil
		);	

		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			queryStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
	}	

	public const string QueryFormat = @"
		SELECT
			CONVERT(Date, Dated) Dated,
			COUNT(*) Occurrences
		FROM
			WordEngineering..HisWord
		WHERE
			CONVERT(Date, Dated) BETWEEN '{0}' AND '{1}'
		GROUP BY
			CONVERT(Date, Dated)
		ORDER BY
			Dated
	";
}


