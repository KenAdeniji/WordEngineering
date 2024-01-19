<%@ WebService Language="C#" Class="LookingAtMeAsAReflectionOfYouWebService" %>

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data.SqlClient;
using System.Text;	

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2024-01-19T07:10:00...2024-01-19T08:16:00 Code.
///	2024-01-16 05:14:20.463	Looking at me as a reflection of you.
///	Location: On Paseo Padre Parkway overhead bridge between Blackstone Way and Siward Drive, North East, walking towards the South East. I knelt on my right knee on a black plastic bag.	
///	Commentary: At Creekwood Terrace, I stood, stopped, at the Center of the road. Divider, 2 entrances to the North, and 2 entrances to the South. How I surround myself...in fact. At the Charter Square entrance to Enea Court, between  	Taqueria El Mex-Cal and Liquor store. I have lived this love...to pass it. Mo ti pray...then I listen. I have pray...then I listen. On Paseo Padre Parkway overhead bridge between Blackstone Way and Siward Drive, North East, walking towards the South East. To accept Me...as nobody will try Me. The 3 words phrases written down on the paper and data entry, entered, into the database are separateable into 3 words and 5 words. The 1st entry, record, is for 4 lanes, roads paths into the Creekwood Terrace and there are 4 beasts, 4 kingdoms, in Daniel 7. Isaiah 53? Yesterday, 2024-01-15 you saw a vehicle with Panther written on it, pass Highway 880 North, towards. TIFF...Kowe? Computer. Must move beyond the part...to the normal. Signature verification? Yoruba alphabets distinction from English alphabets. Sun and Moon, sign? When did He get exact? As He approach? Sir Robert Anderson in his book, The Coming Prince? Prophet Daniel's accuracy.. 06:15 Whose intelligence...I use? 06:16 What did He rely on...to be the same? 06:16 What did He rely on...to be same? 06:18 With us...meeting our match?
///	http://www.robertrubin.com/the-yellow-pad
///	BibleWord,
///	FirstOccurrenceScriptureReference,
///	LastOccurrenceScriptureReference,
///	Occurrences
///	Exact.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class LookingAtMeAsAReflectionOfYouWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		string	word,
		string 	bibleVersion,
		string 	scriptureReference,
		bool	wholeWords
	)
    {
		DataTable resultTable = LookingAtMeAsAReflectionOfYou.Query
		(
			word,
		 	bibleVersion,
		 	scriptureReference,
			wholeWords
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
}
