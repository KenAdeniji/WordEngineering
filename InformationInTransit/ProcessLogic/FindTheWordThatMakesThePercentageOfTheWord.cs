using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.SqlServer.Server;
using System.Collections;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2016-08-07	Find the word that makes the percentage of the word.
///	2016-08-07	http://stackoverflow.com/questions/1722334/extract-only-right-most-n-letters-from-a-string 
///</summary>
namespace InformationInTransit.ProcessLogic
{
    public static partial class FindTheWordThatMakesThePercentageOfTheWord
    {
		public static void Main(string[] argv)
		{
			DataSet otherData = ToKnowTheParentage(Convert.ToDecimal(argv[0]));
			otherData.Tables[0].DumpDataTable();
		}	
		
		public static void RowsAdd(DataTable dataTable, Exact exact, String partialWord)
		{
			dataTable.Rows.Add
			(
				exact.ExactID,
				exact.BibleWord,
				exact.FirstScriptureReference,
				exact.LastScriptureReference,
				exact.Difference,
				exact.Occurrence,
				exact.AlphabetSequenceIndex,
				partialWord
			);
		}
		
		public static DataSet ToKnowTheParentage(decimal checker)
        {
			checker /= 100;
			
			DataTable exactDataTable = (DataTable) DataCommand.DatabaseCommand
			(
				ExactSQL,
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);

			DataSet otherData = new DataSet("OtherData");
			DataTable workTable = new DataTable("workTable");
			
			try
			{
				workTable.Columns.Add("ExactID", typeof(Int64));
				workTable.Columns.Add("BibleWord");
				workTable.Columns.Add("FirstScriptureReference");
				workTable.Columns.Add("LastScriptureReference");
				workTable.Columns.Add("Difference", typeof(long));
				workTable.Columns.Add("Occurrence", typeof(long));
				workTable.Columns.Add("AlphabetSequenceIndex", typeof(long));
				workTable.Columns.Add("PartialWord");

				string bibleWord = "";
				string bibleWordStrip = "";
				string bibleWordForward = "";
				string bibleWordBackward = "";

				int wordLength = bibleWord.Length;
				long alphabetSequenceIndex = AlphabetSequence.Id(bibleWord);
					
				long alphabetSequenceForward = 0;
				long alphabetSequenceBackward = 0;
				
				decimal percentageForward;
				decimal percentageBackward;
				
				long	ExactID;
				string	FirstScriptureReference = null;;
				string	LastScriptureReference = null;
				long?	difference = -1;
				long	Occurrence = -1;
				
				object	temp = null;
				
				foreach(DataRow dataRow in exactDataTable.Rows)
				{
					ExactID = (int) dataRow["ExactID"];
					bibleWord = dataRow["BibleWord"].ToString();
					FirstScriptureReference = (string) dataRow["FirstScriptureReference"];
					
					temp = dataRow["LastScriptureReference"];
					if (!DBNull.Value.Equals(temp))
					{			
						LastScriptureReference = (string) temp;
					}
					else
					{	
						LastScriptureReference = "";
					}
 					
					temp = dataRow["Difference"];
					if (!DBNull.Value.Equals(temp))
					{			
						difference = (int) temp;
					}
					else
					{	
						difference = null;
					}

					Occurrence = (int) dataRow["Occurrence"];
					
					bibleWordStrip = bibleWord.ToAlphaOnly();
					wordLength = bibleWordStrip.Length;
					alphabetSequenceIndex = AlphabetSequence.Id(bibleWord);
					
					alphabetSequenceForward = 0;
					alphabetSequenceBackward = 0;
					
					for (int letterIndex = 0; letterIndex < wordLength; ++letterIndex)
					{
						bibleWordForward = bibleWordStrip.Substring(0, letterIndex + 1);
						bibleWordBackward = bibleWordStrip.Substring(wordLength - letterIndex - 1);
						
						alphabetSequenceForward = AlphabetSequence.Id(bibleWordForward);
						alphabetSequenceBackward = AlphabetSequence.Id(bibleWordBackward);
						
						percentageForward = (decimal) alphabetSequenceForward / alphabetSequenceIndex;
						percentageBackward = (decimal) alphabetSequenceBackward / alphabetSequenceIndex;

						Exact exact = new Exact
						{
							ExactID = ExactID,
							BibleWord = bibleWord,
							FirstScriptureReference = FirstScriptureReference,
							LastScriptureReference = LastScriptureReference,
							Difference = difference,
							Occurrence = Occurrence,
							AlphabetSequenceIndex = alphabetSequenceIndex
						};

						if (checker == percentageForward)
						{
							RowsAdd(workTable, exact, bibleWordForward);
						}
						if (checker == percentageBackward)
						{
							RowsAdd(workTable, exact, bibleWordBackward);
						}
				
/*
						System.Console.WriteLine
						(
							"Bibleword: {0} Forward: {1} Backward: {2} Alphabet Forward: {3} alphabetSequenceBackward: {4} percentageForward: {5} percentageBackward: {6}",
							bibleWord,
							bibleWordForward,
							bibleWordBackward,
							alphabetSequenceForward,
							alphabetSequenceBackward,
							percentageForward,
							percentageBackward
						);
*/						
					}	
				}
			}
			catch(Exception ex)
			{
				System.Console.WriteLine("Exception: {0}", ex.Message);
			}	
				
			otherData.Tables.Add(workTable);
			
			return otherData;
        }
		
		public const string ExactSQL = "SELECT * FROM Bible..Exact ORDER BY ExactID";
		
		public partial class Exact
		{
			public	long	ExactID {get; set;}
			public	string	BibleWord {get; set;}
			public	string	FirstScriptureReference {get; set;}
			public	string	LastScriptureReference {get; set;}
			public	long?	Difference {get; set;}
			public	long	Occurrence {get; set;}
			public	long	AlphabetSequenceIndex {get; set;}
		}	
    }
}
