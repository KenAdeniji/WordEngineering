<%@ WebService Language="C#" Class="QualifiersAreEntryWebService" %>

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

using System.Reflection;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
/// 2020-07-23	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class QualifiersAreEntryWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	questionAndAnswer
	)
    {
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format(SQLStatement, questionAndAnswer), 
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const string SQLStatement = @"
		SELECT * FROM WordEngineering..ActToGod
		WHERE Major = 'Qualifiers are entry.' AND
		(
			Minor LIKE '%{0}%'
		OR	Commentary LIKE '%{0}%'	
		OR	URI LIKE '%{0}%'	
		)
		ORDER BY Dated DESC
	";
}
