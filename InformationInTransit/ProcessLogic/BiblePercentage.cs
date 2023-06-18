using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using InformationInTransit.DataAccess;

/*
2016-04-02	BiblePercentage.cs Created. You wouldn't see this thing, unless your wisdom prevade the LORD.
2016-04-03	https://msdn.microsoft.com/en-us/library/bb531208.aspx
2016-04-03	https://msdn.microsoft.com/en-us/library/xfhwa508.aspx
			2023-06-17T18:05:00	Velicia ... three three ... four end.
								Uncle Jimi walked out of a Center room eastward. Homosexual sex involved. He said Velicia Kim lives on a dignitary street. 1963-04-24 smell (Gbo enu) (We are proving difficult). (We are proving difficult). Alexander III of Macedon (Ancient Greek: ????a?d???, romanized: Alexandros; 20/21 July 356 BC – 10/11 June 323 BC), commonly known as Alexander the Great,[a] was a king of the ancient Greek kingdom of Macedon. Duration	
								http://en.wikipedia.org/wiki/Alexander_the_Great
								Revelation 5:9, Revelation 10, Genesis 13, Genesis 12:14
								At 99 Ranch Market Filipinos ... Hindi wife and husband
								I walked at the Center lane and I exited at South West.
								Bavarian Motor Works (BMW) at the intersection of Fremont Boulevard and Paseo Padre Parkway, North East.
								alphabetSequenceIndexPercentage 
									41%
								alphabetSequenceIndexPercentageScriptureReference
									Esther 3:4, Psalms 10, Isaiah 23, Isaiah 36:20
			public static string Query(decimal percentage)
			{
				return Query(percentage, "All");
			}
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class BiblePercentage
	{
		public static string Query(decimal percentage)
		{
			return Query(percentage, "All");
		}
		
		public static string Query(decimal percentage, string limit)
		{
			Prevade	prevade = null;
			bool found = Prevades.TryGetValue(limit, out prevade);
			if (!found) return null;
			string query = String.Format
			(
				BiblePercentageQueryFormat,
				percentage,
				prevade.FirstChapter,
				prevade.LastChapter,
				prevade.FirstVerse,
				prevade.LastVerse
			);
            string scripturereference = (String) DataCommand.DatabaseCommand
            (
				query,
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
            );
            return scripturereference;
		}
		
		/*
			SELECT
				'{"' + bookTitle + '", new Prevade {FirstChapter=' + CONVERT(VARCHAR, MIN(chapterIDSequence)) +
				', LastChapter=' + CONVERT(VARCHAR, MAX(chapterIDSequence)) +
				', FirstVerse=' + CONVERT(VARCHAR, MIN(verseIDSequence)) +
				', LastVerse=' + CONVERT(VARCHAR, MAX(verseIDSequence)) + '}},'
			FROM
				Bible..Scripture
			GROUP BY
				bookId,
				bookTitle
			ORDER BY
				bookId
		*/
		public static readonly Dictionary<string, Prevade> Prevades = new Dictionary<string, Prevade>()
		{
			{"All", new Prevade {FirstChapter=1,LastChapter=1189,FirstVerse=1,LastVerse=31102}},
			{"Old Testament", new Prevade {FirstChapter=1,LastChapter=929,FirstVerse=1,LastVerse=23145}},
			{"New Testament", new Prevade {FirstChapter=930,LastChapter=1189,FirstVerse=23146,LastVerse=31102}},
			{"Pentateuch", new Prevade {FirstChapter=1,LastChapter=187,FirstVerse=1,LastVerse=5852}},
			{"Joshua - 2 Chronicles", new Prevade {FirstChapter=188,LastChapter=403,FirstVerse=5853,LastVerse=12017}},
			{"Major Prophets", new Prevade {FirstChapter=680,LastChapter=862,FirstVerse=17656,LastVerse=22095}},
			{"Minor Prophets", new Prevade {FirstChapter=680,LastChapter=862,FirstVerse=22096,LastVerse=22292}},
			{"Gospel", new Prevade {FirstChapter=1018,LastChapter=1189,FirstVerse=26924,LastVerse=31102}},
			{"Genesis", new Prevade {FirstChapter=1, LastChapter=50, FirstVerse=1, LastVerse=1533}},
			{"Exodus", new Prevade {FirstChapter=51, LastChapter=90, FirstVerse=1534, LastVerse=2746}},
			{"Leviticus", new Prevade {FirstChapter=91, LastChapter=117, FirstVerse=2747, LastVerse=3605}},
			{"Numbers", new Prevade {FirstChapter=118, LastChapter=153, FirstVerse=3606, LastVerse=4893}},
			{"Deuteronomy", new Prevade {FirstChapter=154, LastChapter=187, FirstVerse=4894, LastVerse=5852}},
			{"Joshua", new Prevade {FirstChapter=188, LastChapter=211, FirstVerse=5853, LastVerse=6510}},
			{"Judges", new Prevade {FirstChapter=212, LastChapter=232, FirstVerse=6511, LastVerse=7128}},
			{"Ruth", new Prevade {FirstChapter=233, LastChapter=236, FirstVerse=7129, LastVerse=7213}},
			{"1 Samuel", new Prevade {FirstChapter=237, LastChapter=267, FirstVerse=7214, LastVerse=8023}},
			{"2 Samuel", new Prevade {FirstChapter=268, LastChapter=291, FirstVerse=8024, LastVerse=8718}},
			{"1 Kings", new Prevade {FirstChapter=292, LastChapter=313, FirstVerse=8719, LastVerse=9534}},
			{"2 Kings", new Prevade {FirstChapter=314, LastChapter=338, FirstVerse=9535, LastVerse=10253}},
			{"1 Chronicles", new Prevade {FirstChapter=339, LastChapter=367, FirstVerse=10254, LastVerse=11195}},
			{"2 Chronicles", new Prevade {FirstChapter=368, LastChapter=403, FirstVerse=11196, LastVerse=12017}},
			{"Ezra", new Prevade {FirstChapter=404, LastChapter=413, FirstVerse=12018, LastVerse=12297}},
			{"Nehemiah", new Prevade {FirstChapter=414, LastChapter=426, FirstVerse=12298, LastVerse=12703}},
			{"Esther", new Prevade {FirstChapter=427, LastChapter=436, FirstVerse=12704, LastVerse=12870}},
			{"Job", new Prevade {FirstChapter=437, LastChapter=478, FirstVerse=12871, LastVerse=13940}},
			{"Psalms", new Prevade {FirstChapter=479, LastChapter=628, FirstVerse=13941, LastVerse=16401}},
			{"Proverbs", new Prevade {FirstChapter=629, LastChapter=659, FirstVerse=16402, LastVerse=17316}},
			{"Ecclesiastes", new Prevade {FirstChapter=660, LastChapter=671, FirstVerse=17317, LastVerse=17538}},
			{"Song of Solomon", new Prevade {FirstChapter=672, LastChapter=679, FirstVerse=17539, LastVerse=17655}},
			{"Isaiah", new Prevade {FirstChapter=680, LastChapter=745, FirstVerse=17656, LastVerse=18947}},
			{"Jeremiah", new Prevade {FirstChapter=746, LastChapter=797, FirstVerse=18948, LastVerse=20311}},
			{"Lamentations", new Prevade {FirstChapter=798, LastChapter=802, FirstVerse=20312, LastVerse=20465}},
			{"Ezekiel", new Prevade {FirstChapter=803, LastChapter=850, FirstVerse=20466, LastVerse=21738}},
			{"Daniel", new Prevade {FirstChapter=851, LastChapter=862, FirstVerse=21739, LastVerse=22095}},
			{"Hosea", new Prevade {FirstChapter=863, LastChapter=876, FirstVerse=22096, LastVerse=22292}},
			{"Joel", new Prevade {FirstChapter=877, LastChapter=879, FirstVerse=22293, LastVerse=22365}},
			{"Amos", new Prevade {FirstChapter=880, LastChapter=888, FirstVerse=22366, LastVerse=22511}},
			{"Obadiah", new Prevade {FirstChapter=889, LastChapter=889, FirstVerse=22512, LastVerse=22532}},
			{"Jonah", new Prevade {FirstChapter=890, LastChapter=893, FirstVerse=22533, LastVerse=22580}},
			{"Micah", new Prevade {FirstChapter=894, LastChapter=900, FirstVerse=22581, LastVerse=22685}},
			{"Nahum", new Prevade {FirstChapter=901, LastChapter=903, FirstVerse=22686, LastVerse=22732}},
			{"Habakkuk", new Prevade {FirstChapter=904, LastChapter=906, FirstVerse=22733, LastVerse=22788}},
			{"Zephaniah", new Prevade {FirstChapter=907, LastChapter=909, FirstVerse=22789, LastVerse=22841}},
			{"Haggai", new Prevade {FirstChapter=910, LastChapter=911, FirstVerse=22842, LastVerse=22879}},
			{"Zechariah", new Prevade {FirstChapter=912, LastChapter=925, FirstVerse=22880, LastVerse=23090}},
			{"Malachi", new Prevade {FirstChapter=926, LastChapter=929, FirstVerse=23091, LastVerse=23145}},
			{"Matthew", new Prevade {FirstChapter=930, LastChapter=957, FirstVerse=23146, LastVerse=24216}},
			{"Mark", new Prevade {FirstChapter=958, LastChapter=973, FirstVerse=24217, LastVerse=24894}},
			{"Luke", new Prevade {FirstChapter=974, LastChapter=997, FirstVerse=24895, LastVerse=26045}},
			{"John", new Prevade {FirstChapter=998, LastChapter=1018, FirstVerse=26046, LastVerse=26924}},
			{"Acts", new Prevade {FirstChapter=1019, LastChapter=1046, FirstVerse=26925, LastVerse=27931}},
			{"Romans", new Prevade {FirstChapter=1047, LastChapter=1062, FirstVerse=27932, LastVerse=28364}},
			{"1 Corinthians", new Prevade {FirstChapter=1063, LastChapter=1078, FirstVerse=28365, LastVerse=28801}},
			{"2 Corinthians", new Prevade {FirstChapter=1079, LastChapter=1091, FirstVerse=28802, LastVerse=29058}},
			{"Galatians", new Prevade {FirstChapter=1092, LastChapter=1097, FirstVerse=29059, LastVerse=29207}},
			{"Ephesians", new Prevade {FirstChapter=1098, LastChapter=1103, FirstVerse=29208, LastVerse=29362}},
			{"Philippians", new Prevade {FirstChapter=1104, LastChapter=1107, FirstVerse=29363, LastVerse=29466}},
			{"Colossians", new Prevade {FirstChapter=1108, LastChapter=1111, FirstVerse=29467, LastVerse=29561}},
			{"1 Thessalonians", new Prevade {FirstChapter=1112, LastChapter=1116, FirstVerse=29562, LastVerse=29650}},
			{"2 Thessalonians", new Prevade {FirstChapter=1117, LastChapter=1119, FirstVerse=29651, LastVerse=29697}},
			{"1 Timothy", new Prevade {FirstChapter=1120, LastChapter=1125, FirstVerse=29698, LastVerse=29810}},
			{"2 Timothy", new Prevade {FirstChapter=1126, LastChapter=1129, FirstVerse=29811, LastVerse=29893}},
			{"Titus", new Prevade {FirstChapter=1130, LastChapter=1132, FirstVerse=29894, LastVerse=29939}},
			{"Philemon", new Prevade {FirstChapter=1133, LastChapter=1133, FirstVerse=29940, LastVerse=29964}},
			{"Hebrews", new Prevade {FirstChapter=1134, LastChapter=1146, FirstVerse=29965, LastVerse=30267}},
			{"James", new Prevade {FirstChapter=1147, LastChapter=1151, FirstVerse=30268, LastVerse=30375}},
			{"1 Peter", new Prevade {FirstChapter=1152, LastChapter=1156, FirstVerse=30376, LastVerse=30480}},
			{"2 Peter", new Prevade {FirstChapter=1157, LastChapter=1159, FirstVerse=30481, LastVerse=30541}},
			{"1 John", new Prevade {FirstChapter=1160, LastChapter=1164, FirstVerse=30542, LastVerse=30646}},
			{"2 John", new Prevade {FirstChapter=1165, LastChapter=1165, FirstVerse=30647, LastVerse=30659}},
			{"3 John", new Prevade {FirstChapter=1166, LastChapter=1166, FirstVerse=30660, LastVerse=30673}},
			{"Jude", new Prevade {FirstChapter=1167, LastChapter=1167, FirstVerse=30674, LastVerse=30698}},
			{"Revelation", new Prevade {FirstChapter=1168, LastChapter=1189, FirstVerse=30699, LastVerse=31102}}			
		};	
		
		public const string BiblePercentageQueryFormat = " SELECT WordEngineering.dbo.udf_BiblePercentage( {0}, {1}, {2}, {3}, {4} ) ";
	}
	
	public class Prevade
	{
		public int FirstChapter {get; set;}
		public int LastChapter {get; set;}
		public int FirstVerse {get; set;}
		public int LastVerse {get; set;}
	}	
}
