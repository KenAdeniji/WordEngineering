<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeFile="NumberConverter.aspx.cs"
    Inherits="WordEngineering.NumberConverterPage" 
    ValidateRequest="false" 
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Number Converter</title>
</head>
<body>
	<style>
		body{ background-color: Beige; color: DarkGray;  }
	</style>	
    <form id="form1" runat="server">
    <div>
		<asp:DropDownList
			id="dropDownListBase" 
			Width="100px" 
            runat="server"/><br/>
		<asp:TextBox ID="source" runat="server" /><br/>
		<asp:Button ID="submit" runat="server" Text="Submit" OnClick="Submit_Click" /><br/>
		<asp:Literal ID="feedBack" runat="server" /><br/>
    </div>
    </form>
</body>
</html>
