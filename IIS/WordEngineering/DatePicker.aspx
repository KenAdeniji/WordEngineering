<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.aspx.cs" Inherits="WordEngineering.DatePicker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Using jQuery UI from the CDN</title>  
	<link type="text/css" rel="Stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.7/themes/redmond/jquery-ui.css" />  
</head>
<body>
    <form id="form1" runat="server">
        <div>  
            <asp:TextBox ID="txtStartDate" ClientIDMode="Static" runat="server" />  
        </div>  
    </form>
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>  
	<script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.7/jquery-ui.js"></script>  
	<script type="text/javascript">
	    $("#txtStartDate").datepicker();  
    </script>  
</body>
</html>
