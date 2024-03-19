<%@ WebService Language="C#" Class="ThatIAimWebService" %>

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
///	2023-10-01T02:58:00 Created. APass.
///	Ben Forta. Forta.com. Lead and Lag. NaturalOccurringSequence.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ThatIAimWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int aPassIDBegin,
		int	aPassIDEnd,
		DateTime	datedFromBegin,
		DateTime	datedFromEnd,
		DateTime	datedIntermissionBegin,
		DateTime	datedIntermissionEnd,
		DateTime	datedUntilBegin,
		DateTime	datedUntilEnd,
		string	filenameLike,
		string	commentaryLike,
		string	scriptureReferenceLike,
		string	uriLike,
		string	contactIDsIn,
		string	hisWordIDsIn,
		bool	fromUntilFirst,
		decimal zniOet,
		bool	duplicatesOnly
	)
    {
		DataTable resultDataTable = ThatIAim.Query
		(
			aPassIDBegin,
			aPassIDEnd,
			datedFromBegin,
			datedFromEnd,
			datedIntermissionBegin,
			datedIntermissionEnd,
			datedUntilBegin,
			datedUntilEnd,
			filenameLike,
			commentaryLike,
			scriptureReferenceLike,
			uriLike,
			contactIDsIn,
			hisWordIDsIn,
			fromUntilFirst,
			zniOet,
			duplicatesOnly
		);
		string json = JsonConvert.SerializeObject(resultDataTable, Formatting.Indented);
		return json;
    }
}
