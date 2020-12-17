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
using System.Data.SqlClient;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
    /*
        2017-02-21	BibleStatisticsToExpertAtHandIsToExpertAtEvenHelper.cs	Created.
		2016-06-12	https://msdn.microsoft.com/en-us/library/2yd9wwz4.aspx
		2016-06-12	https://msdn.microsoft.com/en-us/library/2s05feca.aspx
		2016-06-12	https://msdn.microsoft.com/en-us/library/aa287601%28v=vs.71%29.aspx
    */
    public static partial class BibleStatisticsToExpertAtHandIsToExpertAtEvenHelper
    {
        public static void Main(string[] argv)
        {
            DataSet resultSet = null;
            if (argv.Length > 0)
            {
                resultSet = Query(argv[0]);
            }
        }

        public static DataSet Query
        (
            String bibleVersion
        )
        {
            DataSet dataSet = null;

            StringBuilder sqlStatement = new StringBuilder();
			StringBuilder wholeWords = new StringBuilder();
			StringBuilder wordsCombined = new StringBuilder();

			for (int i = 0; i < Activities.Length; i++)
			{
				//System.Console.Write("Element({0}): ", i);

                if (sqlStatement.Length > 0)
                {
                    sqlStatement.Append(" UNION ");
                }

				wholeWords = new StringBuilder();
				wordsCombined = new StringBuilder();
				
				for (int j = 0; j < Activities[i].Length; j++)
				{
					//System.Console.Write("{0}{1}", Activities[i][j], j == (Activities[i].Length - 1) ? "" : " ");

					if (wholeWords.Length > 0)
					{
						wholeWords.Append(" OR ");
						wordsCombined.Append(" ");
					}
					
					wholeWords.AppendFormat
					(
						WholeWordsWildCardSearchQueryFormat,
						bibleVersion,
						Activities[i][j]
					);
					
					wordsCombined.Append(Activities[i][j]);
				}

                sqlStatement.AppendFormat
                (
                    BibleStatisticsActivitiesQueryFormat,
                    wholeWords,
					wordsCombined,
					Organs[i]					
                );
				
				System.Console.WriteLine();            
			}
			
            sqlStatement.AppendFormat
			(
				BibleStatisticsActivitiesOrderByFormat,
				wordsCombined
			);
			
            //System.Console.WriteLine(sqlStatement);
			
            dataSet = ProcessSqlStatement(sqlStatement);
            return dataSet;
        }

        public static DataSet ProcessSqlStatement(StringBuilder sql)
        {
            DataSet dataSet = null;
            dataSet = (DataSet)DataCommand.DatabaseCommand
            (
                sql.ToString(),
                CommandType.Text,
                DataCommand.ResultType.DataSet
            );
            return dataSet;
        }

		public static readonly string[][] Activities = new string[][] 
		{ 
			new string[] {"Heard"},
			new string[] {"See", "Saw"},			
			new string[] {"Said", "Ate", "Drank", "Licked"},
			new string[] {"Smell"}
		};		

		public static readonly string[] Organs = new string[] 
		{ 
			"Ear",
			"Eye",
			"Mouth",
			"Nose"
		};		
		
        public const string BibleStatisticsActivitiesQueryFormat = " SELECT " +
			" COUNT(*) AS VerseCount, " +
			" '{2}' AS Organ, " +
			" '{1}' AS Activity, " +			
			" (SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MIN(verseIdSequence) FROM Bible..Scripture_View WHERE {0})) AS FirstScriptureReference, " +
			" (SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MAX(verseIdSequence) FROM Bible..Scripture WHERE {0})) AS LastScriptureReference " +
			" FROM Bible..Scripture " +
			" WHERE {0} ";

        public const string BibleStatisticsActivitiesOrderByFormat = " ORDER BY Organ";
			
        public const string BibleVersionDefault = "KingJamesVersion";
		
		public const string WholeWordsWildCardSearchQueryFormat = " ( {0} LIKE '%[^a-z]{1}[^a-z]%' ) ";		
    }
}
