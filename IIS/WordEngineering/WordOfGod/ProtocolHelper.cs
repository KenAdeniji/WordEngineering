namespace WordEngineering
{

	 ///<summary>ProtocolHelper</summary>
	 ///<remarks>
	 ///	2019-08-08T15:00:00 @ precede .
	 ///	PATH = %SystemRoot%\system32;%SystemRoot%;%SystemRoot%\System32\Wbem;%SYSTEMROOT%\System32\WindowsPowerShell\v1.0\;%SYSTEMROOT%\System32\OpenSSH\;C:\Program Files (x86)\ATI Technologies\ATI.ACE\Core-Static;D:\Program Files (x86)\Microsoft SQL Server\160\Tools\Binn\;D:\Program Files\Microsoft SQL Server\160\Tools\Binn\;D:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\;D:\Program Files\Microsoft SQL Server\160\DTS\Binn\;D:\Program Files (x86)\Microsoft SQL Server\160\DTS\Binn\;C:\Windows\Microsoft.NET\Framework64\v4.0.30319;C:\Windows\Microsoft.NET\Framework64\v3.5;C:\Windows\Microsoft.NET\Framework64\v2.0.50727;C:\Program Files\dotnet\;
	 ///	regsvr32 UtilityProtocol.dll
	 ///	2024-10-21T19:21:00...2024-10-21T21:20:00 Formerly UtilityProtocol.cs not changed, but corrected to ProtocolHelper.cs
	 ///</remarks>
	public class ProtocolHelper
	{
		public static string PrefixProtocol
		(
			string URI
		) 
		{
			if ( URI.IndexOf('@') > -1 && URI.IndexOf('@') < URI.IndexOf('.') )
			{
				return("mailto:" + URI);
			}	
			else if ( URI.IndexOf(':') < 0 )
			{
				return("http://" + URI);
			}
			else 
			{
				return(URI);
			}
		}
	}
}
