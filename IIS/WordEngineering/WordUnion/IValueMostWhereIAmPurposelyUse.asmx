<%@ WebService Language="C#" Class="IValueMostWhereIAmPurposelyUseWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2015-07-30 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IValueMostWhereIAmPurposelyUseWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int	bookIDMinimum,
		int	bookIDMaximum,
		int	chapterMinimum,
		int	chapterMaximum
	)
    {
		DataSet resultSet = IValueMostWhereIAmPurposelyUse.Query
		(
			bookIDMinimum,
			bookIDMaximum,
			chapterMinimum,
			chapterMaximum
		);
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
}
