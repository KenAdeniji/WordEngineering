using System;
using System.IO;
using System.Net;
using System.Text;

///<summary>
///	csc FileTransferProtocolFTPHelper.cs
/// </summary>
namespace InformationInTransit.ProcessLogic
{
	class FileTransferProtocolFTPHelper
	{
		static void Main(string[] args)
		{
			FtpDirectoryList
			(
				"ftp://localhost",
				"anonymous",
				"janeDoe@contoso.com"
			);
		
			FtpDownloadFile
			(
				"ftp://localhost/DEBUG.TXT",
				"anonymous",
				"janeDoe@contoso.com"
			);

			FtpUploadFile
			(
				"ftp://localhost/DEBUG.TXT",
				"anonymous",
				"janeDoe@contoso.com"
			);
			
			long fileSize = FtpGetFileSize
			(
				"ftp://localhost/DEBUG.TXT",
				"anonymous",
				"janeDoe@contoso.com"
			);
			System.Console.WriteLine(fileSize);	
			
			DateTime fileTimestamp = FtpGetFileTimestamp
			(
				"ftp://localhost/DEBUG.TXT",
				"anonymous",
				"janeDoe@contoso.com"
			);
			System.Console.WriteLine(fileTimestamp);
		}
		
		///<remarks>
		///https://msdn.microsoft.com/en-us/library/ms229716%28v=vs.110%29.aspx
		///</remarks>
		public static void FtpDirectoryList
		(
			string uri,
			string user_name,
			string password
		)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential (user_name, password);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);
    
            reader.Close();
            response.Close();
        }		

		public static void FtpDownloadFile
		(
			string uri,
			string user_name,
			string password
		)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
            
            // Copy the contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader("FileTransferProtocolFTPHelper.cs");
            byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
    
            response.Close();
        }
		
		///<remarks>
		///https://msdn.microsoft.com/en-us/library/ms229715%28v=vs.110%29.aspx
		///</remarks>
		public static void FtpUploadFile
		(
			string uri,
			string user_name,
			string password
		)
        {
			// Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
            
            // Copy the contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader("FileTransferProtocolFTPHelper.cs");
            byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
    
            response.Close();
         }
		
		///<remarks>
		///http://csharphelper.com/blog/2015/01/get-file-size-and-last-modification-time-on-an-ftp-server-in-c/
		///</remarks>
		public static long FtpGetFileSize
		(
			string uri,
			string user_name,
			string password
		)
		{
			// Get the object used to communicate with the server.
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
			request.Method = WebRequestMethods.Ftp.GetFileSize;

			// Get network credentials.
			request.Credentials = new NetworkCredential(user_name, password);

			try
			{
				using (FtpWebResponse response =
					(FtpWebResponse)request.GetResponse())
				{
					// Return the size.
					return response.ContentLength;
				}
			}
			catch (Exception ex)
			{
				// If the file doesn't exist, return -1.
				// Otherwise rethrow the error.
				if (ex.Message.Contains("File unavailable")) return -1;
				throw;
			}
		}		

		///<remarks>
		///http://csharphelper.com/blog/2015/01/get-file-size-and-last-modification-time-on-an-ftp-server-in-c/
		///</remarks>
		public static DateTime FtpGetFileTimestamp
		(
			string uri,
			string user_name,
			string password
		)
		{
			// Get the object used to communicate with the server.
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
			request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

			// Get network credentials.
			request.Credentials = new NetworkCredential(user_name, password);

			try
			{
				using (FtpWebResponse response =
					(FtpWebResponse)request.GetResponse())
				{
					// Return the last modified.
					return response.LastModified;
				}
			}
			catch (Exception ex)
			{
				// If the file doesn't exist, return 3000-01-01.
				// Otherwise rethrow the error.
				if (ex.Message.Contains("File unavailable")) return new DateTime(3000, 1, 1);
				throw;
			}
		}
	}
}
