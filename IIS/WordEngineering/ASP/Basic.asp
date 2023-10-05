<%@LANGUAGE="VBSCRIPT" CODEPAGE="1252"%>
<% Option Explicit %>

<%' absolute path - based on web site root %>
<%
'<!-- #include virtual="/pathtoinclude/include.asp" -->
%>
<%' relative path - based on folder of calling page  %>
<%
'<!-- #include file="../../folder1/include.asp" -->
%>
<%
 
Dim MyText
 
MyText = "Basic ASP" + "<br/>"

%>
 
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
 "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Basic ASP</title>
</head>
 
<body>
<%=(MyText)%>

<%
 ' example comment - show the current date
 Response.Write Now()
%>

<%
	Dim sixty
	sixty = 60
	Dim programme 
	programme =  "<br/>" + CStr(sixty) + " minutes " +  + "<br/>"
	Response.Write programme
%> 
 
<%
'if ((bDaysLeft < DateDiff("d", Now(), dBirthDay)) Or _
'   (bDaysLeft > DateDiff("d", Now(), dChristMas)) Then
'        Response.Write "Hooray!"
'End If
%>
 
</body>
</html>

