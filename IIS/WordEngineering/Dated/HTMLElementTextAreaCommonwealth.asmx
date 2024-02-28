<%@ WebService Language="C#" Class="HTMLElementTextAreaCommonwealthWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	http://www.dk.com/us/book/9781465451774-dk-eyewitness-books-judaism
///	2024-02-28T07:30:00...2024-02-28T07:30:00 
///		I am getting informed of the procedure of seeking employment.
///		I was notified that the prospective employee has to build a webpage that may include using a textarea HTML element.
///		Being a member of the Commonwealth of Nations 01:56 may add to your employment chance.
///		Epoch timestamp: 1709078400 
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HTMLElementTextAreaCommonwealthWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement = @"
SELECT 
	RememberID,
	DatedFrom,
	DatedUntil,
	FromUntil
FROM
	WordEngineering..Remember_View
JOIN
	WordEngineering..ActToGod ON FromUntil = Minor
WHERE
	Major = 'HTMLElementTextArea-Commonwealth'
ORDER BY
	RememberID DESC
	";	
}
