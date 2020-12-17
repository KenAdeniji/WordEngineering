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
        2016-06-09	BibleStatisticsPunctuationMarks.html	Created.
        2016-06-10	BibleStatisticsHelper.cs 				Created.
        2016-06-10  http://stackoverflow.com/questions/11912412/single-quotes-escape-during-string-insertion-into-a-database 
    */
    public static partial class BibleStatisticsHelper
    {
        public static void Main(string[] argv)
        {
            DataSet resultSet = null;
            if (argv.Length > 0)
            {
                resultSet = PunctuationMarksQuery(argv[0]);
            }
        }

        public static String CombineVerseText
        (
            String bibleVersion
        )
        {
            DataSet dataSet = null;

			string sqlStatement = String.Format( CombineVerseTextFormat, bibleVersion );
			
			String verseText = (String) DataCommand.DatabaseCommand
            (
                sqlStatement,
                CommandType.Text,
                DataCommand.ResultType.Scalar
            );
            return verseText;
        }

        public static DataSet PunctuationMarksQuery
        (
            String bibleVersion
        )
        {
            DataSet dataSet = null;

            StringBuilder sqlStatement = new StringBuilder();

            foreach (string punctuationMark in PunctuationMarks)
            {
                if (sqlStatement.Length > 0)
                {
                    sqlStatement.Append(" UNION ");
                }

                sqlStatement.AppendFormat
                (
                    BibleStatisticsQueryFormat,
                    bibleVersion,
                    punctuationMark
                );
            }

            sqlStatement.Append(" ORDER BY PunctuationMark ");
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

        public static readonly string[] PunctuationMarks = new String[] 
        {
            ",",
            ".",
            ":",
            ";",
            "(",
            ")",
            "?",
            "!",
            "''"
        };

        public const string BibleStatisticsQueryFormat = "SELECT '{1}' AS	PunctuationMark, " +
    "ScriptureReference		AS	FirstScriptureReference, " +
    "(SELECT scriptureReference FROM Bible..Scripture_View WHERE verseIdSequence = (SELECT MAX(VerseIDSequence) FROM Bible..Scripture WHERE {0} LIKE '%{1}%' )) AS LastScriptureReference, " +
    "(SELECT COUNT (*) FROM Bible..Scripture WHERE {0} LIKE '%{1}%' ) AS VerseCount " +
    "FROM Bible..Scripture " +
    "WHERE verseIdSequence = ( SELECT MIN(VerseIDSequence) FROM Bible..Scripture WHERE {0} LIKE '%{1}%' )";

        public const string BibleVersionDefault = "KingJamesVersion";

		public const string CombineVerseTextFormat =
		@"
			SELECT 
				STUFF((SELECT ' ' + {0}
					FROM Bible..Scripture
					FOR XML PATH('')) ,1,1,'') AS VerseText
		";
		
    }
}
