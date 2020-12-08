<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SQLScript.aspx.cs" Inherits="SQLScript" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL Script</title>
	<style>
		tr th {background-color:yellow; color:black;}
		tr:nth-child(even) {background-color:blanchedalmond; color:blue;}
		tr:nth-child(odd) {background-color:beige; color:black;} 
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tbody>
                <tr>
					<td>Source:</td>
					<td>
                        <asp:DropDownList runat="server" ID="dropDownListSource" />
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
			ID="gridViewSource"
			AllowSorting="true" 
			OnSorting="GridViewSource_Sorting"
		/>	
	</div>
    </form>
</body>
</html>
