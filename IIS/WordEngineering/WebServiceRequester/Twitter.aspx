<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Twitter.aspx.cs" Inherits="WebServiceRequester_Twitter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Twitter</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <asp:label
            runat="server"
            id="labelUserName"
            associatedControlId="userName"
            text="User name"
        />
        <asp:TextBox runat="server" ID="userName" />
        <asp:Button
            runat="server"
            ID="search"
            OnClick="Search_Click"
            Text="Search" 
        />
    </div>
    <asp:ListView
        ID="resultSet"
        runat="server"
     >
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Id</th>
                    <th>Text</th>
                    <th>Date</th>
                </tr>
                <tr runat="server" id="itemPlaceHolder" />
            </table>
        </LayoutTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color:#FFFFFF; color:#284775;">
                <td><asp:Label ID="id" runat="server" Text='<%# Eval("Id") %>' /></td>
                <td><asp:Label ID="text" runat="server" Text='<%# Eval("Text") %>' /></td>
                <td><asp:Label ID="date" runat="server" Text='<%# Eval("Date") %>' /></td>
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr style="background-color:#E0FFFF; color:#333333;">
                <td><asp:Label ID="id" runat="server" Text='<%# Eval("Id") %>' /></td>
                <td><asp:Label ID="text" runat="server" Text='<%# Eval("Text") %>' /></td>
                <td><asp:Label ID="date" runat="server" Text='<%# Eval("Date") %>' /></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>            
    <div style="text-align:center">
        <asp:Literal
            runat="server"
            ID="exceptionMessage"
        />
    </div>
    </form>
</body>
</html>
