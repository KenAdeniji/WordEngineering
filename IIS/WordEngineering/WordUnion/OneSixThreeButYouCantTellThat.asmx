﻿<%@ WebService Language="C#" Class="OneSixThreeButYouCantTellThat" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2017-11-24 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OneSixThreeButYouCantTellThat : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int bookID,
		int	chapterID,
		int	verseID
	)
    {
		String resultSet = (String) DataCommand.DatabaseCommand
		(
			String.Format
			(
				OneSixThreeButYouCantTellThatSelectFormat,
				bookID,
				chapterID,
				verseID
			),
			CommandType.Text,
			DataCommand.ResultType.Scalar
		);

		string json = String.Format
		(
			OneSixThreeButYouCantTellThatJsonFormat,
			resultSet
		);	

		return json;
    }
	
	public const string OneSixThreeButYouCantTellThatSelectFormat = "EXECUTE WordEngineering..usp_OneSixThreeButYouCantTellThat @bookID = {0}, @chapterID = {1}, @verseID = {2}";
	public const string OneSixThreeButYouCantTellThatJsonFormat = "{{\"scriptureReference\": \"{0}\"}}";
}
