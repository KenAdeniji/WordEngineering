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
		2023-07-13T16:39:00 ... 2023-07-13T20:51:00 Debug.
		2019-04-04T12:08:00 andre.nguyen@gqrgm.com
			Andre Nguyen. 
			Recruiting for Larry Page, Kitty Hawk, Javascript.
		Larry Page, co-founder Google.
			http://en.wikipedia.org/wiki/PageRank
		2023-07-13T15:49:00 WHERE	Word IS NOT NULL
		2023-07-13T15:59:00 ... 2023-07-1316:16:00
			http://www.blackwasp.co.uk/soundex.aspx
			http://www.blackwasp.co.uk/soundex_2.aspx
		2023-07-13T16:26:00 0.0 RankImportance	
		2023-07-13T20:43:00 http://stackoverflow.com/questions/31077216/how-to-sort-datatable-with-multi-column-using-linq/31077345#31077345
		2023-07-13T20:50:00 ... 2023-07-13T21:08:00 http://www.20lessons.com/
20 Lessons Book Series
By Robin Nixon


Build
real-world skills in
less than an hour for each lesson,
and follow up to five hours of video tutorials.

Learning web development is now easier than it's ever been

Top-selling author Robin Nixon has written over 30 books on computing, many of which are used as standard references in colleges and universities worldwide. Now Robin brings together his expertise in web development into a new series of titles, each of which will teach you the subject in under 20 lessons of less than an hour each, and that’s including the comprehensive online video tutorial that accompanies each lesson. All the books also come with a collection of example files so you can load them onto your own computer to try out for yourself (mouse over or click the book covers above).

Buy from Amazon and save up to 30%!

    Buy CSS & CSS3: 20 Lessons to Successful Web Development / Kindle Version
    Buy HTML5: 20 Lessons to Successful Web Development / Kindle Version
    Buy JavaScript: 20 Lessons to Successful Web Development / Kindle Version
    Buy PHP: 20 Lessons to Successful Web Development / Kindle Version

Video Tutorials

There are 20 videos per book, comprising between 4 and 5 hours of additional tutorials based around the examples in the books. Altogether there are 80 videos containing almost 20 hours of material.
	*/
	public class ThisIsHowIHaveDesireToUseYou
	{
		public static DataTable Query
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

			Dictionary<string, string> dictionarySort = new Dictionary<string, string>();
			dictionarySort.Add("RankImportance", "desc");
			dictionarySort.Add("HisWordID", "desc");
			
			resultTable.DefaultView.Sort = 
                  String.Join(",", dictionarySort.Select(x => x.Key + " " + x.Value).ToArray());
			resultTable = resultTable.DefaultView.ToTable();
			
			return resultTable;
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
			AND		TRIM(Word) <> ''
			ORDER BY HisWordID DESC
		";
	}
}
