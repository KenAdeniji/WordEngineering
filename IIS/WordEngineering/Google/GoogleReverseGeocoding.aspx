<%@ Page 
    Language="C#" 
    AutoEventWireup="true"
    CodeFile="GoogleReverseGeocoding.aspx.cs"
    Inherits="GoogleReverseGeocoding"
	Async="true"
	AsyncTimeout="180"
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
   <title>Google Reverse Geocoding</title>
</head>

<body>
<form runat="server">
	<asp:Literal runat="server" ID="Feedback" />
</form>	
</body>
</html>
