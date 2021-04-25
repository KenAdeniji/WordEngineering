using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
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
			Collection<OleDbParameter> oleDbParameterCollection = new Collection<OleDbParameter>();

            if (bookIDMinimum.HasValue && bookIDMinimum > 0)
			{
				oleDbParameterCollection.Add(new OleDbParameter("@bookIDMinimum", bookIDMinimum));
			}

            if (bookIDMaximum.HasValue && bookIDMaximum > 0)
			{
				oleDbParameterCollection.Add(new OleDbParameter("@bookIDMaximum", bookIDMaximum));
			}

            if (chapterMinimum.HasValue && chapterMinimum > 0)
			{
				oleDbParameterCollection.Add(new OleDbParameter("@chapterMinimum", chapterMinimum));
			}

            if (chapterMaximum.HasValue && chapterMaximum > 0)
			{
				oleDbParameterCollection.Add(new OleDbParameter("@chapterMaximum", chapterMaximum));
			}
			
			DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
			(
				"WordEngineering..usp_IValueMostWhereIAmPurposelyUse",
				CommandType.StoredProcedure,
				DataCommand.ResultType.DataSet,
				oleDbParameterCollection
			);
			
			return resultSet;
		}
	}		
}
