<%@ WebService Language="C#" Class="AndHeFeelsItIsGoodWebService" %>

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
using System.Data.Odbc;
using System.Data.SqlClient;

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2022-04-05 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AndHeFeelsItIsGoodWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	word
	)
    {
	
		word = word.Trim();

		StringBuilder	sbWhere	=	new StringBuilder();
		
		foreach(String columnName in StringColumnNames)
		{
			if (sbWhere.Length > 0)
			{
				sbWhere.Append( " OR " );
			}
			
			sbWhere.AppendFormat
			(
				"{0} LIKE '%{1}%'",
				columnName,
				word
			);	
		}

		DateTime dated;
		bool isDateTime = DateTime.TryParse(word, out dated);
		
		if (isDateTime)
		{
			string shortDate = dated.ToString("yyyy-MM-dd");
			
			foreach(String columnName in DateTimeColumnNames)
			{
				if (sbWhere.Length > 0)
				{
					sbWhere.Append( " OR " );
				}
				
				sbWhere.AppendFormat
				(
					"CONVERT(Date, {0}) = '{1}'",
					columnName,
					shortDate
				);	
			}
		}

		int index;
		bool isInt = Int32.TryParse(word, out index);
		
		if (isInt)
		{
			foreach(String columnName in IntColumnNames)
			{
				if (sbWhere.Length > 0)
				{
					sbWhere.Append( " OR " );
				}
				
				sbWhere.AppendFormat
				(
					"CONVERT(int, {0}) = {1}",
					columnName,
					index
				);	
			}
		}
		
		String queryStatement =	String.Format
		(
			QueryStatement,
			sbWhere.ToString()
		);

		//return queryStatement;
	
		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			queryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = @"
SELECT
	WordEngineering..Contact.ContactID  AS ContactID,
	COUNT(WordEngineering..HisWord.ContactID) AS HisWordCount,
	MIN(WordEngineering..HisWord.Dated) AS HisWordDatedMinimum,
	MAX(WordEngineering..HisWord.Dated) AS HisWordDatedMaximum
FROM
	WordEngineering..Contact
	JOIN WordEngineering..HisWord ON WordEngineering..Contact.ContactID = WordEngineering..HisWord.ContactID
WHERE
	1 = 1 AND ( {0} )
GROUP BY
	WordEngineering..Contact.ContactID
ORDER BY
	 WordEngineering..Contact.ContactID		
";
	public readonly String[] StringColumnNames = new String[] 
	{ 
		"WordEngineering..Contact.FirstName",
		"WordEngineering..Contact.LastName",
		"WordEngineering..Contact.OtherName",
		"WordEngineering..Contact.Title",
		"WordEngineering..Contact.Company",
		"WordEngineering..Contact.Commentary",
	};
	
	public readonly String[] DateTimeColumnNames = new String[] 
	{ 
		"WordEngineering..Contact.Dated"
	};
	
	public readonly String[] IntColumnNames = new String[]
	{ 
		"WordEngineering..Contact.ContactID"
	};
}
