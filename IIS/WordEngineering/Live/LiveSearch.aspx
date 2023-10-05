<%@ Page
    Language="C#"
    AutoEventWireup="true"
    CodeFile="LiveSearch.aspx.cs"
    Inherits="LiveSearch"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Live Search</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />    
        <div>
            <asp:TextBox ID="question" runat="server" />
            <asp:Button ID="search" runat="server" OnClick="Search_Click" Text="Search" />
        </div>
        <div>
            <asp:Repeater ID="suggestions" runat="server">
                <ItemTemplate>
                    <asp:HyperLink
                        ID="suggestionUrl"
                        runat="server"
                        NavigateUrl='<%# Request.CurrentExecutionFilePath + 
                                        "?q=" +
                                        DataBinder.Eval(Container, "DataItem")
                                    %>'
                        Text='<%# DataBinder.Eval(Container, "DataItem") %>'
                    />                        
                </ItemTemplate>
                <SeparatorTemplate>, </SeparatorTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:DataList
                ID="results"
                runat="server"
            >
                <ItemTemplate>
                    <asp:HyperLink
                        ID="resultUrl"
                        runat="server"
                        NavigateUrl='<%# Eval("Url") %>'
                        Text='<%# Eval("Title") %>'
                    />
                    <br />
                    <%# Eval("Description") %>
                </ItemTemplate>                
            </asp:DataList>                
        </div>        
    </form>
</body>
</html>