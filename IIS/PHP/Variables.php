<?php
	class Variables
	{
		public function display($header, $arrayVariable) {
			$output = "<tr><th colspan=\"2\">" . $header . "</th></tr>";
			echo $output;
			foreach ($arrayVariable as $key => $value) {
				$output = "<tr><td>" . $key . "</td><td>" . $value . "</td></tr>";
				echo $output;
			}
			unset($value); // break the reference with the last element
		}
	}
	echo "<table>";
	Variables::display('Superglobals', Superglobals);	
	Variables::display('$GLOBALS', $GLOBALS);
	Variables::display('$_SERVER', $_SERVER);
	Variables::display('$_GET', $_GET);
	Variables::display('$_POST', $_POST);
	Variables::display('$_FILES', $_FILES);
	Variables::display('$_REQUEST', $_REQUEST);
	Variables::display('$_SESSION', $_SESSION);
	Variables::display('$_ENV', $_ENV);
	Variables::display('$_COOKIE', $_COOKIE);
	Variables::display('$php_errormsg', $php_errormsg);
	Variables::display('$http_response_header', $http_response_header);
	Variables::display('$argc', $argc);
	Variables::display('$argv', $argv);
	echo "</table>";
?>
