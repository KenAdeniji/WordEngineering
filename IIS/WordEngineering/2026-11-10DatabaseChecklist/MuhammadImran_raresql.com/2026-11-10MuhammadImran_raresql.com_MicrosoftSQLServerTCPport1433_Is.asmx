<%@ WebService Language="C#" Class="MuhammadImran_raresql_MicrosoftSQLServerTCPport1433_Is" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2026-11-10	http://www.raresql.com/2013/04/20/sql-server-how-to-find-sql-server-port-number
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MuhammadImran_raresql_MicrosoftSQLServerTCPport1433_Is : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query()
    {
		string sqlServerPortNumber = (string) DataCommand.DatabaseCommand
		(
			SQLSelect,
			CommandType.Text,
			DataCommand.ResultType.Scalar
		);
		
		return sqlServerPortNumber;
    }

	public const String SQLSelect = @"
		Select value_data as PortNumber1433
		From sys.dm_server_registry
		Where registry_key like '%IPALL%' and
		value_name ='TcpPort'
	";
}
