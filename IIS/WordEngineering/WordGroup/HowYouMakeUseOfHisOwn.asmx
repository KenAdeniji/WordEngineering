 <%@ WebService Language="C#" Class="HowYouMakeUseOfHisOwnWebService" %>
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

///<summary>
///	2019-07-10	Created. 	Numbers that appear together.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HowYouMakeUseOfHisOwnWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		String number,
		String bibleVersion
	)
    {
		var numberCombination = number.Split
		(
			ScriptureReferenceHelper.SubsetSeparator,
			StringSplitOptions.RemoveEmptyEntries 
		);
		
		StringBuilder sb = new StringBuilder();
		
		foreach (String numberComb in numberCombination)
		{
			sb.AppendFormat
			(
				"AND {0} LIKE '%{1}%'",
				"ActToGod.Minor",
				numberComb.Trim()
			);	
		}
		
		String query = String.Format
		(
			SelectQuery,
			bibleVersion,
			sb
		);
		
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			query,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const String SelectQuery = @"
		SELECT ActToGod.ScriptureReference, {0} AS VerseText, ActToGod.Minor AS Number
		FROM WordEngineering..ActToGod 
		JOIN Bible..Scripture_View ON ActToGod.ScriptureReference = Scripture_View.ScriptureReference
		WHERE ActToGod.Major = 'Numbers that appear together' {1}
		ORDER BY ActToGod.Dated Desc
	";
}
