<%@ WebService Language="C#" Class="HoweverWeAreThatIsWhereWeAreWebService" %>

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
///	2022-02-17T14:48:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HoweverWeAreThatIsWhereWeAreWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion
	)
    {
	
		StringBuilder	sb	=	new StringBuilder();
		
		sb.Append
		(
			QueryStatementPre
		);

		for 
		(
			int namesIndex = 0, namesLength = NameChanges.Length / 2;
			namesIndex < namesLength;
			++namesIndex
		)
		{
			if (namesIndex > 0)
			{
				//sb.Append(" UNION ");
			}
			sb.AppendFormat
			(
				QueryStatementFormat,
				bibleVersion,
				NameChanges[namesIndex, 0],
				NameChanges[namesIndex, 1]
			);
		}	
	
		//return sb.ToString();
	
		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatementPre = @"
	DECLARE @verseIDNameChange AS INTEGER

	DECLARE @newNameWildCard AS NVARCHAR(MAX)
	DECLARE @oldNameWildCard AS NVARCHAR(MAX)
	";
	
	public const string QueryStatementFormat = @"
	
	SELECT
		@oldNameWildCard = '%' + '{1}' + '%',
		@newNameWildCard = '%' + '{2}' + '%'

	SELECT TOP 1
		@verseIDNameChange = VerseIDSequence
	FROM
		Bible..Scripture
	WHERE
		{0} LIKE @oldNameWildCard AND {0} LIKE @newNameWildCard
	ORDER BY
		VerseIDSequence

	SELECT 
		'{1}' As BibleWordOld,
		'{2}' As BibleWordNew,
		STUFF
		(
			(
				SELECT ', ' + ScriptureReference 
				FROM Bible..Scripture_View
				WHERE 
					{0} LIKE @oldNameWildCard
				AND {0} LIKE @newNameWildCard
				AND VerseIDSequence >= @verseIDNameChange
				FOR XML PATH('')
			)
			,1,1,''
		) AS ScriptureReferenceBoth,

		STUFF
		(
			(
				SELECT ', ' + ScriptureReference 
				FROM Bible..Scripture_View
				WHERE 
					{0} LIKE @oldNameWildCard
				AND {0} NOT LIKE @newNameWildCard
				AND VerseIDSequence >= @verseIDNameChange
				FOR XML PATH('')
			)
			,1,1,''
		) AS ScriptureReferenceOld,

		STUFF
		(
			(
				SELECT ', ' + ScriptureReference 
				FROM Bible..Scripture_View
				WHERE 
					{0} NOT LIKE @oldNameWildCard
				AND {0} LIKE @newNameWildCard
				AND VerseIDSequence >= @verseIDNameChange
				FOR XML PATH('')
			)
			,1,1,''
		) AS ScriptureReferenceNew
		
";
		public static readonly String[,] NameChanges = new String[,]
		{
			{"Abram", "Abraham"},
			{"Sarai", "Sarah"},
			{"Gideon", "Jerubaal"},
			{"Solomon", "Jedidiah"}
		};
}
