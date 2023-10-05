<%@ WebService Language="C#" Class="ContactFormWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2016-07-30	Created.	ContactForm.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ContactFormWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public void Insert
	(
		String	name,
		String	email,
		String	subject,
		String	message
	)
    {
		name = name.Trim();
		if (String.IsNullOrEmpty(name)) return;

		email = email.Trim();
		if (String.IsNullOrEmpty(email)) return;
		
		subject = subject.Trim();
		if (String.IsNullOrEmpty(subject)) return;

		message = message.Trim();
		if (String.IsNullOrEmpty(message)) return;
		
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
		sqlParameterCollection.Add(new SqlParameter("@name", name));
		sqlParameterCollection.Add(new SqlParameter("@email", email));
		sqlParameterCollection.Add(new SqlParameter("@subject", subject));
		sqlParameterCollection.Add(new SqlParameter("@message", message));
		
		DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_ContactFormInsert",
			CommandType.StoredProcedure,
			DataCommand.ResultType.NonQuery,
			sqlParameterCollection
		);
	}
}
