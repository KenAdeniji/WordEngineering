<%@ WebService Language="C#" Class="BibleSectionWebService" %>

using System;
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

using InformationInTransit.ProcessLogic;

///<summary>
///	2018-01-12	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleSectionWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String DictionaryKeys()
    {
		String[] keys = BibleSection.DictionaryKeys();

		string json = JsonConvert.SerializeObject(keys, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String ScriptureReference
	(
		string	bibleSection,
		int		alphabetSequenceIndex
	)
    {
		String scriptureReference = BibleSection.ScriptureReference
		(
			bibleSection,
			alphabetSequenceIndex
		);
		string json = JsonConvert.SerializeObject(scriptureReference, Formatting.Indented);
		return json;
	}
}
