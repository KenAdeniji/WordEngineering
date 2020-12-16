<?php
/* Specify the server and connection string attributes. */

phpinfo();

echo "Before variable.v2";
$serverName = "(local)";
$connectionInfo = array( "Database"=>"AdventureWorks");

/* Connect using Windows Authentication. */
echo "Before connect.v2";

try
  {
  
  if (1==2)
  {
	  $conn = sqlsrv_connect( $serverName, $connectionInfo);
	if( $conn === false )
	{
		 echo "Unable to connect.</br>";
		 die( print_r( sqlsrv_errors(), true));
	}
	echo "After connect";
	/* Query SQL Server for the login of the user accessing the
	database. */
	$tsql = "SELECT CONVERT(varchar(32), SUSER_SNAME())";
	$stmt = sqlsrv_query( $conn, $tsql);
	if( $stmt === false )
	{
		 echo "Error in executing query.</br>";
		 die( print_r( sqlsrv_errors(), true));
	}

	/* Retrieve and display the results of the query. */
	$row = sqlsrv_fetch_array($stmt);
	echo "User login: ".$row[0]."</br>";

	/* Free statement and connection resources. */
	sqlsrv_free_stmt( $stmt);
	sqlsrv_close( $conn);
	
	}
	catch (Exception $e)
	{
	
		echo 'Message: ' .$e->getMessage();
		
	}
}

?>
