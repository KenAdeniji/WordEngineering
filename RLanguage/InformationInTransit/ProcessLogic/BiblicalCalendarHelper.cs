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
            Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

            if (year >= 1)
            {
				sqlParameterCollection.Add(new SqlParameter("@year", year));
			}	

            if (month >= 1)
            {
				sqlParameterCollection.Add(new SqlParameter("@month", month));
			}	
			
            if (day >= 1)
            {
				sqlParameterCollection.Add(new SqlParameter("@day", day));
			}	
			
            if (!String.IsNullOrEmpty(commentary))
            {
				sqlParameterCollection.Add(new SqlParameter("@commentary", commentary));
			}	

            if (!String.IsNullOrEmpty(scriptureReference))
            {
				sqlParameterCollection.Add(new SqlParameter("@scriptureReference", scriptureReference));
			}

            if (!String.IsNullOrEmpty(uri))
            {
				sqlParameterCollection.Add(new SqlParameter("@uri", uri));
			}
			
            DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
            (
                "WordEngineering..uspBiblicalCalendarSelect",
                CommandType.StoredProcedure,
                DataCommand.ResultType.DataSet,
                sqlParameterCollection
            );
			
			return dataSet;
        }
    }
}
