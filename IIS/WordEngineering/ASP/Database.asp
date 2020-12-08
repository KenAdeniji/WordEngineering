<%@LANGUAGE="VBSCRIPT" CODEPAGE="1252"%>
<% Option Explicit %>

<%
	' create a connection object
	Set oConnection = Server.CreateObject("ADODB.Connection")
 
	' open a connection to a data source
	oConnection.Open "Driver={MySQL ODBC 3.51 Driver};server=localhost;port=3306;uid=mysqluser;pwd=mysqlpass;database=mysqldbname;Option=16384"
	
	' build the query to run
	sQuery ="INSERT INTO Company VALUES ("Microsoft")"
 
	' execute the insert statement
	'oConnection.Execute sQuery, nRecordsAffected, adCmdText + adExecuteNoRecords
 
	'Response.Write "Records Affected: " & nRecordsAffected
	
	sQuery = "SELECT companyid, companyname FROM tblCompany"
 
	' create the recordset object to hold the result sets
	Set rs = Server.CreateObject("ADODB.Recordset")
 
	' set the number of records to fetch into memory at once (performance)
	rs.CacheSize = 256
	 
	' execute the query and populate the recordset 
	rs.Open sQuery, oConnection, adOpenKeySet, adLockReadOnly, adCmdText

	' EOF checks for the end of a recordset
	If Not rs.EOF Then
			' The Fields collection accesses fields from a single record
			sFirstName = rs.Fields("firstname").Value
	 
			' You can enumerate all fields in the record
			For Each oFld In rs.fields
					Response.Write "Field = " & oFld.Name & "<br>"
					Response.Write "Value = " & oFld.Value & "<br>"
			Next
	End If

	' You can also loop through all records
	Do Until rs.EOF
        Response.Write "Name = " & rs.Fields("firstname").Value & "<br>"
        ' make sure you don't forget this next step
        ' MoveNext will move to the next record in the resultset
        rs.MoveNext
	Loop
 
	' following is always a good idea to clean up resources ASAP
	rs.Close : rs = 0
	
	' this will close the database connection 
	oConnection.Close
%>