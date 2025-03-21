﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;
using System.Text.RegularExpressions;

using System.Web;

using HtmlAgilityPack;

using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	/*
		2019-10-05	When the pastor is preaching, you don't with the scripture to come in subsequent.
					https://stackoverflow.com/questions/9552081/easiest-way-to-extract-metatags-from-downloaded-html-file
					https://stackoverflow.com/questions/124492/c-sharp-httpwebrequest-command-to-get-directory-listing
					https://stackoverflow.com/questions/799049/problem-with-c-sharp-regular-expression-for-extracting-meta-tags
	*/	
    public static partial class WhenThePastorIsPreachingYouDontWithTheScriptureToComeInSubsequent
    {
		public static void Main(String[] argv)
		{
			System.Console.WriteLine
			(
				string.Join<string>(",", CheckMetaTags(argv[0], argv[1]))
			);	
		}
		
		public static List<String> CheckMetaTags
		(
			string uri,
			string metaWord
		)
		{
			List<String> uriList = DirectoryListing(uri);
			//return uriList;
			List<String> uriFound = new List<String>();
			foreach(string uriCurrent in uriList)
			{
				Dictionary<string, string> metaInformation = 
					RetrieveFileMetaTags(uriCurrent);
				bool metaFound = false;	
				foreach(KeyValuePair<string, string> entry in metaInformation)
				{
					metaFound = StringHelper.Contains
					(
						entry.Value,
						metaWord, 
						StringComparison.InvariantCultureIgnoreCase
					);
					if (metaFound)
					{	
						uriFound.Add(uriCurrent);
						break;
					}	
				}
			}
			return uriFound;
		}
		
		public static FileInfo[] RetrieveDirectoryFiles
		(
			string 	directoryPath,
			string	fileExtension
		)
		{
			DirectoryInfo directory = new DirectoryInfo(directoryPath);
			FileInfo[] files = directory.GetFiles(fileExtension);
			return files;
		}
		
		public static Dictionary<string, string> RetrieveFileMetaTags(string uri)
		{
			WebClient wc = new WebClient();
			wc.Headers.Set("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.0.19) Gecko/2010031422 Firefox/3.0.19 ( .NET CLR 3.5.30729; .NET4.0E)");
			string html  = wc.DownloadString(uri);
			
			Regex metaTag = new Regex(RegexMetaTag);
			Dictionary<string, string> metaInformation = new Dictionary<string, string>();

			foreach(Match m in metaTag.Matches(html)) {
				metaInformation.Add(m.Groups[1].Value, m.Groups[2].Value);
			}
			
			return metaInformation;
		}	
		
		public static List<string> DirectoryListing(string uri)
		{
/*
			HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
			doc.Load(uri);
*/			
			//HtmlDocument doc = new HtmlWeb().Load(uri);

string Url = @"http://localhost/WordEngineering/TheSpanishHaveQuitResemblingNow";
HtmlWeb web = new HtmlWeb();
//uri = HttpUtility.UrlEncode(uri);
//uri = uri.Replace(@"/", @"//");
HtmlDocument doc = web.Load((uri));

			List<string> files = new List<string>();
			String fileName, filePath;
			
			Uri myUri = new Uri(uri); 
			string host = myUri.Host;
			foreach(HtmlNode link in doc.DocumentNode.SelectNodes("//a"))
			{
				//HtmlAttribute att = link["href"];
				//do something with att.Value;
				//files.Add(att.Value);
				fileName = link.GetAttributeValue("href", "");
				filePath = Path.Combine(Url, fileName);
				filePath = @"http://localhost" + fileName;
				filePath = @"http://" + host + fileName;
				if (filePath.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase))
				{	
					files.Add(filePath);
				}	
			}
			return files;
		}
		/*
		List<string> image_links = new List<string>(); foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//img")) { image_links.Add( link.GetAttributeValue("src", "") ); }
		*/
		
		public static string[] RetrieveFiles(string url)
		{
			List<string> files = new List<string>(500);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{
				using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					string html = reader.ReadToEnd();

					Regex regex = new Regex("<a href=\".*\">(?<name>.*)</a>");
					MatchCollection matches = regex.Matches(html);

					if (matches.Count > 0)
					{
						foreach (Match match in matches)
						{
							if (match.Success)
							{
								string[] matchData = match.Groups[0].ToString().Split('\"');
								files.Add(matchData[1]);
							}
						}
					}
				}
			}
			return files.ToArray();
		}		
                                                               		
		public const string RegexMetaTag = @"<meta[\s]+[^>]*?name[\s]?=[\s""']+(.*?)[\s""']+content[\s]?=[\s""']+(.*?)[""']+.*?>";
    }
}

