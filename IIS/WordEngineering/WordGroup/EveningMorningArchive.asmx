<%@ WebService Language="C#" Class="EveningMorningWebService" %>

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
///	2021-04-26T15:20:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class EveningMorningWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion,
		String	bibleWord
	)
    {
		StringBuilder sb = new StringBuilder();

		string[] bibleWords = bibleWord.Split
		(
			BibleWordHelper.SplitSeparator,
			StringSplitOptions.RemoveEmptyEntries
		);		

		sb.AppendFormat
		(
			InitialStatement,
			bibleVersion,
			bibleWords[0]
		);
		
		for 
		(
			int bibleWordIndex = 1, bibleWordLength = bibleWords.Length;
			bibleWordIndex < bibleWordLength;
			++bibleWordIndex
		)
		{
			sb.AppendFormat
			(
				WordIndexOfFormat,
				bibleWords[bibleWordIndex - 1],
				bibleWords[bibleWordIndex],
				bibleVersion
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
	
	public const string InitialStatement = 
	@"
		SELECT ScriptureReference, {0}
		FROM Bible..Scripture_View 
		WHERE ( CHARINDEX('{1}', {0}) > -1 ) 
	";	
	public const string WordIndexOfFormat = " AND ( CHARINDEX('{0}', {2}) < CHARINDEX('{1}', {2}) )";
}
