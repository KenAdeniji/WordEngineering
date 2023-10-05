<%@ WebService Language="C#" Class="AudioPowerWebService" %>

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using System.Text;
using System.Drawing;
using System.Linq;
using System.Collections.ObjectModel;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

/*
2013-10-27 Used MapPath(). Dino Esposito.
http://stackoverflow.com/questions/18827081/c-sharp-base64-string-to-jpeg-image
http://www.w3schools.com/html/html5_audio.asp
http://stackoverflow.com/questions/13499337/increase-post-data-size-in-jquery-javascript
*/
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AudioPowerWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string SendFileToServer
	(
		string fileContent,
		string fileName
	)
    {
		string exceptionMessage = "";
		string pathToFiles = Server.MapPath(DirectoryPath);
		
		string filePath = Path.Combine(pathToFiles, fileName);

		FileStream fs = new FileStream(filePath, FileMode.Create);

		// Construct a BinaryFormatter and use it to serialize the data to the stream.
		BinaryFormatter formatter = new BinaryFormatter();
		try 
		{
			formatter.Serialize(fs, fileContent);
		}
		catch (SerializationException ex) 
		{
			exceptionMessage = "Failed to serialize. Reason: " + ex.Message;
			throw;
		}
		catch (Exception ex) 
		{
			exceptionMessage = ex.Message;
			throw;
		}
		finally 
		{
			fs.Close();
		}			
	
		string json = JsonConvert.SerializeObject(exceptionMessage);

		return json;
    }
	
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string DirectoryListing()
    {
		string exceptionMessage = "";
		string pathToFiles = Server.MapPath(DirectoryPath);
		
		string [] fileEntries = Directory.GetFiles(pathToFiles);
		
		Collection<String> files = new Collection<String>();
		string filename;
		
		foreach(string file in fileEntries)
		{
			filename = file.Substring(file.LastIndexOf(Path.DirectorySeparatorChar) + 1);
			files.Add(filename);
		}
		
		string json = JsonConvert.SerializeObject(files);
		return json;
    }

	public const string DirectoryPath = @"UploadedFiles";
}
