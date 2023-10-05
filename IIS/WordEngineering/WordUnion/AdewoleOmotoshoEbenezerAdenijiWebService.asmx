<%@ WebService Language="C#" Class="AdewoleOmotoshoEbenezerAdenijiWebService" %>
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

///<summary>
///	2016-03-12	Created.	AdewoleOmotoshoEbenezerAdenijiWebService.asmx
///	2019-06-02	WordEngineering..usp_AdewoleOmotoshoEbenezerAdenijiRecursiveCommonTableExpression	EssentialSQL.com/recursive-ctes-explained
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AdewoleOmotoshoEbenezerAdenijiWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String FamilyTree()
    {
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_AdewoleOmotoshoEbenezerAdenijiRecursiveCommonTableExpression" ,
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String FamilyTreeView()
    {
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			"WordEngineering..AdewoleOmotoshoEbenezerAdeniji_View ORDER BY parent, id" ,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
}
