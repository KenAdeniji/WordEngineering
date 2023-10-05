<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YouTubeSearch.aspx.cs" Inherits="YouTubeSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>YouTube Search</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="labelTag" runat="server" AssociatedControlID="tag" Text="Tag" />
            <asp:TextBox ID="tag" runat="server" />
            <asp:Button ID="search" runat="server" Text="Query Submit" OnClick="Search_Click" />
        </div>
        <div>
            <asp:GridView ID="gridViewVideo" runat="server" />
        </div>
    </form>
</body>
</html>
