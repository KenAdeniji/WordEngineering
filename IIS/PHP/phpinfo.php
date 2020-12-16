<?php
/* Specify the server and connection string attributes. */

phpinfo();



  try
  {
  
	  echo "Before variable";
	  
	  $a = 10;
	  $b = 5;
	  //$c = $a / $b;

	  
		//ho "c is " + $c;
		
		// Server in the this format: <computer>\<instance name> or 
		// <server>,<port> when using a non default port number
		$server = "(local)";

		echo $server;
		
		
		
		$conn = sqlsrv_connect( $server);

		if( $conn === false )
		{
			echo "failed to connect";
		}
		else
		{
			echo "connected";
		}
		

		
			 // { die( FormatErrors( sqlsrv_errors() ) ); }
				  
				//echo "connected";
	
  }	  
  catch (Exception $e)
  {

		echo "failed";

		//echo 'Message: ' .$e->getMessage();
			
  }	

?>
