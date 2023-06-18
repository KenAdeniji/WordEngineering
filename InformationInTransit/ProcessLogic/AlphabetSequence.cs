using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data;
using System.Data.SqlClient;

using System.Text.RegularExpressions;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

/*
	2016-05-18	In such; He has provided for man.
	2016-05-19	https://msdn.microsoft.com/en-us/library/b873y76a%28v=vs.110%29.aspx
	2016-05-19	http://www.databasejournal.com/features/mssql/article.php/3464481/Using-a-Subquery-in-a-T-SQL-Statement.htm
	2016-05-29	DeEd()		I am getting ready to seventy five percent.
	2016-05-31	TwoField()	Two field. O. J. Simpson.
	2017-01-13	I will install 1-2-3 on computer, then you may play twenty five percent. It had stay for integration. Who sought the earlier people trial.
	2017-01-13	Love fears, no more.
	2018-04-06	Id(string question)
				Check for only English letters.
				After a life, you justify yourself.
				Prior to HTML, the link, bibliography was at the bottom. Léopold, alphabetsequence, 74. Leopold, alphabetsequence, 79.	
	2018-08-01	Support for word, numeric. Odun. It is sweet. A friend shared the wafers he purchased at $1.50 from 99 Ranch Market, when the wafers were first introduced they cost less, but when people started buying them, the price was brought higher.
	2021-05-30	Equidistant Letter Sequence (ELS). The Bible Code. Word broken into length; and determine the AlphabetSequence for each set?
					Could I come, as final answer? Making improvement in advance.
					https://stackoverflow.com/questions/7316258/how-to-get-only-letters-from-a-string-in-c/7316298
	2023-06-17T18:05:00	Velicia ... three three ... four end.
				Uncle Jimi walked out of a Center room eastward. Homosexual sex involved. He said Velicia Kim lives on a dignitary street. 1963-04-24 smell (Gbo enu) (We are proving difficult). (We are proving difficult). Alexander III of Macedon (Ancient Greek: ????a?d???, romanized: Alexandros; 20/21 July 356 BC – 10/11 June 323 BC), commonly known as Alexander the Great,[a] was a king of the ancient Greek kingdom of Macedon. Duration	
				http://en.wikipedia.org/wiki/Alexander_the_Great
				Revelation 5:9, Revelation 10, Genesis 13, Genesis 12:14
				At 99 Ranch Market Filipinos ... Hindi wife and husband
				I walked at the Center lane and I exited at South West.
				Bavarian Motor Works (BMW) at the intersection of Fremont Boulevard and Paseo Padre Parkway, North East.
				Between 2023-06-17 ... 2023-06-18 twin sibling kept on urinating on the South West toilet bowl seat,
					I went to urinate at North Center on a few occasions,
					I later undressed my trouser and I pulled my shirt up.
				Alphabet Sequence
				256
				Genesis 10:21, 1 Samuel 20, Matthew 4, Revelation 9:5
				AlphabetSequenceIndexPercentage 41.02564102564103%
				AlphabetSequenceIndexPercentageScriptureReference Esther 3:4, Psalms 10, Isaiah 23, Isaiah 36:20
				http://stackoverflow.com/questions/3210393/how-do-i-remove-all-non-alphanumeric-characters-from-a-string-except-dash
	2023-06-18T11:05:00 ... 2023-06-18T11:44:00
        public static string VeliciaThreeThreeFourEnd
		(
			string	question
		)
        {
			int alphabetSequenceIndex = Id(question);
		
			question = question.Replace("?", "");
			question = question.Replace(".", "");
			question = question.Replace(",", "");
			question = question.Replace(";", "");
			question = question.Replace(" ", "");
			question = question.Replace("\"", "");
			question = question.Replace("'", "");

*/
namespace InformationInTransit.ProcessLogic
{
    public partial class AlphabetSequence
    {
		public static void Main(string[] argv)
		{
			//InSuch( argv[0], argv[1] );	
			//DeEd(Convert.ToDecimal(argv[0]));
			
			/*
			int id = Id(argv[0]);
			string scriptureReference = ScriptureReference(id);
			
			System.Console.WriteLine
			(
				"Word: {0} Id: {1} ScriptureReference: {2}",
				argv[0],
				id,
				scriptureReference
			);
			*/
			
			Collection<ItHadStayForIntegration> itHadStayForIntegrations = WordBrokenIntoLength
			(
				argv[0],
				5
			);
		}
		
