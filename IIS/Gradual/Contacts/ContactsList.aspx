
<%@ Page 
    Language="C#"
    MasterPageFile="~/MasterPages/MasterPage.master"
    AutoEventWireup="true"
    CodeFile="ContactsList.aspx.cs"
    Inherits="WordEngineering.Contacts_ContactsList"
    Title="Contacts List"
%>

<%@ Register Src="~/UC/Contacts/ContactDisplay.ascx" TagName="ContactDisplay" TagPrefix="WordEngineering" %>
<%@ Register Src="~/UC/Contacts/ContactForm.ascx" TagName="ContactForm" TagPrefix="WordEngineering" %>
<%@ Register Src="~/UC/Contacts/ContactsList.ascx" TagName="ContactsList" TagPrefix="WordEngineering" %>
<%@ Register Src="~/UC/Menus/Header.ascx" TagName="HeaderMenu" TagPrefix="WordEngineering" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" AsyncPostBackTimeout="300" />
	<div>
		<asp:UpdatePanel
			ID="updatePanelContentPage"
			runat="server"
			UpdateMode="Conditional">
			<ContentTemplate>
            	<div style="margin-left:0px; margin-right:auto;">
                    <WordEngineering:HeaderMenu ID="HeaderMenu1" runat="server" />
	            </div>
				<table style="margin-left:0px; margin-right:auto;">
					<tr>
						<td>
							<asp:TextBox 
							    ID="Query"
							    runat="server"
							    Columns="55"
							    MaxLength="2048"
							/>
                            <asp:Button
								ID="Search"
								runat="server"
								Text="Search"
								OnClick="Search_OnClick"
							/>
						</td>
					</tr>
				</table>
				<table style="margin-left:0px; margin-right:auto;">
					<tr>
						<td valign="top">
							<WordEngineering:ContactsList 
								ID="ContactsList1"
								runat="server" />
						</td>
						<td valign="top">
						    <WordEngineering:ContactDisplay
						        ID="ContactDisplay1"
						        runat="server" />
						</td>
						<td valign="top">
						    <WordEngineering:ContactForm
						        ID="ContactForm1"
						        runat="server"
						        Visible="false" />
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>	
	</div>
</asp:Content>