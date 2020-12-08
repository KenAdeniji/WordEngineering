<%@ WebService Language="C#" Class="JesusToSacrificeEverythingToSacrificeAllWebService" %>

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
///	2020-09-06	Jesus to sacrifice everything, to sacrifice all.
///	2020-09-07 	Created.	https://stackoverflow.com/questions/47871264/issue-with-using-charindex-and-substring
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class JesusToSacrificeEverythingToSacrificeAllWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String bibleVersion)
    {
		DataTable result = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(SelectQuery, bibleVersion),
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const string SelectQuery = @"
		SELECT
			{0} AS VerseText,
			SUBSTRING
			(
				{0}, charindex('(', {0})+1,
					charindex(')', {0}) - charindex('(', {0}) - 1
			) AS InBracket,
			ScriptureReference
		FROM Bible..Scripture_View 
		WHERE charindex('(', {0}) > 0 AND charindex(')', {0}) > 0
		ORDER BY BookID, ChapterID, VerseID
	";
}
