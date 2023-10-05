<%@ WebHandler Language="C#" Class="ViewContactSetHandler" %>
using System;
using System.Web;

using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

/*
	2019-07-03	https://stackoverflow.com/questions/4356275/return-flat-text-from-net-webservice
*/	
public class ViewContactSetHandler : IHttpHandler 
{
    public void ProcessRequest(HttpContext context) 
    {
        context.Response.ContentType = "text/plain";
		
        //context.Response.Write("some plain text");
		context.Response.Write(Query());
    }

	public static string Query()
	{
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			"SELECT * FROM WordEngineering..ViewContactSet ORDER BY ContactID",
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string result = "";
		
		/*
		result = string.Join
		(
			System.Environment.NewLine,
			CommaSeparatedValueCSVHelper.ToCsvRows(dataTable).ToArray() 
		);
		*/
		
		result = DataTableExtensionMethods.WriteToCsvFile(dataTable);

		return result;
	}

    public bool IsReusable 
    {
        get { return true; }
    }
}
