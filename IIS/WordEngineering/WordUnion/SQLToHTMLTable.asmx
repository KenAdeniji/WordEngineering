<%@ WebService Language="C#" Class="SQLToHTMLTable" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Text;

using Newtonsoft.Json;

///<summary>
/// 2017-06-24	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SQLToHTMLTable : System.Web.Services.WebService
{
	public static object DatabaseCommand
	(
		string cmdText,
		string databaseConnectionString,
		ResultType resultType
	)
	{
		DataSet dataSet;
		DataTable dataTable;
		Object returnValue = null;
		SqlCommand sqlCommand;
		SqlConnection sqlConnection = null;
		SqlDataAdapter sqlDataAdapter;

		if (String.IsNullOrEmpty(databaseConnectionString))
		{
			databaseConnectionString = DatabaseConnectionString;
		}
		try
		{
			sqlConnection = new SqlConnection(databaseConnectionString);
			sqlConnection.Open();
			sqlCommand = new SqlCommand(cmdText, sqlConnection);
			switch (resultType)
			{
				case ResultType.DataSet:
					sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					dataSet = new DataSet();
					dataSet.Locale = CultureInfo.CurrentCulture;
					sqlDataAdapter.Fill(dataSet);
					returnValue = dataSet;
					break;

				case ResultType.DataTable:
					sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					dataTable = new DataTable();
					dataTable.Locale = CultureInfo.CurrentCulture;
					sqlDataAdapter.Fill(dataTable);
					returnValue = dataTable;
					break;

				case ResultType.NonQuery:
					returnValue = sqlCommand.ExecuteNonQuery(); break;

				case ResultType.DataReader:
					returnValue = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection); break;

				case ResultType.Scalar:
					returnValue = sqlCommand.ExecuteScalar(); break;

				case ResultType.XmlReader:
					returnValue = sqlCommand.ExecuteXmlReader(); break;
			}		
		}
		catch (SqlException ex)
		{
			EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
			throw;
		}
		finally
		{
			if (resultType != ResultType.DataReader)
			{
				sqlConnection.Close();
			}
		}
		return returnValue;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
	public String Query
	(
		string	sqlStatement,
		string	databaseConnectionString
	)
    {
		if (databaseConnectionString == "")
		{
			databaseConnectionString = null;
		}	
		
		var statements = sqlStatement.ToLower().Split(new Char[] {';'});
		
		for (int index = 0, count = statements.Length; index < count; ++index)
		{
			statements[index] = statements[index].Trim();
			if (statements[index].StartsWith("select") == false)
			{
				return null;
			}	
		}
		
		DataSet dataSet = (DataSet) DatabaseCommand
		(
			sqlStatement,
			databaseConnectionString,
			ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string DatabaseConnectionString = "Data Source=(local);Initial Catalog=Master;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=60;Application Name=Master;MultipleActiveResultSets=True;";
	
	public enum ResultType
	{
		DataSet,
		DataTable,
		NonQuery,
		DataReader,
		Scalar,
		XmlReader
	}
	
}
