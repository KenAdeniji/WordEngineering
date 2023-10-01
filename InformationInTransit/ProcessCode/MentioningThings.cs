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
	///	2023-09-28T13:14:00 Word heard. Mentioning things. 
	///		BN.com 3600 Stevens Creek Boulevard. Stevens Creek and San Tomas. San Jose,	California (CA) 95117.
	///	2023-09-29T11:51:00 Created.
	///		Exact table?
	///	2023-09-29T11:51:00 ... 2023-09-29T12:52:00 Code.
	///	2023-09-29T12:57:00 ... 2023-09-29T13:43:00 Debug.	
	///</summary>
	public class MentioningThings
	{
		public static DataTable Query
		(
			string 	scriptureReference,
			string 	bibleVersion,
			string	word
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
			resultDataTable.AcceptChanges();
			return resultDataTable;
		}	
	}
}
