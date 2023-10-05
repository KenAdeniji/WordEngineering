<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RSSReader.aspx.cs" Inherits="RSSReader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RSS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="feed">
    
        RSS Feed:
            
        <asp:DropDownList ID="FeedList" 
                          DataValueField="Url"
                          DataTextField="Name"
                          runat="server"/>
                
        <asp:Button ID="ReadBtn" runat="server" Text="Read" onclick="ReadBtn_Click" />
        
    </div>
    
    <br />
        
    <asp:ListView ID="ListView1" runat="server">
    
        <LayoutTemplate>
        
            <table class="gridview">
            
                <th>Published</th>
                <th>Article</th>
                <th>Comments</th>
                <th>Tags</th>
                
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </tbody>
            
            </table>
        
        </LayoutTemplate>
        
        <ItemTemplate>
            <tr>
                <td><%#Eval("Published", "{0:d}") %></td>
                <td>
                    <a href='<%#Eval("Url")%>'><%#Eval("Title") %></a>
                </td>
                <td>
                    <%#Eval("NumComments") %>
                </td>
                <td>
                    <asp:Repeater ID="Repeater1" DataSource='<%#Eval("Tags") %>' runat="server">
                        <ItemTemplate> <%#Container.DataItem %> </ItemTemplate>
                        <SeparatorTemplate>,</SeparatorTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        
        </ItemTemplate>
        
    </asp:ListView>
    </form>
</body>
</html>
