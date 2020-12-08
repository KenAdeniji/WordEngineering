<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Carlos.aspx.cs" Inherits="Carlos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>Carlos</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tbody>
                <tr align="center">
					<td>
                        <asp:TextBox runat="server" ID="question" Columns="30" />
                        <asp:DropDownList runat="server" ID="accordingTo" />
                        <asp:Button runat="server" ID="submit" Text="Submit" OnClick="Submit_Click" /> 
                    </td>
                </tr>
                <tr>
					<td>
						<asp:GridView
							runat="server"
							ID="exactGridView"
							AllowSorting="true" 
							OnSorting="ExactGridView_Sorting"
						/>	
                    </td>
                </tr>
        </table>
    </div>
    </form>
</body>
</html>
