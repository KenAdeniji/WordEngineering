<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ToMostExtentOfTalent.aspx.cs" Inherits="ToMostExtentOfTalent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>To Most Extent of Talent</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tbody>
                <tr>
					<td>Word</td>
					<td>
                        <asp:TextBox runat="server" ID="word" Columns="30" />
                    </td>
                </tr>
                <tr>
					<td>Scripture Reference</td>
					<td>
                        <asp:TextBox runat="server" ID="scriptureReference" Columns="70" />
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
			ID="toMostExtentOfTalentGridView"
			AllowSorting="true" 
			OnSorting="ToMostExtentOfTalentGridView_Sorting"
		/>	
	</div>
    </form>
</body>
</html>
