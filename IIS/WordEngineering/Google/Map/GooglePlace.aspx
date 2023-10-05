<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GooglePlace.aspx.cs" Inherits="GooglePlace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat="server">
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8″ />
<title>Google Place</title>
</head>
<body>
<form runat="server">
<!--
https://maps.googleapis.com/maps/api/place/search/json?location=-33.8670522,151.1957362&radius=7500&types=library&sensor=false&key=AIzaSyA3s7tNLie9_XAyKwzl8sGypCllGrkEqu8
-->
    <fieldset>
        <legend>Query</legend>
        <table>
            <tbody>
            <tr>
                <td>Latitude:</td>
                <td><asp:TextBox runat="server" ID="latitude" /></td>
                <td>Longitude:</td>
                <td><asp:TextBox runat="server" ID="longitude" /></td>
                <td>Radius:</td>
                <td><asp:TextBox runat="server" ID="radius" /></td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                Types: 
                <asp:TextBox runat="server" ID="types" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                (For example, "park", "library", "local_government_office", "establishment"): 
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6"><asp:Button ID="query" runat="server" Text="Query" OnClick="Query_Click" /></td>
            </tr>
            </tbody>
        </table>
    </fieldset>
    <div id="feedback" runat="server" />
</form>
</body>
</html>
