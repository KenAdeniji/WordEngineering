using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Diagnostics;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

/*
	2020-02-22 	Created.
	2020-02-22	dataSetFilter.Merge( dataTable.Select( filterExfo ) );
	2020-02-22	https://stackoverflow.com/questions/6007872/filtering-dataset
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class ExistsIn
	{
		public static DataSet Query
		(
			string	bibleVersion,
			string	bibleWord,
			string	logic,
			string	scriptureReferenceIncluded,
			string	scriptureReferenceExcluded,
			bool	wholeWords
		)
		{
			String[] 	scriptureReferenceSubset	=	null;
			DataSet		dataSetExcluded				= 	null;
			DataSet		dataSetIncluded				= 	null;
			DataSet		dataSetFilter				= 	new DataSet();
			DataSet		dataSetEmpty				= 	new DataSet();
			
			DataView 	dataView 					= 	null;
			
			bool		inExcluded					=	false;
			bool		inIncluded					=	false;
			
			String filterInfo = StringHelper.ContainLogic
			(
				"verseText", 
				bibleWord,
				logic,
				wholeWords
			).ToString();
			
			ScriptureReferenceHelper.Process
            (
                scriptureReferenceExcluded,
                ref scriptureReferenceSubset,
                ref dataSetExcluded,
                ScriptureReferenceHelper.ExactQueryFormat,
                bibleVersion
            );

			foreach(DataTable dataTable in dataSetExcluded.Tables)
			{
				dataView = dataTable.DefaultView;
				dataView.RowFilter = filterInfo;
				if (dataView.Count > 0)
				{
					inExcluded = true;
					break;
				}	
			}

			ScriptureReferenceHelper.Process
            (
                scriptureReferenceIncluded,
                ref scriptureReferenceSubset,
                ref dataSetIncluded,
                ScriptureReferenceHelper.ExactQueryFormat,
                bibleVersion
            );

			foreach(DataTable dataTable in dataSetIncluded.Tables)
			{
				dataView = dataTable.DefaultView;
				dataView.RowFilter = filterInfo;
				if (dataView.Count > 0)
				{
					inIncluded = true;
				}	
				dataSetFilter.Tables.Add(dataView.ToTable());
			}

			return (!inExcluded && inIncluded) ? dataSetFilter : dataSetEmpty;
		}
    }
}
