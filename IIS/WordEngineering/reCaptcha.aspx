<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeFile="recaptcha.aspx.cs"
    Inherits="RecaptchaPage" 
    ValidateRequest="false" 
%>

<%@ register tagprefix="recaptcha" namespace="Recaptcha" assembly="Recaptcha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recaptcha</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<recaptcha:recaptchacontrol
			id="recaptcha" 
			runat="server"
			publickey="6LfIZNUSAAAAAJ-h-D1aJPkjBGZjjXyGRQ33vJCc"
			privatekey="6LfIZNUSAAAAABwEN6bQ0aDad5vzeRnQaBE2Uu_D"
		/>
		<asp:Label ID="feedBack" runat="server" />
		<asp:Button ID="submit" runat="server" Text="Submit" OnClick="Submit_Click" />
    </div>
    </form>
</body>
</html>
