<%@ WebService Language="C#" Class="IWillTakeThemUpForTakingMyDelayWebService" %>
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

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;

///<summary>
/// 2018-09-25	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IWillTakeThemUpForTakingMyDelayWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String scriptureReference
	)
    {
		return
		(
			IWillTakeThemUpForTakingMyDelay.Query(scriptureReference)
		);	
    }
}
