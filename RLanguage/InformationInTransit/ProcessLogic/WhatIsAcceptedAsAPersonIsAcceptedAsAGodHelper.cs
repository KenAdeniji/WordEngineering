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
        2016-12-27	Created.	WhatIsAcceptedAsAPersonIsAcceptedAsAGodHelper.cs
    */
    public static partial class WhatIsAcceptedAsAPersonIsAcceptedAsAGodHelper
    {
        public static void Main(string[] argv)
        {
            DataSet resultSet = null;
            if (argv.Length > 0)
            {
                resultSet = ScriptureReferenceQuery(argv[0], argv[1]);
            }
        }

        public static DataSet BibleWordQuery
        (
            String bibleVersion,
			String word
        )
        {
            DataSet dataSet = null;

            StringBuilder sqlStatement = new StringBuilder();
			StringBuilder wordWhere = new StringBuilder();

			string[] words = word.Split(',');
			
			for (int i = 0; i < words.Length; i++)
			{
				words[i] = words[i].Trim();
                if (sqlStatement.Length > 0)
                {
					sqlStatement.Append(";");
                }

				wordWhere = new StringBuilder();

				wordWhere.AppendFormat
				(
					WholeWordsWildCardSearchQueryFormat,
					bibleVersion,
					words[i]
				);
				
                sqlStatement.AppendFormat
                (
                    BibleWordQueryFormat,
					words[i],	
					wordWhere
                );
			}

            System.Console.WriteLine(sqlStatement);
			
            dataSet = ProcessSqlStatement(sqlStatement);
            return dataSet;
        }

        public static DataSet ScriptureReferenceQuery
        (
            String bibleVersion,
			String word
        )
        {
            DataSet dataSet = null;

            String tableColumn = bibleVersion;
            if (String.Compare(bibleVersion, BibleVersionDefault, true) == 0)
            {
                tableColumn = "VerseText";
            }

            StringBuilder sqlStatement = new StringBuilder();
			StringBuilder wordWhere = new StringBuilder();

			string[] words = word.Split(',');
			
			for (int i = 0; i < words.Length; i++)
			{
				words[i] = words[i].Trim();
                if (sqlStatement.Length > 0)
                {
					sqlStatement.Append(";");
                }

				wordWhere = new StringBuilder();

				wordWhere.AppendFormat
				(
					ScriptureReferenceSearchQueryFormat,
					words[i]
				);
				
                sqlStatement.AppendFormat
                (
                    ScriptureReferenceQueryFormat,
					tableColumn,	
					wordWhere
                );
			}

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

        public const string BibleVersionDefault = "KingJamesVersion";

        public const string BibleWordQueryFormat = "SELECT '{0}' AS SearchClause, COUNT(*) AS RoundCount FROM Bible..Scripture WHERE {1} ";
    		
		public const string WholeWordsWildCardSearchQueryFormat = " ( {0} LIKE '%[^a-z]{1}[^a-z]%' ) ";	

		public const string ScriptureReferenceQueryFormat = "SELECT '{0}' AS SearchClause, LEN({0}) AS RoundCount FROM Bible..Scripture WHERE {1} ";		
		public const string ScriptureReferenceSearchQueryFormat = " ( ScriptureReference = '{0}' ) ";
		
    }
}
