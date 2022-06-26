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
	///</summary>
	public class DoWeChooseToBeKnownAsWhoHelper
	{
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
			
			int rowID = -1;
			int rowCount = 0;
			int rowFirst = -1;
			int rowIndex = -1;
			
			ScriptureReferenceHelper.Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.ExactQueryFormat,
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
					DataRow[] dataRows = dataTable.Select(expression);				
					
					rowID = -1;
					rowCount = 0;
					
					for(rowIndex = 0; rowIndex < dataRows.Length; ++rowIndex)
					{
						if ( rowID == -1 )
						{
							rowCount = 1;
							rowFirst = rowIndex;
							dataRow = dataRows[rowIndex];

							workRow = workTable.NewRow();
							workRow["WordID"] = ++wordID;
							workRow["BibleWord"] = adjust;
							workRow["FirstOccurrenceScriptureReference"] = dataRow["ScriptureReference"];
							workTable.Rows.Add(workRow);
							continue;
						}	
						++rowCount;
						if ( rowIndex - rowFirst > rowCount )
						{
							workRow["FrequencyOfOccurrence"] = rowCount;
							workRow["LastOccurrenceScriptureReference"] = dataRow["ScriptureReference"];;
						}
					}
				}
			}
			
			workTable.AcceptChanges();
			
			return workTable;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
	}
}
