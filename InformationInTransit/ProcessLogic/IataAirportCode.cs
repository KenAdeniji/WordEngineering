using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Collections.ObjectModel;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;

namespace InformationInTransit.ProcessLogic
{
    public static partial class IataAirportCode
    {
        public static void Main(string[] argv)
        {
			DataSet dataSet = new DataSet();
			dataSet.ReadXml("airport-codes.xml");
			
			DataCommand.DatabaseCommand
			(
				"TRUNCATE TABLE AManDevelopedInAll..IataAirportCode",
				CommandType.Text,
				DataCommand.ResultType.NonQuery
			);

			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				Collection<OleDbParameter> oleDbParameterCollection = new Collection<OleDbParameter>();
					
				OleDbParameter code = new OleDbParameter("@code", SqlDbType.VarChar);
				OleDbParameter airport = new OleDbParameter("@airport", SqlDbType.VarChar);

				oleDbParameterCollection.Add(code);
				oleDbParameterCollection.Add(airport);

				code.Value = dataRow["code"];
				airport.Value = dataRow["airport"];
				
				DataCommand.DatabaseCommand
				(
					"AManDevelopedInAll..usp_IataAirportCodeInsert",
					CommandType.StoredProcedure,
					DataCommand.ResultType.NonQuery,
					oleDbParameterCollection
				);
			}
        }
    }
}
