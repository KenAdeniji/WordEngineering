<%@ WebService Language="C#" Class="WhenItIsSoEverThatIAmWebService" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2023-09-30T21:21:00 Created. Exact table?
///	2023-09-30T18:48:00 When it is so ever...that I Am?
///		Boba Queen. 34420A Fremont Boulevard. Fremont, California (CA) 94555, walking northward. 2 lesbian females were sitting down and kissing.
///		2023-09-30T20:01:00 ... 2023-09-30T20:15:00 On Paseo Padre Parkway between Blackstone Way and Siward Drive. Select 1 FROM BibleDictionary..WordDictionary WHERE BibleWord = @BibleWord. Orange fruit seed hanging off the branch of a tree. Light blue face mask on the ground.  Walking southward. 19:34 Urine. 19:44 Urine. 20:11 Microsoft Windows operating system no response error, mouse error, keyboard error, clipboard error.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenItIsSoEverThatIAmWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string 	scriptureReference,
		string 	bibleVersion,
		string	bibleWord	
	)
    {
		DataTable resultDataTable = WhenItIsSoEverThatIAm.Query
		(
				scriptureReference,
				bibleVersion,
				bibleWord
		);
		string json = JsonConvert.SerializeObject(resultDataTable, Formatting.Indented);
		return json;
    }
}
