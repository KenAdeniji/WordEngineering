<%@ WebService Language="C#" Class="TimeHasAdjustedAsTheEvent" %>

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
///	2019-03-23	Created.
///	2019-03-22	Time has adjusted, as the event.
///	2007-02-16	dotnettechnologies.com/dotnettechnologies/PermaLink,guid,40eea460-fff4-46be-aa87-e5b38db7558e.aspx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TimeHasAdjustedAsTheEvent : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int		wordCount,
		string 	wordLike,
		int		wordLengthMinimum,
		int		wordLengthMaximum
	)
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			String.Format
			(
				SelectStatement,
				wordCount,
				wordLike,
				wordLengthMinimum,
				wordLengthMaximum
			),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = 
		@"SELECT
			TOP {0} UPPER(BibleWord) AS BibleWord
			FROM
				Bible..Exact 
			WHERE 
				BibleWord LIKE '%{1}%'
			AND	LEN(BibleWord) BETWEEN {2} AND {3}
			ORDER BY
				NewID() 
		";
}
