<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TechnoratiAPI.aspx.cs" Inherits="TechnoratiAPI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Technorati API</title>
</head>
<body>
    <form id="form1" runat="server">

        <%--div tag for css layout--%>

        <div style="float:left;">
            <div style="padding:3px">
                <asp:Label
                    ID="Query"
                    runat="server"
                    AssociatedControlID="query"
                    Text="Query"
                />
            </div>
            <div style="padding:3px">
                <asp:Label
                    ID="labelUrl"
                    runat="server"
                    AssociatedControlID="url"
                    Text="Url"
                />
            </div>
            <div style="padding:3px">
                <asp:Label
                    ID="labelKeyword"
                    runat="server"
                    AssociatedControlID="keyword"
                    Text="Keyword"
                />
            </div>
            <div style="padding:3px">
                <asp:Label
                    ID="labelUsername"
                    runat="server"
                    AssociatedControlID="username"
                    Text="Username"
                />
            </div>
        </div>
        
        <div style="float:left;">
            <div style="padding:3px">
                <asp:DropDownList 
                    ID="technoratiQuery"
                    runat="server"
                    DataTextField="value"
                    DataValueField="key" 
                />
            </div>
            <div style="padding:3px">
                <asp:TextBox
                    ID="url"
                    runat="server" 
                    Columns="50"
                    Text="Technorati.com"
                />
            </div>
            <div style="padding:3px">
                <asp:TextBox
                    ID="keyword"
                    runat="server" 
                    Columns="50"
                />
            </div>
            <div style="padding:3px">
                <asp:TextBox
                    ID="username"
                    runat="server" 
                    Columns="50"
                />
            </div>
        </div>

<%--        <div style="clear:both">
            <asp:Label
                ID="requestUri" 
                runat="server" 
            />
        </div>
--%>        
        <div style="clear:both;">
            <div style="padding:3px">
                <asp:Button
                    ID="querySubmit"
                    runat="server"
                    OnClick="QuerySubmit_Click"
                    Text="Query Submit" 
                />
            </div>
        </div>

        <div style="clear:both">
            <asp:Label
                ID="resultSet" 
                runat="server" 
            />
        </div>
        
    </form>
</body>
</html>
