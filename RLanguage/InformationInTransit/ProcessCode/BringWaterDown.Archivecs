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

using InformationInTransit.DataAccess;

using InformationInTransit.ProcessCode;

namespace InformationInTransit.ProcessLogic
{
	///<summary>
	///		2020-09-13	Created.
	///</summary>
	public class BringWaterDown
	{
		public static DataTable Query
		(
			String 	scriptureReference,
			String	bibleVersion,
			String	bibleUnitChapterIDOrVerseID,
			int		rowCount,
			String	topOrBottom
		)
		{
			scriptureReference = ScriptureReferenceHelper.BibleGroupSubstituteReplace(scriptureReference);
			
			String resultSet = "";
			topOrBottom = topOrBottom.CapitalizeFirstLetterOfAllTheWords();
			
			String[] scriptureReferenceSubset = scriptureReference.Split
			(
				ScriptureReferenceHelper.PrePostSeparator
			);
			
			scriptureReferenceSubset[0] = scriptureReferenceSubset[0].Trim();
			
			int scriptureReferenceSubsetLength = scriptureReferenceSubset.Length;
			
			string bibleBookEnd = scriptureReferenceSubsetLength == 1
				? scriptureReferenceSubset[0] : scriptureReferenceSubset[1].Trim();
			
			DataTable books = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SQL_Book,
					scriptureReferenceSubset[0],
					bibleBookEnd
				),	
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);

			int lastRow = books.Rows.Count - 1;
			
			int	startingBook = (int) books.Rows[0]["BookID"];
			int endingBook = (int) books.Rows[lastRow]["BookID"];

			String sqlStatement = "";
			
			if (topOrBottom == "Top") 
			{
				sqlStatement = String.Format
				(
					SQLQueryTop,
					bibleVersion,
					startingBook,
					endingBook,
					bibleUnitChapterIDOrVerseID,
					rowCount,
					topOrBottom
				);	
			}	
			else
			{
				sqlStatement = String.Format
				(
					SQLQueryBottom,
					bibleVersion,
					startingBook,
					endingBook,
					bibleUnitChapterIDOrVerseID,
					rowCount,
					topOrBottom
				);	
			}
			
			DataTable detail = (DataTable) DataCommand.DatabaseCommand
			(
				sqlStatement,	
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
			return detail;
		}

		public const String SQL_Book =
		@"
			SELECT TOP 1 BookID
			FROM Bible..Scripture_View
			WHERE BookTitle = '{0}' 
			UNION
			SELECT TOP 1 BookID
			FROM Bible..Scripture_View
			WHERE BookTitle = '{1}' 
			ORDER BY BookID
		";
			
		public const String SQLQueryTop =
		@"
			SELECT ScriptureReference, {0} AS VerseText
			FROM Bible..Scripture_View
			WHERE
				BookID BETWEEN {1} AND {2}
				AND {3} <= {4} 
			ORDER BY VerseIDSequence
		";	
		
		public const String SQLQueryBottom =
		@"
			SELECT ScriptureReference, {0} AS VerseText
			FROM Bible..Scripture_View AS Scripture_View_Outer
			WHERE
				BookID BETWEEN {1} AND {2}
				AND {3} >=
				(
					SELECT MAX({3}) - {4}
					FROM Bible..Scripture_View AS Scripture_View_Inner
					WHERE Scripture_View_Outer.BookID = Scripture_View_Inner.BookID
				)	
			ORDER BY VerseIDSequence
		";	
	}		
} 	
