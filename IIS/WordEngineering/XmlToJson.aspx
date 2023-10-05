<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeFile="XmlToJson.aspx.cs"
    Inherits="XmlToJson" 
    ValidateRequest="false" 
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Xml to Json</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:textbox id="xmlContent" runat="server" textmode="multiline" rows="12" columns="60" style="width:515px; background: #FFD700"/>
    </div>
    <div>
		<asp:button id="xml2Json" runat="server" text="Convert XML to JSON" onClick="Xml2Json_Click"/>
    </div>
    <div>
        <asp:Literal ID="feedback" runat="server" />
    </div>
    <div>
		<asp:textbox id="jsonContent" runat="server" textmode="multiline" rows="12" columns="60" style="width:515px; background: #F5F5DC"/>
    </div>
    </form>
</body>
</html>
