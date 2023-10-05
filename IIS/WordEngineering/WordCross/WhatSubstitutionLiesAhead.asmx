<%@ WebService Language="C#" Class="WhatSubstitutionLiesAheadWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;

using System.Management.Automation;

///<summary>
///	2021-11-09T12:43:00 Created. https://docs.microsoft.com/en-us/powershell/scripting/learn/tutorials/01-discover-powershell?view=powershell-7.2#powershell-cmdlets
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatSubstitutionLiesAheadWebService : System.Web.Services.WebService
{
	public String ServerMapPath = null;
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
		StringBuilder sb = new StringBuilder();
		String verbKeyword = "";
		using (PowerShell powerShell = PowerShell.Create()){
		  // Source functions.
		  powerShell.AddScript("Get-Verb | Select-Object -Property Verb");

		  // invoke execution on the pipeline (collecting output)
		  Collection<PSObject> PSOutput = powerShell.Invoke();                

		  // loop through each output object item
		  foreach (PSObject outputItem in PSOutput)
		  {
			 // if null object was dumped to the pipeline during the script then a null object may be present here
			 if (outputItem != null)
			 {                      
				verbKeyword = outputItem.ToString();
				verbKeyword = verbKeyword.Substring(7);
				verbKeyword = verbKeyword.Remove(verbKeyword.Length - 1);
				if (sb.Length > 0)
				{
					sb.Append(", ");
				}	
				sb.Append(verbKeyword);
			 }
		   }     

		   // check the other output streams (for example, the error stream)
		   if (powerShell.Streams.Error.Count > 0)
		   {
			  // error records were written to the error stream.
			  // Do something with the error
		   }
		}  
		return sb.ToString();
    }
}
