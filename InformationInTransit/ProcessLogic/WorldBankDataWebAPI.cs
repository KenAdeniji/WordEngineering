using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.IO;
using System.Net;
//using System.Net.Http;
using System.Text;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Windows.Markup;
using System.Xml.Serialization;

//using InformationInTransit.ProcessLogic;

///<summary>
/// Sample download list of countries from the World Bank Data sources at http://data.worldbank.org/
///	csc WorldBankDataWebAPI.cs /reference:System.Net.Http.dll
/// </summary>
class WorldBankDataWebAPI
{
	static string _address = "http://api.worldbank.org/countries?format=json";
	static string _addressXml = "http://api.worldbank.org/countries?format=xml";
	static void Main(string[] args)
	{
		LoadCountries();
	}
	
	public static void LoadCountries()
	{
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(_addressXml);
		DataTable dataTable = dataSet.Tables[1];
	}
	
	public static object FromJson<T>(string json) where T : class
	{
		MemoryStream ms = null;
		DataContractJsonSerializer ser;
		object obj; 
		try
		{
			ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
			ser = new DataContractJsonSerializer(typeof(T));
			obj = ser.ReadObject(ms) as T;
		}
		finally
		{
			ms.Close();
			ms.Dispose();
		}
		return obj;
	} 

	public static List<Country> RetrieveCountries() 
	{
        using (WebClient client = new WebClient()) {

			var result = client.DownloadString(_address);

			//System.Console.WriteLine(result);
			
			int index = result.IndexOf("id");
			
			var subset = result.Substring(index - 3);
			
			subset = "{\"country\":" + subset + "}";

			System.Console.WriteLine(subset);
			
			//CountryModel rootObject = (CountryModel) SerializationHelper.FromJson<CountryModel>(result);
			//CountryModel rootObject = (CountryModel) FromJson<CountryModel>(result);
			//Country rootObject = (Country) FromJson<Country>(subset);
			
			List<Country> resultCountries = null;
			
			try
			{
				resultCountries = (List<Country>) FromJson<Country>(subset);
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			foreach(Country country in resultCountries)
			{
				System.Console.WriteLine(country);
			}	
			return resultCountries;
        }
    }

	static void UsingWebRequest()
	{
		Uri ourUri = new Uri(_address);            

		// Create a 'WebRequest' object with the specified url. 
		WebRequest myWebRequest = WebRequest.Create(_address); 

		// Send the 'WebRequest' and wait for response.
		WebResponse myWebResponse = myWebRequest.GetResponse(); 
		
		// Obtain a 'Stream' object associated with the response object.
	Stream ReceiveStream = myWebResponse.GetResponseStream();
	        	
	Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

        // Pipe the stream to a higher level stream reader with the required encoding format. 
	 StreamReader readStream = new StreamReader( ReceiveStream, encode );
	 Console.WriteLine("\nResponse stream received");
	 Char[] read = new Char[256];

        // Read 256 charcters at a time.     
	 int count = readStream.Read( read, 0, 256 );
        Console.WriteLine("HTML...\r\n");

	while (count > 0) 
	{
    	    // Dump the 256 characters on a string and display the string onto the console.
	    String str = new String(read, 0, count);
	    Console.Write(str);
	    count = readStream.Read(read, 0, 256);
	}

       Console.WriteLine("");
     // Release the resources of stream object.
     readStream.Close();

     // Release the resources of response object.
     myWebResponse.Close(); 
	}
	
	/*
	static void UsingHttpClient()
	{
		// Create an HttpClient instance
        HttpClient client = new HttpClient();
        // Send a request asynchronously continue when complete
		client.GetAsync(_address).ContinueWith(
			(requestTask) =>
		{
		// Get HTTP response from completed task.
		HttpResponseMessage response = requestTask.Result;
		// Check that response was successful or throw exception
		response.EnsureSuccessStatusCode();
		// Read response asynchronously as JsonValue and write out top facts for each country
		response.Content.ReadAsAsync<JsonArray>().ContinueWith(
		(readTask) =>
		{
			Console.WriteLine("First 50 countries listed by The World Bank...");
			foreach (var country in readTask.Result[1])
			{
				Console.WriteLine("   {0}, Country Code: {1}, Capital: {2}, Latitude: {3}, Longitude: {4}",
					country.Value["name"],
					country.Value["iso2Code"],
					country.Value["capitalCity"],
					country.Value["latitude"],
					country.Value["longitude"]);
			}
		});
	});

	Console.WriteLine("Hit ENTER to exit...");
	Console.ReadLine();
	}
	*/
	
    public class CountryModel
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }

        public List<Country> Countries { get; set; }
    }

    [DataContractAttribute]
	public class Country
    {
        public string Id { get; set; }
        public string Iso2Code { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
    }

    public class Region
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
