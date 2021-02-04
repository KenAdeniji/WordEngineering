<%@ WebService Language="C#" Class="InSomeonesLifeILived_LettingHimGive_TheReachingOfSomeoneWebService" %>

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
///	2021-02-03T21:47:00 ... 2021-02-03T22:02:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class InSomeonesLifeILived_LettingHimGive_TheReachingOfSomeoneWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			SQLSelectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const String SQLSelectStatement = @"
		SELECT
			HisWordID,
			Dated,
			Word,
			Commentary,
			ContactID,
			URI,
			Location,
			Scene
		FROM
			WordEngineering..HisWord
		WHERE
			CONVERT(Date, Dated) =
			(
				SELECT
					MAX(CONVERT(Date, Dated))
				FROM
					WordEngineering..HisWord
			)
		ORDER BY
			HisWordID DESC,
			Dated DESC
	";
}
