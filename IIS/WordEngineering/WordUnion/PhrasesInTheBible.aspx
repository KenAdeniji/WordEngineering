<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhrasesInTheBible.aspx.cs" Inherits="PhrasesInTheBible" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Phrases in the Bible</title>
	<link rel="stylesheet" type="text/css" href="9432.css">
</head>
<body>
    <form id="form1" runat="server">
	<div align="center">
		<asp:GridView
			runat="server"
			ID="gridViewPhrasesInTheBible"
			AllowSorting="true" 
			OnSorting="GridViewPhrasesInTheBible_Sorting"
		/>	
	</div>
    </form>
</body>
</html>
