<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResponseHeaders.aspx.cs" Inherits="WordEngineering.Network.ResponseHeaders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Response Headers</title>
</head>
<body style="background-color:blue; color:yellow">
    <form id="form1" runat="server">
        <div align="center">
			<asp:Label
				id="LabelServer"
				runat="server" 
				AssociatedControlID="uri"
				Text="Universal Resource Index (URI):" 
			/>
			&nbsp;&nbsp;&nbsp;	
			<asp:TextBox
				id="uri"
				runat="server"
			/>            
			<br><br>
			<asp:Button
				ID="QuerySubmit"
				runat="server"
				Text="Query Submit"
				OnClick="QuerySubmit_Click"
			/>
			<input
				id="clear"
				onclick="document.forms[0].reset();" 
				type="button"
				value="Reset"
			/>
			<br><br>	
			<asp:TextBox id="feedback" TextMode="multiline" runat="server" columns="80" rows="25" />
        </div>
    </form>
</body>
</html>
