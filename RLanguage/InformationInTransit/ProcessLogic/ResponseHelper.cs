using System;
using System.Web;
using System.Web.UI;
 
namespace InformationInTransit.ProcessLogic
{
	public static class ResponseHelper
	{
		/*
			2017-06-03	http://extensionmethod.net/1835/csharp/response/force-download-any-file
			// full path to your file
			var yourFilePath = HttpContext.Current.Request.PhysicalApplicationPath + "Files\yourFile.jpg";
			// save downloaded file as (name)
			var saveFileAs = "yourFile.jpg";
			 
			// start force download of your file
			Response.ForceDownload(yourFilePath, saveFileAs);
		*/	
		public static void ForceDownload(this HttpResponse Response, string fullPathToFile, string outputFileName)
		{
			Response.Clear();
			Response.AddHeader("content-disposition", "attachment; filename=" + outputFileName);
			Response.WriteFile(fullPathToFile);
			Response.ContentType = "";
			Response.End();
		}
	}
}

