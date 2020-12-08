<!DOCTYPE html>
<html>
<head>
<!--
	2018-01-01	https://www.w3schools.com/asp/asp_ajax.asp
	2018-01-01	https://www.w3schools.com/asp/ado_connect.asp
	2018-01-01	https://www.w3schools.com/asp/ado_recordset.asp
	2018-01-01	http://download.cnet.com/Access-2000-Tutorial-Northwind-Traders-Sample-Database/3000-2251_4-10742880.html
	2018-01-01	http://microsoft.com/en-us/download/details.aspx?id=13255
-->
</head>
<body>
<%
response.expires=-1
sql="SELECT CompanyName FROM CUSTOMERS WHERE CUSTOMERID="
sql=sql & "'" & request.querystring("q") & "'"
set conn=Server.CreateObject("ADODB.Connection")
rem conn.Provider="Microsoft.Jet.OLEDB.4.0"

'pathName = Server.Mappath("Nwind.mdb")
'response.write(pathName)

set conn=Server.CreateObject("ADODB.Connection")
conn.Open "MicrosoftAccessNorthwind"

set rs=Server.CreateObject("ADODB.recordset")
rs.Open sql, conn

do until rs.EOF
  for each x in rs.Fields
    response.write("<tr><td><b>" & x.name & "</b></td>")
    response.write("<td>" & x.value & "</td></tr>")
  next
  rs.MoveNext
loop

%>
</body>
</html>
