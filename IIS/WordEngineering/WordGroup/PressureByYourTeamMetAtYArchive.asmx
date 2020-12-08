<%@ WebService Language="C#" Class="PressureByYourTeamMetAtYWebService" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2020-12-02 Created.	https://stackoverflow.com/questions/38608142/fuzzy-matching-using-soundex-on-sql-combination-of-tables
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class PressureByYourTeamMetAtYWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	firstBibleVersion,
		String	secondBibleVersion
	)
    {
		DataTable result = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				SelectFormat,
				firstBibleVersion,
				secondBibleVersion
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const string SelectFormat = @"
		SELECT distinct t1.ScriptureReference, t1.{0}, t2.{1}
		FROM Bible..Scripture_View t1
		JOIN Bible..Scripture_View t2
			on t1.VerseIDSequence = t2.VerseIDSequence
		AND	SOUNDEX(t1.{0}) = SOUNDEX(t2.{1})
";
}
