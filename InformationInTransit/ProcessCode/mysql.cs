/*

	using System.Data.OleDb;
	using System.Data;

	OleDbConnection myConn;
	OleDbDataReader MyReader = null;

	String DBConectString = "Provider=MySQLProv;Data Source=Your_MySQL_Database;User Id=MyUsername; Password=MyPassword;";

	try
	{
	  myConn = new OleDbConnection
				(
					DBConectString
				);

	  myConn.Open();
	  string sql = "SELECT * FROM Table";
	  OleDbCommand cmd = new OleDbCommand(sql, myConn); 

	  MyReader = cmd.ExecuteReader();

	  while (MyReader.Read())
	  {
		Console.WriteLine( MyReader["Product_Name"].ToString() );
	  }

	  MyReader.Close();       
	}
	catch(Exception ee)
	{
	  Console.WriteLine( ee.ToString() );
	}
	finally
	{
	   if (MyReader != null && !MyReader.IsClosed)
	   {
		  MyReader.Close();
	   }

	   if (myConn != null && myConn.State == ConnectionState.Open)
	   {
		  myConn.Close();
	   }
	}

*/

using System;
//using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Data;
	
namespace PreparedStatement
{
    class Program
    {
        static void Main(string[] args)
        {
			
            //string cs = @"server=localhost;userid=dbuser;password=s$cret;database=testdb";

			//string cs = "Provider=MySQLProv;Data Source=Your_MySQL_Database;User Id=MyUsername; Password=MyPassword;";		

			/*
            using var con = new MySqlConnection(cs);
            con.Open();

            var sql = "INSERT INTO cars(name, price) VALUES(@name, @price)";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", "BMW");
            cmd.Parameters.AddWithValue("@price", 36600);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Console.WriteLine("row inserted");
			
			*/
			
			OleDbConnection myConn = null;
			OleDbDataReader MyReader = null;

			String DBConectString ;
			
			DBConectString
				= "Provider=MySQLProv;Data Source=adriel; User Id=MyUsername; Password=MyPassword;";
					
			DBConectString 		
				//= "Provider=MSDASQL; DRIVER={MySQL ODBC 3.51Driver}; SERVER= localhost; DATABASE=Your_MySQL_Database; UID= Your_Username; PASSWORD=Your_Password; OPTION=3";
				= "[Provider=MSDASQL;] DRIVER=driver; SERVER=server;DATABASE=database; UID=MyUserID; PWD=MyPassword";
				
			try
			{
				
			  myConn = new OleDbConnection
						(
							DBConectString
						);

			  myConn.Open();
			  string sql = "SELECT * FROM Table";
			  OleDbCommand cmd = new OleDbCommand(sql, myConn); 

			  MyReader = cmd.ExecuteReader();

			  while (MyReader.Read())
			  {
				Console.WriteLine( MyReader["Product_Name"].ToString() );
			  }

			  MyReader.Close();       
			}
			catch(Exception ee)
			{
			  Console.WriteLine( ee.ToString() );
			}
			finally
			{
				
				if (MyReader != null && !MyReader.IsClosed)
				{
					MyReader.Close();
				}

				if (myConn != null && myConn.State == ConnectionState.Open)
				{
					myConn.Close();
				}
			}	
			
        }
    }
}