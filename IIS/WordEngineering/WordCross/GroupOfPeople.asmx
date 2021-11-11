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

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;

///<summary>
///	2021-11-10T18:18:00 Created. https://docs.microsoft.com/en-us/powershell/scripting/learn/tutorials/01-discover-powershell?view=powershell-7.2#powershell-cmdlets
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
	)
    {
		string json = JsonConvert.SerializeObject(new GroupOfPeople.Apostle(), Formatting.Indented);
		return json;
    }
}
