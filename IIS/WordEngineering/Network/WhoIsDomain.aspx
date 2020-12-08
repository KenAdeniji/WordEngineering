<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WhoIsDomain.aspx.cs" Inherits="WordEngineering.Network.WhoIsDomain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Who is Domain</title>
</head>
<body style="background-color:blue; color:yellow">
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label
                            id="LabelServer"
                            runat="server" 
                            AssociatedControlID="whoIsServer"
                            Text="Server:"
                        />            
                    </td>
                    <td>
                        <asp:TextBox
                            id="whoIsServer"
                            runat="server"
                        />            
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label
                            id="LabelPort"
                            runat="server" 
                            AssociatedControlID="whoIsPort"
                            Text="Port:"
                        />            
                    </td>
                    <td>
                        <asp:TextBox
                            id="whoIsPort"
                            runat="server"
                        />            
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label
                            id="LabelDomain"
                            runat="server" 
                            AssociatedControlID="whoIsDomain"
                            Text="Domain:"
                        />            
                    </td>
                    <td>
                        <asp:TextBox
                            id="whoIsDomain"
                            runat="server"
                        />            
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
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
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Literal
                            ID="feedback"
                            runat="server"
                        />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
