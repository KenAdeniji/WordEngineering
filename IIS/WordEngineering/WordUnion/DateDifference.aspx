<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DateDifference.aspx.cs" Inherits="DateDifference" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>Date Difference</title>
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
                        Text="Date From (terminus a quo)"
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
                        Text="Date To (terminus ad quem)"
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
                <td colspan="2">
                    <asp:Label
                        ID="yearMonthWeekDay"
                        runat="server"
                    />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
