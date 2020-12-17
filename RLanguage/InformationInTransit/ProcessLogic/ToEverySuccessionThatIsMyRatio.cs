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
        2016-12-08	Created.	ToEverySuccessionThatIsMyRatio.cs
		2019-03-02	one of a thousand (Job 9:3).
    */
    public static partial class ToEverySuccessionThatIsMyRatio
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
			
			for (int index = 0; index < Ratio.Length; index++)
			{
                if (sqlStatement.Length > 0)
                {
                    sqlStatement.Append(" UNION ");
                }

                sqlStatement.AppendFormat
                (
                    BibleStatisticsRatioQueryFormat,
					bibleVersion,
					Ratio[index]
                );
			}
			
            sqlStatement.Append(BibleStatisticsRatioOrderByClause);
			
            System.Console.WriteLine(sqlStatement);
			
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

		public static readonly string[] Ratio = new string[] 
		{ 
			"Half",
			"A third",
			"A fourth",
			"A fifth",
			"Tenth",			
			"One of a thousand"
		};		

        public const string BibleStatisticsRatioQueryFormat = 
		@"
			SELECT
				'{1}' AS Ratio,
				COUNT(*) AS VerseCount,
				(SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MIN(verseIdSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%{1}%')) AS FirstScriptureReference, 
				(SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MAX(verseIdSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%{1}%')) AS LastScriptureReference
			FROM 
				Bible..Scripture_View
			WHERE
			{0} LIKE '%{1}%'
		";
		
        public const string BibleStatisticsRatioOrderByClause = " ORDER BY Ratio";
			
        public const string BibleVersionDefault = "KingJamesVersion";
		
		public const string WholeWordsWildCardSearchQueryFormat = " ( {0} LIKE '%[^a-z]{1}[^a-z]%' ) ";		
    }
}
 