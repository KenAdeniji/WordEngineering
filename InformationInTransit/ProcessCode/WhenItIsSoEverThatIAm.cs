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
	///	2023-09-30T18:48:00 When it is so ever...that I Am?
	///		Boba Queen. 34420A Fremont Boulevard. Fremont, California (CA) 94555, walking northward. 2 lesbian females were sitting down and kissing.
	///		2023-09-30T20:01:00 ... 2023-09-30T20:15:00 On Paseo Padre Parkway between Blackstone Way and Siward Drive. Select 1 FROM BibleDictionary..WordDictionary WHERE BibleWord = @BibleWord. Orange fruit seed hanging off the branch of a tree. Light blue face mask on the ground.  Walking southward. 19:34 Urine. 19:44 Urine. 20:11 Microsoft Windows operating system no response error, mouse error, keyboard error, clipboard error.
	///		2023-09-30T20:01:00 ... 2023-09-30T21:10:00 Code complete.
	///</summary>
	public class WhenItIsSoEverThatIAm
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
			resultDataTable.Columns.Add("BibleDictionary", typeof(string));
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
						scalarResult = DataCommand.DatabaseCommand
						(
							String.Format
							(
								WordExists,
								verseWord
							),
							System.Data.CommandType.Text,
							DataCommand.ResultType.Scalar
						);
				
						if
						(
							scalarResult == null || scalarResult == DBNull.Value
						)
						{
							continue;
						}
						
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
							resultDataRow["BibleDictionary"] = verseWord;
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
		
		public const string WordExists = @"
			SELECT TOP 1 1 WordExists
			FROM BibleDictionary..BibleDictionary
			WHERE BibleWord = '{0}'
		";
	}
}
