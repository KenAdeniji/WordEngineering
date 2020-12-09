<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeFile="ContactsList.ascx.cs"
    Inherits="WordEngineering.UC_Contacts_ContactsList" 
%>

<asp:GridView
	ID="GridViewContact"
	Runat="server"
	AllowPaging="True"
	DataKeyNames="ContactId"
	AutoGenerateColumns="False"
	OnPageIndexChanging="GridView_PageIndexChanging"
	OnPageIndexChanged="GridView_PageIndexChanged"
> 
	<Columns>
		<asp:TemplateField>
			<HeaderTemplate>
				<asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
			</HeaderTemplate>
			<ItemTemplate>
				<asp:CheckBox runat="server" ID="RowLevelCheckBox" />
				<input
					id="ContactId"
					runat="server"
					type="hidden"
					value='<%# Eval("ContactId") %>' 
				/>
			</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField ShowHeader="False">
			<ItemTemplate>
				<asp:LinkButton
					id="ItemTemplateNicknameOrFullname"
					runat="server"
					Text='<%# Eval("NicknameOrFullname") %>'
					OnClick="ItemTemplateNicknameOrFullname_Click"
					CausesValidation="false"
				/>
			</ItemTemplate>
		</asp:TemplateField>
	</Columns>
	<EmptyDatatemplate>
		<asp:Label
			id="EmptyDataTemplate"
			runat="server"
			Text="No match found."
		/>    
	</EmptyDataTemplate>
	<SelectedRowStyle
	    backColor="LightCyan"
	    foreColor="DarkBlue"
	    font-bold="true"
    /> 
</asp:GridView>