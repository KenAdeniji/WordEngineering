using System;
using System.Net;
namespace Microsoft.Samples.BingSearch
{
	class Program
	{
		static void Main(string[] args)
		{
			// This is the query - or you could get it from args.
			string query = "Xbox Live";
			// Create a Bing container.
			string rootUri = "https://api.datamarket.azure.com/Bing/Search";
			var bingContainer = new Bing.BingSearchContainer(new Uri(rootUri));
			// Replace this value with your account key.
			var accountKey = "0635D7FCDC7EEF370678CA58B4D1F4CB9E03898E";
			// Configure bingContainer to use your credentials.
			bingContainer.Credentials = new NetworkCredential(accountKey, accountKey);
			// Build the query.
			var imageQuery = bingContainer.Image(query, null, null, null, null, null, null);
			var imageResults = imageQuery.Execute();
			foreach (var result in imageResults)
			{
				Console.WriteLine(result.Title);
			}
		}
	}
}
 
