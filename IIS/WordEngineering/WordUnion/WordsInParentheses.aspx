<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WordsInParentheses.aspx.cs" Inherits="WordsInParentheses" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Words In Parentheses</title>
	<link rel="stylesheet" type="text/css" href="9432.css">
</head>
<body>
    <form id="form1" runat="server">
	<div align="center">
		<asp:GridView
			runat="server"
			ID="gridViewWordsInParentheses"
			AllowSorting="true" 
			OnSorting="GridViewWordsInParentheses_Sorting"
		/>	
	</div>
    </form>
</body>
</html>
