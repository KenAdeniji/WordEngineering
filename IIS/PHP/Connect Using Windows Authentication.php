<?php
/* Specify the server and connection string attributes. */
//phpinfo();
$serverName = "(local)";
$connectionInfo = array( "Database"=>"AdventureWorks");

try
  {

	$conn = sqlsrv_connect( $serverName, $connectionInfo);
	if( $conn === false )
	{
		 echo "Unable to connect.</br>";
		 die( print_r( sqlsrv_errors(), true));
	}
	
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
	
?>
