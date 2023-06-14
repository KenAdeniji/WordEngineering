<%@ WebService Language="C#" Class="WeAcceptEachOtherAsOursWebService" %>

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

using Newtonsoft.Json;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2023-06-12T00:00:00 Created. We accept each other ... as ours.
///	2023-06-13T17:31:00 AlphabetSequenceIndexIgnore
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WeAcceptEachOtherAsOursWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	bibleWord,
		int		alphabetSequenceIndex
	)
    {
		string sqlStatement = "";
		if (alphabetSequenceIndex < 1)
		{
			sqlStatement = String.Format
			(
				QueryStatementAlphabetSequenceIndexIgnore,
				bibleWord
			);
		}		
		else
		{
			sqlStatement = String.Format
			(
				QueryStatement,
				alphabetSequenceIndex,
				bibleWord
			);
		}		
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement =
	@"
		SELECT
			*
		FROM
			Bible..Exact_View
		WHERE
			AlphabetSequenceIndex = {0}
		AND	Difference(BibleWord, '{1}') = 4	
	";

	public const String QueryStatementAlphabetSequenceIndexIgnore =
	@"
		SELECT
			*
		FROM
			Bible..Exact_View
		WHERE
			Difference(BibleWord, '{0}') = 4	
	";
}

