using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;

using InformationInTransit.DataAccess;

/*
	2015-08-21 Created. Are you a spiritual son? Word by design.
	0        1
	1234567890
	   d  g
	Biblical Name
	DictionaryId	DictionaryWord	Commentary
	12				Abednego		servant of light; shining.
	DictionaryId	DictionaryWord	Commentary
	14				Abednego		servant of Nego=Nebo, the Chaldee name given to Azariah, one of Daniel's
									three companions (Dan. 2:49). With Shadrach and Meshach, he was
									delivered from the burning fiery furnace (3:12-30).
	2015-08-21	http://forums.asp.net/t/1213793.aspx?How+to+do+LTrim+and+RTrim+in+C+
	SELECT * FROM Bible..Exact  
		WHERE  SUBSTRING(BibleWord, 4, 1) = 'd'  AND  SUBSTRING(BibleWord, 7, 1) = 'g'  ORDER BY SequenceOrderId
	SELECT * FROM Bible..Exact WHERE BibleWord LIKE '%dg%' ORDER BY SequenceOrderId
*/
namespace InformationInTransit.ProcessLogic
{
    /// <summary>AreYouASpiritualSon.</summary>
    public static partial class AreYouASpiritualSon
    {
        ///<summary>The entry point for the application.</summary>
        public static void Main
        (
			string[] argv
        )
        {
			Process("   d  g");
        }
		
		///<summary>ConditionClause</summary>
		public static StringBuilder BuildConditionClause
		(
			String searchFor
		)
		{
			searchFor = searchFor.TrimEnd();
			StringBuilder whereClause = new StringBuilder();
			for 
			(
				int index = 0, length = searchFor.Length;
				index < length;
				++index
			)
			{
				char searchCharacter = searchFor[index];
				if (searchCharacter == ' ')
				{
					continue;
				}
				if (whereClause.Length == 0)
				{
					whereClause.Append(" WHERE ");
				}
				else				
				{
					whereClause.Append(" AND ");
				}
				whereClause.AppendFormat(SearchCondition, index + 1, searchCharacter);
			}
			return whereClause;
		}

		///<summary>Process</summary>
		public static DataSet Process
		(
			String searchFor
		)
		{
			StringBuilder whereClause = BuildConditionClause(searchFor);
			string sql = String.Format(Statement, whereClause);
			//System.Console.WriteLine(sql);
			DataSet dataSet = null;
			dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				sql.ToString(),
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return dataSet;
		}

		const string SearchCondition = " SUBSTRING(BibleWord, {0}, 1) = '{1}' ";
		const string Statement = "SELECT * FROM Bible..Exact {0} ORDER BY BibleWord";
    }
}
