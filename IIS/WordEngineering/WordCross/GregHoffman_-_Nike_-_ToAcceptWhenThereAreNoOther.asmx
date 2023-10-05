<%@ WebService Language="C#" Class="GregHoffmanNikeToAcceptWhenThereAreNoOtherWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2022-07-27 Created. To accept when there are no other. Biblical name, actor, place.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class GregHoffmanNikeToAcceptWhenThereAreNoOtherWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion
	)
    {
		StringBuilder sb = new StringBuilder();
		
		for (int i = 0; i < JaggedArrayBibleWord.Length; i++)
        {
			if ( i > 0 )
			{
				sb.Append(";");
			}
			for (int j = 0; j < JaggedArrayBibleWord[i].Length; j++)
            {
				if (j > 0)
				{
					sb.Append(" UNION ");
				}
				sb.AppendFormat
				(
					QueryStatementSubSet,
					bibleVersion,
					JaggedArrayBibleWord[i][j]
				);	
            }
        }
		
		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

	public const string QueryStatementSubSet = @"
SELECT
	'{1}' AS BibleWord,
	COUNT(*) AS Occurrences
FROM
	Bible..Scripture
WHERE
	{0} LIKE '%[^a-z]{1}[^a-z]%'
";

public static readonly String[][] JaggedArrayBibleWord = new String[][] //Biblical name, actor, place
{
new String[] { "God", "Jesus", "Adam", "Eve", "Cain", "Abel", "Seth", "Enoch", "Noah", "Abraham", "Sarah", "Lot", "Isaac", "Ishmael", "Esau", "Israel", "Joseph", "Judah", "Moses", "Aaron", "Joshua", "Samuel", "David", "Solomon", "Elijah", "Elisha", "Isaiah", "Jeremiah", "Ezekiel", "Daniel", "Peter", "Paul" }, //Actor
new String[] { "Eden", "Egypt", "Moab", "Ammon", "Jordan", "Bethlehem", "Jerusalem", "Babylon", "Persia", "Grecia", "Italy", "Rome", "Heaven", "Hell" } //Place
};	
}

