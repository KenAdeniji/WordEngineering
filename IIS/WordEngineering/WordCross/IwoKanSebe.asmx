<%@ WebService Language="C#" Class="IwoKanSebeWebService" %>

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
using System.Data.Odbc;
using System.Data.SqlClient;

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
/// 2023-02-15 16:05:11.910	Iwo kan sebe. You only do it.
///	2023-02-22T12:19:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IwoKanSebeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	source,
		String	orderBy,
		long	maximumRecords
	)
    {
		StringBuilder sql = new StringBuilder();
		
		String[] sources = source.Split
		(
			SubsetSeparator,
			StringSplitOptions.RemoveEmptyEntries 
		);
		
		String maximumRecordsSubstitution = maximumRecords < 1 ? "" : String.Format(" TOP {0} ", maximumRecords);
		String orderBySubstitution = String.IsNullOrEmpty(orderBy) ? "" : String.Format(" ORDER BY {0} ", orderBy);
		
		foreach (String sourceCurrent in sources)
		{
			sql.AppendFormat
			(
				SelectQuery,
				maximumRecordsSubstitution,
				sourceCurrent,
				orderBySubstitution
			);
		}

		DataSet resultSet = (DataSet)DataCommand.DatabaseCommand
		(
			sql.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	String SelectQuery = 
	@" 
		SELECT {0} *
		FROM WordEngineering..{1}
		{2}
		;
	";
	public static readonly char[] SubsetSeparator = {',', ';'};
}
