<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YahooQuote.aspx.cs" Inherits="Yahoo_YahooQuote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Yahoo stock quote</title>
</head>
<body>
    <form id="form2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>

    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="False">
      <ContentTemplate>
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal">
          <itemtemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Symbol") %>'>
            </asp:Label>
            &nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Bind("Quote") %>'>
            </asp:Label>
            &nbsp;|&nbsp;
          </itemtemplate>
        </asp:DataList>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
      </ContentTemplate>
      <triggers>
        <asp:asyncpostbacktrigger ControlID="Timer1" EventName="Tick" />
      </triggers>
    </asp:UpdatePanel>
    <asp:Timer ID="Timer1" runat="server" Interval="10000" ontick="Timer1_Tick">
    </asp:Timer>
    </form>
</body>
</html>