        public static int Id(string question)
        {
            int alphabetSequence = 0;
			
			bool isNumerical = int.TryParse(question, out alphabetSequence);
			
			if (isNumerical)
			{
				return alphabetSequence;
			}	
			
            foreach (char q in question)
            {
                int ascii = 0;
                int index = 0;

                ascii = (int) q;
				
				/*
                if (Char.IsLower(q) && q >= 'a' && q >= 'z')
                {
                    index = ascii - 96;
                }
                if (Char.IsUpper(q)  && q >= 'A' && q >= 'Z')
                {
                    index = ascii - 64;
                }
				*/
				
                if (ascii >= 97 && ascii <= 122)
                {
                    index = ascii - 96;
                }
                if (ascii >= 65 && ascii <= 90)
                {
                    index = ascii - 64;
                }
                alphabetSequence += index;
				System.Console.WriteLine
				(
					"q: {0} ascii: {1} index: {2} alphabetSequence: {3}",
					q,
					ascii,
					index,
					alphabetSequence
				);
            }
            return alphabetSequence;
        }

        public static DataSet DeEd(decimal percent)
        {
			String sqlStatement = String.Format
			(
				SQLStatementDeEdFormat,
				percent
			);

			System.Console.WriteLine(sqlStatement);
			
			DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
			(
				sqlStatement,
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			
			return dataSet;	
		}

        public static DataSet InSuch(string word, string booksCollection)
        {
			int alphabetSequenceIndex = Id(word);
			int sequenceOrderID = -1;
			StringBuilder sqlStatementInSuch = new StringBuilder();

			string[] books =  booksCollection.Split(',');
			
			foreach (string booksGroup in books)
			{
				BooksGroup booksGroupCurrent = BooksCollection.Find(x => x.GroupName == booksGroup.Trim().ToLower());
			
				if (booksGroupCurrent == null) { continue; }
				
				++sequenceOrderID;
				
				int chapters = 	(	
									booksGroupCurrent.ChapterIdSequenceMaximum - 
									booksGroupCurrent.ChapterIdSequenceMinimum
								) + 1;

				int verses = 	(	
									booksGroupCurrent.VerseIdSequenceMaximum - 
									booksGroupCurrent.VerseIdSequenceMinimum
								) + 1;
								
				int	moduloChapter = alphabetSequenceIndex % chapters;
				int moduloVerse = alphabetSequenceIndex % verses;
				
				int chapterIdSequenceForward = booksGroupCurrent.ChapterIdSequenceMinimum + moduloChapter - 1;
				int chapterIdSequenceBackward = booksGroupCurrent.ChapterIdSequenceMaximum - moduloChapter;

				int verseIdSequenceForward = booksGroupCurrent.VerseIdSequenceMinimum + moduloVerse - 1;
				int verseIdSequenceBackward = booksGroupCurrent.VerseIdSequenceMaximum - moduloVerse + 1;
				
				if (sqlStatementInSuch.Length > 0)
				{
					sqlStatementInSuch.Append(" UNION " );
				}
				
				sqlStatementInSuch.AppendFormat
				(
					SQLStatementInSuchFormat,
					sequenceOrderID,
					booksGroup,
					chapterIdSequenceBackward,
					chapterIdSequenceForward,
					verseIdSequenceBackward,
					verseIdSequenceForward
				);
			}	

			sqlStatementInSuch.Append(" ORDER BY SequenceOrderID ");
			
			DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
			   (
					sqlStatementInSuch.ToString(),
					System.Data.CommandType.Text,
					DataCommand.ResultType.DataSet
				);
			
			return dataSet;	
		}
		
		public static string LeviticusAirDrop
		(
			string word,
			string bookIDs
		)
		{
			int id = Id(word);
			int	bookApart = -1;
			int	bookIDReady = -1;
			int bookIDValue = -1;;
			int val = 0;
			
			string[] bookIdentities = bookIDs.Split
			(
				new[] { ',', ';', ' ' },
                StringSplitOptions.RemoveEmptyEntries
			);

			string 	scriptureReference = "";
			string	scriptureReferenceVerseForward = "";
			
			foreach(string bookIDCurrent in bookIdentities)
			{
				Int32.TryParse( bookIDCurrent, out val );
				
				bookApart = (int) DataCommand.DatabaseCommand
                (
                    String.Format
					(
						"SELECT MAX(verseIdSequence) - MIN(verseIdSequence) FROM Bible..Scripture WHERE BookID = {0}",
						val
					),
                    System.Data.CommandType.Text,
                    DataCommand.ResultType.Scalar
                );
				
				System.Console.WriteLine
				(
					"bookIDCurrent: {0} | bookApart: {1}",
					bookIDCurrent,
					bookApart
				);
				
				if (id < bookApart)
				{
					Int32.TryParse( bookIDCurrent, out bookIDReady );
					break;
				}

				id -= bookApart;	
			}	

			scriptureReferenceVerseForward = (String) DataCommand.DatabaseCommand
			(
				String.Format
				(
					"SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIdSequence = ( SELECT MIN(verseIdSequence) + {1} FROM Bible..Scripture WHERE BookId = {0})",
					bookIDReady,
					id
				),
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			
			scriptureReference = scriptureReferenceVerseForward;
			
			return scriptureReference;
		}	
		
        public static string ScriptureReference(int alphabetSequenceIndex)
        {
            string reference = (String) DataCommand.DatabaseCommand
                               (
                                    "SELECT Bible.dbo.udf_AlphabetSequenceIndexScriptureReference(" + alphabetSequenceIndex + ")",
                                    System.Data.CommandType.Text,
                                    DataCommand.ResultType.Scalar
                                );
            return reference;
        }
		
        public static string ScriptureReferenceWhereClause(int alphabetSequenceIndex)
        {
			int	moduloChapter = alphabetSequenceIndex % ChapterIdSequenceMaximum;
			int moduloVerse = alphabetSequenceIndex % VerseIdSequenceMaximum;
			
			int chapterIdSequenceFirst = moduloChapter;
			int chapterIdSequenceLast = ChapterIdSequenceMaximum - moduloChapter + 1;

			int verseIdSequenceFirst = moduloVerse;
			int verseIdSequenceLast = VerseIdSequenceMaximum - moduloVerse + 1;
			
			string scriptureReferenceWhereClause = String.Format
			(
				ScriptureReferenceWhereClauseFormat,
				verseIdSequenceFirst,
				chapterIdSequenceFirst,
				chapterIdSequenceLast,
				verseIdSequenceLast
			);
			
			return scriptureReferenceWhereClause;
		}

        public static string TwoField
		(
			int 	bookID,
			int		chapterID,
			int		verseID,
			int		increment,
			string	choice
		)
        {
			String sqlStatement = String.Format
			(
				SQLStatementTwoFieldFormat,
				bookID,
				chapterID,
				verseID,
				increment,
				choice
			);
            String reference = 	(String) DataCommand.DatabaseCommand
								(
                                    sqlStatement,
                                    System.Data.CommandType.Text,
                                    DataCommand.ResultType.Scalar
                                );
            return reference;
        }

        public static string VeliciaThreeThreeFourEnd
		(
			string	question
		)
        {
			int alphabetSequenceIndex = Id(question);
		
			question = question.Replace("?", "");
			question = question.Replace(".", "");
			question = question.Replace(",", "");
			question = question.Replace(";", "");
			question = question.Replace(" ", "");
			question = question.Replace("\"", "");
			question = question.Replace("'", "");
			
			Regex regularExpression = new Regex("[^a-zA-Z]");
			string alphabetsOnly = regularExpression.Replace(question, "");
			decimal alphabetSequenceIndexPercentage = 
				( AlphabetSequenceIndexPercentageRatio * alphabetSequenceIndex )
				/ alphabetsOnly.Length;
			String alphabetSequenceIndexPercentageScriptureReference = BiblePercentage.Query
			(
				alphabetSequenceIndexPercentage
			);
			string alphabetSequenceIndexJSON = String.Format
			(
				VeliciaThreeThreeFourEndJsonFormat,
				alphabetSequenceIndexPercentage,
				alphabetSequenceIndexPercentageScriptureReference
			);	
            return alphabetSequenceIndexJSON;
        }
		
		public static Collection<ItHadStayForIntegration> WhoSoughtTheEarlierPeopleTrial(string word)
		{
			Collection<ItHadStayForIntegration> itHadStayForIntegrations =
				new Collection<ItHadStayForIntegration>();
			StringBuilder sb = new StringBuilder();
			String currentWord;
			int id;
			string scriptureReference;
			ItHadStayForIntegration itHadStayForIntegration;
			foreach(char currentCharacter in word)
			{
				if (!Char.IsLetter(currentCharacter))
				{
					sb.Append(currentCharacter);
					continue;
				}	
				sb.Append(currentCharacter);
				currentWord = sb.ToString();
				id = Id(currentWord);
				scriptureReference = ScriptureReference(id);
				itHadStayForIntegration = new ItHadStayForIntegration
				{
					Word = currentWord,
					Id = id,
					ScriptureReference = scriptureReference
				};
				itHadStayForIntegrations.Add(itHadStayForIntegration);
			}	
			return itHadStayForIntegrations;
		}	

		public static Collection<ItHadStayForIntegration> WordBrokenIntoLength
		(
			string word,
			int sizeLength
		)
		{
			Collection<ItHadStayForIntegration> itHadStayForIntegrations =
				new Collection<ItHadStayForIntegration>();
			String onlyLetters = new String(word.Where(Char.IsLetter).ToArray());
			String currentWord;
			int id;
			string scriptureReference;
			ItHadStayForIntegration itHadStayForIntegration;
			for
			(
				int currentPosition = 0, lengthTotal = onlyLetters.Length;
				currentPosition < lengthTotal;
				currentPosition += sizeLength
			)
			{
				if (currentPosition + sizeLength > lengthTotal)
				{
					sizeLength = lengthTotal - currentPosition;
				}		
				/*
				System.Console.WriteLine
				(
					"{0} {1} {2} {3}",
					onlyLetters, currentPosition, sizeLength, lengthTotal
				);
				*/		
				currentWord = onlyLetters.Substring(currentPosition, sizeLength);
				id = Id(currentWord);
				scriptureReference = ScriptureReference(id);
				itHadStayForIntegration = new ItHadStayForIntegration
				{
					Word = currentWord,
					Id = id,
					ScriptureReference = scriptureReference
				};
				itHadStayForIntegrations.Add(itHadStayForIntegration);
			}	
			return itHadStayForIntegrations;
		}	

		public static string YourIDOrWhatDoYouWriteYourCommonID
		(
			string	scriptureReference,
			string	scriptureSelection
		)	
		{
			string sqlStatement = "";
			
			switch (scriptureSelection)
			{
				case "Verse Forward":
					sqlStatement = String.Format
					(
						SQLStatementYourIDOrWhatDoYouWriteYourCommonIDFormat,
						"VerseIdSequence",
						scriptureReference
					);	
					break;	
				case "Chapter Forward":
					sqlStatement = String.Format
					(
						SQLStatementYourIDOrWhatDoYouWriteYourCommonIDFormat,
						"ChapterIdSequence",
						scriptureReference
					);	
					break;	
				case "Chapter Backward":
					sqlStatement = String.Format
					(
						SQLStatementYourIDOrWhatDoYouWriteYourCommonIDFormat,
						"1190 - ChapterIdSequence",
						scriptureReference
					);	
					break;	
				case "Verse Backward":
					sqlStatement = String.Format
					(
						SQLStatementYourIDOrWhatDoYouWriteYourCommonIDFormat,
						"31103 - VerseIdSequence",
						scriptureReference
					);	
					break;	
			}	
			
            int id =	(int) DataCommand.DatabaseCommand
			(
                sqlStatement,
                System.Data.CommandType.Text,
                DataCommand.ResultType.Scalar
            );

			string alphabetSequenceScriptureReference = ScriptureReference(id);
			
			return alphabetSequenceScriptureReference;
			
		}
		
        public const decimal AlphabetSequenceIndexPercentageRatio = 100M / 26M;
		public const int ChapterIdSequenceMaximum = 1189;
        public const int VerseIdSequenceMaximum = 31102;

		public const string ScriptureReferenceWhereClauseFormat = " ( verseIdSequence IN ({0}, {3}) OR chapterIdSequence IN ({1}, {2}) ) ";

		public const string	SQLStatementDeEdFormat = 
		"SELECT {0} AS sequenceOrderID, " + 
			" ( SELECT TOP 1 BookTitle + ' ' + CONVERT(VARCHAR, chapterId) FROM Bible..Scripture_View WHERE ChapterIdSequencePercent >= {0} ORDER BY verseIDSequence ) chapterIDForward, " +
			" ( SELECT TOP 1 BookTitle + ' ' + CONVERT(VARCHAR, chapterId) FROM Bible..Scripture_View WHERE ChapterIdSequence = ( SELECT MAX(chapterIdSequence) FROM Bible..Scripture WHERE chapterIdSequencePercent <= 100 - {0} ) ORDER BY verseIDSequence DESC ) chapterIDBackward, " +
			" ( SELECT TOP 1 ScriptureReference FROM Bible..Scripture_View WHERE VerseIdSequencePercent >= {0} ORDER BY verseIDSequence ) verseForward, " +
			" ( SELECT TOP 1 ScriptureReference FROM Bible..Scripture_View WHERE VerseIdSequence = ( SELECT MAX(verseIdSequence) FROM Bible..Scripture_View WHERE verseIdSequencePercent <= 100 - {0} ) ORDER BY verseIDSequence DESC ) verseBackward";

		public const string	SQLStatementInSuchFormat = 
			"SELECT {0} AS sequenceOrderID, '{1}' AS booksGroup, " + 
				" ( SELECT TOP 1 BookTitle + ' ' + CONVERT(VARCHAR, chapterId) FROM Bible..Scripture_View WHERE	ChapterIdSequence = {2} ) chapterIDBackward, " +
				" ( SELECT TOP 1 BookTitle + ' ' + CONVERT(VARCHAR, chapterId) FROM Bible..Scripture_View WHERE	ChapterIdSequence = {3} ) chapterIDForward, " +
				" ( SELECT ScriptureReference FROM Bible..Scripture WHERE VerseIdSequence = {4} ) verseBackward, " +
				" ( SELECT ScriptureReference FROM	Bible..Scripture WHERE VerseIdSequence = {5} ) verseForward ";

		public const string	SQLStatementTwoFieldFormat = 
			"SELECT WordEngineering.dbo.udf_TwoField({0}, {1}, {2}, {3}, '{4}');";

		public const string	VeliciaThreeThreeFourEndJsonFormat = "{{\"alphabetSequenceIndexPercentage\": {0}, \"alphabetSequenceIndexPercentageScriptureReference\": \"{1}\"}}";
		
		public const string SQLStatementYourIDOrWhatDoYouWriteYourCommonIDFormat =
			"SELECT TOP 1 {0} FROM Bible..Scripture_View WHERE ScriptureReference LIKE '%{1}%' ORDER BY VerseIdSequence";
			
		public static readonly List<BooksGroup> BooksCollection = new List<BooksGroup>
        {
            new BooksGroup() 
			{ 
				GroupName="all", ChapterIdSequenceMaximum = 1189, ChapterIdSequenceMinimum = 1,
				VerseIdSequenceMaximum = 31102, VerseIdSequenceMinimum = 1
			},
            new BooksGroup() 
			{ 
				GroupName="old testament", ChapterIdSequenceMaximum = 929, ChapterIdSequenceMinimum = 1,
				VerseIdSequenceMaximum = 23145, VerseIdSequenceMinimum = 1
			},
            new BooksGroup() 
			{ 
				GroupName="new testament", ChapterIdSequenceMaximum = 1189, ChapterIdSequenceMinimum = 930,
				VerseIdSequenceMaximum = 31102, VerseIdSequenceMinimum = 23146
			},
            new BooksGroup() 
			{ 
				GroupName="pentateuch", ChapterIdSequenceMaximum = 187, ChapterIdSequenceMinimum = 1,
				VerseIdSequenceMaximum = 5852, VerseIdSequenceMinimum = 1
			},
            new BooksGroup() 
			{ 
				GroupName="major prophets", ChapterIdSequenceMaximum = 862, ChapterIdSequenceMinimum = 680,
				VerseIdSequenceMaximum = 22095, VerseIdSequenceMinimum = 17656
			},
            new BooksGroup() 
			{ 
				GroupName="minor prophets", ChapterIdSequenceMaximum = 929, ChapterIdSequenceMinimum = 863,
				VerseIdSequenceMaximum = 23145, VerseIdSequenceMinimum = 22096
			},
            new BooksGroup() 
			{ 
				GroupName="gospel", ChapterIdSequenceMaximum = 1018, ChapterIdSequenceMinimum = 930,
				VerseIdSequenceMaximum = 26924, VerseIdSequenceMinimum = 23146
			}
		};
		
		public partial class BooksGroup
		{
			public string GroupName {get; set;}
			public int ChapterIdSequenceMaximum {get; set;}
			public int ChapterIdSequenceMinimum {get; set;}
			public int VerseIdSequenceMaximum {get; set;}
			public int VerseIdSequenceMinimum {get; set;}
		}
    }
	
	public partial class ItHadStayForIntegration
	{
		public string Word {get; set;}
		public int Id {get; set;}
		public string ScriptureReference {get; set;}
	}	
}
