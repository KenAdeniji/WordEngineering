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
        2017-03-05	Created.	IRealizeMyFullSenseInMakingManHelper.cs
    */
    public static partial class IRealizeMyFullSenseInMakingManHelper
    {
        public static void Main(string[] argv)
        {
        }

        public static DataSet Query
        (
            String 	bibleVersion,
			String	who,
			String	bodyPart,
			String	activity
        )
        {
            DataSet dataSet = null;

            StringBuilder sb = new StringBuilder();
			sb.Append( StringHelper.MakeQueryClause(bibleVersion, who, "AND", "OR") ); 
			sb.Append( StringHelper.MakeQueryClause(bibleVersion, bodyPart, "AND", "OR") ); 
			sb.Append( StringHelper.MakeQueryClause(bibleVersion, activity, "AND", "OR") ); 
			
			StringBuilder sqlStatement = new StringBuilder();
			sqlStatement.AppendFormat
			(
				SQLFormat,
				bibleVersion,
				sb.ToString()
			);
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

        public const string SQLFormat = "SELECT {0} AS verseText, bookId, chapterId, verseId FROM Bible..Scripture WHERE 1=1 {1} ORDER BY VerseIDSequence ";			
        public const string BibleVersionDefault = "KingJamesVersion";
		public const string WholeWordsWildCardSearchQueryFormat = " ( {0} LIKE '%[^a-z]{1}[^a-z]%' ) ";		
    }
}
