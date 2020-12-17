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
2014-03-11 LifeIsASpectatorIfYouObserveItThatWaySQLCLR.cs. Life is a spectator, if you observe it that way.
2014-04-04 alreadyPresent implemented. This East, the East must obey.
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class LifeIsASpectatorIfYouObserveItThatWay
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
		public static SqlString Query(string question)
		{
			string adjust = null;
			string selectStatementWordType = null;
			
			question = question.Replace("'", "''");
			string[] words = question.Split(SplitSeparator);

			StringBuilder sbSelectStatement = new StringBuilder();
			StringBuilder sbWhereClause = new StringBuilder();

			StringBuilder wordInScriptureReference = new StringBuilder();			
			StringBuilder wordInWhere = new StringBuilder();
						
			int? wordListed = null;
			int? wordType = null;
			
			int alphabetSequenceId = AlphabetSequence.Id(question);
			int alreadyPresent = -1;
			
			string alphabetSequenceScriptureReferenceSelectStatement = null;
			string alphabetSequenceScriptureReferenceWhereClause = AlphabetSequence.ScriptureReferenceWhereClause(alphabetSequenceId);
			
			object scalar = null;
			
			foreach(string word in words)
			{
				adjust = word.Trim();
				if (adjust == String.Empty)
				{
					continue;
				}
				
				selectStatementWordType = String.Format
				(
					SelectStatementWordTypeFormat,
					adjust
				);
				
				scalar = DataCommand.DatabaseCommand
				(
					selectStatementWordType,
					(SqlContext.IsAvailable) ? "context connection=true" : DataCommand.ConnectionStringMaster,
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				
				wordType = scalar == System.DBNull.Value ? null : (int?) scalar;
				
				if (wordType == 1)
				{
					continue;
				}

				alphabetSequenceScriptureReferenceSelectStatement = String.Format
				(
					AlphabetSequenceScriptureReferenceSelectStatementFormat,
					alphabetSequenceScriptureReferenceWhereClause,
					adjust
				);
				
				scalar = DataCommand.DatabaseCommand
				(
					alphabetSequenceScriptureReferenceSelectStatement,
					(SqlContext.IsAvailable) ? "context connection=true" : DataCommand.ConnectionStringMaster,
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				
				//System.Console.WriteLine(alphabetSequenceScriptureReferenceSelectStatement);
				
				wordListed = scalar == System.DBNull.Value ? null : (int?) scalar;
				
				if (wordListed == null)
				{
					continue;
				}

				if (wordInScriptureReference.Length == 0)
				{
					wordInScriptureReference.Append
					(
						adjust
					);
				}
				else
				{
					alreadyPresent = wordInScriptureReference.ToString().IndexOf
					(
						adjust,
						StringComparison.OrdinalIgnoreCase
					);
					
					if (alreadyPresent < 0)
					{
						wordInScriptureReference.Append
						(
							", " + adjust
						);
					}	
				}
			}
				
			//System.Console.WriteLine(wordInWhere);
			//System.Console.WriteLine(wordInScriptureReference);
			
			return wordInScriptureReference.ToString();
		}
		
		public const string LikeClauseFormat = "question LIKE '%{0}%'";
		public const string SelectStatementWordInWhereBeginFormat = @"VerseText IN ('%{0}%'";
		public const string SelectStatementWordInWhereContinueFormat = @", '%{0}%'";
		public const string SelectStatementWordTypeFormat = @"SELECT 1 FROM WordEngineering..WordType
			WHERE Words LIKE '%{0}%'
		";
		public const string AlphabetSequenceScriptureReferenceSelectStatementFormat = @"
			SELECT 1 FROM Bible..Scripture WHERE {0} AND VerseText LIKE '%{1}%'
		";	
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
	}
}
