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
2014-02-18T10:56:00 God will know me at heart.
2014-02-19T17:00:00 http://www.sqlteam.com/article/using-coalesce-to-build-comma-delimited-string Using COALESCE to Build Comma-Delimited String
2014-02-19T17:02:00 http://stackoverflow.com/questions/124295/how-do-i-deploy-a-managed-stored-procedure-without-using-visual-studio How do I deploy a managed stored procedure without using Visual Studio?
2014-02-19T20:58:00 http://blogs.msdn.com/b/mollman/archive/2007/03/23/managing-internal-connection-strings-in-sql-clr-code-during-testing.aspx
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class GodWillKnowMeAtHeart
	{
		public static void Main (string[] argv)
		{
			foreach(string current in argv)
			{
				SqlString result = Query(current);
				System.Console.WriteLine(result);
			}	
		}
		
		[SqlFunction(DataAccess = DataAccessKind.Read)]
		public static SqlString Query(string verseText)
		{
			string adjust = null;
			verseText = verseText.Replace("'", "''");
			string[] words = verseText.Split(SplitSeparator);
			StringBuilder sbSelectStatement = new StringBuilder();
			StringBuilder sbWhereClause = new StringBuilder();
			
			foreach(string word in words)
			{
				adjust = word.Trim();
				if (adjust == String.Empty)
				{
					continue;
				}
				
				if (sbWhereClause.Length == 0 )
				{
					sbWhereClause.Append(" WHERE ");
				}
				else
				{
					sbWhereClause.Append(" AND ");
				}
				
				sbWhereClause.AppendFormat
				(
					LikeClauseFormat,
					adjust
				);	
			}	
			
			sbSelectStatement.AppendFormat
			(
				SelectStatementFormat,
				sbWhereClause
			);
				
			object scalar = DataCommand.DatabaseCommand
			(
				sbSelectStatement.ToString(),
				(SqlContext.IsAvailable) ? "context connection=true" : DataCommand.ConnectionStringMaster,
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			
			string result = scalar == System.DBNull.Value ? null : (string) scalar;
			return result;
		}
		
		public const string LikeClauseFormat = "verseText LIKE '%{0}%'";
		public const string SelectStatementFormat = @"DECLARE @SomeColumnList VARCHAR(MAX) 
			SELECT @SomeColumnList = COALESCE(@SomeColumnList + ', ', '') + scriptureReference FROM Bible..Scripture {0} ORDER BY bookId, chapterId, verseId; 
			SELECT @SomeColumnList";
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
	}
}
