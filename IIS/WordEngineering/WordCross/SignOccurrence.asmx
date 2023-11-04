<%@ WebService Language="C#" Class="SignOccurrenceWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

/*
		2023-11-03T08:10:00 
			Mo tun fi se border.
			I made it border, again.
			07:02 Urine. I am at 99 Ranch Market and doing wordprocessing.
				I printed some copies of my work on paper, but I will have to find my pages.
				Out of the 3 1/2 floppy disks I sought for a document storage.
				I found out that Tony of Albertsons Lucky is being carried eastward into 99 Ranch Market and he is pronounced dead.
				Joyce Sherman drove us to the intersection of Paseo Padre Parkway and Siward Drive.
				08:38 When is my work done? Buki asked father figure on the 3rd occasion for 400 to repair his vehicle. 
				08:41 Dizzy sleepy. During the night dream I remembered that 2 male siblings and fighting. 	
				SELECT 
					ScriptureReference,
					KingJamesVersion
				FROM
					Bible..Scripture_View
				WHERE
						KingJamesVersion like '%third day%'
					OR	KingJamesVersion like '%third week%'
					OR	KingJamesVersion like '%third month%'
					OR	KingJamesVersion like '%third year%'
					OR	KingJamesVersion like '%third time%'
				ORDER BY
					VerseIDSequence ASC
			DayTime? 
			09:10 SignOccurrence? 
			Some of the destination... that have witness Jewish diaspora...do not want this experience, again. convert integer to ordinal, cardinal?
*/
///<summary>
///	2023-11-04T07:22:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SignOccurrenceWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	bibleWord,
		string	bibleVersion
	)
    {
		DataTable dataTable = SignOccurrence.Query
		(
			bibleWord,
			bibleVersion
		);

		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;

    }
}
