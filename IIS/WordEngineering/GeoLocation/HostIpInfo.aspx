<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HostIpInfo.aspx.cs" Inherits="WebServiceRequester_HostIpInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HostIP.info</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>Latitude</td>
                <td><asp:Label ID="latitude" runat="server" /></td>
            </tr>
            <tr>
                <td>Longitude</td>
                <td><asp:Label ID="longitude" runat="server" /></td>
            </tr>
            <tr>
                <td>Country Name</td>
                <td><asp:Label ID="countryName" runat="server" /></td>
            </tr>
            <tr>
                <td>Country Code</td>
                <td><asp:Label ID="countryCode" runat="server" /></td>
            </tr>
            <tr>
                <td>Name</td>
                <td><asp:Label ID="suburb" runat="server" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

