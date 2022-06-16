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
	///	2022-06-15T22:11:00 Created.
	///</summary>
	public class OneMustAddToTheSourceOfGovernmentHelper
	{
		public static DataTable Extract
		(
			string 			scriptureReference,
			ref String[] 	scriptureReferenceSubset,
			ref DataSet 	result,
			string			bibleWord,
			string			bibleVersion
		)
		{
			//CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

			string adjust = null;
			string verseText = null;
			string[] words = null;
			
			DataRow workRow = null;
		
			ScriptureReferenceHelper.Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.ExactQueryFormat,
                bibleVersion
            );

			DataTable workTable = new DataTable();
			workTable.Columns.Add("BibleWord", typeof(string));
			workTable.Columns.Add("FirstOccurrenceScriptureReference", typeof(string));
			workTable.Columns.Add("LastOccurrenceScriptureReference", typeof(string));
			workTable.Columns.Add("FrequencyOfOccurrence", typeof(int));
			workTable.PrimaryKey = new DataColumn[] { workTable.Columns["BibleWord"] };

			foreach(DataTable dataTable in result.Tables)
			{
				foreach(DataRow dataRow in dataTable.Rows)
				{
					verseText = (string) dataRow["VerseText"];
					words = verseText.Split(SplitSeparator);
					foreach(string word in words)
					{
						adjust = word.Trim();
						if (adjust == String.Empty)
						{
							continue;
						}
						adjust = char.ToUpper(adjust[0]) + adjust.Substring(1);
						scriptureReference = (string) dataRow["ScriptureReference"];

						workRow = workTable.Rows.Find(adjust);
						if (workRow == null)
						{
							workRow = workTable.NewRow();
							workRow["BibleWord"] = adjust;
							workRow["FirstOccurrenceScriptureReference"] = scriptureReference;
							workRow["FrequencyOfOccurrence"] = 1;
							workTable.Rows.Add(workRow);  
						}
						else
						{
							workRow["LastOccurrenceScriptureReference"] = scriptureReference;
							workRow["FrequencyOfOccurrence"] = (int) workRow["FrequencyOfOccurrence"] + 1;
						}
					}
				}	
			}
			
			return workTable;
		}
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};

        public class SameWordComparer : EqualityComparer<string>
        {
            public override bool Equals(string s1, string s2)
            {
                return s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase);
            }

            public override int GetHashCode(string s)
            {
                return base.GetHashCode();
            }
        }

        public class Participation
        {
			public string BibleWord { get; set; }
            public string FirstOccurrenceScriptureReference { get; set; }
            public string LastOccurrenceScriptureReference { get; set; }
            public int FrequencyOfOccurrence { get; set; }
        }	
	}
}
