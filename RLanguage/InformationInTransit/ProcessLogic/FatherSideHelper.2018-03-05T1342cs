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

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2018-02-27	Father you have been, in me; this is my side, in you. Get all the occurrences of a word, and find the count of words and letters on either sides of the word, first or last occurrence of the word.
		2018-03-04	Created.
	*/
	public static partial class FatherSideHelper
	{
		public static void Main(string[] argv)
		{
			DataSet 		resultSet = null;
			String[]		scriptureReferenceSubset = null;
			StringBuilder	sql	= null;
			
			if (argv.Length > 0)
			{
                resultSet = Filter
				(
					BibleQuery.BibleQueryFormat,
					BibleQuery.BibleVersionDefault,
					argv[0],
					true,
					"all",
					"and",
					ref resultSet,
					"Genesis 22, John 1",
					ref scriptureReferenceSubset,
					ref sql,
					true
				);
			}		
		}

		public static DataSet Filter
		(
					String			bibleQueryFormat,
					String			bibleVersion,
					String			bibleWord,
					bool			forwardDirection,
					String			limitChosen,
					String			logic,
			ref 	DataSet			resultSet,
					String			scriptureReference,
			ref 	String[]		scriptureReferenceSubset,
			ref		StringBuilder	sql,
					bool			wholeWords
		)
		{
			BibleQuery.Query
			(
				BibleQuery.BibleQueryFormat,
				bibleVersion,
				bibleWord,
				limitChosen,
				logic,
				ref resultSet,
				scriptureReference,
				ref scriptureReferenceSubset,
				ref sql,
				wholeWords
			);

			string verseText;
			int position;
			string leftSentence;
			string rightSentence;
			int leftWords;
			int rightWords;
			int leftLetters;
			int rightLetters;

			List<Side> Sides = new List<Side>();
			
			foreach(DataTable dataTable in resultSet.Tables)
			{
				foreach(DataRow dataRow in dataTable.Rows)
				{
					verseText = (String) dataRow["VerseText"];
					if (forwardDirection)
					{	
						position = verseText.IndexOf(bibleWord, StringComparison.CurrentCultureIgnoreCase);
					}
					else
					{	
						position = verseText.LastIndexOf(bibleWord, StringComparison.CurrentCultureIgnoreCase);
					}
					leftSentence = verseText.Substring(0, position);
					rightSentence = verseText.Substring(position);
					leftWords = StringHelper.WordCount(leftSentence);
					rightWords = StringHelper.WordCount(rightSentence);
					leftLetters = StringHelper.LetterCount(leftSentence);
					rightLetters = StringHelper.LetterCount(rightSentence);
					Sides.Add
					(
						new Side
						{
							ScriptureReference = ScriptureReferenceHelper.ScriptureReference.Syntax
							(
								(int) dataRow["BookID"],
								(int) dataRow["ChapterID"],
								(int) dataRow["VerseID"]
							),
							Position = position,
							LeftWords = leftWords,
							RightWords = rightWords,	
							LeftLetters = leftLetters,
							RightLetters = rightLetters
						}	
					);	
				}
			}	
			DataTable filterTable = DataTableHelper.ToDataTable(Sides);
			DataSet filterSet = new DataSet();
			filterSet.Tables.Add(filterTable); 
			return filterSet;	
		}
		
		public class Side
		{
			public string ScriptureReference { get; set; }
			public int Position { get; set; }
			public int LeftWords { get; set; }
			public int RightWords { get; set; }
			public int LeftLetters { get; set; }
			public int RightLetters { get; set; }
		}	
	}
}
