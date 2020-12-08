<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccessControl.aspx.cs" Inherits="File_AccessControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Access Control</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tr>
                <td>
                    <asp:Label runat="server" ID="labelFileUpload" Text="File" AssociatedControlID="fileUpload" />
                </td>
                <td>
                    <asp:FileUpload runat="server" ID="fileUpload" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button
                        runat="server"
                        ID="accessControlEntries"
                        Text="Access Control Entries"
                        OnClick="AccessControlEntries_Click"
                    />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Literal runat="server" ID="literal" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
