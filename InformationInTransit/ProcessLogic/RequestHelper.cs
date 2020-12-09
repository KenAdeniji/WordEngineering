using System;
using System.IO;
using System.Net;

namespace InformationInTransit.ProcessLogic
{
	public static partial class RequestHelper
	{
		///<summary>
		/// 2014-04-02 http://codekeep.net/snippets/af2f92fc-5f28-4910-a570-ba35c00e0f17.aspx
		///</summary>
		public static string RetrieveCurrentPageName()
		{
			string path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
			string filename = fileInfo.Name;
			return filename;
		}
	}
}
