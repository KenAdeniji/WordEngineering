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
	2017-04-02	Created.	Types the being. 	TypesTheBeingHelper.cs
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class TypesTheBeingHelper
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
                "WordEngineering..usp_TypesTheBeingQuery",
                CommandType.StoredProcedure,
                DataCommand.ResultType.DataSet,
                sqlParameterCollection
            );
			
			return dataSet;
        }
    }
}
