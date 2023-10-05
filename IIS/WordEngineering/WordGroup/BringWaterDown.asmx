<%@ WebService Language="C#" Class="BringWaterDownWebService" %>

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

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-09-13 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BringWaterDownWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	scriptureReference,
		String	bibleVersion,
		String	bibleUnitChapterIDOrVerseID,
		int		rowCount,
		String	topOrBottom
	)
    {
		DataTable resultTable = BringWaterDown.Query
		(
			scriptureReference,
			bibleVersion,
			bibleUnitChapterIDOrVerseID,
			rowCount,
			topOrBottom
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
	}
}

