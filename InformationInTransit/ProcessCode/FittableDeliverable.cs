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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

using ChristianNagel;	

namespace InformationInTransit.ProcessCode
{
	/*
		2023-09-07 Fittable deliverable.
		2023-09-07T21:30:00 Created.
		2023-09-07T22:38:00	Code complete.
		2023-09-08T00:21:00	... 2023-09-08T04:40:00 Debug .asmx ... .html.
		2023-09-08T08:36:00	http://stackoverflow.com/questions/13220279/comparing-two-int-variables-with-room-margin-for-error
		2023-09-08T08:40:00	http://stackoverflow.com/questions/4767656/most-reliable-way-of-comparing-datetimes
		2023-09-08T08:07:00	... 2023-09-08T11:35:00 Debug .asmx ... .html. Suppress discard columns.
	*/
	public class FittableDeliverable
	{
		public static DataTable Query
		(
			String 	word,
			bool	displayCombinedResults
		)
		{
			String[] words = word.Split
			(
				ScriptureReferenceHelper.SubsetSeparator,
				StringSplitOptions.RemoveEmptyEntries 
			);
			DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
			(
				QueryStatement,
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
			double rankImportance;
			String[] combinedResultsWord;
			int combinedResultsWordLength = 0;
			SoundexUtility soundexUtility = new SoundexUtility();
			
			bool isDateTime = false;
			bool isNumeric = false;
			
			DateTime datedFrom;
			DateTime datedUntil;
			
			Int32 rememberFromUntil;
			
			foreach(DataRow dataRow in resultTable.Rows)
			{
				rankImportance = 0;
				foreach(String wordCurrent in words)
				{
					combinedResultsWord = dataRow["combinedResults"].ToString().Split
					(
						ScriptureReferenceHelper.SubsetSeparator,
						StringSplitOptions.RemoveEmptyEntries 
					);
					combinedResultsWordLength = combinedResultsWord.Length;
					
					foreach(String combinedResultsWords in combinedResultsWord)
					{
						rankImportance = 0;
						isDateTime = wordCurrent.IsDateTime();
						isNumeric = wordCurrent.IsNumeric();
						
						if ( isNumeric == true )
						{
							rememberFromUntil = (Int32) dataRow["RememberFromUntil"];
							rankImportance += 
								rememberFromUntil * 
								Int32.Parse(wordCurrent) /
								Int32.MaxValue;
						}			
						else
						{	
							rankImportance +=
								( 1.0 / 4.0 ) *
								soundexUtility.Compare
								(
									wordCurrent,
									combinedResultsWords
								);
						}		
					}	
				}
				
				if ( combinedResultsWordLength < 1 )
				{
					dataRow.Delete();
				}		
				else
				{	
					dataRow["Rank"] = rankImportance / combinedResultsWordLength;
				}	
			}	

			resultTable.AcceptChanges();

			if (displayCombinedResults == false)
			{	
				resultTable.Columns.Remove("CombinedResults");
			}	

			Dictionary<string, string> dictionarySort = new Dictionary<string, string>();
			dictionarySort.Add("Rank", "desc");
			dictionarySort.Add("RememberID", "desc");
			
			resultTable.DefaultView.RowFilter = "Rank > 0";
			
			resultTable.DefaultView.Sort = 
                  String.Join(",", dictionarySort.Select(x => x.Key + " " + x.Value).ToArray());
			resultTable = resultTable.DefaultView.ToTable();
			
			return resultTable;
		}

        public const string QueryStatement = 
		@"
			SELECT
				0.0 Rank,
				t1.RememberID			RememberID,
				t1.DatedFrom			RememberDatedFrom,
				t1.DatedUntil			RememberDatedUntil,
				t1.FromUntil			RememberFromUntil,
				t1.ToFro				RememberToFro,
				t1.YearMonthWeekDay		RememberYearMonthWeekDay,
/*				
				t2.HisWordID			HisWordID,
				t2.Word					HisWordWord,
				t2.Commentary			HisWordCommentary,
				t3.ContactID			ContactContactID,
				t3.Name					ContactName,
				t3.Telephone			ContactTelephone,
				t3.Email				ContactEmail,
				t3.URI					ContactURI,
				t3.StreetAddress		ContactStreetAddress,
*/				
					CONVERT( VARCHAR, t1.DatedFrom )	+ ' ' +
					CONVERT( VARCHAR, t1.DatedUntil ) + ' ' +
					CONVERT( VARCHAR, t1.FromUntil ) + ' ' +
					CONVERT( VARCHAR, t1.ToFro ) + ' ' +
					CONVERT( VARCHAR, t1.YearMonthWeekDay ) + ' ' +	
					ISNULL( t2.Word, '' ) + ' ' +	
					ISNULL( t2.Commentary, '' ) + ' ' +	
					ISNULL( t3.Name, '' ) + ' ' +
					ISNULL( t3.Telephone, '' ) + ' ' + 
					ISNULL( t3.Email, '' ) + ' ' + 
					ISNULL( t3.URI, '' ) + ' ' +
					ISNULL( t3.StreetAddress, '' )
				CombinedResults
			FROM 	WordEngineering..Remember_View t1 
			FULL OUTER JOIN	WordEngineering..HisWord_View t2 ON (t1.HisWordID = t2.HisWordID )
			FULL OUTER JOIN	WordEngineering..ViewContactSet t3 ON ( t1.ContactID = t3.ContactID )
			WHERE 
				t1.ContactID IS NOT NULL
			AND t1.HisWordID IS NOT NULL	
			ORDER BY t1.RememberID DESC
		";
	}
}
