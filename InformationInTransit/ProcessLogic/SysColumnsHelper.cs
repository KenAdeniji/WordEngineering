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
	2016-12-10	https://msdn.microsoft.com/en-us/library/ms176106.aspx
	2016-12-10	SysColumnsHelper.cs 	Created.
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class SysColumnsHelper
    {
        public static void Main(string[] argv)
        {
        }

        public static DataSet Query
		(
			string	query
		)
        {
            Collection<OleDbParameter> oleDbParameterCollection = new Collection<OleDbParameter>();

            if (!String.IsNullOrEmpty(query))
            {
				oleDbParameterCollection.Add(new OleDbParameter("@query", query));
			}	

            DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
            (
                "WordEngineering..usp_SysColumnsQuery",
                CommandType.StoredProcedure,
                DataCommand.ResultType.DataSet,
                oleDbParameterCollection
            );
			
			return dataSet;
        }
    }
}
