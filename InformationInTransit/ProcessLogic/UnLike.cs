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
2014-02-21T18:55:00 UnLike.cs  A word not in the Bible.
2014-02-24T07:36:00 Non-Biblical word.
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class UnLike
	{
		public static void Main (string[] argv)
		{
			foreach(string current in argv)
			{
				SqlString unlike = Query(current);
				//System.Console.WriteLine(unlike);
			}	
		}
		
		[SqlFunction(DataAccess = DataAccessKind.Read)]
		public static SqlString Query(string wordSaid)
		{
			string adjust = null;
			wordSaid = wordSaid.Replace("'", "''");
			string[] words = wordSaid.Split(SplitSeparator);
			String selectStatement = null;
			StringBuilder unLike = new StringBuilder();
			
			foreach(string word in words)
			{
				adjust = word.Trim();
				if (adjust == String.Empty)
				{
					continue;
				}
			
				selectStatement = String.Format
				(
					SelectStatementFormat,
					adjust
				);
				
				object scalar = DataCommand.DatabaseCommand
				(
					selectStatement,
					(SqlContext.IsAvailable) ? "context connection=true" : DataCommand.ConnectionStringMaster,
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				
				string result = scalar == System.DBNull.Value ? null : (string) scalar;
				
				if (result == null)
				{
					if (unLike.Length > 0)
					{
						unLike.Append(", ");
					}
					unLike.Append(word);
				}
				
				/*
				System.Console.WriteLine
				(
					"Word: {0} | selectStatement: {1} | Result: {2} | UnLike: {3}",
					word,
					selectStatement,
					result,
					unLike
				);
				*/
			}
			return unLike.ToString();
		}
		
		public const string SelectStatementFormat = @"SELECT TOP 1 BibleWord FROM Bible..Exact WHERE BibleWord = '{0}'";
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
	}
}
