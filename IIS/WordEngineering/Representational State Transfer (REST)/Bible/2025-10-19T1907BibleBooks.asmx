<%@ WebService Language="C#" Class="BibleBooksWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2025-10-19T19:07:00 Created. http://stackoverflow.com/questions/9726486/convert-asmx-c-sharp-web-service-to-rest
///		answered Nov 23, 2018 at 11:24
///		Serhat Oz's user avatar
///		Serhat Oz
///		79888 silver badges13
///	2025-10-19T19:31:00	When one loves God... that is made in Him.
///	2025-10-19T19:59:00	What is necessary the same.
///		1st tablet, intake. During my Master's degree, the 3 Amigos did the work.
///	2025-10-19T20:00:00	How to do it I know... how you will do it... is what I want to know?
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleBooksWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
	public void getBibleBooks()
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			@"
				SELECT DISTINCT BookID, BookTitle
				FROM Bible..Scripture_View
				ORDER BY BookID
			",
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		Context.Response.Write(json);
    }
}
