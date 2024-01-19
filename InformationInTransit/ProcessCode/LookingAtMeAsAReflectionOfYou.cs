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
	///	2024-01-19T06:24:00...2024-01-19T08:16:00 Code.
	///	2024-01-16 05:14:20.463	Looking at me as a reflection of you.
	///	Location: On Paseo Padre Parkway overhead bridge between Blackstone Way and Siward Drive, North East, walking towards the South East. I knelt on my right knee on a black plastic bag.	
	///	Commentary: At Creekwood Terrace, I stood, stopped, at the Center of the road. Divider, 2 entrances to the North, and 2 entrances to the South. How I surround myself...in fact. At the Charter Square entrance to Enea Court, between  	Taqueria El Mex-Cal and Liquor store. I have lived this love...to pass it. Mo ti pray...then I listen. I have pray...then I listen. On Paseo Padre Parkway overhead bridge between Blackstone Way and Siward Drive, North East, walking towards the South East. To accept Me...as nobody will try Me. The 3 words phrases written down on the paper and data entry, entered, into the database are separateable into 3 words and 5 words. The 1st entry, record, is for 4 lanes, roads paths into the Creekwood Terrace and there are 4 beasts, 4 kingdoms, in Daniel 7. Isaiah 53? Yesterday, 2024-01-15 you saw a vehicle with Panther written on it, pass Highway 880 North, towards. TIFF...Kowe? Computer. Must move beyond the part...to the normal. Signature verification? Yoruba alphabets distinction from English alphabets. Sun and Moon, sign? When did He get exact? As He approach? Sir Robert Anderson in his book, The Coming Prince? Prophet Daniel's accuracy.. 06:15 Whose intelligence...I use? 06:16 What did He rely on...to be the same? 06:16 What did He rely on...to be same? 06:18 With us...meeting our match?
	///	http://www.robertrubin.com/the-yellow-pad
	///	BibleWord,
	///	FirstOccurrenceScriptureReference,
	///	LastOccurrenceScriptureReference,
	///	Occurrences
	///	Exact.
	///</summary>
	public class LookingAtMeAsAReflectionOfYou
	{
		public static DataTable Query
		(
			string	word,
			string 	bibleVersion,			
			string 	scriptureReference,
			bool	wholeWords
		)
		{
			String[] scriptureReferenceSubset = null;
			DataSet dataSet = null;
			String verseText;
			String[] verseTexts;
			
			word = word.ToLower();
			
			String[] words = StringHelper.SplitWords(word);
			
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

			foreach(String currentWord in words)
			{
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
						
						verseTexts = StringHelper.SplitWords(verseText);
						
						foreach(String verseWord in verseTexts)
						{
							if
							(
								( wholeWords && verseWord.Equals(currentWord) )
								||
								( !wholeWords  && verseWord.Contains(currentWord) )
							)
							{		
								resultDataRow = resultDataTable.Rows.Find
								(
									new Object[] 
									{
										currentWord
									}
								);

								if ( resultDataRow == null )
								{
									resultDataRow = resultDataTable.NewRow(); 
									resultDataRow["BibleWord"] = currentWord;
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
			}
			resultDataTable.AcceptChanges();
			return resultDataTable;
		}	
	}
}
