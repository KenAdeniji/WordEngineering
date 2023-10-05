<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UriView.aspx.cs" Inherits="WordEngineering.UriView" %>

<%@ Register Assembly="UtilityProtocol" Namespace="WordEngineering" TagPrefix="UtilityProtocol" %>

<html>
	<head>
		<title>URI View</title>
	</head>
	<body>
		<form 
			ID="formURI" 
			runat="server"
			enctype="multipart/form-data"    
			autocomplete="on"
			defaultbutton="ButtonSubmit"
			defaultfocus="DropDownListTableName"
		>

		<table align="center" border="0">
		<tbody>
			<asp:Panel
				runat="server"
				id="PanelSearchQuery"
				BackColor="gainsboro"
			>
				<tr align="center">
					<td align="center" colspan=2>
						Search Query
					</td>
				</tr>

				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"       
							id="LabelTableName"
							Text="<u>T</u>able Name:"
							AccessKey="T"
							AssociatedControlId="DropDownListTableName"
						/>
					</td>
					<td align="left"> 
						<asp:SqlDataSource
							ID="SqlDataSourceTable" 
							Runat="server"
							ConnectionString="<%$ ConnectionStrings:URI %>"
							SelectCommand="SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME"
						/>

						<asp:DropDownList
							runat="Server"
							ID="DropDownListTableName"
							DataSourceID="SqlDataSourceTable"
							DataTextField="Table_Name"
							DataValueField="Table_Name"
						/>        
					</td>
				</tr>
	  
				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"       
							id="LabelURI"
							Text="<u>U</u>RI:"
							AccessKey="U"
							AssociatedControlId="TextBoxURI"
						/>
					</td>
					<td align="left">       
						<asp:TextBox
							ID="TextBoxURI"
							runat="Server"
						/>        
					</td>
				</tr>
      
				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"       
							id="LabelTitle"
							Text="<u>T</u>itle:"
							AccessKey="T"
							AssociatedControlId="TextBoxTitle"
						/>
					</td>
       
					<td align="left">       
						<asp:TextBox
							ID="TextBoxTitle"
							runat="Server"
						/>        
					</td>
				</tr>

				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"       
							id="LabelKeyword"
							Text="<u>K</u>eyword:"
							AccessKey="K"
							AssociatedControlId="TextBoxKeyword"
						/>
					</td>
					<td align="left">
						<asp:TextBox
							ID="TextBoxKeyword"
							runat="Server"
						/>        
					</td>
				</tr>
				
				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"       
							id="LabelDated"
							Text="<u>D</u>ated:"
							AccessKey="D"
							AssociatedControlId="TextBoxDatedFrom"
						/>
					</td>
					<td align="left">        
						<asp:TextBox
							ID="TextBoxDatedFrom"
							runat="Server"
						/>
						-
						<asp:TextBox
							ID="TextBoxDatedTo"
							runat="Server"
						/>
					</td>
				</tr>
				
				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"       
							id="LabelSequenceOrderId"
							Text="<u>S</u>equence Order Id:"
							AccessKey="D"
							AssociatedControlId="TextBoxSequenceOrderIdFrom"
						/>
					</td> 
					<td align="left">        
						<asp:TextBox
							ID="TextBoxSequenceOrderIdFrom"
							runat="Server"
						/>
						-
						<asp:TextBox
							ID="TextBoxSequenceOrderIdTo"
							runat="Server"
						/>
					</td>
				</tr>
				<tr align="center">
					<td align="center" colspan="2">
						<asp:Button id="ButtonSubmit" onclick="Submit_Click" runat="server" Text="Submit"/>
						<button onclick="document.getElementById("formURI").reset();">Reset</button>
					</td>     
				</tr>        
			</asp:Panel>
		</tbody>    
		</table>    

		<div align="center">
			<asp:GridView
				id="UriGridView" 
				runat="server" 
				AllowPaging="true"
				AllowSorting="true"
				AutoGenerateColumns=False
				DataKeyNames="URI, sequenceOrderId"
				OnPageIndexChanging="UriGridView_Paging"
				OnSorting="UriGridView_Sorting"
				SelectedIndex=0
				ShowFooter=True
			>
				<HeaderStyle BackColor='#CCCC99'/>

				<RowStyle BackColor='#eeeeee'/>
			
				<AlternatingRowStyle BackColor='#ffffe8'/>

				<Columns>
               
					<asp:TemplateField
						HeaderText="URI"
						SortExpression="URI"
					>
						<ItemTemplate>
							<asp:HyperLink  
								Runat="Server"
								id="HyperLinkGridViewURIItemTemplateURI" 
								NavigateUrl='<%# UtilityProtocol.PrefixProtocol( Eval("URI").ToString() ) %>'
								Text='<%# Eval("URI") %>'
								Target="_blank"
							/>  
						</ItemTemplate>
					</asp:TemplateField>

					<asp:BoundField
						DataField="Title"
						HeaderText="Title"
						ItemStyle-HorizontalAlign="Left"
						SortExpression="Title"
					/>
					
					<asp:BoundField
						DataField="Keyword"
						HeaderText="Keyword"
						ItemStyle-HorizontalAlign="Left"
						SortExpression="Keyword"
					/>

					<asp:BoundField 
						DataField="Dated"
						DataFormatString="{0:s}"
						HeaderText="Dated"
						HtmlEncode="false"
						ItemStyle-HorizontalAlign="Left"						
						SortExpression="Dated"						
					/>
					
					<asp:BoundField
						DataField="SequenceOrderId"
						HeaderText="SequenceOrderId"
						ItemStyle-HorizontalAlign="Left"
						SortExpression="SequenceOrderId"
					/>

				</Columns>
			</asp:GridView>
		</div>
	  
		<div align="center">
			<asp:Literal id="feedBack" runat="server" />
		</div>
		</form>
	</body>
</html>
