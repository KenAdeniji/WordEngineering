<%@ WebService Language="C#" Class="BibleWord" %>

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
using InformationInTransit.UserInterface;

///<remarks>
/// 2015-05-16 BibleWord.asmx created.
///</remarks>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleWord : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Select()
    {
		/*
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"SELECT * FROM Bible..KJV",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
		*/
		

		string json = "[{\"age\": 0}]";
		return json; 

    }
}
