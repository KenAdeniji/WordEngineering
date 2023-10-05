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

namespace InformationInTransit.ProcessCode
{
	/*
		2023-07-13T15:29:00 ... 2023-07-13T16:39:00 Created.
		2023-07-13T15:29:00 ... 2023-07-13T16:39:00 Code.
		2023-07-13T15:29:00 ... 2023-07-13T16:39:00 Compile.
		2019-04-04T12:08:00 andre.nguyen@gqrgm.com
			Andre Nguyen. 
			Recruiting for Larry Page, Kitty Hawk, Javascript.
		Larry Page, co-founder Google.
			http://en.wikipedia.org/wiki/PageRank
		2023-07-13T15:49:00 WHERE	Word IS NOT NULL
		2023-07-1315:59:00 ... 2023-07-1316:16:00
			http://www.blackwasp.co.uk/soundex.aspx
			http://www.blackwasp.co.uk/soundex_2.aspx
		2023-07-1316:26:00 0.0 RankImportance	
	*/
	public class MoMoPeHarryAMoSoPeYouDoWell
	{
		public static void Main(String[] args)
		{
			Query(args[0]);
		}	
		public static DataView Query
		(
			String word
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
			decimal rankImportance;
			String[] hisWordWord;
			int hisWordWordLength = 0;
			SoundexUtility soundexUtility = new SoundexUtility();
			foreach(DataRow dataRow in resultTable.Rows)
			{
				rankImportance = 0;
				foreach(String wordCurrent in words)
				{
					hisWordWord = dataRow["Word"].ToString().Split
					(
						ScriptureReferenceHelper.SubsetSeparator,
						StringSplitOptions.RemoveEmptyEntries 
					);
					hisWordWordLength = hisWordWord.Length;
					foreach(String hisWordWords in hisWordWord)
					{
						rankImportance +=
							soundexUtility.Compare
							(
								wordCurrent,
								hisWordWords
							);
					}	
				}
				dataRow["RankImportance"] =
					rankImportance /
					hisWordWordLength
					;
			}	

			// Create DataView
			DataView view = new DataView(resultTable);
			view.Sort = "RankImportance DESC, HisWordID DESC";
			
			return view;
		}
		
        public const string QueryStatement = 
		@"
			SELECT
				0.0 RankImportance,
				HisWordID,
				Dated,
				Word,
				Commentary
			FROM 	WordEngineering..HisWord				
			WHERE	Word IS NOT NULL
				AND	Word LIKE '%September%'
			ORDER BY HisWordID DESC
		";
	}
}
