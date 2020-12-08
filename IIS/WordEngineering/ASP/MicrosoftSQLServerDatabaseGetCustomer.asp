<!DOCTYPE html>
<html>
<head>
<!--
	2018-01-02	https://www.w3schools.com/asp/asp_ajax.asp
	2018-01-02	https://www.w3schools.com/asp/ado_connect.asp
	2018-01-02	https://www.w3schools.com/asp/ado_recordset.asp
	2018-01-02	https://support.microsoft.com/en-us/help/300382/how-to-create-a-database-connection-from-an-asp-page-in-iis
-->
</head>
<body>
<%
'response.expires=-1
sql="SELECT CompanyName FROM CUSTOMERS WHERE CUSTOMERID="
sql=sql & "'" & request.querystring("q") & "'"
set conn=Server.CreateObject("ADODB.Connection")
conn.Open "Provider=SQLOLEDB; Data Source = (local); Initial Catalog = Northwind; User Id = DummyLogin; Password=DummyLogin;"

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
