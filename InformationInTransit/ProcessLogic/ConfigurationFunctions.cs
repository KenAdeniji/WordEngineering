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
        2016-12-08	Created.	ConfigurationFunctions.cs
    */
    public static partial class ConfigurationFunctions
    {
        public static void Main(string[] argv)
        {
            DataSet resultSet = Query();
        }

        public static DataSet Query()
        {
            DataSet dataSet = null;

			StringBuilder sqlStatement = new StringBuilder();
			
			for (int index = 0; index < ConfigurationFunction.Length; index++)
			{
                if (sqlStatement.Length > 0)
                {
                    sqlStatement.Append(" UNION ");
                }

                sqlStatement.AppendFormat
                (
                    ConfigurationFunctionsQueryFormat,
					ConfigurationFunction[index]
                );
			}
			
            sqlStatement.Append(ConfigurationFunctionsOrderByClause);
			
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

		public static readonly string[] ConfigurationFunction = new string[] 
		{ 
			"DATEFIRST",
			"DBTS",
			"LANGID",
			"LANGUAGE",
			"LOCK_TIMEOUT",
			"MAX_CONNECTIONS",
			"MAX_PRECISION",
			"NESTLEVEL",
			"OPTIONS",
			"REMSERVER",
			"SERVERNAME",
			"SERVICENAME",
			"SPID",
			"TEXTSIZE",
			"VERSION"
		};		

        public const string ConfigurationFunctionsQueryFormat = 
		@"
			SELECT
				'@@{0}' AS Variable,
				CONVERT(VARCHAR, @@{0}) AS Value
		";
		
		public const string ConfigurationFunctionsOrderByClause = " ORDER BY Variable ";
    }
}
