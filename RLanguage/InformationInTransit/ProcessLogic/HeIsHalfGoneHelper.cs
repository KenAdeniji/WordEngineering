using System;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using InformationInTransit.DataAccess;

/*
	2016-12-09	He is half gone. Will generate template in programming languages.
	2016-12-17	HeIsHalfGoneHelper.cs 	Created.
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class HeIsHalfGoneHelper
    {
        public static void Main(string[] argv)
        {
        }

        public static DataSet Query
		(
			string	query
		)
        {
            Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

            if (!String.IsNullOrEmpty(query))
            {
				sqlParameterCollection.Add(new SqlParameter("@query", query));
			}	

            DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
            (
                "WordEngineering..usp_HeIsHalfGoneQuery",
                CommandType.StoredProcedure,
                DataCommand.ResultType.DataSet,
                sqlParameterCollection
            );
			
			return dataSet;
        }
    }
}
