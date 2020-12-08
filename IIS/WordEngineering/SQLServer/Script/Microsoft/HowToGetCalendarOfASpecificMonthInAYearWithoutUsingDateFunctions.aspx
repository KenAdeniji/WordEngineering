<%@ Page 
	Language="C#"
	AutoEventWireup="true"
	CodeFile="HowToGetCalendarOfASpecificMonthInAYearWithoutUsingDateFunctionsPage.aspx.cs"
	Inherits="HowToGetCalendarOfASpecificMonthInAYearWithoutUsingDateFunctionsPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to get calendar of a specific month in a year without using date functions</title>
	<style>
		tr th {background-color:yellow; color:gray;}
		tr:nth-child(even) {background-color:blanchedalmond; color:blue;}
		tr:nth-child(odd) {background-color:beige; color:black;} 
	</style>
</head>
<body>
    <form id="form1" runat="server">
		<fieldset>
			<legend>Year & Month</legend>
			<asp:Label
				id="labelYear"
				text="Year:"
				AssociateId="year"
				runat="server"
			/>
			<asp:TextBox
				id="year"
				runat="server"
			/>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Label
				id="labelMonth"
				text="Month:"
				AssociateId="month"
				runat="server"
			/>
			<asp:TextBox
				id="month"
				runat="server"
			/>
		</fieldset>
		<br/>
		<asp:Button 
			id="query"
			text="Query"
			runat="server"
			onClick="Query_Click"
		/>
		<br/><br/>
		<asp:GridView
			id="resultSet" 
			runat="server"
		/>
    </form>
</body>
</html>
