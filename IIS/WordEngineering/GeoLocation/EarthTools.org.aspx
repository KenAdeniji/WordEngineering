<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EarthTools.org.aspx.cs" Inherits="WebServiceRequester_EarthTools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EarthTools.org</title>
    <style>
        body {
            background-color: blue;
            color: yellow;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>Latitude:</td>
                <td><asp:TextBox ID="latitude" runat="server" /></td>
                <td>Longitude:</td>
                <td><asp:TextBox ID="longitude" runat="server" /></td>
            </tr>
            <tr>
                <td>Day:</td>
                <td><asp:TextBox ID="dateDay" runat="server" /></td>
                <td>Month:</td>
                <td><asp:TextBox ID="dateMonth" runat="server" /></td>
            </tr>
            <tr>
                <td>Timezone:</td>
                <td><asp:TextBox ID="dateTimezone" runat="server" /></td>
                <td>Daylight saving time (DST):</td>
                <td><asp:CheckBox ID="dateDaylightSavingTimeDST" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="4">
                    Timezone: Hours offset from UTC (from -12 to 14).
                    Alternatively, use '99' as the timezone in order to
                    automatically work out the timezone based on the given
                    latitude/longitude.
                </td>    
            </tr>
            <tr>
                <td colspan="4">
					<asp:Button ID="querySubmit" runat="server" Text="Query" onClick="QuerySubmit_Click" />
				</td>
            </tr>
            <tr>
                <td colspan="4">
                    <div>
                        <fieldset>
                            <legend>Timezone:</legend>
                            <asp:Literal ID="timezoneOutput" runat="server" />
                        </fieldset>
                    </div>
				</td>
            </tr>
            <tr>
                <td colspan="4">
                    <div>
                        <fieldset>
                            <legend>Sunrise And Sunset Times:</legend>
                            <asp:Literal ID="sunriseAndSunsetTimesOutput" runat="server" />
                        </fieldset>
                    </div>
				</td>
            </tr>
            <tr>
                <td colspan="4">
                    <div>
                        <fieldset>
                            <legend>Elevation Height Above Sea Level:</legend>
                            <asp:Literal ID="elevationHeightAboveSeaLevelOutput" runat="server" />
                        </fieldset>
                    </div>
				</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

