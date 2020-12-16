<%@ Page 
    Language="C#" 
    AutoEventWireup="true"
    CodeFile="Logout.aspx.cs"
    Inherits="Membership_Logout"
    Title="Logout"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Logout</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="alignCenter">
            You have been logged out.
            <asp:HyperLink
                ID="Login"
                runat="server"
                NavigateUrl="~/Default.aspx"
                Text="Log back in."
            />
        </div>
    </form>
</body>
</html>