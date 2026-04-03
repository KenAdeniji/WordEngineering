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
		switch (alphabetSequenceIndexPosition)
		{
			case "Index":
				int id = Int32.Parse(word);
				string scriptureReference = AlphabetSequence.ScriptureReference(id);
				json = String.Format
				(
					JsonFormat,
					id,
					scriptureReference
				);
				break;
		}
		return json;
	}

	public const string JsonFormat = "{{\"id\": {0}, \"scriptureReference\": \"{1}\"}}";
}
