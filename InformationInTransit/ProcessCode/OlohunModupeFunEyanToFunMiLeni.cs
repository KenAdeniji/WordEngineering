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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	///	2023-10-12 Olohun modupe...fun eyan to fun mi, leni.
	///	At the intersection of Paseo Padre Parkway and Blackstone Way, South East.
	///		Separate the number and the rank.
	///	2023-10-12T20:32:00...2023-10-12T20:54:00 Code.
	///	2023-10-12T20:54:00...2023-10-12T21:13:00 Compile.	
	///</summary>
	public class OlohunModupeFunEyanToFunMiLeni
	{
		public static DataTable Query
		(
			string 	scriptureReference,
			string 	bibleVersion,
			string	word,
			bool	includeRanks,
			bool	includeNumerals
		)
		{
			String[] scriptureReferenceSubset = null;
			DataSet dataSet = null;
			String verseText;
			String[] verseTexts;
			
			word = word.ToLower();
			
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref dataSet,
					ScriptureReferenceHelper.ExactQueryFormat,
					bibleVersion
			);
			
			DataTable workDataTable = null;
			DataTable resultDataTable = new DataTable();

			resultDataTable.Columns.Add("BibleWord", typeof(string));
			resultDataTable.Columns.Add("FirstOccurrenceScriptureReference", typeof(string));
			resultDataTable.Columns.Add("LastOccurrenceScriptureReference", typeof(string));
			resultDataTable.Columns.Add("Occurrences", typeof(long));

			resultDataTable.PrimaryKey = new DataColumn[] 
			{ 
				resultDataTable.Columns["BibleWord"] 				
			};
			
			DataRow workDataRow = null;
			DataRow resultDataRow = null;

			String workScriptureReference = null;

			Object scalarResult = null;
			int wordExists = 0;

			for
			(
				int	
					workDataTableIndex = 0,
					workDataTablesCount = dataSet.Tables.Count;
				workDataTableIndex < workDataTablesCount;
				++workDataTableIndex
			)
			{
				workDataTable = dataSet.Tables[workDataTableIndex];
				for
				(
					int 
						workDataRowsIndex = 0,
						workDataTableRowsCount = workDataTable.Rows.Count
					;
					workDataRowsIndex < workDataTableRowsCount;
					++workDataRowsIndex
				)
				{
					workDataRow = workDataTable.Rows[workDataRowsIndex];
					verseText = workDataRow["VerseText"].ToString().ToLower();
					workScriptureReference = workDataRow["ScriptureReference"].ToString();
					
					if 
					(
						verseText.Contains(word) == false
					)
					{  
						continue;
					}
					
					verseTexts = StringHelper.SplitWords(verseText);
					
					foreach(String verseWord in verseTexts)
					{
						if 
						(
							( includeRanks && Ranks.Contains( verseWord ) )
							||
							( includeNumerals && Numerals.Contains( verseWord ) )
						)
						{		
							resultDataRow = resultDataTable.Rows.Find
							(
								new Object[] 
								{
									verseWord
								}
							);

							if ( resultDataRow == null )
							{
								resultDataRow = resultDataTable.NewRow(); 
								resultDataRow["BibleWord"] = verseWord;
								resultDataRow["FirstOccurrenceScriptureReference"] = workScriptureReference;
								resultDataRow["Occurrences"] = 1;
								resultDataTable.Rows.Add(resultDataRow);		
							}
							else
							{	
								resultDataRow["Occurrences"] = (long) resultDataRow["Occurrences"] + 1;
								resultDataRow["LastOccurrenceScriptureReference"] = workScriptureReference;
							}
						}	
					}	
				}
			}
			resultDataTable.AcceptChanges();
			return resultDataTable;
		}	
		public static readonly string[] Ranks =
		{
			"first", "second", "third", "fourth", "fifth", "sixth", 
			"seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
		};	
		public static readonly string[] Numerals =
		{
			"one", "two", "three", "four", "five",
			"six", "seven", "eight", "nine", "ten",
			"eleven", "twelve", "thirteen", "fourteen", "fiftheen",
			"sixteen", "seventeen", "eighteen", "nineteen", "twenty",
			"thirty", "forty", "fifty", "sixty", "seventy",
			"eighty", "ninety", "hundred", "thousand", "million"
		};	
	}
}
