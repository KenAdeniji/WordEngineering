using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using InformationInTransit.DataAccess;

/*
2015-04-09	Created.	WordsInTheBibleScriptureReference.cs
2015-04-09	Coalesce.	http://www.codeproject.com/Tips/334400/Concatenate-many-rows-into-a-single-text-string-us

REM csc WordsInTheBibleScriptureReferenceSQLCLR.cs /reference:..\Bin\Debug\InformationInTransit.dll
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /main:InformationInTransit.ProcessLogic.WordsInTheBibleScriptureReference /reference:mscorlib.dll,System.Core.dll WordsInTheBibleScriptureReferenceSQLCLR.cs ..\DataAccess\DataCommand.cs 
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll,C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll WordsInTheBibleScriptureReferenceSQLCLR.cs ..\DataAccess\DataCommand.cs 

REM Loading and Running the "E:\WordEngineering\InformationInTransit\ProcessLogic\WordsInTheBibleScriptureReferenceSQLCLR.dll" Function in SQL Server
CREATE ASSEMBLY WordsInTheBibleScriptureReferenceSQLCLR from 'E:\WordEngineering\InformationInTransit\ProcessLogic\WordsInTheBibleScriptureReferenceSQLCLR.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION udf_WordsInTheBibleScriptureReference
(
	@words nvarchar(MAX),
	@logic nvarchar(MAX)	
)
RETURNS nvarchar(MAX)
AS EXTERNAL NAME WordsInTheBibleScriptureReferenceSQLCLR.[InformationInTransit.ProcessLogic.WordsInTheBibleScriptureReference].Query
GO

REM Test
SELECT dbo.udf_WordsInTheBibleScriptureReference('In the beginning', 'Phrase')
GO

REM Removing the "udf_WordsInTheBibleScriptureReference" Function Sample
DROP Function udf_WordsInTheBibleScriptureReference
GO

DROP assembly WordsInTheBibleScriptureReferenceSQLCLR
GO

REM ([dbo].[WordsInTheBibleScriptureReference]([Word]))
*/
namespace InformationInTransit.ProcessLogic
{
	public partial class WordsInTheBibleScriptureReference
	{
		public static void Main (string[] argv)
		{
			String iAm = "I Am";
			
			if (argv.Length > 0) 
			{
				iAm = argv[0]; 
			}

			String logic = "And";
			
			if (argv.Length > 1) 
			{
				logic = argv[1]; 
			}
			
			SqlString result = Query(iAm, logic);
			
			System.Console.WriteLine(result);
		}
		
		public static StringBuilder PrepareWhereClause
		(
			string words,
			string logic //And, Or, Phrase
		)
		{
			string[] keywords = null;
			
			if (String.IsNullOrEmpty(logic))
			{
				logic = "and";
			}
			
			logic = logic.ToLower();
			
			if (logic == "phrase")
			{
				keywords = new String[] { words };
			}
			else
			{
				keywords = words.Split(' ');
			}	

			StringBuilder sqlWhereClause = new StringBuilder();
			
			for(int index = 0, count = keywords.Length; index < count; ++index)
			{
				keywords[index] = keywords[index].Trim();
				if (index > 0)
				{
					sqlWhereClause.Append(' ' + logic + ' ');
				}
				sqlWhereClause.AppendFormat(WordQueryFormat, keywords[index]);
			}
			
			if (sqlWhereClause.Length > 0)
			{
				sqlWhereClause.Insert(0, " WHERE ");
			}
			
			return sqlWhereClause;
		}

		[SqlFunction(DataAccess = DataAccessKind.Read)]
		public static String Query(string words, string logic)
		{
			object scalar = null;
			
			StringBuilder whereClause = PrepareWhereClause(words, logic);
			
			String bibleQuery = String.Format
			(
				BibleQueryFormat,
				whereClause
			);
 			
			scalar = DataCommand.DatabaseCommand
			(
				bibleQuery,
				(SqlContext.IsAvailable) ? "context connection=true" : DataCommand.ConnectionStringMaster,
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);

			return scalar.ToString();
		}
		
		public const string BibleQueryFormat = "DECLARE @scriptureReferences VARCHAR(8000); SELECT @scriptureReferences = COALESCE(@scriptureReferences + ', ', '') + ScriptureReference FROM Bible..Scripture_View {0} ORDER BY bookId, chapterId, verseId; SELECT @scriptureReferences;";
		public const string WordQueryFormat = "verseText LIKE '%{0}%'";		
	}
}
