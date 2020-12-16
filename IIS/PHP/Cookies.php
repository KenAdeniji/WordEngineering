<?php
#checking if form has been submitted
if (isset($_POST['submitted'])){
#if yes (form is submitted) assign values from POST array to variables
$newbgColor=$_POST['bgColor'];
$newtxtColor=$_POST['txtColor'];
#set cookies
setcookie("bgColor",$newbgColor,time()+3600);
setcookie("txtColor",$newtxtColor,time()+3600);

}
#in case user has come for first time and cookies are not set then
if ((!isset($_COOKIE['bgColor']) ) && (!isset($_COOKIE['txtColor']))){
$bgColor = "Black";
$txtColor="White";
}
#if cookies are set then use them
else{
$bgColor = $_COOKIE['bgColor'];
$txtColor = $_COOKIE['txtColor'];
}
?>
<!-- HTML Page-->
<html>
<body bgcolor="<?php echo $bgColor ?>" text="<?php echo $txtColor ?>">
<form action= "<?php echo $_SERVER['PHP_SELF']; ?>" method ="POST">
<p>Body Color:</p>
<select name=bgColor>
<option value ="Red">Red</option>
<option value ="Green" selected>Green</option>
<option value ="Blue">Blue</option>
<option value ="Yellow">Yellow</option>
<option value ="Black">Black</option>
<option value ="Brown">Brown</option>
<option value ="White">White</option>
</select>
<p>Text Color:</p>
<select name=txtColor>
<option value ="Red">Red</option>
<option value ="Green" selected>Green</option>
<option value ="Blue">Blue</option>
<option value ="Yellow">Yellow</option>
<option value ="Black">Black</option>
<option value ="Brown">Brown</option>
<option value ="White">White</option>
</select>
<input type ="hidden" name="submitted" value="true"></br>
<input type="submit" value="remind">
</form>
</body>
</html>