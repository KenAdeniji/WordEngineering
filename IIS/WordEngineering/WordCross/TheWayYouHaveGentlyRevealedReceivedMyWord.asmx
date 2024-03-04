<%@ WebService Language="C#" Class="TheWayYouHaveGentlyRevealedReceivedMyWordWebService" %>

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

using System.Linq;
using System.Xml.Linq;

using System.Collections.Specialized;

using System.Text.RegularExpressions;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2024-03-04T08:49:00...2024-03-04T12:31:00	Created.
///	2024-03-04T10:05:00 .asmx file created.
///	2024-03-04T10:24:00 Debug regular expression (RegEx)
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheWayYouHaveGentlyRevealedReceivedMyWordWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable selectTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		DataTable linqTable = selectTable
			.AsEnumerable()
			.Where
				(
					row => Regex.IsMatch
					(
						row["Word"].ToString(),
                        @"\S\?\s"
					)
				)
			.CopyToDataTable();
		
		string json = JsonConvert.SerializeObject(linqTable, Formatting.Indented);
		return json;
	}
	
	public const string QueryStatement = 
	@"
		SELECT 	*
		FROM 	WordEngineering..HisWord				
		ORDER BY HisWordID DESC
	";
}
