<%@ WebService Language="C#" Class="AlfredAdenijiWebService" %>

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
///		Alfred@Adeniji
///		Albert Burton plans to travel with the family to Nigeria using the malformed email address, Alfred@Adeniji. It is missing a domain suffix. There is home renovation work to be done. Albert Burton will need native Yoruba dress, traveling document, and identity cards.
///		11:10...11:11 microsoft windows operating system hourglass. On Dyer Street between Alvarado Boulevard and Alvarado-Niles Road, East side of the road.
///	2024-02-25	As I saw a pronounced in 4 words or 8 words. I have noticed that my dreams 16:29 do not pinpoint specific scenery? Chuck Missler and McAlavany introduced me to trend analysis. Datawarehous...Data science? 16:31 Don McAlvany?
///		McAlvany.com
///	2024-02-26T19:48:00...2024-02-26T20:43:00 SQL.
///	2024-02-26T20:43:00...2024-02-26T21:19:00 Files creation: .asmx, .html
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AlfredAdenijiWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement = @"
		SELECT
			ABS
			(
				DATEDIFF
				(
					Day,
					Dated, 
					(
						LAG(Dated, 1, 0) OVER (ORDER BY HisWordID)
					)
				)
			) TimeSpanInDays,
			LAG(Dated, 1, 0) OVER (ORDER BY HisWordID) DatedFrom,
			Dated DatedUntil
		FROM		WordEngineering..HisWord
		WHERE Scene IS NOT NULL
		ORDER BY TimeSpanInDays DESC, DatedFrom DESC, DatedUntil DESC
	";	
}
