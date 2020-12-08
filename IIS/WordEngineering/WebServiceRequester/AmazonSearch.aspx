<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AmazonSearch.aspx.cs" Inherits="AmazonSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <title>Amazon Search</title>
 <script language="javascript" type="text/javascript">
	function ProductInfoDetailsItemSelected(item)
	{
	    if (typeof productInfo == "undefined") {return;}
        document.getElementById('<%=productInfoDetailsImage.ClientID%>').src = productInfo[item.selectedIndex][0];
    }
  </script>        
 </head>
<body>
    <form id="form1" runat="server" defaultbutton="Go" defaultfocus="keyword">
    <div>
        <table>
            <tr>
                <td>Search:</td>
                <td>
                    <asp:TextBox ID="keyword" runat="server" columns="25" />
                    <asp:RequiredFieldValidator 
                        id="RequiredFieldValidatorKeyword"
                        runat="server"
                        ControlToValidate="keyword"
                        
                    />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButtonList ID="mode" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem Text="Books" Selected="True" />
                        <asp:ListItem Text="Music" />
                        <asp:ListItem Text="DVSs" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Sort:</td>
                <td><asp:DropDownList ID="sort" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButtonList ID="type" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Essential" Value="lite" Selected="True" />
                        <asp:ListItem Text="All Available" Value="heavy" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Page:</td>
                <td><asp:TextBox ID="pageID" runat="server" /></td>
            </tr>                
            <tr>
                <td>Locale:</td>
                <td><asp:DropDownList ID="locale" runat="server"/></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Go" runat="server" Text="Go" OnClick="Go_Click" CausesValidation="true"/>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:ListBox ID="productInfoDetails" runat="server" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Image ID="productInfoDetailsImage" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>