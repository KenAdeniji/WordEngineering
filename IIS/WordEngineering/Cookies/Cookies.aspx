<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeFile="Cookies.aspx.cs"
    Inherits="WordEngineering.CookiesPage" 
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cookies</title>
</head>
<body>
	<style>
		body{ background-color: Beige; color: DarkGray;  }
	</style>	
    <form id="form1" runat="server">
    <div>
		<asp:Literal ID="feedBack" runat="server" /><br/>
    </div>
    </form>
</body>
</html>
