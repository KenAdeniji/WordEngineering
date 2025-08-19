/*
	2022-04-06	Created.
		CLASSPATH =.;C:\Program Files\Microsoft JDBC Driver 10.2 for SQL Server\sqljdbc_10.2\enu\mssql-jdbc-10.2.0.jre17.jar
		https://docs.microsoft.com/en-us/sql/connect/jdbc/building-the-connection-url?view=sql-server-ver15	
		java SQLDatabaseConnection -classpath .;mssql-jdbc-10.2.0.jre17.jar;mssql-jdbc_auth-10.2.0.x64.dll
		
		http://learn.microsoft.com/en-us/sql/connect/jdbc/download-microsoft-jdbc-driver-for-sql-server?view=sql-server-ver16
		http://learn.microsoft.com/en-us/sql/connect/jdbc/building-the-connection-url?view=sql-server-ver16
*/
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

//import com.microsoft.sqlserver.jdbc;

public class SQLDatabaseConnection {

    // Connect to your database.
    // Replace server name, username, and password with your credentials
    public static void main(String[] args) {
        String connectionUrl =
                "jdbc:sqlserver://yourserver.database.windows.net:1433;"
                + "database=AdventureWorks;"
                + "user=yourusername@yourserver;"
                + "password=yourpassword;"
                + "encrypt=true;"
                + "trustServerCertificate=false;"
                + "loginTimeout=30;";
				
		connectionUrl = "jdbc:sqlserver://localhost;database=Bible;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
		
		connectionUrl = "jdbc:sqlserver://HolySpirit.database.windows.net:1433;database=Bible;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
		
		connectionUrl = "jdbc:sqlserver://HOLYSPIRIT.database.windows.net:1433;database=Bible;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
		
		connectionUrl = "jdbc:sqlserver://HOLYSPIRIT;database=Bible;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
		
		connectionUrl = "jdbc:sqlserver://HOLYSPIRIT;encrypt=true;integratedSecurity=true;trustServerCertificate=true;";

        ResultSet resultSet = null;

        try
		{	
			//Driver d = (Driver)Class.forName("com.microsoft.jdbc.sqlserver.SQLServerDriver").newInstance();
		
			Connection connection = DriverManager.getConnection(connectionUrl);
			Statement statement = connection.createStatement();

            // Create and execute a SELECT SQL statement.
            String selectSql = "SELECT ScriptureReference, KingJamesVersion FROM Bible..Scripture_View WHERE ScriptureReference LIKE 'Genesis 22%' OR ScriptureReference LIKE 'Genesis 41%' ORDER BY VerseIDSequence";
            resultSet = statement.executeQuery(selectSql);

            // Print results from select statement
            while (resultSet.next()) {
                System.out.println(resultSet.getString(1) + " " + resultSet.getString(2));
            }
        }
		catch (SQLException e) 
		{
            e.printStackTrace();
        }
		catch (Exception ex) 
		{
            ex.printStackTrace();
        }
    }
}
