using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using InformationInTransit.DataAccess;

/*
2014-02-23 	MeetMyEndThrough.cs. Meet my end, through. Like exact, for number parser. File created, work begun.
			Those that were numbered of them, even of the tribe of Reuben, were forty and six thousand and five hundred (Numbers 1:21). 46500 / 201 = 231.34328358208955223880597014925. 201 / 46500 = 0.00432258064516129032258064516129.
2014-02-23	http://stackoverflow.com/questions/11694910/how-do-you-use-object-initializers-for-a-list-of-key-value-pairs
2014-02-24	http://stackoverflow.com/questions/13988643/case-insensitive-dictionary-with-string-key-type-in-c-sharp
2014-02-25	Word parse.
2014-03-01	Data loss error.
*/
namespace InformationInTransit.ProcessLogic
{
    public static partial class MeetMyEndThrough
    {
        public static void Main(string[] argv)
        {
            bool processingNumber = false;

            Int64 subNumber = 0;
            Int64 totalNumber = 0;
            Int64 wordValue = 0;

            string adjust = null;
            string scriptureReference = null;
            string verseText = null;
            string word = null;
            string[] words = null;

            StringBuilder phrase = null;
            Participation participation = null;
            SameWordComparer compareWord = new SameWordComparer();
            Dictionary<Int64, Participation> uniqueWords = new Dictionary<Int64, Participation>(compareWord);
            bool found = true;

            DataTable dataTable = ReadBible();
            int row = 1;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                processingNumber = false;

                subNumber = 0;
                totalNumber = 0;

                verseText = (string)dataRow["verseText"];
                verseText = verseText.Replace("score", " score");

                words = verseText.Split(SplitSeparator);
                phrase = new StringBuilder();
                subNumber = 0;
                totalNumber = 0;

                for (int wordIndex = 0, wordCount = words.Length; wordIndex < wordCount; ++wordIndex)
                {
                    wordValue = 0;
                    word = words[wordIndex];

                    adjust = word.Trim();
                    if (adjust == String.Empty)
                    {
                        continue;
                    }

                    if (OnesCollection.ContainsKey(adjust))
                    {
                        processingNumber = true;
                        wordValue = OnesCollection[adjust];
                        phrase = AppendText(phrase, adjust);
                        subNumber += wordValue;
                    }
                    else if (TensCollection.ContainsKey(adjust))
                    {
                        processingNumber = true;
                        wordValue = TensCollection[adjust];
                        phrase = AppendText(phrase, adjust);
                        subNumber += wordValue;
                    }
                    else if (PowersCollection.ContainsKey(adjust))
                    {
                        processingNumber = true;
                        wordValue = PowersCollection[adjust];
                        phrase = AppendText(phrase, adjust);
                        if (subNumber == 0)
                        {
                            subNumber = 1;
                        }
                        subNumber *= wordValue;
                    }
                    else if
                    (
                        (string.Compare(And, adjust, StringComparison.OrdinalIgnoreCase) == 0) &&
                        processingNumber == true
                    )
                    {
                        totalNumber += subNumber;
                        subNumber = 0;
                    }
                    else
                    {
                        processingNumber = false;
                        totalNumber += subNumber;
                        subNumber = 0;

                        if (totalNumber == 0)
                        {
                            continue;
                        }

                        scriptureReference = (string)dataRow["ScriptureReference"];
                        //found = uniqueWords.ContainsKey(totalNumber);
                        found = uniqueWords.TryGetValue(totalNumber, out participation);
                        if (!found)
                        {
                            participation = new Participation
                            {
                                Phrase = phrase,
                                FirstOccurrence = scriptureReference,
                                FirstOccurrencePosition = row,
                                Occurrence = 1
                            };
                            uniqueWords.Add(totalNumber, participation);
                        }
                        else
                        {
                            participation.LastOccurrence = scriptureReference;
                            participation.LastOccurrencePosition = row;
                            ++participation.Occurrence;
                        }
                    }

                    System.Console.WriteLine
                    (
                        "scriptureReference: {0} | adjust: {1} | phrase: {2} | processingNumber: {3} | totalNumber: {4} | subNumber: {5}",
                        scriptureReference,
                        adjust,
                        phrase,
                        processingNumber,
                        totalNumber,
                        subNumber
                    );

                    if (processingNumber == false)
                    {
                        phrase = new StringBuilder();
                        subNumber = 0;
                        totalNumber = 0;
                    }
                }
                ++row;
            }

            DataCommand.DatabaseCommand
            (
                "TRUNCATE TABLE Bible..MeetMyEndThrough; DBCC CHECKIDENT('Bible..MeetMyEndThrough', RESEED, 1);",
                CommandType.Text,
                DataCommand.ResultType.NonQuery
            );

