<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnlessOneIsTrueWhereIsTheFound.aspx.cs" Inherits="UnlessOneIsTrueWhereIsTheFoundPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>Unless one is true; where is the found?</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label
                        ID="labelDated"
                        runat="server"
                        AssociatedControlID="datedFrom"
                        Text="Dated"
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
                        ID="labelDuration"
                        runat="server"
                        AssociatedControlID="duration"
                        Text="Duration:"
                    />
                </td>
                <td>                    
                    <asp:TextBox 
                        ID="duration"
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
                        ID="datedTo"
                        runat="server"
                    />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
