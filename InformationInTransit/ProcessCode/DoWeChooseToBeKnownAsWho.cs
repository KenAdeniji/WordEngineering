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
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

using InformationInTransit.DataAccess;

using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	///	2022-06-25T14:10:00 Created.
	///	2022-06-26T12:25:00 Work in progress (WIP).	
	///	2022-06-26T12:36:00 And, ko wa'nbe. And the next row, is not there.
	///	2022-06-26T12:36:00 It should continue; while it is in sequence.
	///</summary>
	public class DoWeChooseToBeKnownAsWhoHelper
	{
		public static void Main(string[] argv)
		{
			string 		scriptureReference = "1 Kings 6";
			String[] 	scriptureReferenceSubset = null;
			DataSet 	result = null;
			String		bibleVersion = "KingJamesVersion";
			String		bibleWord = "Oracle";

			DataTable workTable = DoWeChooseToBeKnownAsWhoHelper.Extract
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref result,
					bibleVersion,
					bibleWord
			);
		}
		
		public static DataTable Extract
		(
			string 			scriptureReference,
			ref String[] 	scriptureReferenceSubset,
			ref DataSet 	result,
			string			bibleVersion,
			string			bibleWord
		)
		{
			//CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

			int wordID = 0;

			string adjust = null;
			string expression = null;
			string[] words = null;
			
			int	bookID = -1;
			int	chapterID = -1;
			int	verseID = -1;
			
			String scriptureReferenceWorkRow = null;
			string scriptureReferenceDetail = null;
			
			int rowIndex = -1;
			
			int	verseIDSequenceCurrent = -1;
			int	verseIDSequenceLast = -1;
			
			ScriptureReferenceHelper.Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.FullPositionQueryFormat,
                bibleVersion
            );

			DataTable workTable = new DataTable();
			workTable.Columns.Add("WordID", typeof(int));
			workTable.Columns.Add("BibleWord", typeof(string));
			workTable.Columns.Add("FirstOccurrenceScriptureReference", typeof(string));
			workTable.Columns.Add("LastOccurrenceScriptureReference", typeof(string));
			workTable.Columns.Add("FrequencyOfOccurrence", typeof(int));
			//workTable.PrimaryKey = new DataColumn[] { workTable.Columns["BibleWord"] };

			DataRow dataRow = workTable.NewRow();
			DataRow workRow = workTable.NewRow();

			words = bibleWord.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);

			foreach(String word in words)
			{
				adjust = word.Trim();
				if (adjust == String.Empty)
				{
					continue;
				}
				adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);
				
				foreach(DataTable dataTable in result.Tables)
				{
					expression = String.Format("VerseText LIKE '%" + word + "%'" );
					DataRow[] dataRows = dataTable.Select(expression, "VerseIDSequence");				
					
					verseIDSequenceCurrent = (int)dataRows[0]["VerseIDSequence"];
					verseIDSequenceLast = verseIDSequenceCurrent - 1;

					dataRow = dataRows[0];

					bookID = (int) dataRow["BookID"];
					chapterID = (int) dataRow["ChapterID"];
					verseID = (int) dataRow["VerseID"];

					scriptureReferenceWorkRow = 
						ScriptureReferenceHelper.ScriptureReference.Syntax(bookID, chapterID, verseID);

					scriptureReferenceDetail = scriptureReferenceWorkRow;
					
					for(rowIndex = 0; rowIndex < dataRows.Length; ++rowIndex)
					{
						dataRow = dataRows[rowIndex];

						if 
						( 
							verseIDSequenceCurrent == verseIDSequenceLast + 1
						)
						{
							workRow = workTable.NewRow();
							workRow["WordID"] = ++wordID;
							workRow["BibleWord"] = adjust;
							
							bookID = (int) dataRow["BookID"];
							chapterID = (int) dataRow["ChapterID"];
							verseID = (int) dataRow["VerseID"];

							scriptureReferenceWorkRow = 
								ScriptureReferenceHelper.ScriptureReference.Syntax(bookID, chapterID, verseID);
							
							workRow["FirstOccurrenceScriptureReference"] = scriptureReferenceWorkRow;
							workRow["FrequencyOfOccurrence"] = 1;
							workTable.Rows.Add(workRow);
						}
						else
						{	
							workRow["FrequencyOfOccurrence"] = verseIDSequenceCurrent - verseIDSequenceLast + 1;
							verseIDSequenceLast = verseIDSequenceCurrent;
							
							workRow["LastOccurrenceScriptureReference"] = scriptureReferenceDetail;
						}
						
						verseIDSequenceCurrent = (int) dataRow["VerseIDSequence"];
						
						bookID = (int) dataRow["BookID"];
						chapterID = (int) dataRow["ChapterID"];
						verseID = (int) dataRow["VerseID"];

						scriptureReferenceDetail = 
							ScriptureReferenceHelper.ScriptureReference.Syntax(bookID, chapterID, verseID);
					}
				}
			}
			
			workTable.AcceptChanges();
			
			return workTable;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
	}
}
