<%@ WebService Language="C#" Class="NeedingWhereIAm" %>

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
using InformationInTransit.ProcessCode;

///<summary>
///	2019-04-03	Created.	Who needs adjustment?
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class NeedingWhereIAm : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			SelectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = 
		@"
			SELECT  
				ActToGod.Minor, 
				ScriptureReferenceSubset.value AS ScriptureReference
			FROM
				WordEngineering..ActToGod
			CROSS APPLY	
				STRING_SPLIT(WordEngineering..ActToGod.ScriptureReference, ',') AS ScriptureReferenceSubset
			WHERE
				Major LIKE '%Comparative verse%'
			ORDER BY
				ActToGod.Minor, 
				ActToGod.ScriptureReference
		";
}
