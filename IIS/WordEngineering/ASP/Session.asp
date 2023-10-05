<!DOCTYPE html>
<html>
<!--
	2018-01-01	https://www.w3schools.com/asp/asp_sessions.asp
	A session ends if a user has not requested or refreshed a page in the application for a specified period. 
	By default, this is 20 minutes. 	
-->
<head>
</head>

<body>
	<%
Session.Timeout=5	REM	Session.Abandon
Session("username")="Donald Duck"
Session("age")=50
	%>
	
	<%
Session.Contents.Remove("age")
Session.Contents.RemoveAll()
	%>
	
<%
Session("username")="Donald Duck"
Session("age")=50

dim i
For Each i in Session.Contents
  Response.Write(Session.Contents(i) & " " & Session(i) & "<br>")
Next
%>	
</body>

</html>
