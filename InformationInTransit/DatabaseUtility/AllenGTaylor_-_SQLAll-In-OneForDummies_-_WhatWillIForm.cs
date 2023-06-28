/*
	2023-06-27T15:21:00	google.com/books/edition/SQL_All_in_One_For_Dummies/0wGQDwAAQBAJ?hl=en
	2023-06-27T15:21:00	stackoverflow.com/questions/3005095/can-i-get-the-names-of-all-the-tables-of-a-sql-server-database-in-a-c-sharp-appl
	2023-06-27T16:27:00 ... 2023-06-27T16:27:00 ODBC Database connection string.
	2023-06-27T19:19:00 ... 2023-06-27T19:50:00	http://stackoverflow.com/questions/11160685/get-columns-of-a-table-by-getschema-method
*/
using System;
using System.Collections;
using System.Collections.Generic;

using System.Data;
using System.Data.Odbc;

namespace InformationInTransit.DatabaseUtility
{
	public partial class WhatWillIForm
	{
		public static OdbcConnection DatabaseConnection
		(
			string	connectionString
		)
		{
			OdbcConnection odbcConnection = new OdbcConnection(connectionString);
			odbcConnection.Open();
			return odbcConnection;
		}		

		public static DataTable QueryColumns
		(
			string	connectionString,
			string 	tableName
		)
		{
			OdbcConnection odbcConnection = DatabaseConnection
			(
				connectionString
			);
			String[] columnRestrictions = new String[4];
			columnRestrictions[2] = tableName;
			DataTable dataTable = odbcConnection.GetSchema
			(
				"Columns",
				columnRestrictions
			);
			odbcConnection.Close();
			return dataTable;
		}		

		public static DataTable QueryTables
		(
			string	connectionString
		)
		{
			OdbcConnection odbcConnection = DatabaseConnection
			(
				connectionString
			);
			DataTable dataTable = odbcConnection.GetSchema
			(
				"Tables"
			);
			odbcConnection.Close();
			return dataTable;
		}		
	}	
}	