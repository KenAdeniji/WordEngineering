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
			
			int verseIDSequenceMinimum = (from row in dataTable.AsEnumerable()
                select row.Field<Int32>("VerseIDSequence")).Min();
				
			int verseIDSequenceMaximum = (from row in dataTable.AsEnumerable()
                select row.Field<Int32>("VerseIDSequence")).Max();

			DataTable resultDataTable = new DataTable();

			resultDataTable.Columns.Add("Key", typeof(string));
			resultDataTable.Columns.Add("ScriptureReference", typeof(string));

			AddRow
			(
				resultDataTable,
				"Verse Minimum", 
				ScriptureReferenceHelper.FullPositionQuery("VerseIDSequence", verseIDSequenceMinimum)
			);	

			AddRow
			(
				resultDataTable,
				"Verse Maximum", 
				ScriptureReferenceHelper.FullPositionQuery("VerseIDSequence", verseIDSequenceMaximum)
			);	

			resultDataTable.AcceptChanges();
			string json = JsonConvert.SerializeObject(resultDataTable, Formatting.Indented);
			return json;
		}

		public static void AddRow
		(
			DataTable	dataTable,
			string 		columnKey,
			string		columnScriptureReference
		)
		{	
            DataRow dataRow = dataTable.NewRow();
            dataRow["Key"] = columnKey;
            dataRow["ScriptureReference"] = columnScriptureReference;
            dataTable.Rows.Add(dataRow);
		}
	}
}