            foreach (KeyValuePair<Int64, Participation> kvp in uniqueWords)
            {
                Collection<OleDbParameter> oleDbParameterCollection = new Collection<OleDbParameter>();
                oleDbParameterCollection.Add(new OleDbParameter("@number", kvp.Key));
                oleDbParameterCollection.Add(new OleDbParameter("@phrase", kvp.Value.Phrase.ToString()));
                oleDbParameterCollection.Add(new OleDbParameter("@firstOccurrence", kvp.Value.FirstOccurrence));

                OleDbParameter lastOccurrence = new OleDbParameter("@lastOccurrence", SqlDbType.VarChar);
                lastOccurrence.IsNullable = true;
                lastOccurrence.Value = DBNull.Value;

                OleDbParameter difference = new OleDbParameter("@difference", SqlDbType.Int);
                difference.IsNullable = true;
                difference.Value = DBNull.Value;

                if (!String.IsNullOrEmpty(kvp.Value.LastOccurrence))
                {
                    lastOccurrence.Value = kvp.Value.LastOccurrence;
                    difference.Value = kvp.Value.LastOccurrencePosition - kvp.Value.FirstOccurrencePosition;
                }

                oleDbParameterCollection.Add(lastOccurrence);
                oleDbParameterCollection.Add(difference);

                oleDbParameterCollection.Add(new OleDbParameter("@Occurrence", kvp.Value.Occurrence));

                DataCommand.DatabaseCommand
                (
                    "Bible..usp_MeetMyEndThroughInsert",
                    CommandType.StoredProcedure,
                    DataCommand.ResultType.NonQuery,
                    oleDbParameterCollection
                );
            }
        }

        public static StringBuilder AppendText(StringBuilder sb, string postfix)
        {
            if (sb.Length > 0)
            {
                sb.Append(' ');
            }
            sb.Append(postfix);
            return sb;
        }

        public static DataTable ReadBible()
        {
            DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
            (
                BibleSQLSelect,
                CommandType.Text,
                DataCommand.ResultType.DataTable
            );
            return dataTable;
        }

        public static readonly char[] SplitSeparator = new Char[] { ' ', ',', '.', ':', ';', '(', ')', '?', '!' };

        public const string And = "and";

        public const string BibleSQLSelect = @"SELECT ScriptureReference, verseText FROM Bible..Scripture_View ORDER BY bookId, chapterId, verseId";

        public static readonly Dictionary<string, Int64> OnesCollection = new Dictionary<string, Int64>
        (
            StringComparer.InvariantCultureIgnoreCase
        )
		{
			{"One", 1},
			{"Two", 2},
			{"Three", 3},
			{"Four", 4},
			{"Five", 5},
			{"Six", 6},
			{"Seven", 7},
			{"Eight", 8},
			{"Nine", 9},
			{"Ten", 10},
			{"Eleven", 11},
			{"Twelve", 12},
			{"Thirteen", 13},
			{"Fourteen", 14},
			{"Fifteen", 15},
			{"Sixteen", 16},
			{"Seventeen", 17},
			{"Eighteen", 18},
			{"Nineteen", 19}
		};

        public static readonly Dictionary<string, Int64> TensCollection = new Dictionary<string, Int64>
        (
            StringComparer.InvariantCultureIgnoreCase
        )
		{
			{"Twenty", 20},
			{"Thirty", 30},
			{"Forty", 40},
			{"Fifty", 50},
			{"Sixty", 60},
			{"Seventy", 70},
			{"Eighty", 80},
			{"Ninety", 90}
		};

        public static readonly Dictionary<string, Int64> PowersCollection = new Dictionary<string, Int64>
        (
            StringComparer.InvariantCultureIgnoreCase
        )
		{
			{"Score", 20},
			{"Hundred", 100},
			{"Thousand", 1000},
			{"Million", 1000000},
			{"Billion", 1000000000},
			{"Trillion", 1000000000000}
		};

        class SameWordComparer : EqualityComparer<Int64>
        {
            public override bool Equals(Int64 i1, Int64 i2)
            {
                return i1.Equals(i2);
            }

            public override int GetHashCode(Int64 s)
            {
                return base.GetHashCode();
            }

        }

        class Participation
        {
            public StringBuilder Phrase { get; set; }
            public string FirstOccurrence { get; set; }
            public string LastOccurrence { get; set; }
            public int FirstOccurrencePosition { get; set; }
            public int? LastOccurrencePosition { get; set; }
            public int Occurrence { get; set; }
        }
    }
}
