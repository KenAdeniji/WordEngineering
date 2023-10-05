<%@LANGUAGE="VBSCRIPT" CODEPAGE="1252"%>
<% Option Explicit %>

<%
Function TodaysDate
	TodaysDate = Now()
End Function

Sub HelloInformalByRef(ByRef sFullName)
        If InStr(1, sFullName, " ") > 0 Then
                sFullName = Left(sFullName, InStr(1, sFullName, " ")-1)
        End If
        Response.Write "Hello "
        Response.Write(sFullName)
 End Sub
 
 Sub HelloInformalByVal(ByVal sFullName)
        If InStr(1, sFullName, " ") > 0 Then
                sFullName = Left(sFullName, InStr(1, sFullName, " ")-1)
        End If
        Response.Write "Hello "
        Response.Write(sFullName)
 End Sub
%>
 
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
 "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Procedure</title>
</head>
 
<body>
<%=TodaysDate()%>
</body>
</html>

