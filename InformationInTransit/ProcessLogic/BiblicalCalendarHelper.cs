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
	2017-02-01	BiblicalCalendarHelper.cs 	Created.
	2017-02-02	To make, yourself necessary.
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class BiblicalCalendarHelper
    {
        public static void Main(string[] argv)
        {
        }

        public static DataSet Query
		(
			int		year,
			int		month,
			int 	day,
			string	commentary,
			string	scriptureReference,
			string	uri
		)
        {
            Collection<OleDbParameter> oleDbParameterCollection = new Collection<OleDbParameter>();

            if (year >= 1)
            {
				oleDbParameterCollection.Add(new OleDbParameter("@year", year));
			}	

            if (month >= 1)
            {
				oleDbParameterCollection.Add(new OleDbParameter("@month", month));
			}	
			
            if (day >= 1)
            {
				oleDbParameterCollection.Add(new OleDbParameter("@day", day));
			}	
			
            if (!String.IsNullOrEmpty(commentary))
            {
				oleDbParameterCollection.Add(new OleDbParameter("@commentary", commentary));
			}	

            if (!String.IsNullOrEmpty(scriptureReference))
            {
				oleDbParameterCollection.Add(new OleDbParameter("@scriptureReference", scriptureReference));
			}

            if (!String.IsNullOrEmpty(uri))
            {
				oleDbParameterCollection.Add(new OleDbParameter("@uri", uri));
			}
			
            DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
            (
                "WordEngineering..uspBiblicalCalendarSelect",
                CommandType.StoredProcedure,
                DataCommand.ResultType.DataSet,
                oleDbParameterCollection
            );
			
			return dataSet;
        }
    }
}
