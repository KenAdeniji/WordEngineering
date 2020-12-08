<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YahooWeather.aspx.cs" Inherits="WordEngineering.Yahoo.YahooWeather" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yahoo Weather</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table align="center">
            <tbody>
                <tr>
                    <td align="center">
                        Zip Code
                    </td>
                    <td align="center">
                        <asp:TextBox runat="server" ID="zipCode" Columns="15" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button runat="server" ID="submit" Text="Submit" OnClick="Submit_Click" /> 
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Literal runat="server" ID="forecast" /> 
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
