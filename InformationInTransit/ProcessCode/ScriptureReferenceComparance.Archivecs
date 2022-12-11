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
	///	2022-12-10T13:43:00 Created.
	///</summary>
	public class ScriptureReferenceComparance
	{
		public static DataTable Query(String scriptureReference, string bibleVersion)
		{
			String[] scriptureReferenceSubset = null;
			DataSet dataSet = null;
			DataTable primaryDataTable; 
			String verseText;
			String[] verseTexts;
			
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref dataSet,
					ScriptureReferenceHelper.ExactQueryFormat,
					bibleVersion
			);
			
			DataTable dataTable;
			long dataTablesCount = dataSet.Tables.Count;
			
			List<StringBuilder> targetSubset = new List<StringBuilder>
				( new StringBuilder[dataTablesCount] );
			
			DataTable wordDataTable = new DataTable();

			wordDataTable.Columns.Add("BibleWord", typeof(string));

			DataRow wordDataRow = null;

			for
			(
				int dataTableIndex = 0;
				dataTableIndex < dataTablesCount;
				++dataTableIndex
			)
			{
				wordDataTable.Columns.Add
				(
					"Occurrences" + (dataTableIndex + 1).ToString().Trim(), 
					typeof(long)
				);
				dataTable = dataSet.Tables[dataTableIndex];
				targetSubset[dataTableIndex] = new StringBuilder();
				for
				(
					int dataRowsIndex = 0, dataTableRowsCount = dataTable.Rows.Count;
					dataRowsIndex < dataTableRowsCount;
					++dataRowsIndex
				)
				{
					verseText = dataSet.Tables[dataTableIndex]
										.Rows[dataRowsIndex]["VerseText"]
										.ToString().ToLower();
					targetSubset[dataTableIndex].Append(verseText);
				}
			}

			wordDataTable.PrimaryKey = new DataColumn[] 
			{ 
				wordDataTable.Columns["BibleWord"] 				
			};

			for
			(
				int dataTableIndex = 0;
				dataTableIndex < dataTablesCount;
				++dataTableIndex
			)
			{
				dataTable = dataSet.Tables[dataTableIndex];
				for
				(
					int dataRowsIndex = 0, dataTableRowsCount = dataTable.Rows.Count;
					dataRowsIndex < dataTableRowsCount;
					++dataRowsIndex
				)
				{
					verseText = dataSet.Tables[dataTableIndex]
										.Rows[dataRowsIndex]["VerseText"]
										.ToString().ToLower();
					verseTexts = StringHelper.SplitWords(verseText);
					
					MatchCollection matches;
					
					foreach(String verseWord in verseTexts)
					{
						wordDataRow = wordDataTable.Rows.Find
						(
							new Object[] 
							{
								verseWord
							}
						);
												
						if ( wordDataRow == null )
						{
							wordDataRow = wordDataTable.NewRow(); 
							wordDataRow["BibleWord"] = verseWord;
							wordDataTable.Rows.Add(wordDataRow);		
						}
			
						for
						(
							int targetIndex = dataTableIndex;
							targetIndex < dataTablesCount;
							++targetIndex
						)
						{
							matches = Regex.Matches
							(
								targetSubset[targetIndex].ToString(),
								verseWord
							);
							wordDataRow
							[
								"Occurrences" + 
								(targetIndex + 1).ToString().Trim()
							] = matches.Count;
						}						
					}	
				}
			}
			wordDataTable.AcceptChanges();
			return wordDataTable;
		}	
	}
}
