<%@ WebService Language="C#" Class="AsideWithChristianityWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using InformationInTransit.ProcessLogic;
using InformationInTransit.ProcessCode;

///<summary>
///	2025-03-10T16:22:00...2025-03-10T17:32:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AsideWithChristianityWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	firstWord,
		String 	secondWord,
		String	thirdWord,
		String	bibleVersion
	)
    {
		return
		(
			AsideWithChristianityHelper.Query
			(
				AlphabetSequence.Id(firstWord),
				AlphabetSequence.Id(secondWord),
				AlphabetSequence.Id(thirdWord),
				bibleVersion
			)
		);	
	}
}
