<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebLogIPWhoIs.aspx.cs" Inherits="WebServiceRequester_WebLogIPWhoIs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"> 

<head id="Head1" runat="server"> 
    <title>Web Log IP WhoIs</title>
    <style type="text/css">
        body { font-family:Verdana;font-size:76%; }
        pre { font-size:10pt; }
        span { cursor:pointer; }
        #dns { float:left; }
        #calendar{ float:left;width:350px; }
        #loading { left:300px;z-index:100;position:absolute; }
    </style>
</head> 

<body> 
    <form id="form1" runat="server">
    <div id="calendar">
      <asp:Calendar ID="Calendar1" runat="server"
        onselectionchanged="Calendar1_SelectionChanged" />
      <asp:Literal ID="ip_addresses" runat="server" />
    </div>

    <div id="dns"></div>
    <div id="loading"></div>
    </form>
    
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script> 
    <script type="text/javascript">
        $(document).ready(function() {
            $("span").each(function() {
                $(this).click(function() {
                    $("#loading").html("<img src=\"http://bloggerbuster.com/images/loading.gif\"/>");
                    $("#dns").empty();
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        data: "{ip: '" + $(this).html() + "'}",
                        url: "WebLogIPWhoIs.aspx/GetWhois",
                        dataType: "json",
                        success: function(response) {
                            $("#loading").empty();
                            $("#dns").html(response.d);
                        }
                    });
                });
            });
        });
    </script> 
</body> 
</html>
 
