using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using InformationInTransit.DataAccess;

/*
	2017-02-14	ExactHelper.cs Created.
	2017-02-14	Our fixation on number. OurFixationOnNumber()
	2003-09-11	Former U.S. President just the letters. 
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class ExactHelper
	{
		public static void Main(string[] argv)
		{
			
		}
		
		public static DataSet OurFixationOnNumber(string word)
		{
			StringBuilder whereAnd = new StringBuilder();
			foreach (char letter in word)
			{
				whereAnd.AppendFormat
				(
					SQLStatementOurFixationOnNumberWhereAndFormat,
					letter
				);	
			}
			string sqlStatement = String.Format
			(
				SQLStatementOurFixationOnNumberFormat,
				whereAnd
			);	
			DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
			(
				sqlStatement,
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return dataSet;
		}
		
		public const string SQLStatementOurFixationOnNumberFormat = "SELECT * FROM Bible..Exact WHERE 1 = 1 {0} ORDER BY BibleWord";
		public const string SQLStatementOurFixationOnNumberWhereAndFormat = " AND BibleWord LIKE '%{0}%' ";
    }
}
