<%@ WebService Language="C#" Class="ThisIsHowIHaveDesireToUseYouWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

///<summary>
///	2023-07-13T16:53:00 ... 2023-07-13T16:58:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ThisIsHowIHaveDesireToUseYouWebService : System.Web.Services.WebService
{
/*
		2023-07-13T20:50:00 ... 2023-07-13T21:11:00 http://www.20lessons.com/
20 Lessons Book Series
By Robin Nixon


Build
real-world skills in
less than an hour for each lesson,
and follow up to five hours of video tutorials.

Learning web development is now easier than it's ever been

Top-selling author Robin Nixon has written over 30 books on computing, many of which are used as standard references in colleges and universities worldwide. Now Robin brings together his expertise in web development into a new series of titles, each of which will teach you the subject in under 20 lessons of less than an hour each, and that’s including the comprehensive online video tutorial that accompanies each lesson. All the books also come with a collection of example files so you can load them onto your own computer to try out for yourself (mouse over or click the book covers above).

Buy from Amazon and save up to 30%!

    Buy CSS & CSS3: 20 Lessons to Successful Web Development / Kindle Version
    Buy HTML5: 20 Lessons to Successful Web Development / Kindle Version
    Buy JavaScript: 20 Lessons to Successful Web Development / Kindle Version
    Buy PHP: 20 Lessons to Successful Web Development / Kindle Version

Video Tutorials

There are 20 videos per book, comprising between 4 and 5 hours of additional tutorials based around the examples in the books. Altogether there are 80 videos containing almost 20 hours of material.
*/
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String word
	)
    {
		DataTable dataTable = ThisIsHowIHaveDesireToUseYou.Query
		(
			word
		);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
}


