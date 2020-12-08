<%@ WebService Language="C#" Class="OjoToOhunBaPariPeluWon" %>

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
///	2019-04-09	Created.	http://www.apress.com/us/book/9781590599808?token=cyberweek18&utm_campaign=3_fjp8312_Apress_US_PLA_cyberweek18#otherversion=9781430206255
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OjoToOhunBaPariPeluWon : System.Web.Services.WebService
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
				BookID,
				BookTitle,
				MAX(ChapterID) AS Chapters,
				RANK() OVER (ORDER BY MAX(ChapterID) DESC) AS ChapterRank,
				COUNT(VerseID) AS Verses,
				RANK() OVER (ORDER BY COUNT(VerseID) DESC) AS VerseRank
			FROM
				Bible..Scripture_View
			GROUP BY
				BookID,
				BookTitle
			ORDER BY
				MAX(ChapterID) DESC
		";
}
