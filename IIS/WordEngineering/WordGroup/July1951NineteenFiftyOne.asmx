<%@ WebService Language="C#" Class="July1951NineteenFiftyOne" %>

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

using System.Linq;
using System.Linq.Dynamic;

using Newtonsoft.Json;

using InformationInTransit.ProcessLogic;

///<summary>
///	2019-04-18	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class July1951NineteenFiftyOne : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int		bookIDMinimum,
		int		bookIDMaximum,
		string	bookTitle,
		string	sortBy,
		string	sortDirection
	)
    {
		List<BibleBook> dataSet = 
			(
				from BibleBook bibleBook in BibleBook.BibleBooks
				where 
					bibleBook.Id >= bookIDMinimum && 
					bibleBook.Id <= bookIDMaximum &&
					bibleBook.Title.IndexOf(bookTitle, StringComparison.InvariantCultureIgnoreCase) > -1
				select bibleBook
			).ToList();
			
		dataSet = dataSet.OrderBy(sortBy + " " + sortDirection).ToList();	
			
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
