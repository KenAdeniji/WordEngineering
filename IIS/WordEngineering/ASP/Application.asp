<!DOCTYPE html>
<html>
<!--
	2018-01-01	https://www.w3schools.com/asp/asp_applications.asp
-->
<head>
</head>

<body>
	There are
	<%
	Response.Write(Application("users"))
	%>
	active connections.
	
<%
dim i
dim j
j=Application.Contents.Count
For i=1 to j
	REM Response.Write(Application[i] & "<br>")
	Response.Write(Application.Contents(i) & "<br>")
Next
%>	
</body>
</html>
