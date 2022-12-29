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
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	///	2022-12-28T22:21:00 Created.
	///	2022-12-29T07:53:00	Will determine when a Bible Word is included in a Scripture Reference.
	///</summary>
	public class WhatRemembranceOfMan
	{
		public static DataSet Query
		(
			String	bibleVersion,
			DataSet	bibleWordDataSet,
			String	scriptureReference,
			bool	scriptureReferenceIn
		)
		{
			String[] scriptureReferenceSubset = null;
			DataSet scriptureReferenceDataSet = null;
			
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref scriptureReferenceDataSet,
					ScriptureReferenceHelper.BibleSequenceQueryFormat,
					bibleVersion
			);
			
			DataTable bibleWordDataTable = bibleWordDataSet.CustomMerge();
			DataTable scriptureReferenceDataTable = scriptureReferenceDataSet.CustomMerge();
			
			string scriptureReferenceLiteral = "";
			
			for 
			(
				int	bibleWordRowIndex = 0, bibleWordRowCount = bibleWordDataTable.Rows.Count;
				bibleWordRowIndex < bibleWordRowCount;
				++bibleWordRowIndex
			)
			{
				scriptureReferenceLiteral = ScriptureReferenceHelper.ScriptureReference.Syntax
				(
					(int) bibleWordDataTable.Rows[bibleWordRowIndex]["BookID"],
					(int) bibleWordDataTable.Rows[bibleWordRowIndex]["ChapterID"],
					(int) bibleWordDataTable.Rows[bibleWordRowIndex]["VerseID"]
				);
				
				DataRow[] foundRows = scriptureReferenceDataTable.Select
				(
					String.Format
					(
						SearchExpressionFormat,
						scriptureReferenceLiteral
					)	
				);

				if (foundRows.Count() > 0 && !scriptureReferenceIn)
				{
					bibleWordDataTable.Rows[bibleWordRowIndex].Delete();
				}
				else if (foundRows.Count() < 1 && scriptureReferenceIn)
				{
					bibleWordDataTable.Rows[bibleWordRowIndex].Delete();
				}
			}	
			
			bibleWordDataTable.AcceptChanges();
			
			DataSet resultDataSet = new DataSet();
			resultDataSet.Tables.Add(bibleWordDataTable);
			return resultDataSet;
		}
		
		public const String SearchExpressionFormat = "ScriptureReference = '{0}'";
	}
}
