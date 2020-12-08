<%@ Page 
    Language="C#" 
    AutoEventWireup="true"
    CodeFile="GoogleOpenID.aspx.cs"
    Inherits="GoogleOpenID" 
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
   <title>Google OpenID</title>
</head>

<body>
<form runat="server">
	<asp:Button 
		ID="googleLogin"
		runat="server"
		CommandArgument="https://www.google.com/accounts/o8/id"
        OnCommand="GoogleLogin_Click" 
		Text="Sign In with Google" 
	/>
</form>	
</body>
</html>
