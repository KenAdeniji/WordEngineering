<%@ WebService Language="C#" Class="ToLookAtTheAspirationOfKindWebService" %>

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
using InformationInTransit.ProcessCode;

///<summary>
/// 2020-03-17	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToLookAtTheAspirationOfKindWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	bibleVersion,
		string	firstWord,
		string	secondWord
	)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryFormat,
				bibleVersion,
				firstWord,
				secondWord
			),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	public const string QueryFormat =
	@"
SELECT 
	ScriptureReference,
	{0} AS VerseText
FROM Bible..Scripture_View
where CHARINDEX('{2}', {0}) < CHARINDEX('{1}', {0})
and CHARINDEX('{2}', {0}) > 0
order by VerseIdSequence	
	";
}
