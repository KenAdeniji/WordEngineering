using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;

using InformationInTransit.DataAccess;

/*
2015-07-31 	IValueMostWhereIAmPurposelyUse.cs.
2015-07-31	http://stackoverflow.com/questions/12528107/check-an-integer-value-is-null-in-c-sharp	HasValue property
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class IValueMostWhereIAmPurposelyUse
	{
		public static void Main(string[] argv)
		{
		}
		
		public static DataSet Query
		(
			int?	bookIDMinimum,
			int?	bookIDMaximum,
			int?	chapterMinimum,
			int?	chapterMaximum
		)
		{
			Collection<OdbcParameter> odbcParameterCollection = new Collection<OdbcParameter>();

            if (bookIDMinimum.HasValue && bookIDMinimum > 0)
			{
				odbcParameterCollection.Add(new OdbcParameter("@bookIDMinimum", bookIDMinimum));
			}

            if (bookIDMaximum.HasValue && bookIDMaximum > 0)
			{
				odbcParameterCollection.Add(new OdbcParameter("@bookIDMaximum", bookIDMaximum));
			}

            if (chapterMinimum.HasValue && chapterMinimum > 0)
			{
				odbcParameterCollection.Add(new OdbcParameter("@chapterMinimum", chapterMinimum));
			}

            if (chapterMaximum.HasValue && chapterMaximum > 0)
			{
				odbcParameterCollection.Add(new OdbcParameter("@chapterMaximum", chapterMaximum));
			}
			
			DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
			(
				"WordEngineering..usp_IValueMostWhereIAmPurposelyUse",
				CommandType.StoredProcedure,
				DataCommand.ResultType.DataSet,
				odbcParameterCollection
			);
			
			return resultSet;
		}
	}		
}
