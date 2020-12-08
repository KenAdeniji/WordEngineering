<%@ Page
    Language="C#"
    AutoEventWireup="true" 
    CodeFile="Digg.aspx.cs" 
    Inherits="Digg" 
    EnableEventValidation="false" 
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 <%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Digg</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label id="labelList" runat="server" AssociatedControlID="list">  
                        List                
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList
                        id="list"
                        runat="server"
                    >
                        <asp:ListItem Text="Stories" />
                        <asp:ListItem Text="Users" />
                        <asp:ListItem Text="Events" />
                        <asp:ListItem Text="Comments" />
                        <asp:ListItem Text="Topics" />
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label id="labelGet" runat="server" AssociatedControlID="get">  
                        Get                
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList
                        id="get"
                        runat="server"
                    />
                </td>
            </tr>
            
            <ajaxToolkit:CascadingDropDown
                ID="CascadingDropDownListGet"
                runat="server"
                TargetControlID="get"
                ParentControlID="list"
                PromptText="Please select a get"
                ServiceMethod="GetGetForList"
                ServicePath="DiggListGetService.asmx"
                Category="Get"
            />

            <tr>
                <td>
                    <asp:Label id="labelName" runat="server" AssociatedControlID="name">  
                        Name
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox
                        id="name"
                        runat="server"
                    />
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label id="labelUsername" runat="server" AssociatedControlID="username">  
                        Username
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox
                        id="username"
                        runat="server"
                    />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label id="labelId" runat="server" AssociatedControlID="id">  
                        Ids (space separated)
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox
                        id="id"
                        runat="server"
                    />
                </td>
            </tr>
            
            <tr>
                <td align="center" colspan="2">
                    <asp:Button
                        ID="QuerySubmit"
                        runat="server"
                        Text="Query Submit"
                        OnClick="QuerySubmit_Click"
                    />
                    <input
                        id="clear"
                        onclick="document.forms[0].reset();" 
                        type="button"
                        value="Reset"
                    />    
                </td>
            </tr>
            
        </table>
        <div>
            <asp:GridView ID="gridViewDigg" runat="server" />
        </div>
    </form>
</body>
</html>
