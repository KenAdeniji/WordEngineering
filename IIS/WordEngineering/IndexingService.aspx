<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndexingService.aspx.cs" Inherits="IndexingService" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Indexing Service</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox id="q" runat="server" />
        <asp:Button id="search" Text="Search" runat="server" OnClick="Search_Click" />
        <asp:GridView id="resultSet" runat="server" />
    </div>
    </form>
</body>
</html>
