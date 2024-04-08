using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

/*
	2024-04-05	To initiate all bring. Word received.
	2024-04-06T06:30:00...2024-04-06T11:43:00 ToInitiateAllBring.cs file created.
*/
namespace InformationInTransit.ProcessCode
{
    public partial class ToInitiateAllBring
    {
		public static string Query
		(
			String word
		)
		{
			String resultSet = null;

			string[] words = word.Split
			(
				BibleWordHelper.SplitSeparator,
				StringSplitOptions.RemoveEmptyEntries
			);
			
			if (words.Count() < WordsCountRelevant)
			{
				return resultSet;
			}

			int[] alphabetSequenceIndexes = {-1, -1, -1};
			
			for 
			(
				int wordIndex = 0;
				wordIndex < WordsCountRelevant;
				++wordIndex
			)
			{
				alphabetSequenceIndexes[wordIndex] = AlphabetSequence.Id
				(
					words[wordIndex]
					);
			}	

			String queryStatement = String.Format
			(
				QueryFormat,
				alphabetSequenceIndexes[0],
				alphabetSequenceIndexes[1],
				alphabetSequenceIndexes[2]
			);	

            string scriptureReference = (String) DataCommand.DatabaseCommand
			(
				queryStatement,
                System.Data.CommandType.Text,
                DataCommand.ResultType.Scalar
            );
			
            return scriptureReference;
		}	

		public const int WordsCountRelevant = 3;

		public const string QueryFormat = @"
			SELECT WordEngineering.dbo.udf_ToInitiateAllBring
			(
				{0},
				{1},
				{2}
			)
		";
	}
}
