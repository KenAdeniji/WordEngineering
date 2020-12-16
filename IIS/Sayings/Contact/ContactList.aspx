<%@ Page 
    Language="C#"
    MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="true"
    CodeFile="ContactList.aspx.cs"
    Inherits="WordEngineering.Contact_ContactList"
    Title="Contacts List"
%>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderActionMenu" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" AsyncPostBackTimeout="300" />
	<div>
		<asp:UpdatePanel
			ID="updatePanelContentPage"
			runat="server"
			UpdateMode="Conditional">
			<ContentTemplate>
				<div style="margin-left:0px; margin-right:auto;">
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
				</div>
				<div style="margin-left:0px; margin-right:auto; float:left;">
					<asp:GridView ID="gridViewContact" runat="server"  
						AutoGenerateColumns="False"  
						GridLines="None"  
						AllowPaging="true"  
						CssClass="mGrid"  
						PagerStyle-CssClass="pgr"  
						AlternatingRowStyle-CssClass="alt"
						OnSelectedIndexChanged="gridViewContact_SelectedIndexChanged" 
					>  
						<Columns>  
							<asp:TemplateField ShowHeader="False">
								<ItemTemplate>
									<asp:LinkButton
										id="ItemTemplateFullname"
										runat="server"
										Text='<%# Eval("Fullname") %>'
										CausesValidation="false"
									/>
								</ItemTemplate>
							</asp:TemplateField>
							<asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="HiddenColumn" HeaderStyle-CssClass="HiddenColumn"/>
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

					<asp:Literal
						ID="feedback"
						runat="server"
					/>
				</div>

				<div style="margin-left:0px; margin-right:auto; float:left;">
					<asp:FormView ID="formViewContact" runat="server">
					    <ItemTemplate>
							<hr />
							<table border="0">
								<tr>
									<td class="Label">Dated:</td>
									<td class="Value">
									  <%# Eval("Dated") %>
									</td>
								</tr>
							</table>
							<hr />
						</ItemTemplate>
					</asp:FormView>		
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>	
	</div>
</asp:Content>
