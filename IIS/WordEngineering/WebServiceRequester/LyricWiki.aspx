<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LyricWiki.aspx.cs" Inherits="LyricWiki" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LyricWiki.org</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
<%--        
            <tr>
                <td>Album</td>
                <td><asp:TextBox ID="album" runat="server" /></td>
            </tr>
--%>
            <tr>
                <td>Artist</td>
                <td><asp:TextBox ID="artist" runat="server" /></td>
            </tr>
            <tr>
                <td>Song</td>
                <td><asp:TextBox ID="song" runat="server" /></td>
            </tr>
<%--
            <tr>
                <td>Year</td>
                <td><asp:TextBox ID="year" runat="server" /></td>
            </tr>
            <tr>
                <td>Message</td>
                <td><asp:DropDownList ID="message" runat="server" /></td>
            </tr>
--%>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="search" runat="server" Text="Search" OnClick="Search_Click" />
                    <input name="cancel" type="reset" onclick="document.forms[0].reset();" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <pre>
    <asp:Literal id="feedback" runat="server" EnableViewState="false" />
    </pre>
    
    <br />
    <asp:PlaceHolder ID="placeHolder" runat="server" EnableViewState="false" />
    </form>
</body>
</html>
