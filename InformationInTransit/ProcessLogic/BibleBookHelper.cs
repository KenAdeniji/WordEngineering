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
	2016-12-09	https://technet.microsoft.com/en-us/library/ms174408(v=sql.90).aspx
	2016-12-09	BibleBookHelper.cs 	Created.
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class BibleBookHelper
    {
        public static void Main(string[] argv)
        {
        }

        public static DataSet Query
		(
			int		bookIDMinimum,
			int		bookIDMaximum,
			string 	bookTitle,
			string	testament
		)
        {
            Collection<OleDbParameter> oleDbParameterCollection = new Collection<OleDbParameter>();

			oleDbParameterCollection.Add(new OleDbParameter("@bookIDMinimum", bookIDMinimum));
			oleDbParameterCollection.Add(new OleDbParameter("@bookIDMaximum", bookIDMaximum));

            if (!String.IsNullOrEmpty(bookTitle))
            {
				oleDbParameterCollection.Add(new OleDbParameter("@bookTitle", bookTitle));
			}	

            if (!String.IsNullOrEmpty(testament))
            {
				oleDbParameterCollection.Add(new OleDbParameter("@testament", testament));
			}
			
            DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
            (
                "Bible..usp_BibleBooksQuery",
                CommandType.StoredProcedure,
                DataCommand.ResultType.DataSet,
                oleDbParameterCollection
            );
			
			return dataSet;
        }
    }
}
