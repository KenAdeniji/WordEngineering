<html>
 <head>
  <title>PHP Test</title>
 </head>
 <body>
 <?php 
	echo '<p>Hello World</p><br />'; 
	echo $_SERVER['HTTP_USER_AGENT'];
	echo '<br />';
	if (strpos($_SERVER['HTTP_USER_AGENT'], 'MSIE') !== FALSE) {
		echo 'You are using Internet Explorer.<br />';
	}
 ?> 
 </body>
</html>
