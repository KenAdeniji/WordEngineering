using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2016-01-28	Created.	HisWordHelper.cs
			APairingOfOurSum()
			BibleWord versus HisWord?
		2016-03-15	string[] words = sentence.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);	
		2017-05-13	ExcludeNonEssentialPartsOfSpeech(List<String> existWords) 	
			csi.edu/ip/adc/faculty/bbennett/ps011exp.htm
			BrenOCon.com
		2017-05-14	WordPreExistence(string question)
		2017-07-05	AsYouUseIt()
	*/
	public static partial class HisWordHelper
	{
		public static void Main(string[] argv)
		{
			DataSet resultSet = null;
			if (argv.Length > 0)
			{
				resultSet = APairingOfOurSum(argv[0]);
				BuildResult(resultSet);
				System.Console.WriteLine
				(
					AsYouUseIt(argv[0])
				);	
			}		
		}

		public static DataSet APairingOfOurSum
		(
			String	question
		)
		{
			DataSet dataSet = null;
			
			question = question.Replace("'", "''");
			dataSet = CheckForPhrase(question);
			//dataSet.Tables[0].DumpDataTable();
			if (dataSet.IsEmpty() == false)
			{
				return dataSet;
			}
			
			List<string> existWords = WordPreExistence(question);
			
			string wordCombination = string.Join(" ", existWords.ToArray());
			dataSet = CheckForPhrase(wordCombination);
			if (dataSet.IsEmpty() == false)
			{
				return dataSet;
			}
			dataSet = CheckForCombination(existWords, "and");
			if (dataSet.IsEmpty() == false)
			{
				return dataSet;
			}

			List<string> essentialPartsOfSpeech = ExcludeNonEssentialPartsOfSpeech(existWords);

			if (essentialPartsOfSpeech == null || essentialPartsOfSpeech.Count == 0)
			{
				return null;
			}	
			
			wordCombination = string.Join(" ", essentialPartsOfSpeech.ToArray());
			
			dataSet = CheckForPhrase(wordCombination);
			if (dataSet.IsEmpty() == false)
			{
				return dataSet;
			}
			
			dataSet = CheckForCombination(essentialPartsOfSpeech, "and");
			
			return dataSet;
		}
		
		//Created AsYouUseIt().
		[SqlFunction(DataAccess = DataAccessKind.Read)]
		public static SqlString AsYouUseIt
		(
			String question
		)
		{
			DataSet dataSet = APairingOfOurSum(question);
			StringBuilder ids = dataSet.ConcatenateColumnID("SequenceOrderId");
			return ids.ToString();
		}
		
		public static DataSet CheckForCombination
		(
			List<String>	keywords,
			String			logic
		)
		{
			DataSet dataSet = null;
			StringBuilder sqlWhereClause = new StringBuilder(" WHERE ");

			if (keywords.Count == 0)
			{
				return dataSet;
			}

			for(int wordIndex = 0; wordIndex < keywords.Count; ++wordIndex)
			{
				if (wordIndex > 0)
				{
					sqlWhereClause.Append(" " + logic + " ");
				}
				
				sqlWhereClause.AppendFormat
				(
					WholeWordsWildCardSearchQueryFormat,
					keywords[wordIndex]
				);
			}
			StringBuilder sqlStatement = new StringBuilder();
			sqlStatement.AppendFormat(HisWordQueryFormat, sqlWhereClause);
			dataSet = ProcessSqlStatement(sqlStatement);

			//dataSet.Tables[0].DumpDataTable();
			return dataSet;
		}
		
		public static DataSet CheckForPhrase
		(
			String	question
		)
		{
			DataSet dataSet = null;
			StringBuilder sqlWhereClause = new StringBuilder(" WHERE ");

			question = question.Trim();
			
			if (question.Length == 0)
			{
				return dataSet;
			}

			sqlWhereClause.AppendFormat
			(
				WholeWordsWildCardSearchQueryFormat,
				question
			);
			
			StringBuilder sqlStatement = new StringBuilder();
			sqlStatement.AppendFormat(HisWordQueryFormat, sqlWhereClause);
			dataSet = ProcessSqlStatement(sqlStatement);

			//dataSet.Tables[0].DumpDataTable();
			return dataSet;
		}

		public static List<String> ExcludeNonEssentialPartsOfSpeech(List<String> existWords)
		{
			List<String>	essentialPartsOfSpeech	 = new List<String>();

			String nonessentialPartsOfSpeech = (String)DataCommand.DatabaseCommand
			(
				NonEssentialPartsOfSpeechQueryFormat,
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			
			int indexFound = -1;
			
			foreach(String existWord in existWords)
			{
				indexFound = nonessentialPartsOfSpeech.IndexOf(existWord, StringComparison.CurrentCultureIgnoreCase);
				if (indexFound < 0)
				{
					essentialPartsOfSpeech.Add(existWord);
				}	
			}

			return essentialPartsOfSpeech;
		}
		
		public static DataSet Query
		(
			String	logic,
			String	question,
			bool	wholeWords
		)
		{
			DataSet resultSet = null;
			StringBuilder sqlWhereClause = new StringBuilder();
			String[] keywords = null;

			StringBuilder sqlWord = PrepareSqlStatement
            (
                logic,
                question,
				wholeWords,
                out keywords
            );
			if (sqlWord.Length == 0)
			{
				return resultSet;
			}
			else
			{
				sqlWhereClause.AppendFormat
				(
					WhereQueryFormat,
					"(" + sqlWord + ")"
				);
			}
			
			StringBuilder sqlStatement = new StringBuilder();
			sqlStatement.AppendFormat(HisWordQueryFormat, sqlWhereClause);
			resultSet = ProcessSqlStatement(sqlStatement);
			return resultSet;
		}
		
		public static StringBuilder BuildResult
		(
			DataSet dataSet
		)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<table id='resultSet' border='1'>");
			foreach(DataTable dataTable in dataSet.Tables)
			{
				foreach(DataRow dataRow in dataTable.Rows)
				{
					int sequenceOrderID = (int) dataRow["SequenceOrderID"];
					DateTime dated = (DateTime) dataRow["Dated"];
					string word = (string) dataRow["Word"];
					
					sb.Append
					(
						"<tr><td>" + sequenceOrderID + "</td><td>" + dated + 
						"</td><td>" + word + "</td></tr>"
					);
				}
			}
			sb.Append("</table>");
			return sb;
		}
		
		public static StringBuilder PrepareSqlStatement
        (
            string logic,
            string question,
			bool wholeWords,
            out string[] keywords
        )
		{
			if (logic == "phrase")
			{
				keywords = new String[] { question };
			}
			else
			{
				keywords = Split(question);
			}	
			
			string queryFormat = wholeWords ? WholeWordsWildCardSearchQueryFormat : PartialWordsQueryFormat;
			StringBuilder sqlStatement = new StringBuilder();
			StringBuilder sqlWhereClause = new StringBuilder();
			
			for(int index = 0, count = keywords.Length; index < count; ++index)
			{
				keywords[index] = keywords[index].Trim();
				if (index > 0)
				{
					sqlWhereClause.Append(' ' + logic + ' ');
				}
				sqlWhereClause.AppendFormat(queryFormat, keywords[index]);
			}
			return sqlWhereClause;
		}

		public static DataSet ProcessSqlStatement(StringBuilder sql)
		{
			DataSet dataSet = null;
			dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				sql.ToString(),
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return dataSet;
		}

		public static string[] Split
        (
			string sentence
        )
		{
			string[] words = sentence.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			return words;
		}

		public static List<string> WordPreExistence(string question)
		{
			string[] keywords = Split(question);
			
			var distinctWords = new List<string>(keywords.Distinct());
			List<string> existWords = new List<string>();

			foreach(string word in distinctWords)
			{
				string wholeWordsFindSqlStatement = String.Format
				(
					WholeWordsWildCardSearchQueryFormat,
					word
				);	
				string hisWordFindSqlStatement = String.Format
				(
					HisWordFindFormat,
					" WHERE " + wholeWordsFindSqlStatement
				);	
				Object result = DataCommand.DatabaseCommand
				(
					hisWordFindSqlStatement,
					System.Data.CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				int sequenceOrderID = -1;
				if (result != null && result != DBNull.Value)
				{
					sequenceOrderID = (int) result;
					existWords.Add(word);
				}		
			}	
			
			return existWords;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
		
		public const string HisWordQueryFormat = "SELECT * FROM WordEngineering..HisWord {0} ORDER BY HisWordID ;";
		public const string	HisWordFindFormat = "SELECT TOP 1 HisWordID FROM WordEngineering..HisWord {0}";
		public const string NonEssentialPartsOfSpeechQueryFormat = "SELECT STUFF((SELECT ' ' + Commentary + ' ' FROM WordEngineering..ActToGod WHERE Major = 'Parts of Speech' FOR XML PATH('')) ,1,1,'') AS nonEssentialPartsOfSpeech";
		public const string WhereQueryFormat = " WHERE {0} {1} {2} ";
		public const string WholeWordsWildCardSearchQueryFormat = "  ( Word LIKE  '%[^a-z]{0}[^a-z]%' ) ";
		public const string PartialWordsQueryFormat = "   ( Word LIKE '%{0}%' ) ";
	}
}
