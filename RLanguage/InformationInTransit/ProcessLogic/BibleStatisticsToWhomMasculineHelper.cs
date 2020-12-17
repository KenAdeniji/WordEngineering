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
        2017-10-13	Created.
    */
    public static partial class BibleStatisticsToWhomMasculineHelper
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

            String tableColumn = bibleVersion;
            if (String.Compare(bibleVersion, BibleVersionDefault, true) == 0)
            {
                tableColumn = "VerseText";
            }

            StringBuilder sqlStatement = new StringBuilder();
			StringBuilder oppositeWhere = new StringBuilder();
			StringBuilder wordWhere = new StringBuilder();
			String wordsCombined = "";

			for (int i = 0; i < Opposites.Length; i++)
			{
				//System.Console.Write("Element({0}): ", i);

                if (sqlStatement.Length > 0)
                {
                    sqlStatement.Append(" UNION ");
                }

				wordWhere = new StringBuilder();
				oppositeWhere = new StringBuilder();

				string word = Opposites[i][0];
				string opposite = Opposites[i][1];
				
				wordsCombined = word + " " + opposite;
				
				wordWhere.AppendFormat
				(
					WholeWordsWildCardSearchQueryFormat,
					tableColumn,
					word
				);

				oppositeWhere.AppendFormat
				(
					WholeWordsWildCardSearchQueryFormat,
					tableColumn,
					opposite
				);
				
                sqlStatement.AppendFormat
                (
                    BibleStatisticsOppositesQueryFormat,
					wordsCombined,
                    wordWhere,
					oppositeWhere
                );
			}
			
            sqlStatement.AppendFormat
			(
				BibleStatisticsOppositesOrderByFormat,
				wordsCombined
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

		public static readonly string[][] Opposites = new string[][] 
		{ 
			new string[] {"Man", "Woman"},
			new string[] {"Boy", "Girl"},
			new string[] {"Father", "Mother"},
			new string[] {"He", "She"},
			new string[] {"Him", "Her"},
			new string[] {"Husband", "Wife"},			
			new string[] {"King", "Queen"},
			new string[] {"Male", "Female"},
			new string[] {"Prince", "Princess"},
			new string[] {"Son", "Daughter"}
		};		

        public const string BibleStatisticsOppositesQueryFormat = " SELECT " +
			" COUNT(*) AS VerseCount, " +
			" '{0}' AS Words, " +			
			" (SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MIN(verseIdSequence) FROM Bible..Scripture WHERE {1})) AS WordFirstScriptureReference, " +
			" (SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MAX(verseIdSequence) FROM Bible..Scripture WHERE {1})) AS WordLastScriptureReference, " +
			" (SELECT COUNT(*) FROM Bible..Scripture WHERE {1}) AS OppositeVerseCount, " +			
			" (SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MIN(verseIdSequence) FROM Bible..Scripture WHERE {2})) AS OppositeFirstScriptureReference, " +
			" (SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MAX(verseIdSequence) FROM Bible..Scripture WHERE {2})) AS OppositeLastScriptureReference, " +
			" (SELECT COUNT(*) FROM Bible..Scripture WHERE {2}) AS WordVerseCount " +			
			" FROM Bible..Scripture " +
			" WHERE {1} OR {2} ";

        public const string BibleStatisticsOppositesOrderByFormat = " ORDER BY " + " Words";
			
        public const string BibleVersionDefault = "KingJamesVersion";
		
		public const string WholeWordsWildCardSearchQueryFormat = " ( {0} LIKE '%[^a-z]{1}[^a-z]%' ) ";		
    }
}
 