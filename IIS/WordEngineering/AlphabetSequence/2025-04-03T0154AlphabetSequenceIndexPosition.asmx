<%@ WebService Language="C#" Class="AlphabetSequenceIndexPositionWebService" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

/*
	2026-04-03T03:46:00 int id = Int32.Parse(word);
*/
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AlphabetSequenceIndexPositionWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string 	word,
		string	alphabetSequenceIndexPosition
	)
    {
		string json = "";
		string scriptureReference = "";
		switch (alphabetSequenceIndexPosition)
		{
			case "Index":
				int id = Int32.Parse(word);
				scriptureReference = AlphabetSequence.ScriptureReference(id);
				json = String.Format
				(
					JsonFormat,
					id,
					scriptureReference
				);
				break;
			case "Verse forward":
				dynamic verseIdSequenceForward = DataCommand.DatabaseCommand
				(
					String.Format
					(
						@"
							SELECT VerseIDSequence
							FROM Bible..Scripture_View
							WHERE ScriptureReference = '{0}'
						",
						word
					),
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				scriptureReference = AlphabetSequence.ScriptureReference(verseIdSequenceForward);
				json = String.Format
				(
					JsonFormat,
					verseIdSequenceForward,
					scriptureReference
				);
				break;
			case "Verse backward":
				dynamic verseIdSequenceBackward = DataCommand.DatabaseCommand
				(
					String.Format
					(
						@"
							SELECT VerseIDSequence
							FROM Bible..Scripture_View
							WHERE ScriptureReference = '{0}'
						",
						word
					),
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				scriptureReference = AlphabetSequence.ScriptureReference(31103 - verseIdSequenceBackward);
				json = String.Format
				(
					JsonFormat,
					verseIdSequenceBackward,
					scriptureReference
				);
				break;
			case "Chapter forward":
				dynamic chapterIdSequenceForward = DataCommand.DatabaseCommand
				(
					String.Format
					(
						@"
							SELECT TOP 1 ChapterIDSequence
							FROM Bible..Scripture_View
							WHERE ScriptureReference LIKE '{0}:%'
						",
						word
					),
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				scriptureReference = AlphabetSequence.ScriptureReference(chapterIdSequenceForward);
				json = String.Format
				(
					JsonFormat,
					chapterIdSequenceForward,
					scriptureReference
				);
				break;
			case "Chapter backward":
				dynamic chapterIdSequenceBackward = DataCommand.DatabaseCommand
				(
					String.Format
					(
						@"
							SELECT TOP 1 ChapterIDSequence
							FROM Bible..Scripture_View
							WHERE ScriptureReference LIKE '{0}:%'
						",
						word
					),
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				scriptureReference = AlphabetSequence.ScriptureReference(1189 - chapterIdSequenceBackward);
				json = String.Format
				(
					JsonFormat,
					chapterIdSequenceBackward,
					scriptureReference
				);
				break;
		}
		return json;
	}

	public const string JsonFormat = "{{\"id\": {0}, \"scriptureReference\": \"{1}\"}}";
}
