<?php
$host="localhost"; // Host name
$username="mgs_user"; // Mysql username
$password="pa55w0rd"; // Mysql password
$db_name="Contact"; // Database name
$tbl_name="Login"; // Table name

// Connect to server and select databse.
mysql_connect("$host", "$username", "$password")or die("cannot connect");
mysql_select_db("$db_name")or die("cannot select DB");

// username and password sent from form
$email=$_POST['email'];
$password=$_POST['password'];

// To protect MySQL injection (more detail about MySQL injection)
$email = stripslashes($email);
$password = stripslashes($password);
$email = mysql_real_escape_string($email);
$password = mysql_real_escape_string($password);

$sql="SELECT * FROM $tbl_name WHERE email='$email' and password='$password'";
$result=mysql_query($sql);

// Mysql_num_row is counting table row
$count=mysql_num_rows($result);
// If result matched $email and $password, table row must be 1 row

if($count==1){
// Register $email, $password and redirect to file "login_success.php"
$row = mysql_fetch_assoc($result);
$loginId = $row['LoginId'];

/*
session_register("email");
session_register("password");
session_register($loginId);
*/

session_start();
$_SESSION["email"] = $email;
$_SESSION["password"] = $password;
$_SESSION["loginId"] = $loginId;

header("location:index.php");
}
else {
echo "Wrong Username or Password";
}
?>
