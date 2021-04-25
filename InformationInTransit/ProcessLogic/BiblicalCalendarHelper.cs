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
            Collection<OdbcParameter> odbcParameterCollection = new Collection<OdbcParameter>();

            if (year >= 1)
            {
				odbcParameterCollection.Add(new OdbcParameter("@year", year));
			}	

            if (month >= 1)
            {
				odbcParameterCollection.Add(new OdbcParameter("@month", month));
			}	
			
            if (day >= 1)
            {
				odbcParameterCollection.Add(new OdbcParameter("@day", day));
			}	
			
            if (!String.IsNullOrEmpty(commentary))
            {
				odbcParameterCollection.Add(new OdbcParameter("@commentary", commentary));
			}	

            if (!String.IsNullOrEmpty(scriptureReference))
            {
				odbcParameterCollection.Add(new OdbcParameter("@scriptureReference", scriptureReference));
			}

            if (!String.IsNullOrEmpty(uri))
            {
				odbcParameterCollection.Add(new OdbcParameter("@uri", uri));
			}
			
            DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
            (
                "WordEngineering..uspBiblicalCalendarSelect",
                CommandType.StoredProcedure,
                DataCommand.ResultType.DataSet,
                odbcParameterCollection
            );
			
			return dataSet;
        }
    }
}
