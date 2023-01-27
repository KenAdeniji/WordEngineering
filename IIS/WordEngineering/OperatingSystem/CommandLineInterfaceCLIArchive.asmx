<%@ WebService Language="C#" Class="CommandLineInterfaceCLIWebService" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Diagnostics;
using System.Text;

///<summary>
///	2023-01-11T14:44:00	Created.
///	2023-01-11T15:02:00	https://stackoverflow.com/questions/4291912/process-start-how-to-get-the-output
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class CommandLineInterfaceCLIWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	command
	)	
    {
		var proc = new Process 
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = command,
				Arguments = "",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true
			}
		};
		
		string line;
		
		StringBuilder sb = new StringBuilder();
		
		proc.Start();
		while (!proc.StandardOutput.EndOfStream)
		{
			line = proc.StandardOutput.ReadLine();
			sb.Append(line);
			sb.Append(System.Environment.NewLine);
		}
		return sb.ToString();
	}
	
}
