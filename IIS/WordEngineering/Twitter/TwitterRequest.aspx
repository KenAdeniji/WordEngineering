<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TwitterRequest.aspx.cs" Inherits="WordEngineering.TwitterRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Twitter</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="screen_nameLabel" AssociatedControlID="screen_name">Screen Name:</asp:Label>  
        <asp:TextBox runat="server" ID="screen_name" />
        <asp:Button runat="server" ID="queryRequest" Text="Query" OnClick="QueryRequest_Click"/>
        <br />
        <asp:Literal runat="server" ID="resultSet"></asp:Literal>
    </div>
    </form>
</body>
</html>
