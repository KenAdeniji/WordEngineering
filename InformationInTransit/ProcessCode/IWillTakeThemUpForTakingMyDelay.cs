using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data.SqlClient;

using System.Linq;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

/*
	2018-09-25	Created.
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class IWillTakeThemUpForTakingMyDelay
	{
		public static String Query(String scriptureReference)
		{
			String[] 	scriptureReferenceSubset = null;
			DataSet 	result = null;
			ScriptureReferenceHelper.Process
			(
				scriptureReference,
				ref scriptureReferenceSubset,
				ref result,
				ScriptureReferenceHelper.FullPositionQueryFormat,
				"KingJamesVersion"
			);
			DataTable dataTable;
			String columnName = "resultIndex";
			for
			(
				int dataTableIndex = 0, dataTableCount = result.Tables.Count;
				dataTableIndex < dataTableCount;
				++dataTableIndex
			)
			{	
				dataTable = result.Tables[dataTableIndex];
				DataColumn dataColumn = new DataColumn(columnName, typeof(Int32));
				dataTable.Columns.Add(dataColumn);
				for
				(
					int dataRowIndex = 0, dataRowCount = dataTable.Rows.Count;
					dataRowIndex < dataRowCount;
					++dataRowIndex
				)
				{	
					dataTable.Rows[dataRowIndex][columnName] = dataTableIndex;
				}
				dataTable.AcceptChanges();
			}
			DataTable mergedTable = result.CustomMerge();
			var sortTable = mergedTable.AsEnumerable()
					.OrderBy(r => r.Field<int>("verseIdSequence"))
					.ThenBy(r => r.Field<int>("resultIndex"))
					.CopyToDataTable()
					;
			StringBuilder sbScriptureReference = new StringBuilder();
			int groupIndex = -1;
			int resultIndex = -1;
			for
			(
				int sortRowIndex = 0, sortRowCount = sortTable.Rows.Count;
				sortRowIndex < sortRowCount;
				++sortRowIndex
			)
			{	
				resultIndex = (int) sortTable.Rows[sortRowIndex]["resultIndex"];
				if (resultIndex == groupIndex)
				{
					continue;
				}
				groupIndex = resultIndex;
				if (sbScriptureReference.Length > 0)
				{
					sbScriptureReference.Append(", ");
				}
				sbScriptureReference.Append
				( 
					scriptureReferenceSubset[ resultIndex ] 
				);
			}
			string json = String.Format
			(
				JsonFormat,
				sbScriptureReference.ToString()
			);	
			return json;
		}
		public const string JsonFormat = "{{\"scriptureReference\": \"{0}\"}}";
	}
}
