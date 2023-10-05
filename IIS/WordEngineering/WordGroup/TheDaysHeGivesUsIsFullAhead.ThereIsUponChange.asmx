<%@ WebService Language="C#" Class="TheDaysHeGivesUsIsFullAheadThereIsUponChangeWebService" %>

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
///	2018-11-28 Created.	stackoverflow.com/questions/15221338/how-to-get-a-list-of-all-extended-properties-for-all-objects
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheDaysHeGivesUsIsFullAheadThereIsUponChangeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			SelectQuery,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const String SelectQuery = @"SELECT S.name as [Schema Name], O.name AS [Object Name], c.name as [Column Name], ep.name, ep.value AS [Extended property]
FROM WordEngineering.sys.extended_properties EP
LEFT JOIN WordEngineering.sys.all_objects O ON ep.major_id = O.object_id 
LEFT JOIN WordEngineering.sys.schemas S on O.schema_id = S.schema_id
LEFT JOIN WordEngineering.sys.columns AS c ON ep.major_id = c.object_id AND ep.minor_id = c.column_id";
}
