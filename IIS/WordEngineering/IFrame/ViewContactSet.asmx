<%@ WebService Language="C#" Class="ViewContactSetWebService" %>
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

using System.Xml;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2019-06-26	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ViewContactSetWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
	)
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"SELECT * FROM WordEngineering..ViewContactSet ORDER BY ContactID",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Newtonsoft.Json.Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Xml,XmlSerializeString=true)]
	public string RetrieveXmlString()
	{
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"SELECT * FROM WordEngineering..ViewContactSet ORDER BY ContactID",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		return dataSet.ToXml();
	}	
}
