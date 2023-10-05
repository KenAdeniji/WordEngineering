<%@ WebService Language="C#" Class="AlphabetSequenceWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.ProcessLogic;

/*
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
///<summary>
///	2015-11-05	Created.	AlphabetSequenceWebService.asmx
///	2016-05-18	InSuch()	In such; He has provided for man.
///	2016-05-29	DeEd()		I am getting ready to seventy five percent.
///	2016-05-31	TwoField()	Two field. O. J. Simpson.
/// 2017-01-13	Love fears, no more.
///	2017-06-05	Where about of God; is where about; I know.
/// 2017-12-16	IAmAfraidOfTheMark.
///	2017-12-25	YourIDOrWhatDoYouWriteYourCommonID.
///	2021-05-30	Equidistant Letter Sequence (ELS). The Bible Code. Word broken into length; and determine the AlphabetSequence for each set?
///					Could I come, as final answer? Making improvement in advance.
///					https://stackoverflow.com/questions/7316258/how-to-get-only-letters-from-a-string-in-c/7316298
///	2023-06-17	AlphabetSequence.VeliciaThreeThreeFourEnd(word);
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AlphabetSequenceWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public int ID(string word)
    {
		int id = AlphabetSequence.Id(word);
		return id;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String DeEd(decimal percent)
    {
		DataSet resultSet = AlphabetSequence.DeEd(percent);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
	}
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String IAmAfraidOfTheMark
	(
		string word,
		String scriptureReference
	)
    {
		int id = AlphabetSequence.Id(word);
		
		String scriptureReferenceVerseForward = IAmAfraidOfTheMarkHelper.Query
		(
			word,
			scriptureReference
		);
		
		string json = String.Format
		(
			JsonFormat,
			id,
			scriptureReferenceVerseForward
		);
		
		return json;
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String InSuch(string word, string booksCollection)
    {
		InSuchCombine inSuchCombine = new InSuchCombine()
		{
			ID = ID(word),
			GroupsScriptureReferences = AlphabetSequence.InSuch(word, booksCollection)
		};
		
		string json = JsonConvert.SerializeObject(inSuchCombine, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String LeviticusAirDrop(string word, string bookIDs)
    {
		int id = AlphabetSequence.Id(word);
		
		String scriptureReference = AlphabetSequence.LeviticusAirDrop
		(
			word,
			bookIDs
		);
		
		string json = String.Format
		(
			JsonFormat,
			id,
			scriptureReference
		);
		
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string word)
    {
		int id = AlphabetSequence.Id(word);
		string scriptureReference = AlphabetSequence.ScriptureReference(id);
		
		string json = String.Format
		(
			JsonFormat,
			id,
			scriptureReference
		);

		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String TwoField
	(
		int 	bookID,
		int		chapterID,
		int		verseID,
		int		increment,
		string	choice
	)
    {
		string scriptureReference = AlphabetSequence.TwoField
		(
			bookID,
			chapterID,
			verseID,
			increment,
			choice
		);
		return scriptureReference;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String VeliciaThreeThreeFourEnd(string word)
    {
		return AlphabetSequence.VeliciaThreeThreeFourEnd(word);
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String WhereAboutOfGodIsWhereAboutIKnow(string word)
    {
		StringBuilder sb = new StringBuilder();
		String[] words = word.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
		String[] currentPart;
		String currentWord;
		int startingPosition, endingPosition;
		String currentSubset;
		foreach(String currentLine in words)
		{
			currentPart = currentLine.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.None);
			currentWord = currentPart[0];
			startingPosition = Convert.ToInt32(currentPart[1]) - 1;
			endingPosition = Convert.ToInt32(currentPart[2]) - 1;
			currentSubset = currentWord.Substring(startingPosition, (endingPosition - startingPosition) + 1);
			sb.Append(currentSubset);
		}
		int id = AlphabetSequence.Id(sb.ToString());
		string scriptureReference = AlphabetSequence.ScriptureReference(id);
		
		string json = String.Format
		(
			JsonFormat,
			id,
			scriptureReference
		);

		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String WhoSoughtTheEarlierPeopleTrial
	(
		String word
	)	
    {
		Collection<ItHadStayForIntegration> itHadStayForIntegrations = AlphabetSequence.WhoSoughtTheEarlierPeopleTrial
		(
			word
		);	
		string json = JsonConvert.SerializeObject(itHadStayForIntegrations, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String WordBrokenIntoLength
	(
		String word,
		int sizeLength
	)	
    {
		Collection<ItHadStayForIntegration> itHadStayForIntegrations = AlphabetSequence.WordBrokenIntoLength
		(
			word,
			sizeLength
		);	
		string json = JsonConvert.SerializeObject(itHadStayForIntegrations, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String YourIDOrWhatDoYouWriteYourCommonID
	(
		string	scriptureReference,
		string	scriptureSelection
	)	
    {
		String alphabetSequenceScriptureReference = AlphabetSequence.YourIDOrWhatDoYouWriteYourCommonID
		(
			scriptureReference,
			scriptureSelection
		);	
		string json = String.Format
		(
			TwoFieldJsonFormat,
			alphabetSequenceScriptureReference
		);	
		return json;
	}
	
	public partial class InSuchCombine
	{
		public	int 	ID {get; set;}
		public	DataSet	GroupsScriptureReferences {get; set;}
	}
	
	public const string JsonFormat = "{{\"id\": {0}, \"scriptureReference\": \"{1}\"}}";
	public const string TwoFieldJsonFormat = "{{\"scriptureReference\": \"{0}\"}}";
}
