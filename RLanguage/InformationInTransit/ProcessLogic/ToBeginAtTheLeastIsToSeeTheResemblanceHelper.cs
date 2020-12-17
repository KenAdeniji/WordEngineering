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
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-10-01	Created.
		2017-10-01	https://social.msdn.microsoft.com/Forums/vstudio/en-US/7ed74243-63fe-4c41-95b1-ca9f5b06bf7c/datatable-linq-remove-rows-where-not-in-array?forum=csharpgeneral
	*/
	public static partial class ToBeginAtTheLeastIsToSeeTheResemblanceHelper
	{
		public static DataSet Query
		(
			string	bibleVersion,
			string	uri
		)
		{
			DataRow[] 	rows = null;
			DataSet 	dataSet = new DataSet();
			DataTable 	dataTable = null;
			
			string		webContent 	=	WebHelper.GetPageAsString(uri);
			
			webContent = webContent.CapitalizeFirstLetterOfAllTheWords();
			
			string[]	webWords	=	webContent.Split(SplitSeparator);
			
			webWords = webWords.Distinct().ToArray();
			
			dataTable = (DataTable)DataCommand.DatabaseCommand
			(
				ExactQuery,
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			rows = dataTable.AsEnumerable().Where(x => !webWords.Contains(x.Field<string>("BibleWord"))).ToArray();
			foreach (DataRow row in rows) dataTable.Rows.Remove(row);
			dataTable.AcceptChanges();			
			dataSet.Tables.Add(dataTable);

			dataTable = (DataTable)DataCommand.DatabaseCommand
			(
				BibleDictionaryQuery,
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			rows = dataTable.AsEnumerable().Where(x => !webWords.Contains(x.Field<string>("BibleDictionaryWord"))).ToArray();
			foreach (DataRow row in rows) dataTable.Rows.Remove(row);
			dataTable.AcceptChanges();			
			dataSet.Tables.Add(dataTable);
			
			return dataSet;
		}	

		public const string BibleDictionaryQuery = "SELECT * FROM BibleDictionary..BibleDictionary_View ORDER BY BibleDictionaryWord";
		public const string ExactQuery = "SELECT * FROM Bible..Exact ORDER BY BibleWord";
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!', '[', ']', '{', '}', '<', '>'};
	}
}
