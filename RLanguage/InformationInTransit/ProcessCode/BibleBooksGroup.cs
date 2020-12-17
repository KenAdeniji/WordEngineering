using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

using InformationInTransit.ProcessLogic;

using System.Globalization;
using System.Threading;

namespace InformationInTransit.ProcessCode
{
	/*
		2019-06-21	Created.
		2019-06-21	https://forums.asp.net/t/1201252.aspx?How+to+do+Select+top+1+customer+from+customers+in+Linq+to+Sql+
		2019-06-21	https://biblewithann.wordpress.com/2013/10/21/divisions-classifications-of-bible-books/
		2019-06-21	https://stackoverflow.com/questions/51661419/to-concatenate-values-of-a-particular-column-in-multiple-rows-using-linq
		2019-07-03	https://stackoverflow.com/questions/37205657/how-to-select-then-orderby-using-linq/37205907	
	*/
    public partial class BibleBooksGroup
    {
        public static void Main(string[] argv)
        {
        }

        public string Condition
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

		public static string TitleJoin()
		{
			var query =
				from bibleBookGroup in BibleBooksGroups 
				orderby bibleBookGroup.Title
				select bibleBookGroup.Title
				;
			var titles = query.ToList();				
			return String.Join(",", titles);
		}

		public static string Query
		(
			String question,
			String bibleVersion,
			String queryFormat
		)
		{
			String[] scriptureReferenceSubset = question.Split
			(
				ScriptureReferenceHelper.SubsetSeparator,
				StringSplitOptions.RemoveEmptyEntries 
			);
			StringBuilder sb = new StringBuilder();
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
			foreach(String subset in scriptureReferenceSubset)
			{
				String groupCondition = 
				(
					from bibleBookGroup in BibleBooksGroups 
					where 
						cultureInfo.CompareInfo.IndexOf
						(
							subset,
							bibleBookGroup.Title,
							CompareOptions.IgnoreCase
						) == 0
					select bibleBookGroup.Condition
				).First();
				sb.AppendFormat
				(
					queryFormat,
					bibleVersion,
					groupCondition
				);	
			}
			return sb.ToString();
		}	

		public const String QueryFormat = @"
			SELECT ScriptureReference, {0} AS VerseText
			FROM Bible..Scripture_View
			WHERE {1}
			ORDER BY BookID, ChapterID, VerseID;
		";

		[XmlArray("BibleBooksGroups")]
		[XmlArrayItem("BibleBooksGroup")]
        public static readonly Collection<BibleBooksGroup> BibleBooksGroups = new Collection<BibleBooksGroup>
        {
			new BibleBooksGroup{ Title = "Apocalyptic", Condition = "BookID = 27 OR BookID = 66" },
			new BibleBooksGroup{ Title = "Gospels", Condition = "BookID BETWEEN 40 AND 43" },
			new BibleBooksGroup{ Title = "Historical", Condition = "BookID BETWEEN 6 AND 17" },
			new BibleBooksGroup{ Title = "Major Prophets", Condition = "BookID BETWEEN 23 AND 27" },
			new BibleBooksGroup{ Title = "Minor Prophets", Condition = "BookID BETWEEN 28 AND 39" },
			new BibleBooksGroup{ Title = "New Testament", Condition = "BookID BETWEEN 40 AND 66" },
			new BibleBooksGroup{ Title = "Old Testament", Condition = "BookID BETWEEN 1 AND 39" },
			new BibleBooksGroup{ Title = "Pauline Epistles", Condition = "BookID BETWEEN 45 AND 57" },
            new BibleBooksGroup{ Title = "Pentateuch", Condition = "BookID BETWEEN 1 AND 5" },
			new BibleBooksGroup{ Title = "Poetry", Condition = "BookID BETWEEN 18 AND 22" }
        };
    }
}
