<%@ WebService Language="C#" Class="WhenThePastorIsPreachingYouDontWithTheScriptureToComeInSubsequentWebService" %>

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

using System.Web.Script.Serialization;

using System.IO;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;

///<summary>
///	2019-10-05 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenThePastorIsPreachingYouDontWithTheScriptureToComeInSubsequentWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string uri,
		string metaWord
	)
    {
		String ServerMapPath = HttpContext.Current.Server.MapPath("~/"); 
		if ( ServerMapPath != null)
		{
			//uri = Path.Combine( ServerMapPath, uri );
		}

		List<String> resultSet = WhenThePastorIsPreachingYouDontWithTheScriptureToComeInSubsequent.CheckMetaTags
		(
			uri,
			metaWord
		);
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
	}
}
