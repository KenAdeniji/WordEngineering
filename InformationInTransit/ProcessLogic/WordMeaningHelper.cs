using System;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using InformationInTransit.DataAccess;

/*
	2016-12-09	https://technet.microsoft.com/en-us/library/ms174408(v=sql.90).aspx
	2016-12-09	WordMeaningHelper.cs 	Created.
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class WordMeaningHelper
    {
        public static void Main(string[] argv)
        {
        }

        public static DataSet Query
		(
			string	query
		)
        {
            Collection<OdbcParameter> odbcParameterCollection = new Collection<OdbcParameter>();

            if (!String.IsNullOrEmpty(query))
            {
				odbcParameterCollection.Add(new OdbcParameter("@query", query));
			}	

            DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
            (
                "WordEngineering..usp_WordMeaningQuery",
                CommandType.StoredProcedure,
                DataCommand.ResultType.DataSet,
                odbcParameterCollection
            );
			
			return dataSet;
        }
    }
}
