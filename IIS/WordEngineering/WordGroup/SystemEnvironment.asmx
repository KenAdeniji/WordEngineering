<%@ WebService Language="C#" Class="SystemEnvironmentWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Text;

using System.Reflection;

using Newtonsoft.Json;

///<summary>
///	2023-04-12T15:27:00 ... 2023-04-12T15:44:00	Created.
///	http://google.com/books/edition/Pro_C_10_with_NET_6/bVa2zgEACAAJ?hl=en
///	http://stackoverflow.com/questions/9893028/c-sharp-foreach-property-in-object-is-there-a-simple-way-of-doing-this
///	http://stackoverflow.com/questions/23187288/print-all-system-environment-information-using-system-reflection
/// ProcessId (new in 10.0)
/// ProcessPath (new in 10.0)
///	2023-04-13T09:25:00 What develops our fundamental?
///		The author could explicitly call property or method.
///		But if it is an old release it may not later implementation have support.
///	2023-04-13T09:31:00 Deprecated functionality.
///		What do I do today to be absent tomorrow?
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SystemEnvironmentWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		
		var properties = typeof(System.Environment)
                .GetProperties
				(
						BindingFlags.Public
					| 	BindingFlags.Static
				);

		List<KeyValue> keysValues = new List<KeyValue>();
	
		foreach(var property in properties)
		{
			keysValues.Add(new KeyValue(property.Name, property.GetValue(null)));
		}	

		string json = JsonConvert.SerializeObject
		(
			keysValues,
			Formatting.Indented
		);
		
		return json;
    }
}

public class KeyValue
{
	public KeyValue( String Key, object Value)
	{
		this.Key = Key;
		this.Value = Value;
	}
	
	public string Key { get; set; }
	public object Value { get; set; }
}	
