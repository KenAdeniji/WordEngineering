using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	///	2022-11-25T14:37:00 Created.
	///	2022-11-26T06:21:00 ... 2022-11-26T10:21:00
	///		http://stackoverflow.com/questions/13139366/c-sharp-linq-query-on-data-table-to-select-all-minimum-values-with-duplicates
	///</summary>
	public class IKeepOnFindingWhereIAmThatIMayChooseWhereIBelong
	{
		public static string Query(String scriptureReference, string bibleVersion)
		{
			String[] scriptureReferenceSubset = null;
			DataSet dataSet = null;
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref dataSet,
					ScriptureReferenceHelper.FullPositionQueryFormat,
					bibleVersion
			);
			
			DataTable dataTable = DataSetHelper.CustomMerge(dataSet);

			DataView dv = new DataView(dataTable);

			DataTable resultDataTable = new DataTable();

			resultDataTable.Columns.Add("Key", typeof(string));
			resultDataTable.Columns.Add("VerseText", typeof(string));
			resultDataTable.Columns.Add("ScriptureReference", typeof(string));
			
			int verseTextLengthMinimum = 
			(
				from row in dataTable.AsEnumerable()
                select row["VerseText"].ToString().Length
			).Min();

			dv.RowFilter = String.Format
			(
				"LEN(VerseText) = {0}",
				verseTextLengthMinimum
			);
			
			AddRow
			(
				resultDataTable,
				"Verse Text Length Minimum", 
				ScriptureReferenceHelper.IKeepOnFindingWhereIAmThatIMayChooseWhereIBelongQuery
				(
					"VerseIDSequence",
					(int) dv[0]["VerseIDSequence"],
					bibleVersion
				),
				ScriptureReferenceHelper.FullPositionQuery
				(
					"VerseIDSequence",
					(int) dv[0]["VerseIDSequence"]
				)
			);	

			int verseTextLengthMaximum = 
			(
				from row in dataTable.AsEnumerable()
                select row["VerseText"].ToString().Length
			).Max();

			dv.RowFilter = String.Format
			(
				"LEN(VerseText) = {0}",
				verseTextLengthMaximum
			);
			
			AddRow
			(
				resultDataTable,
				"Verse Text Length Maximum", 
				ScriptureReferenceHelper.IKeepOnFindingWhereIAmThatIMayChooseWhereIBelongQuery
				(
					"VerseIDSequence",
					(int) dv[0]["VerseIDSequence"],
					bibleVersion
				),
				ScriptureReferenceHelper.FullPositionQuery
				(
					"VerseIDSequence",
					(int) dv[0]["VerseIDSequence"]
				)
			);	

			int verseIDSequenceMinimum = 
			(
				from row in dataTable.AsEnumerable()
                select row.Field<Int32>("VerseIDSequence")
			).Min();
				
			AddRow
			(
				resultDataTable,
				"Verse Minimum", 
				ScriptureReferenceHelper.IKeepOnFindingWhereIAmThatIMayChooseWhereIBelongQuery
				(
					"VerseIDSequence",
					verseIDSequenceMinimum,
					bibleVersion
				),
				ScriptureReferenceHelper.FullPositionQuery
				(
					"VerseIDSequence",
					verseIDSequenceMinimum
				)
			);	

			int verseIDSequenceMaximum = 
			(
				from row in dataTable.AsEnumerable()
                select row.Field<Int32>("VerseIDSequence")
			).Max();

			AddRow
			(
				resultDataTable,
				"Verse Maximum", 
				ScriptureReferenceHelper.IKeepOnFindingWhereIAmThatIMayChooseWhereIBelongQuery
				(
					"VerseIDSequence",
					verseIDSequenceMaximum,
					bibleVersion
				),
				ScriptureReferenceHelper.FullPositionQuery
				(
					"VerseIDSequence", 
					verseIDSequenceMaximum
				)
			);	

			int verseIDSequenceCount = dataTable.Rows.Count;
			
			AddRow
			(
				resultDataTable,
				"Count", 
				verseIDSequenceCount.ToString(),
				""
			);	

			int verseIDSequenceDistinctCount = dataTable
				.AsEnumerable()
				.Select(r => r.Field<int>("VerseIDSequence"))
				.Distinct()
				.Count();

			AddRow
			(
				resultDataTable,
				"Distinct Count", 
				verseIDSequenceDistinctCount.ToString(),
				""
			);	
	
			resultDataTable.AcceptChanges();
			string json = JsonConvert.SerializeObject(resultDataTable, Formatting.Indented);
			return json;
		}

		public static void AddRow
		(
			DataTable	dataTable,
			string 		columnKey,
			string		columnVerseText,
			string		columnScriptureReference
		)
		{	
            DataRow dataRow = dataTable.NewRow();
            dataRow["Key"] = columnKey;
			dataRow["VerseText"] = columnVerseText;
            dataRow["ScriptureReference"] = columnScriptureReference;
            dataTable.Rows.Add(dataRow);
		}
	}
}
