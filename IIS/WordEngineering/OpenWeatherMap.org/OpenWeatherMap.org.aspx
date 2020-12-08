<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenWeatherMap.org.aspx.cs" Inherits="OpenWeatherMapOrgPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OpenWeatherMap.org</title>
    <style>
        body {
            background-color: blue;
            color: yellow;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <table>
            <tr>
                <td>City:</td>
                <td><asp:TextBox ID="city" runat="server" columns="20" /></td>
            </tr>
            <tr>
                <td colspan="2">
					<asp:Button ID="querySubmit" runat="server" Text="Query" onClick="QuerySubmit_Click" />
				</td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="text-align:left">
                        <fieldset>
                            <legend>Weather:</legend>
                            <asp:Literal ID="weatherOutput" runat="server" />
                        </fieldset>
                    </div>
				</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

