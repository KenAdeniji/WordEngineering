<%@ WebService Language="C#" Class="TheNightWasOverWhenIWas_HeCelebrateHimselfOverYouWebService" %>

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

///<summary>
///	2018-12-14	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheNightWasOverWhenIWas_HeCelebrateHimselfOverYouWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string bibleVersion,
		string bibleUnit,
		int	beginStart,	
		int stepInterval,
		int endFinish
	)	
    {
		StringBuilder sb = new StringBuilder();
		for (int index = beginStart; index <= endFinish; index += stepInterval)
		{
			sb.AppendFormat
			(
				BibleUnitIteratorFormat,
				bibleVersion,
				bibleUnit,
				index
			);
		}
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string BibleUnitIteratorFormat =
		"SELECT ScriptureReference, {0} AS VerseText FROM Bible..Scripture_View WHERE {1} = {2} ORDER BY BookID, ChapterID, VerseID;";
}
