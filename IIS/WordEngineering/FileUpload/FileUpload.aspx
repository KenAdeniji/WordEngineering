<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="FileUpload_FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload</title>
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
                    <input type="file" id="fileUpload" multiple="multiple" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button
                        runat="server"
                        ID="submit"
                        Text="File Upload"
                        OnClick="Submit_Click"
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
