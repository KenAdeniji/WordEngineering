<%@ Page
	Language="C#"
	AutoEventWireup="true"
	CodeFile="HowToGetInformationOfSQLServerAndDatabasesPage.aspx.cs"
	Inherits="HowToGetInformationOfSQLServerAndDatabasesPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to get information of SQL Server and databases (SQL)</title>
	<!--
	This T-SQL script will demo how to get the version of SQL Server, the installation path, number of CPU, path of all user database and log files of all databases.
	-->
	<style>
		tr th {background-color:yellow; color:gray;}
		tr:nth-child(even) {background-color:blanchedalmond; color:blue;}
		tr:nth-child(odd) {background-color:beige; color:black;} 
	</style>
</head>
<body>
    <form id="form1" runat="server">
		<asp:GridView
			id="versionOfSQLServer" 
			runat="server"
		/>
		<br /><br />
		
		<asp:GridView
			id="cpu" 
			runat="server"
		/>
		<br /><br />

		<asp:GridView
			id="userDatabasesPath" 
			runat="server"
		/>
		<br /><br />

		<asp:GridView
			id="logFilesOfDatabases" 
			runat="server"
		/>
    </form>
</body>
</html>
