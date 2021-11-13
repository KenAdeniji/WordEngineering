<%@ WebService Language="C#" Class="GroupOfPeopleWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Reflection;
using System.Runtime.Remoting;

using Newtonsoft.Json;

using InformationInTransit.ProcessLogic;
using InformationInTransit.ProcessCode;

///<summary>
///	2021-11-10T18:18:00 Created. https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly.createinstance?view=net-5.0
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class GroupOfPeopleWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string typeName
	)
    {
/*	
		ObjectHandle handle = Activator.CreateInstance("InformationInTransit", "ProcessCode.GroupOfPeople." + typeName);
		dynamic groupOfPeople = handle.Unwrap();
		string json = JsonConvert.SerializeObject
		(
			groupOfPeople,
			Formatting.Indented
		);
		return json;
*/		
/*
		Assembly assem = typeof(GroupOfPeople).Assembly;
		dynamic groupOfPeople = assem.CreateInstance("InformationInTransit.ProcessCode.GroupOfPeople." + typeName);
		string json = JsonConvert.SerializeObject
		(
			groupOfPeople,
			Formatting.Indented
		);
		return json;
*/
		dynamic groupOfPeople = TypeHelper.Instantiate(typeName);
		string json = JsonConvert.SerializeObject
		(
			groupOfPeople,
			Formatting.Indented
		);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryApostle
	(
	)
    {
		string json = JsonConvert.SerializeObject(new GroupOfPeople.Apostle(), Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryChildOfJacob
	(
	)
    {
		string json = JsonConvert.SerializeObject(new GroupOfPeople.ChildOfJacob(), Formatting.Indented);
		return json;
    }
}
