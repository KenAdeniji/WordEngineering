<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebServiceX_USZip.aspx.cs" Inherits="WebServiceRequester_WebServiceX_USZip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebServiceX.net USZip</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
	<table>
		<tr>
			<td>
				<asp:DropDownList id="operation" runat="server" />
			</td>
			<td>
				<asp:TextBox id="entry" runat="server" />
			</td>
		</tr>

		<tr>
			<td align="right" colspan="2">
				<asp:Button id="submitQuery" runat="server" Text="Submit" onClick="SubmitQuery_Click" />
			</td>
		</tr>
	</table>
    </div>
    <div>
        <asp:GridView ID="gridView" runat="server" />
    </div>
    </form>
</body>
</html>
