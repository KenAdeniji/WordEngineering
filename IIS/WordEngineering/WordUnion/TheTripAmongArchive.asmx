<%@ WebService Language="C#" Class="TheTripAmongWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2016-06-14 	Created.
///	2016-06-14	http://stackoverflow.com/questions/3222125/fastest-way-to-remove-first-char-in-a-string
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheTripAmongWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
		StringBuilder sb = new StringBuilder();
		String topLevelDomainCurrent;
		foreach(string topLevelDomain in TopLevelDomain)
		{
			topLevelDomainCurrent = topLevelDomain.Substring(1);
			if (sb.Length > 1)
			{
				sb.Append(" UNION ");
			}	
			sb.Append
			(
				String.Format
				(
					SQLStatementFormat,
					topLevelDomainCurrent
				)
			);
		}
		
		DataSet resultSet = (DataSet) Repository.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			Repository.ResultSet.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string SQLStatementFormat = "SELECT '{0}' AS TopLevelDomain, TRIM(STUFF((SELECT ' ' + BibleWord + ' ' FROM Bible..Exact WHERE SOUNDEX(BibleWord) = SOUNDEX('{0}') ORDER BY BibleWord FOR XML PATH('')) ,1,1,'')) AS BibleWord";
	public readonly string[] TopLevelDomain = new String[]
	{
		".aero",
		".asia",
		".cat",
		".coop",
		".edu",
		".gov",
		".int",
		".jobs",
		".mil",
		".mobi",
		".museum",
		".post",
		".tel",
		".travel",
		".xxx"		
	};	
}
