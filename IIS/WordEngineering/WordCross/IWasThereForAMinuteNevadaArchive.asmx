<%@ WebService Language="C#" Class="IWasThereForAMinuteNevadaWebService" %>

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
///	2021-10-19T10:37:00 Created.
/// Prophet title in the New Testament?
///		There are references to the Old Testament prophets.
///		Jesus, a prophet like Moses
///		And when they had gone through the isle unto Paphos, they found a certain sorcerer, a false prophet, a Jew, whose name was Barjesus: (Acts 13:6).
///		Judaea a certain prophet, named Agabus (Acts 21:10)
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IWasThereForAMinuteNevadaWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String bibleVersion	
	)
    {
		StringBuilder sb = new StringBuilder();
		foreach(String role in Roles)
		{
			if (sb.Length > 0)
			{
				sb.Append(" UNION ");
			}	
			sb.AppendFormat
			(
				QueryStatement,
				role,
				bibleVersion
			);	
		}
		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = @"
SELECT '{0}' AS Role, COUNT('*') AS Occurrences
FROM Bible..Scripture
WHERE {1} LIKE '%{0}%'
";	
	public static readonly string[] Roles = new String[]
	{
		"King",
		"Queen",
		"Prince",
		"Priest",
		"Prophet",
		"Son of Man"
	};
	
}
