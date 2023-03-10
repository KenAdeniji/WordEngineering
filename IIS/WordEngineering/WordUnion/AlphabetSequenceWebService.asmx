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

///<summary>
///	2015-11-05	Created.	AlphabetSequenceWebService.asmx
///	2016-05-18	InSuch()	In such; He has provided for man.
///	2016-05-29	DeEd()		I am getting ready to seventy five percent.
///	2016-05-31	TwoField()	Two field. O. J. Simpson.
/// 2017-01-13	Love fears, no more.
///	2017-06-05	Where about of God; is where about; I know.
/// 2017-12-16	IAmAfraidOfTheMark.
///	2017-12-25	YourIDOrWhatDoYouWriteYourCommonID.
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
