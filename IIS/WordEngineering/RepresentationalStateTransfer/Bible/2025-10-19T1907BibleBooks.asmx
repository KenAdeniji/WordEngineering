<%@ WebService Language="C#" Class="BibleBooksWebService" %>

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
//using System.Web.Script.Serialization;

//using System.Text.Json;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2025-10-19T19:07:00 Created. http://stackoverflow.com/questions/9726486/convert-asmx-c-sharp-web-service-to-rest
///		answered Nov 23, 2018 at 11:24
///		Serhat Oz's user avatar
///		Serhat Oz
///		79888 silver badges13
///	2025-10-18	http://www.abibliadigital.com.br
///		Brazilian Márcio Vinícius Sena omarciovsena · he/him ?? CTO e Dir. de Comunidades @impulso_team. Escrevo p/ profissionais tech e Falo com CTOs e Tech Leaders no Hi Tech Podcast 428 followers · 28 following  Impulso Anápolis, Goiás contato@marciosena.com.br https://beacons.ai/omarciovsena @omarciovsena
///	2025-10-19	github.com/Kikobeats/awesome-api
/// 	Kiko Beats Kikobeats Software writer. 1.6k followers · 196 following @microlinkhq Murcia, Spain josefrancisco.verdu@gmail.com https://kikobeats.com @Kikobeats
///	2025-10-19	vinaysahni.com/best-practices-for-a-pragmatic-restful-api
///		Vinay Sahni Full stack developer  ·  Co-Founder of Enchant vinay@sahni.org  ·  @veesahni Best Practices for Designing a Pragmatic RESTful API
///	2025-10-19T19:31:00	When one loves God... that is made in Him.
///	2025-10-19T19:59:00	What is necessary the same.
///		1st tablet, intake. During my Master's degree, the 3 Amigos did the work.
///	2025-10-19T20:00:00	How to do it I know... how you will do it... is what I want to know?
///		http://localhost/wordengineering/Representational%20State%20Transfer%20(REST)/Bible/2025-10-19T1907BibleBooks.asmx/getBibleBooks
///	2025-10-20T10:07:00 For either a sacred text title or scripture reference, determine the other information?
///	2025-10-22T10:44:00	http://github.com/omarciovsena/abibliadigital/blob/master/DOCUMENTATION.md
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleBooksWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
	public String getBibleBooks
	(
		string bookID
	)
    {
		string sqlStatement = "";
		int bookNumber = -1;
		bool bookIDs = int.TryParse(bookID, out bookNumber);
		if (bookID == "")
		{
			sqlStatement = "SELECT DISTINCT BookID, BookTitle FROM Bible..Scripture_View ORDER BY BookID";
		}
		else if (bookNumber == -1)
		{
			sqlStatement = String.Format
			(
				@"
					SELECT TOP 1 BookID, BookTitle
					FROM Bible..Scripture_View
					WHERE BookID = {0}
				",
				bookID
			);
		}
		else
		{
			sqlStatement = String.Format
			(
				@"
					SELECT DISTINCT BookID, BookTitle
					FROM Bible..Scripture_View
					WHERE BookID IN ({0})
				",
				bookID
			);
		}

		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;

/*		
		JavaScriptSerializer serializer = new JavaScriptSerializer();
		Context.Response.Clear();
        Context.Response.ContentType = "application/json";
		string jsonString = serializer.Serialize(dataTable);
        Context.Response.Write(jsonString);
*/
		/*	
		string jsonString = JsonSerializer.Serialize(dataTable);
		Context.Response.Write(jsonString);	
		*/
    }
}
