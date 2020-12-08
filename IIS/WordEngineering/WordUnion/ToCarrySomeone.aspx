<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ToCarrySomeone.aspx.cs" Inherits="ToCarrySomeone" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="9432.css" type="text/css" media="screen" />   
    <title>To carry someone</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label
                        ID="labelDatedFrom"
                        runat="server"
                        AssociatedControlID="datedFrom"
                        Text="From (terminus a quo)"
                    />
                </td>
                <td>                    
                    <asp:TextBox 
                        ID="datedFrom"
                        runat="server"
                    />                        
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label
                        ID="labelDatedTo"
                        runat="server"
                        AssociatedControlID="datedTo"
                        Text="To (terminus ad quem)"
                    />
                </td>
                <td>                    
                    <asp:TextBox 
                        ID="datedTo"
                        runat="server"
                    />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label
                        ID="labelTimed"
                        runat="server"
                        AssociatedControlID="timed"
                        Text="Time"
                    />
                </td>
                <td>                    
                    <asp:TextBox 
                        ID="timed"
                        runat="server"
                    />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button
                        ID="submit"
                        runat="server"
                        OnClick="Submit_Click"
                        Text="Submit"
                    />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label
                        ID="daysTotalLabel"
                        runat="server"
						Text="Days Total"
                    />
                </td>
				<td>
                    <asp:Label
                        ID="daysTotal"
                        runat="server"
                    />
                </td>
            </tr>
<!--
            <tr>
                <td>
                    <asp:Label
                        ID="timedRatioLabel"
                        runat="server"
						Text="Timed Ratio (%)"
                    />
                </td>
				<td>
                    <asp:Label
                        ID="timedRatio"
                        runat="server"
                    />
                </td>
            </tr>
-->			
            <tr>
                <td>
                    <asp:Label
                        ID="timedPercentageLabel"
                        runat="server"
						Text="Timed Percentage (%)"
                    />
                </td>
				<td>
                    <asp:Label
                        ID="timedPercentage"
                        runat="server"
                    />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label
                        ID="daysTimedLabel"
                        runat="server"
						Text="Days Timed"
                    />
                </td>
				<td>
                    <asp:Label
                        ID="daysTimed"
                        runat="server"
                    />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label
                        ID="datedIntervalLabel"
                        runat="server"
						Text="Dated Interval"
                    />
                </td>
				<td>
                    <asp:Label
                        ID="datedInterval"
                        runat="server"
                    />
                </td>
            </tr>
            <tr>
 				<td colspan="2">
                    <asp:Label
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
