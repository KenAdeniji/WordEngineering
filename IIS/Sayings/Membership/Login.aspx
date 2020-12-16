<%@ Page 
    Language="C#"
    AutoEventWireup="true"
    CodeFile="Login.aspx.cs"
    Inherits="Membership_Login"
    Title="Log In"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server" />
<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>Log In</legend>
            <asp:Login
                ID="Login1"
                runat="server"
            />
        </fieldset>
    </form>
</body>
</html>