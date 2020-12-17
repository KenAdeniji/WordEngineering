<?php
function get_login_password($email, $password) {
    global $db;
    $query = "SELECT loginId FROM login
              WHERE email = $email and password = $password";
	try {
		$logins = $db->query($query);
		echo $logins;
		/*
		if ($logins == false)
		{
			$login_message = 'Invalid login, please try again';
			require_once('login.php');
		}			
		$logins = $logins->fetch();
		if ($logins == false)
		{
			$login_message = 'Invalid login, please try again';
			require_once('login.php');
		}
		*/	
		$loginId = $logins['loginIds'];
	}
	catch (PDOException $e) {
        $error_message = $e->getMessage();
        include('../errors/database_error.php');
        exit();
    }
    $_SESSION['loginId']=loginId;
	return $loginId;
}
?>
