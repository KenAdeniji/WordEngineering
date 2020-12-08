<%@ WebService Language="C#" Class="DirectoryListing" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2016-11-17 	Created. DirectoryListing.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DirectoryListing : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	directory,
		string	fileExtension
	)
    {
		if (string.IsNullOrEmpty(directory))
		{
			directory = @"E:\WordEngineering\IIS\WordEngineering\WordUnion";
		}

		string[] resultSet = FileHelper.FindFiles
		(
			directory,
			fileExtension,
			System.IO.SearchOption.TopDirectoryOnly
		);
		
		for(int i = 0; i < resultSet.Length; i++)
		{
			resultSet[i] = Path.GetFileName(resultSet[i]);
		}	
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
}
