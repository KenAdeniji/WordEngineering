using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.DataAccess;	

namespace InformationInTransit.ProcessCode
{
	/*
		2018-11-29	https://webstyleguide.com/1-strategy.html
		2018-11-30
		No programming experience. A ma lo fun ki ni kan, Monday.
		No programming experience. We will go for something, Monday. 
		A female wants to visit the Bays, she holds a map.
		I am on the West wall that runs vertically and a Caucasian male let me down.
		At a get together, I eat cookies.
		In the case of dreams, when there are no words spoken; an alternate to GetAPage.html, AlphabetSequence, is to look at the keywords, in the dream, and do a count group by order by. 
		Eventuate.
		2018-11-30	https://social.msdn.microsoft.com/Forums/vstudio/en-US/77ed73c3-fb56-414a-bacf-0cdcd41afff4/remove-element-from-an-array-of-string?forum=csharpgeneral
		2018-11-30	https://stackoverflow.com/questions/853526/using-linq-to-remove-elements-from-a-listt
		2018-11-30	https://stackoverflow.com/questions/43765962/c-sharp-join-string-comma-delimited-but-double-quote-all-values-inside
		2018-11-30	https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
		2018-11-30T18:55:00 ... 2018-11-30T20:01:00 SelectQuery.Length;
		2018-11-30T23:56:00	https://stackoverflow.com/questions/37575198/using-linq-to-groupby-and-sum-datatable
	*/
    public static partial class Eventuate
    {
        public static void Main(string[] argv)
        {
            Query
			(
				argv[0],
				BibleWordHelper.PartsOfSpeech
			);
        }

		public static DataTable Query
		(
			String sentence,
			String exempt
		)
		{
			string[] sentenceWordsArray = sentence.Split(BibleWordHelper.SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			List<string> sentenceWordsList = new List<string>(sentenceWordsArray);
			string[] exemptWords = exempt.Split(BibleWordHelper.SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			
			sentenceWordsList.RemoveAll(x => exemptWords.Contains(x));

			StringBuilder sbOuter = new StringBuilder();
			StringBuilder sbInner = new StringBuilder();
			
			for
			(
				int outerIndex = 0, outerLength = 3; //SelectQuery.Length;
				outerIndex < outerLength;
				++outerIndex
			)
			{
				if (sbOuter.Length > 0)
				{
					sbOuter.Append(" UNION ");
				}
				sbOuter.AppendFormat
				(
					"SELECT ContactID AS ContactID, Count(*) AS Counter FROM {0} ",
					SelectQuery[outerIndex, 0]
				);
				sbInner = new StringBuilder();
				foreach (String currentWord in sentenceWordsList)
				{
					if (sbInner.Length == 0)
					{
						sbInner.Append(" WHERE ContactID IS NOT NULL AND ( ");
					}
					else 
					{
						sbInner.Append(" OR ");
					}
					sbInner.AppendFormat
					(
						" {0} LIKE '%{1}%' ",
						SelectQuery[outerIndex, 1],
						currentWord
					);
				}
				sbInner.Append(" ) GROUP BY ContactID HAVING Count(*) > 0 ");
				sbOuter.Append(sbInner);
			}
			DataTable tableRaw = (DataTable) DataCommand.DatabaseCommand
			(
				sbOuter.ToString(),
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			DataTable tableSum = tableRaw.AsEnumerable()
				.GroupBy(r => r.Field<int>("ContactID"))
				.Select
				(
					g =>
					{
						var row = tableRaw.NewRow();
						row["ContactID"] = g.Key;
						row["Counter"] = g.Sum(r => r.Field<int>("Counter"));
						return row;
					}
				).CopyToDataTable();
			return tableSum;
		}
		
		public static readonly String[,] SelectQuery = new String[3,2]
        {
            {"WordEngineering..HisWord", "Word"},
            {"WordEngineering..HisWord", "Commentary"},
            //{"WordEngineering..Dream", "Commentary"},
            {"WordEngineering..CaseBasedReasoning", "Commentary"}
        };
    }
}
