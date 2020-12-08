<%@ Page 
	Language="C#"
	AutoEventWireup="true"
	CodeFile="HowToCalculateTheIncreasingPercentageOfSalesEachMonthPage.aspx.cs"
	Inherits="HowToCalculateTheIncreasingPercentageOfSalesEachMonthPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to combine multiple rows into one row by a same column value</title>
	<style>
		tr th {background-color:yellow; color:gray;}
		tr:nth-child(even) {background-color:blanchedalmond; color:blue;}
		tr:nth-child(odd) {background-color:beige; color:black;} 
	</style>
</head>
<body>
    <form id="form1" runat="server">
		<asp:GridView
			id="sampleData" 
			runat="server"
		/>
		<br /><br />
		
		<asp:GridView
			id="resultSet" 
			runat="server"
		/>
    </form>
</body>
</html>
