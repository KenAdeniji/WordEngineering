 <!DOCTYPE html>
<html>
<!--
	2018-01-01	https://www.w3schools.com/asp/asp_inputforms.asp
-->
<head>
</head>

<body>
Welcome
<%
response.write(request.querystring("fname"))
response.write(" " & request.querystring("lname"))
%>
</body>
</html>
