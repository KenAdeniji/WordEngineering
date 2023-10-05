<!DOCTYPE html>
<html>
<head>
<!--
	2018-01-02	https://www.w3schools.com/asp/asp_ajax.asp
-->
<script>
function showCustomer(str)
{
	if (str=="")
	{
	  document.getElementById("txtHint").innerHTML="";
	  return;
	}
	if (window.XMLHttpRequest)
	{
		// code for IE7+, Firefox, Chrome, Opera, Safari
		xmlhttp=new XMLHttpRequest();
	}
	else
	{
		// code for IE6, IE5
		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
	}
	xmlhttp.onreadystatechange=function()
	{
		if (this.readyState==4 && this.status==200)
		{
			document.getElementById("txtHint").innerHTML=this.responseText;
		}
		if (this.readyState==4 && this.status==500)
		{
			document.getElementById("txtHint").innerHTML=this.responseText;
		}
	}
	xmlhttp.open("GET","MicrosoftSQLServerDatabaseGetCustomer.asp?q="+str,true);
	xmlhttp.send();
}
</script>
</head
<body>

<form>
<select name="customers" onchange="showCustomer(this.value)">
<option value="">Select a customer:</option>
<option value="ALFKI">Alfreds Futterkiste</option>
<option value="NORTS ">North/South</option>
<option value="WOLZA">Wolski Zajazd</option>
</select>
</form>

<div id="txtHint">Customer info will be listed here...</div>
</body>
</html>
