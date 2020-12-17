using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;

[ServiceContract(Name = "IoannisPanagopoulosRestServices")]
public interface IIoannisPanagopoulosRestServices
{
    [OperationContract]
    [WebGet(UriTemplate = Routing.GetClientRoute, BodyStyle = WebMessageBodyStyle.Bare)]
    string GetClientNameById(string id);
}

public static class Routing
{
    public const string GetClientRoute = "/Client/{id}";
}

///<remarks>
///		http://www.progware.org/Blog/post/A-simple-REST-service-in-C.aspx
///		netstat -anb | findstr ":81"
///		http://localhost:81/IoannisPanagopoulosRestServices/client/msdn
///</remarks>
[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, 
                 ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class IoannisPanagopoulosRestServices:IIoannisPanagopoulosRestServices
{
    public string GetClientNameById(string id)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();
		sqlParameterCollection.Add(new SqlParameter("@uri", id));

		string dataRecord = "2005-04-25 01:00:00.000 2015-04-04 14:36:50.110";
		DataTable dataTable = null;
		
		try
		{
			dataTable = (DataTable) Repository.DatabaseCommand
			(
				"URI..usp_IoannisPanagopoulosRestServicesSelect",
				CommandType.StoredProcedure,
				Repository.ResultSet.DataTable,
				sqlParameterCollection
			);
			
			if (dataTable.Rows.Count > 0)
			{
				dataRecord = String.Format
				(
					DataRecordFormat,
					dataTable.Rows[0]["DatedFrom"],
					dataTable.Rows[0]["DatedUntil"]
				);	
			}
		}
		catch(Exception ex)
		{
		}
		
		return dataRecord;
    }
	public const string DataRecordFormat = "Dated {0} ... {1}";
}
