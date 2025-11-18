<%@ WebService Language="C#" Class="DatabaseMetadataWebService" %>

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
///	2025-11-17T19:30:00 Created. http://stackoverflow.com/questions/887370/sql-server-extract-table-meta-data-description-fields-and-their-data-types
///	DDL triggers. Database schema changes. To record columnar insertion or deletion.
///	Metadata database dictionary.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DatabaseMetadataWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		dynamic dataTable = DataCommand.DatabaseCommand
		(
			@"
				SELECT 
					sys.tables.name TableName,
					sys.columns.name ColumnName,
					sys.extended_properties.name ExtendedPropertyName,	
					sys.extended_properties.value ExtendedPropertyValue
				FROM
					WordEngineering.sys.extended_properties INNER JOIN WordEngineering.sys.columns
						ON 	WordEngineering.sys.extended_properties.major_id = WordEngineering.sys.columns.object_id
							AND	WordEngineering.sys.extended_properties.minor_id = WordEngineering.sys.columns.column_id
					INNER JOIN WordEngineering.sys.tables 
						ON WordEngineering.sys.columns.object_id = WordEngineering.sys.tables.object_id
				WHERE
					WordEngineering.sys.extended_properties.value IS NOT NULL
				ORDER BY
					WordEngineering.sys.tables.name,
					WordEngineering.sys.columns.name,
					WordEngineering.sys.extended_properties.name,
					WordEngineering.sys.extended_properties.value
			",
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
}
