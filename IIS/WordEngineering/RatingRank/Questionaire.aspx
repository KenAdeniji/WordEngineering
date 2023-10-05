<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Questionaire.aspx.cs" Inherits="Questionaire" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Questionaire</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tbody>
                <tr>
					<td align="center">
                        <asp:Label runat="server" ID="labelUri">Uri:</asp:Label>
                    </td>
					<td align="center">
                        <asp:TextBox runat="server" ID="uri" Columns="50" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
