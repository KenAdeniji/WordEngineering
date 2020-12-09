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
        2017-03-23	Created.	BibleStatisticsLogicACoOperatorOfOurApartHelper.cs
								And, nor, or, with.
    */
    public static partial class BibleStatisticsLogicACoOperatorOfOurApartHelper
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
			StringBuilder wordWhere = new StringBuilder();

			for (int i = 0; i < Word.Length; i++)
			{
				//System.Console.Write("Element({0}): ", i);

                if (sqlStatement.Length > 0)
                {
                    sqlStatement.Append(" UNION ");
                }

				wordWhere = new StringBuilder();

				string word = Word[i];
				
				wordWhere.AppendFormat
				(
					WholeWordsWildCardSearchQueryFormat,
					bibleVersion,
					word
				);
				
                sqlStatement.AppendFormat
                (
                    BibleStatisticsCommunicationQueryFormat,
					word,	
					wordWhere
                );
			}

            sqlStatement.Append
			(
				BibleStatisticsCommunicationOrderByClause
			);
			
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

		public static readonly string[] Word = new string[]
		{ 
			"And",
			"Both",
			"Either",
			"Neither",
			"Nor",
			"Not",
			"Or",
			"With"
		};		

        public const string BibleStatisticsCommunicationQueryFormat = " SELECT " +
			" COUNT(*) AS VerseCount, " +
			" '{0}' AS Word, " +			
			" (SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MIN(verseIdSequence) FROM Bible..Scripture WHERE {1})) AS WordFirstScriptureReference, " +
			" (SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MAX(verseIdSequence) FROM Bible..Scripture WHERE {1})) AS WordLastScriptureReference " +
			" FROM Bible..Scripture " +
			" WHERE {1} ";

        public const string BibleStatisticsCommunicationOrderByClause = " ORDER BY " + " Word";
		
		public const string WholeWordsWildCardSearchQueryFormat = " ( {0} LIKE '%[^a-z]{1}[^a-z]%' ) ";		
    }
}
