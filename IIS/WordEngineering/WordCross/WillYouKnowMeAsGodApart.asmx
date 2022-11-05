<%@ WebService Language="C#" Class="WillYouKnowMeAsGodApartWebService" %>
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

using System.Text;

using System.Linq;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.ProcessLogic;

///<summary>
///		2022-11-05T05:45:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WillYouKnowMeAsGodApartWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		String word
	)
    {
		DataTable DataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(SelectQuery, word),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(DataTable, Formatting.Indented);
		return json;
	}
	
	String SelectQuery = 
	@" 
		SELECT IHaveDecidedToWorkOnAGradualImprovingSystem..vw_ContactsList.Dated AS Dated, 
		NicknameOrFullname, OrganizationName, StreetAddressJoin, PhoneNumberConcatenate, Note
		FROM IHaveDecidedToWorkOnAGradualImprovingSystem..vw_ContactsList
		WHERE 
			NicknameOrFullname LIKE '%{0}%'
		OR	OrganizationName LIKE '%{0}%'
		OR	StreetAddressJoin LIKE '%{0}%'
		OR	PhoneNumberConcatenate LIKE '%{0}%'
		OR	Note LIKE '%{0}%'
		ORDER BY
			Dated, NicknameOrFullname, OrganizationName, StreetAddressJoin, PhoneNumberConcatenate, Note
	";
}
