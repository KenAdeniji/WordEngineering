/*
	2014-01-20 http://msdn.microsoft.com/en-us/library/ee890485%28v=vs.110%29.aspx
	2014-01-20 http://archive.msdn.microsoft.com/nclsamples/Wiki/View.aspx?title=FTP%20Client
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;

namespace InformationInTransit.ProcessLogic
{
    public static partial class FtpHelper
    {
        public static void Download(string downloadUrl)
        {
            Stream responseStream = null;
            FileStream fileStream = null;
			StreamReader reader = null;
			try
			{
				FtpWebRequest downloadRequest =
					(FtpWebRequest)WebRequest.Create(downloadUrl);
				FtpWebResponse downloadResponse =
					(FtpWebResponse)downloadRequest.GetResponse();
				responseStream = downloadResponse.GetResponseStream();

				string fileName =
					Path.GetFileName(downloadRequest.RequestUri.AbsolutePath);

				if (fileName.Length == 0)
				{
					reader = new StreamReader(responseStream);
					Console.WriteLine(reader.ReadToEnd());
				}
				else
				{
					fileStream = File.Create(fileName);
					byte[] buffer = new byte[1024];
					int bytesRead;
					while (true)
					{
						bytesRead = responseStream.Read(buffer, 0, buffer.Length);
						if (bytesRead == 0)
							break;
						fileStream.Write(buffer, 0, bytesRead);
					}
				}
				Console.WriteLine("Download complete.");
			}
			catch (UriFormatException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (WebException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}
            finally
            {
				if (reader != null)
					reader.Close();
				else if (responseStream != null)
                    responseStream.Close();
                if (fileStream != null)
                    fileStream.Close();
            }
        }

        public static void Upload(string fileName, string uploadUrl)
        {
            Stream requestStream = null;
            FileStream fileStream = null;
            FtpWebResponse uploadResponse = null;
			try
			{
				FtpWebRequest uploadRequest =
					(FtpWebRequest)WebRequest.Create(uploadUrl);
				uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;

				// UploadFile is not supported through an Http proxy
				// so we disable the proxy for this request.
				uploadRequest.Proxy = null;

				requestStream = uploadRequest.GetRequestStream();
				fileStream = File.Open(fileName, FileMode.Open);

				byte[] buffer = new byte[1024];
				int bytesRead;
				while (true)
				{
					bytesRead = fileStream.Read(buffer, 0, buffer.Length);
					if (bytesRead == 0)
						break;
					requestStream.Write(buffer, 0, bytesRead);
				}
				
				// The request stream must be closed before getting 
				// the response.
				requestStream.Close();

				uploadResponse =
					(FtpWebResponse)uploadRequest.GetResponse();
				Console.WriteLine("Upload complete.");
			}
			catch (UriFormatException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (WebException ex)
			{
				Console.WriteLine(ex.Message);
			}
            finally
            {
                if (uploadResponse != null)
                    uploadResponse.Close();
                if (fileStream != null)
                    fileStream.Close();
                if (requestStream != null)
                    requestStream.Close();
            }
        }

        public static void List(string listUrl)
        {
            StreamReader reader = null;
            try
            {
                FtpWebRequest listRequest =
                    (FtpWebRequest)WebRequest.Create(listUrl);
                listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse listResponse =
                    (FtpWebResponse)listRequest.GetResponse();
                reader = new StreamReader(listResponse.GetResponseStream());
                Console.WriteLine(reader.ReadToEnd());
                Console.WriteLine("List complete.");
            }
			catch (UriFormatException ex)
			{
				Console.WriteLine(ex.Message);
			}
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

		/// <summary>  
        /// Code to upload file to FTP Server  
        /// </summary>  
        /// <param name="strFilePath">Complete physical path of the file to be uploaded</param>  
        /// <param name="strFTPPath">FTP Path</param>  
        /// <param name="strUserName">FTP User account name</param>  
        /// <param name="strPassword">FTP User password</param>  
        /// <returns>Boolean value based on result</returns>  
        public static bool UploadToFTP(string strFilePath, string strFTPPath, string strUserName, string strPassword)  
        {  
           try  
           {   
                //Create a FTP Request Object and Specify a Complete Path  
                string strFileName = strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1); 
                FtpWebRequest reqObj = (FtpWebRequest)WebRequest.Create(strFTPPath + @"/" + strFileName);  
                //Call A FileUpload Method of FTP Request Object  
                reqObj.Method = WebRequestMethods.Ftp.UploadFile;  
                //If you want to access Resource Protected You need to give User Name and PWD  
                reqObj.Credentials = new NetworkCredential(strUserName, strPassword);  
                // Copy the contents of the file to the request stream.  
                StreamReader sourceStream = new StreamReader(strFilePath);  
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());  
                sourceStream.Close();  
                reqObj.ContentLength = fileContents.Length;  
                Stream requestStream = reqObj.GetRequestStream();  
                requestStream.Write(fileContents, 0, fileContents.Length);  
                requestStream.Close();  
                FtpWebResponse response = (FtpWebResponse)reqObj.GetResponse();  
                //response.Close();  
           }  
           catch (Exception Ex)  
           {       // report error  
                   throw Ex;  
           }  
           return true;  
		}   
    }
}
