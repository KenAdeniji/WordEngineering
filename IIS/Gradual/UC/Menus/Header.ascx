<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeFile="Header.ascx.cs"
    Inherits="WordEngineering.UC_Menus_Header" 
%>

<span id="Initiate" runat="server">
    <asp:LinkButton
        id="New"
        runat="server"
        Text="New"
        OnClick="MenuNew_Click"
        CausesValidation="false"
    />

    <asp:LinkButton
        id="Edit"
        runat="server"
        Text="Edit"
        OnClick="MenuEdit_Click"
        CausesValidation="false"
    />

    <asp:LinkButton
        id="Delete"
        runat="server"
        Text="Delete"
        OnClick="MenuDelete_Click"
        CausesValidation="false"
    />
</span>

<span id="End" runat="server" style="display: none">
    <asp:LinkButton
        id="Save"
        runat="server"
        Text="Save"
        OnClick="MenuSave_Click"
        CausesValidation="false"
    />

    <asp:LinkButton
        id="Cancel"
        runat="server"
        Text="Cancel"
        OnClick="MenuCancel_Click"
        CausesValidation="false"
    />
</span>