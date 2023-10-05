<%@ WebService Language="C#" Class="LivesOnWordWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

using System.IO;
using System.Net;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2017-11-30 	Created.
///	2017-11-30	https://davidwalsh.name/fakepath
///	https://msdn.microsoft.com/en-us/library/system.io.path.changeextension%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class LivesOnWordWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Request
	(
		string	format,
		string	description,
		string	filename,
		string	fileContents,
		bool	ftpInformation,
		string	ftpDirectory,
		string	ftpFilename,
		string	ftpUsername,
		string	ftpPassword
	)
    {
		String exceptionMessage = "";
		String feedback = "";
		String ftpPath = "";
		String randomFilename = "";
		
		if (format != "File Upload")
		{
			fileContents = description;
		}
		
		if (String.IsNullOrEmpty(filename))
		{
			randomFilename = Path.GetRandomFileName();
			filename = Path.ChangeExtension(randomFilename, format);
		}
		
		feedback = filename;
		
		try
		{
			// Get the object used to communicate with the server.
			filename = filename.Replace("C:\\fakepath\\", "");

			ftpPath = FTPDefaultDirectory + filename;
			
			if 
			(
				ftpInformation &&
				!String.IsNullOrEmpty(ftpDirectory) &&
				!String.IsNullOrEmpty(ftpFilename)
			)
			{
				char lastCharacter = ftpDirectory.Substring(ftpDirectory.Length - 1)[0];

				ftpDirectory = ftpDirectory + 
					(
						(
							lastCharacter == Path.DirectorySeparatorChar || 
							lastCharacter == Path.AltDirectorySeparatorChar
						) 
						? "" : Char.ToString(Path.AltDirectorySeparatorChar)
					);
			
				ftpPath = ftpDirectory + ftpFilename;
			}
			
			feedback = String.Format
			(
				FTPPathAnchor,
				ftpPath
			);	
			
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create
			(
				ftpPath
			);
			
			request.Method = WebRequestMethods.Ftp.UploadFile;

			// This example assumes the FTP site uses anonymous logon.
			if 
			(
				ftpInformation &&
				!String.IsNullOrEmpty(ftpUsername) &&
				!String.IsNullOrEmpty(ftpPassword)
			)
			{
				request.Credentials = new NetworkCredential
				(
					ftpUsername,
					ftpPassword
				);
			}
			
			// Copy the contents of the file to the request stream.
			/*
			StreamReader sourceStream = new StreamReader(fileUpload);
			byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
			sourceStream.Close();
			request.ContentLength = fileContents.Length;
			*/
			
			Stream requestStream = request.GetRequestStream();
			
			ASCIIEncoding encoding = new ASCIIEncoding ();
			byte[] byteData = encoding.GetBytes(fileContents);
			
			requestStream.Write(byteData, 0, fileContents.Length);
			requestStream.Close();

			FtpWebResponse response = (FtpWebResponse)request.GetResponse();

			Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

			response.Close();	
		}
		catch (Exception ex)
		{
			exceptionMessage = ex.Message;
			feedback = exceptionMessage;
		}
		
		string json = JsonConvert.SerializeObject(feedback, Formatting.Indented);
		return json;
    }
	
	public const string FTPDefaultDirectory = @"ftp://e-comfort.ephraimtech.com/LivesOnWord/";
	public const string FTPPathAnchor = @"<a href='{0}' target='_blank'>{0}</s>";
}
