using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

using HtmlAgilityPack;

namespace InformationInTransit.ProcessLogic
{
	/*
		2018-01-24	Created.
		2018-01-24	http://www.4guysfromrolla.com/articles/011211-1.aspx
		2018-01-24	http://msdn.microsoft.com/en-us/library/way3dy9w.aspx?f=255&MSPPError=-2147217396
	*/
	public class HeFinallyShowedItToMe
	{
		public static void Main(string[] argv)
		{
			ParseHTMLDocument
			(
				"",
				"a"
			);
		}
		
        public static DataSet ParseHTMLDocument
		(
			string 	sqlUri,
			string	nodeName
		)
        {
			string url = !String.IsNullOrEmpty(sqlUri) ? sqlUri : UriHtml;
			
			var web = new HtmlWeb();
			var document = web.Load(url);

			nodeName = nodeName.Trim().ToLower();
			
			/*
			if (metaTags != null)
			{
			   foreach (var tag in metaTags)
			   {
					if (tag.Attributes["name"] != null && tag.Attributes["content"] != null)
					{
						System.Console.WriteLine
						(
							"Name: {0} Content: {1}",
							tag.Attributes["name"].Value,
							tag.Attributes["content"].Value
						);	
					}
			   }
			}
			
			var linksOnPage = from lnks in document.DocumentNode.Descendants()
                  where lnks.Name == nodeName &&
                       lnks.Attributes["href"] != null &&
                       lnks.InnerText.Trim().Length > 0
                  select new
                  {
                     Url = lnks.Attributes["href"].Value,
                     Text = lnks.InnerText
                  }; 

			if (linksOnPage != null)
			{
			   foreach (var anchor in linksOnPage)
			   {
					if (anchor.Url != null && anchor.Text != null)
					{
						System.Console.WriteLine
						(
							"Url: {0} Text: {1}",
							anchor.Url,
							anchor.Text
						);	
					}
			   }
			}
			*/

			DataTable dataTable = new DataTable();
			
/*
			switch (nodeName)
			{
				case "a":
					var anchors = from nodes in document.DocumentNode.Descendants()
					where  nodes.Name == nodeName
					select new
					{
						Url = nodes.Attributes["href"].Value,
						Text = nodes.InnerText
					}; 
					dataTable = anchors.CopyToDataTable();
					break;
				case "abbr":
				case "acronym":
					var abbr = from nodes in document.DocumentNode.Descendants()
					where  nodes.Name == nodeName
					select new
					{
						Title = nodes.Attributes["title"].Value,
						Text = nodes.InnerText
					}; 
					dataTable = abbr.CopyToDataTable();
					break;
				case "img":
					var images = from nodes in document.DocumentNode.Descendants()
					where  nodes.Name == nodeName
					select new
					{
						Source = nodes.Attributes["src"].Value
					}; 
					dataTable = images.CopyToDataTable();
					break;
				case "meta":
					var metas = from nodes in document.DocumentNode.Descendants()
					where  nodes.Name == nodeName &&
                       nodes.Attributes["name"] != null &&
                       nodes.Attributes["content"] != null 
					select new
					{
						Name = nodes.Attributes["name"].Value,
						Content = nodes.Attributes["content"].Value
					}; 
					dataTable = metas.CopyToDataTable();
					break;	
				case "title":
					var title = from nodes in document.DocumentNode.Descendants()
					where  nodes.Name == nodeName
					select new
					{
						Text = nodes.InnerText
					}; 
					dataTable = title.CopyToDataTable();
					break;
			}	
*/			
			DataSet dataSet = new DataSet();
			dataSet.Tables.Add(dataTable);
			
			return dataSet;
        }
	
        public static string SQLQuery
		(
			string sqlUri
		)
        {
			string url = !String.IsNullOrEmpty(sqlUri) ? sqlUri : UriHtml;

			DataSet dataSet = new DataSet();
			//dataSet.ReadXml(url);
			
			//DataTable dataTable = dataSet.Tables[0];

			// Presuming the DataTable has a column named Date.
			string expression = "_blank = '_new'";
			// string expression = "OrderQuantity = 2 and OrderID = 2";

			// Sort descending by column named CompanyName.
			string sortOrder = "href ASC";
			DataRow[] foundRows;

			// Use the Select method to find all rows matching the filter.
			//foundRows = dataTable.Select(expression, sortOrder);
	  
			return url;
        }

		public const string UriHtml = "http://localhost/WordEngineering/WordUnion/2015-10-23DoctoralDissertation.html";
	}
}
