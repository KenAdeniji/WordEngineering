<%@ Page 
	Language="C#"
	AutoEventWireup="true"
	CodeFile="FindInefficientQueryPlansPage.aspx.cs"
	Inherits="FindInefficientQueryPlansPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Find Inefficient Query Plans</title>
	<style>
		tr th {background-color:yellow; color:gray;}
		tr:nth-child(even) {background-color:blanchedalmond; color:blue;}
		tr:nth-child(odd) {background-color:beige; color:black;} 
	</style>
</head>
<body>
    <form id="form1" runat="server">
		<asp:GridView
			id="uptime_Information" 
			runat="server"
		/>
		<br><hr><br>
		
		<asp:GridView
			id="overallByTotalCPUTime" 
			runat="server"
		/>
		<br><hr><br>
		
		<asp:GridView
			id="overallByAverageCPUTimePerExec" 
			runat="server"
		/>
		<br><hr><br>
		
		<asp:GridView
			id="overallByTotalReadIOs" 
			runat="server"
		/>
		<br><hr><br>
		
		<asp:GridView
			id="overallByAverageReadIOsPerExec" 
			runat="server"
		/>
		<br><hr><br>
		
		<asp:GridView
			id="overallByTotalRecompiles" 
			runat="server"
		/>
		<br><hr><br>
		
		<asp:GridView
			id="overallByAverageRecompilesPerExec" 
			runat="server"
		/>
		<br><hr><br>
		
		<asp:GridView
			id="overallMostExecutions" 
			runat="server"
		/>
    </form>
</body>
</html>
