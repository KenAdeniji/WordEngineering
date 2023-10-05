<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HisWord.aspx.cs" Inherits="HisWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>HisWord</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tbody>
                <tr>
					<td>Word:</td>
					<td>
                        <asp:TextBox runat="server" ID="word" Columns="50" />
                    </td>
                </tr>
                <tr>
					<td>Commentary:</td>
					<td>
                        <asp:TextBox runat="server" ID="commentary" Columns="50" />
                    </td>
                </tr>
                <tr>
					<td>Dated:</td>
					<td>
                        <asp:TextBox runat="server" ID="datedFrom" Columns="15" />
						-
                        <asp:TextBox runat="server" ID="datedUntil" Columns="15" />
                    </td>
                </tr>
                <tr>
					<td>Contact Id:</td>
					<td>
                        <asp:TextBox runat="server" ID="contactId" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button runat="server" ID="submit" Text="Submit" OnClick="Submit_Click" /> 
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
	<div align="center">
		<asp:GridView
			runat="server"
			ID="hisWordGridView"
			AllowSorting="true" 
			OnSorting="HisWordGridView_Sorting"
		/>	
	</div>
    </form>
</body>
</html>
