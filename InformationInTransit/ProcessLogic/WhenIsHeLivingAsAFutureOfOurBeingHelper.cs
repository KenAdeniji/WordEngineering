using System;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using InformationInTransit.DataAccess;

/*
	2016-12-11	WhenIsHeLivingAsAFutureOfOurBeingHelper.cs 	Created.
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class WhenIsHeLivingAsAFutureOfOurBeingHelper
    {
        public static void Main(string[] argv)
        {
        }

        public static DataSet Query
		(
			string	query
		)
        {
            Collection<OleDbParameter> sqlParameterCollection = new Collection<OleDbParameter>();

            if (!String.IsNullOrEmpty(query))
            {
				sqlParameterCollection.Add(new OleDbParameter("@query", query));
			}	

            DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
            (
                "WordEngineering..usp_WhenIsHeLivingAsAFutureOfOurBeingQuery",
                CommandType.StoredProcedure,
                DataCommand.ResultType.DataSet,
                sqlParameterCollection
            );
			
			return dataSet;
        }
    }
}
