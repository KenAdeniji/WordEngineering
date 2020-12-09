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

namespace InformationInTransit.ProcessLogic
{
	///<summary>
	///	2018-02-04 Created.
	///	2018-02-05 https://stackoverflow.com/questions/5065593/find-the-intersection-of-two-lists-in-linq
	///</summary>
	public static class DidTheDutchWonHelper
	{
		public static void Main(String[] argv)
		{
			DidTheDutchWon
			(
				"KingJamesVersion",
				"Matthew 1:1-17",
				"Luke 3:23-34"
			);	
		}
		
		public static DataSet DidTheDutchWon
		(
			String	bibleVersion,
			String	scriptureReferenceFirst,
			String	scriptureReferenceSecond
		)
		{
			//CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
	
			String[]				scriptureReferenceSubset	=	null;
			DataSet 				dataSetFirst				=	null;
			DataSet 				dataSetSecond				=	null;
			DataTable 				dataTableFirst;
			DataTable 				dataTableSecond;
			StringCollection		uniquesFirst;
			StringCollection		uniquesSecond;
			StringCollection		bibleWordsFirst;
			StringCollection		bibleWordsSecond;
			List<String>			onlyInFirstSet;
			List<String>			onlyInSecondSet;
			List<String>			inBothSets;
	
			ScriptureReferenceHelper.Process
            (
                scriptureReferenceFirst,
                ref scriptureReferenceSubset,
                ref dataSetFirst,
                ScriptureReferenceHelper.BibleQueryFormat,
                bibleVersion
            );

			ScriptureReferenceHelper.Process
            (
                scriptureReferenceSecond,
                ref scriptureReferenceSubset,
                ref dataSetSecond,
                ScriptureReferenceHelper.BibleQueryFormat,
                bibleVersion
            );
			
			dataTableFirst = dataSetFirst.CustomMerge();
			dataTableSecond = dataSetSecond.CustomMerge();
			
			uniquesFirst = DataTableHelper.DataTableColumnSplitStringCollection
			(
				dataTableFirst,
				"VerseText"
			);

			uniquesSecond = DataTableHelper.DataTableColumnSplitStringCollection
			(
				dataTableSecond,
				"VerseText"
			);
			
			DataTable dataTableBibleDictionary = (DataTable) DataCommand.DatabaseCommand
			(
				"SELECT * FROM BibleDictionary..BibleDictionary",
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
			bibleWordsFirst 		= 	BibleDictionaryHelper.FindBibleWords(uniquesFirst);
			bibleWordsSecond		=	BibleDictionaryHelper.FindBibleWords(uniquesSecond);
			
			var	firstBibleWords 	= 	bibleWordsFirst.Cast<string>().ToList();
			var	secondBibleWords	= 	bibleWordsSecond.Cast<string>().ToList();

			onlyInFirstSet			= 	firstBibleWords.Except(secondBibleWords).ToList();
			onlyInSecondSet			= 	secondBibleWords.Except(firstBibleWords).ToList();
			inBothSets				=	firstBibleWords.Intersect(secondBibleWords).ToList();
			
			DidTheDutchWonHelperFormatted formatted = new DidTheDutchWonHelperFormatted();
			formatted.FirstSet	=	onlyInFirstSet;
			formatted.SecondSet	=	onlyInSecondSet;

			DataTable 	dataTableResultInBothSets 	= DataTableHelper.GetDataTableFromArray
			(
				inBothSets.ToArray(),
				"In Both Sets"
			);
			
			DataTable 	dataTableResultFirst 	= DataTableHelper.GetDataTableFromArray
			(
				onlyInFirstSet.ToArray(),
				"First Only"
			);

			DataTable 	dataTableResultSecond 	= DataTableHelper.GetDataTableFromArray
			(
				onlyInSecondSet.ToArray(),
				"Second Only"
			);
			
			DataSet		dataSetResult	=	new DataSet();
			dataSetResult.Tables.Add(dataTableResultInBothSets);
			dataSetResult.Tables.Add(dataTableResultFirst);
			dataSetResult.Tables.Add(dataTableResultSecond);
			
			return		dataSetResult;
		}
	
		public class DidTheDutchWonHelperFormatted
		{
			public List<String>	FirstSet;
			public List<String>	SecondSet;
		}	
	}
}
