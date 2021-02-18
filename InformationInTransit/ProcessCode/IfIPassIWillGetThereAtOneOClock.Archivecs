using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.ProcessLogic;
using InformationInTransit.DataAccess;	

namespace InformationInTransit.ProcessCode
{
	/*

		2021-02-17T13:44:00	Created.	
	*/
    public partial class IfIPassIWillGetThereAtOneOClock : SeparateTheirDesireOfTheBible
    {
		public static void BuildBookGroupParts
		(
			ref	DataSet	resultSet,
				String	bibleBookGroup
		)
		{
			StringBuilder sbParseBibleBookGroup = BibleWordHelper.ParseBibleBookGroup(bibleBookGroup);
			
			DataTable minMaxTable = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				(
					QueryFormatBibleBookGroups,
					QuerySource,
					sbParseBibleBookGroup
				),
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);

			int chapterIDSequenceMinimum = (int) minMaxTable.Rows[0]["ChapterIDSequenceMinimum"];
			int chapterIDSequenceMaximum = (int) minMaxTable.Rows[0]["ChapterIDSequenceMaximum"];
			int chapterIDSequenceRange = chapterIDSequenceMaximum - chapterIDSequenceMinimum;

			int verseIDSequenceMinimum = (int) minMaxTable.Rows[0]["VerseIDSequenceMinimum"];
			int verseIDSequenceMaximum = (int) minMaxTable.Rows[0]["VerseIDSequenceMaximum"];
			int verseIDSequenceRange = verseIDSequenceMaximum - verseIDSequenceMinimum;
		
			foreach(DataTable dataTable in resultSet.Tables)
			{
				
				dataTable.Columns.Add("ChapterIDRatio", typeof(double)); 
				dataTable.Columns.Add("VerseIDRatio", typeof(double)); 
				dataTable.Columns.Add("ChapterVerseIDRatio", typeof(double), "VerseIDRatio - ChapterIDRatio");
				
				foreach(DataRow dataRow in dataTable.Rows)
				{
					dataRow["ChapterIDRatio"] = (double) 
					(
						((int)dataRow["ChapterIDSequence"] - chapterIDSequenceMinimum) 
						/ chapterIDSequenceRange
					);

					dataRow["VerseIDRatio"] = (double) 
					(
						((int)dataRow["VerseIDSequence"] - verseIDSequenceMinimum) / 
						verseIDSequenceRange
					);
				}
			}	
		}	
		
		public override String RetrieveDefaultColumnsPrefix
		{
			get { return DefaultColumnsPrefix; }
		}
		
		public static string	DefaultColumnsPrefix = "ScriptureReference, ChapterIDSequence, VerseIDSequence";
		
		public const String QueryFormatBibleBookGroups = @"
			SELECT 
				MIN(ChapterIDSequence) AS ChapterIDSequenceMinimum,
				MAX(ChapterIDSequence) AS ChapterIDSequenceMaximum,
				MIN(VerseIDSequence) AS VerseIDSequenceMinimum,
				MAX(VerseIDSequence) AS VerseIDSequenceMaximum
			FROM {0} WHERE {1}
		";
    }
}
