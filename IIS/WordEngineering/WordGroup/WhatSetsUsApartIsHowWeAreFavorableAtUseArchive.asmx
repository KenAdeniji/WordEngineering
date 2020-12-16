 <%@ WebService Language="C#" Class="WhatSetsUsApartIsHowWeAreFavorableAtUseWebService" %>
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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

///<summary>
///	2019-06-21	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatSetsUsApartIsHowWeAreFavorableAtUseWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		String question,
		String bibleVersion
	)
    {
		String query = BibleBooksGroup.Query
		(
			question,
			bibleVersion,
			BibleBooksGroup.QueryFormat
		);
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			query,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string TitleJoin()
    {
		return BibleBooksGroup.TitleJoin();
	}
}
