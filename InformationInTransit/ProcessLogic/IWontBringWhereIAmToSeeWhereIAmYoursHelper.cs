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
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-12-30	Created.
		2017-12-30	I won't bring where I am; to see where I am yours.
	*/	
	public static class IWontBringWhereIAmToSeeWhereIAmYoursHelper
	{
		public static DataTable Query
		(
			string 	scriptureReference,
			string	bibleVersion
		)
		{
			String[] scriptureReferenceSubset = null;
			DataSet result = null;
			
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref result,
					BibleKingJamesVersionQueryVerseIdSequenceFormat,
					bibleVersion
			);

			DataTable customMerge = DataSetHelper.CustomMerge(result);
			
			DataColumn verseIdSequenceTestamentColumn = customMerge.Columns.Add("verseIdSequenceTestament", typeof(int));  
			
			DataColumn verseIdSequenceBookColumn = customMerge.Columns.Add("verseIdSequenceBook", typeof(int));
			
			DataColumn verseIdSequenceBookColumnReverse = customMerge.Columns.Add("verseIdSequenceBookReverse", typeof(int));  			
  
			int bookID;
			int chapterID;
			int verseID;

			int verseIdSequence;
			int	verseIdSequenceTestament;
			int	verseIdSequenceBook;
			int	verseIdSequenceBookReverse;
			
			string sqlStatement = "";
			
			for(int rowID = 0; rowID < customMerge.Rows.Count; ++rowID)
			{
				DataRow dataRow = customMerge.Rows[rowID];
				
				bookID = (int) dataRow["bookId"];
				chapterID = (int) dataRow["chapterId"];
				verseID = (int) dataRow["verseId"];
				verseIdSequence = (int) dataRow["verseIdSequence"];
			
				verseIdSequenceTestament = bookID < 40 ? verseIdSequence : 
					verseIdSequence - ScriptureReferenceHelper.VerseCountOldTestament;
				
				dataRow["verseIdSequenceTestament"] = verseIdSequenceTestament;
				
				sqlStatement = String.Format
				(
					BibleKingJamesVersionQueryVerseIdSequenceBookFormat,
					verseIdSequence,
					bookID
				);

				verseIdSequenceBook	= (int) DataCommand.DatabaseCommand
				(
					sqlStatement,
					System.Data.CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				
				dataRow["verseIdSequenceBook"] = verseIdSequenceBook;
				
				sqlStatement = String.Format
				(
					BibleKingJamesVersionQueryVerseIdSequenceBookReverseFormat,
					verseIdSequence,
					bookID
				);

				verseIdSequenceBookReverse	= (int) DataCommand.DatabaseCommand
				(
					sqlStatement,
					System.Data.CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				
				dataRow["verseIdSequenceBookReverse"] = verseIdSequenceBookReverse;
			}
			
			customMerge.AcceptChanges();  

			return customMerge;
		}
		
		public const string BibleKingJamesVersionQueryVerseIdSequenceFormat = "SELECT bookId, chapterId, verseId, verseText, scriptureReference, verseIdSequence FROM Bible..Scripture_View WHERE {0} ORDER BY bookId, chapterId, verseId;";
		
		public const string BibleKingJamesVersionQueryVerseIdSequenceBookFormat = 
			"SELECT TOP 1 verseIdSequence + 1 - (SELECT MIN(verseIdSequence) FROM Bible..Scripture WHERE bookId = {1}) FROM Bible..Scripture WHERE verseIdSequence = {0} ORDER BY verseIdSequence";
			
		public const string BibleKingJamesVersionQueryVerseIdSequenceBookReverseFormat = 
			"SELECT TOP 1 (SELECT MAX(verseIdSequence) FROM Bible..Scripture WHERE bookId = {1}) - verseIdSequence + 1 FROM Bible..Scripture WHERE verseIdSequence = {0} ORDER BY verseIdSequence";
	}	
}
