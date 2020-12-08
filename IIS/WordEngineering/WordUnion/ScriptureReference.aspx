<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScriptureReference.aspx.cs" Inherits="ScriptureReferencePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>Scripture Reference</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align=center>
        <asp:TextBox 
            ID="question"
            runat="server"
			columns="70"
        />                        
        <asp:Button
            ID="submit"
			runat="server"
			OnClick="Submit_Click"
			Text="Submit"
		/>
		<br />
		<asp:Literal
			id="resultSet" 
			runat="server"
		/>
    </div>
    </form>
</body>
</html>
