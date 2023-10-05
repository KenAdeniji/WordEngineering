<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeFile="StudentClass.aspx.cs"
    Inherits="StudentClass" 
    ValidateRequest="false" 
%>

<%@ Import Namespace="System.Data.Entity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Class</title>
    <style type="text/css">
        tr:nth-child(even) {background: #FFD700} tr:nth-child(odd) {background: #F5F5DC} 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView 
            id="GridViewStudentClass"
            runat="server"
            AutoGenerateEditButton="true"
            AutoGenerateColumns="false"
            DataKeyNames="ID"
            ItemType="InformationInTransit.ProcessLogic.StudentClass.Student"

            OnRowEditing="StudentClassGridView_RowEditing"         
            OnRowCancelingEdit="StudentClassGridView_RowCancelingEdit" 
            OnRowUpdated="StudentClassGridView_RowUpdated"
            OnRowUpdating="StudentClassGridView_RowUpdating"
        >
            <Columns>
                <asp:TemplateField HeaderText="ID" SortExpression="ID">
                    <EditItemTemplate>
                        <asp:Label
                            ID="labelID"
                            runat="server"
                            Text="<%#: Item.ID %>"
                        />
                    </EditItemTemplate>
                    <ItemTemplate><%#: Item.ID %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                    <EditItemTemplate>
                        <asp:TextBox
                            ID="textBoxFirstName"
                            runat="server"
                            Text="<%#: BindItem.FirstName %>"
                        />
                    </EditItemTemplate>
                    <ItemTemplate><%#: Item.FirstName %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastName" SortExpression="LastName">
                    <EditItemTemplate>
                        <asp:TextBox
                            ID="textBoxLastName"
                            runat="server"
                            Text="<%#: BindItem.LastName %>"
                        />
                    </EditItemTemplate>
                    <ItemTemplate><%#: Item.LastName %></ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Literal ID="feedback" runat="server" />
    </div>
    
    </form>
</body>
</html>
