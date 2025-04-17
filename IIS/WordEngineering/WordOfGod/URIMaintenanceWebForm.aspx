<%@ Page 
	Language="C#" 
	debug=true
	Inherits="WordEngineering.URIMaintenancePage"
%>

<html>
	<head>
		<title>URI Web Form</title>
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
					<td align="center" colspan=2>Search Query</td>
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
						<asp:DropDownList
						 runat="Server"
						 ID="DropDownListTableName"
						 DataSourceID="SqlDataSourceTable"
						 DataTextField="Table_Name"
						 DataValueField="Table_Name"
						 OnPreRender="DropDownListTableName_PreRender"
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
						 id="LabelCommentary"
						 Text="<u>C</u>ommentary:"
						 AccessKey="C"
						 AssociatedControlId="TextBoxCommentary"
						/>
					</td>
					<td align="left">
						<asp:TextBox
						 ID="TextBoxCommentary"
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
							 id="LabelInternetCountryCodeTopLevelDomain_ccTLD"
							 Text="<u>I</u>nternet Country Code Top Level Domain (ccTLD):"
							 AccessKey="I"
							 AssociatedControlId="TextBoxInternetCountryCodeTopLevelDomain_ccTLD"
						/>
					</td>
					<td align="left" colspan="2">
						<asp:TextBox
							 ID="TextBoxInternetCountryCodeTopLevelDomain_ccTLD"
							 runat="Server"
						/>        
					</td>
				</tr>
				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"       
							id="LabelURIReferrer"
							Text="URI Re<u>f</u>errer:"
							AccessKey="F"
							AssociatedControlId="TextBoxURIReferrer"
						/>
					</td>
					<td align="left">
						<asp:TextBox
							 ID="TextBoxURIReferrer"
							 runat="Server"
						/>        
					</td>
				</tr>
				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"       
							id="LabelReferrer"
							Text="<u>R</u>eferrer:"
							AccessKey="R"
							AssociatedControlId="TextBoxReferrer"
						/>
					</td>
					<td align="left">       
						<asp:TextBox
							 ID="TextBoxReferrer"
							 runat="Server"
						/>        
					</td>
				</tr>
				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"       
							id="LabelScriptureReference"
							Text="Scri<u>p</u>ture Reference"
							AccessKey="P"
							AssociatedControlId="TextBoxScriptureReference"
						/>
					</td>
					<td align="left">       
						<asp:TextBox
							 ID="TextBoxScriptureReference"
							 runat="Server"
						/>        
					</td>
				</tr>
				<tr align="center">
					<td align="left">
						<asp:Label
							runat="server"
							id="LabelContactID"
							Text="C<u>o</u>ntact ID"
							AccessKey="O"
							AssociatedControlId="TextBoxContactIDFrom"
						/>
					</td>
					<td align="left">       
						<asp:TextBox
							 ID="TextBoxContactIDFrom"
							 runat="Server"
						/>        
						-
						<asp:TextBox
							 ID="TextBoxContactIDUntil"
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
						 ID="TextBoxDatedUntil"
						 runat="Server"
						/>
					</td>
				</tr>
				<tr align="center">
					<td align="left">
						<asp:Label
						 runat="server"       
						 id="LabelEventDateFrom"
						 Text="<u>E</u>vent Dated:"
						 AccessKey="E"
						 AssociatedControlId="TextBoxEventDateFrom"
						/>
					</td>
					<td align="left">        
						<asp:TextBox
						 ID="TextBoxEventDateFrom"
						 runat="Server"
						/>
						-
						<asp:TextBox
						 ID="TextBoxEventDateUntil"
						 runat="Server"
						/>
					</td>
				</tr>
				<tr align="center">
					<td align="left">
						<asp:Label
						 runat="server"       
						 id="LabelSequenceOrderID"
						 Text="<u>S</u>equence Order ID:"
						 AccessKey="D"
						 AssociatedControlId="TextBoxSequenceOrderIDFrom"
						/>
					</td> 
					<td align="left">        
						<asp:TextBox
							ID="TextBoxSequenceOrderIDFrom"
							runat="Server"
						/>
						-
						<asp:TextBox
							ID="TextBoxSequenceOrderIDUntil"
							runat="Server"
						/>
					</td>
				</tr>
				<tr align="center">
					<td align="center" colspan="2">
						<asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"     runat="server"   Text="Submit"/>
						<asp:Button id="ButtonReset"   onclick="ButtonReset_Click"      runat="server"   Text="Reset"/>
					</td>      
				</tr>        
			</asp:Panel>
		</tbody>    
	</table>    

	<table align="center" border="0">
		<tbody>
			<asp:Panel
				runat="server"
				id="PanelFilenameURI"
				BackColor="gainsboro"
			>
				<tr align="center">
					<td align="center">
						Filename URI:
						<input 
							id="HtmlInputFileURI" 
							type="file" 
							runat="server" 
						/>
						<asp:Button id="ButtonFileOpen"  onclick="ButtonFileOpen_Click"  runat="server"   Text="Open" />
						<asp:Button id="ButtonFileSave"  onclick="ButtonFileSave_Click"  runat="server"   Text="Save" />
					</td>
				</tr>      
			</asp:Panel>
		</tbody>    
   </table>    

					<asp:SqlDataSource
						ID="SqlDataSourceTable" 
						Runat="server"
						ConnectionString="<%$ ConnectionStrings:URI %>"
						SelectCommand="SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME"
					/>
					<asp:SqlDataSource
						ID="SqlDataSourceURIGridView" 
						Runat="server"
						ConnectionString="<%$ ConnectionStrings:URI %>"
						DeleteCommand="EXEC usp_URIDelete @tableName, @sequenceOrderID"
						InsertCommand="EXEC usp_URIInsert @tableName, @uri, @title, @keyword, @commentary, @uriReferrer, @referrer, @contactID, @scriptureReference, @dated, @sequenceOrderID"
						SelectCommandType="StoredProcedure"
						SelectCommand="dbo.usp_URISelect"
						UpdateCommand="EXEC usp_URIUpdate @tableName, @uri, @title, @keyword, @commentary, @uriReferrer, @referrer, @contactID, @scriptureReference, @dated, @sequenceOrderID"
					>
					<deleteparameters>
						<asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
					</deleteparameters>
					<insertparameters>
						<asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="uri" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="title" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="keyword" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="commentary" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="uriReferrer" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="referrer" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="contactID" ConvertEmptyStringToNull=true Type="Int32" />
						<asp:parameter name="scriptureReference" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
						<asp:parameter name="sequenceOrderID" ConvertEmptyStringToNull=true Type="Int32" />
					</insertparameters>
					<selectparameters>
						<asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
						<asp:controlparameter name="uri" controlid="TextBoxURI" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="Input" DefaultValue = "|" />
						<asp:controlparameter name="title" controlid="TextBoxTitle" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="Input"  DefaultValue = "|" />
						<asp:controlparameter name="commentary" controlid="TextBoxCommentary" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="Input"  DefaultValue = "|" />
						<asp:controlparameter name="keyword" controlid="TextBoxKeyword" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="Input" DefaultValue = "|" />
						<asp:controlparameter name="internetCountryCodeTopLevelDomain_ccTLD" controlid="TextBoxInternetCountryCodeTopLevelDomain_ccTLD" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="Input" DefaultValue = "|" />
						<asp:controlparameter name="uriReferrer" controlid="TextBoxUriReferrer" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="Input"  DefaultValue = "|" />						
						<asp:controlparameter name="referrer" controlid="TextBoxReferrer" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="Input"  DefaultValue = "|" />
						<asp:controlparameter name="scriptureReference" controlid="TextBoxScriptureReference" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="Input" Defaultvalue="|"/>					
						<asp:controlparameter name="contactIDFrom" controlid="TextBoxContactIDFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="Input"  DefaultValue = "-1" />
						<asp:controlparameter name="contactIDUntil" controlid="TextBoxContactIDUntil" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="Input"  DefaultValue = "2147483647" />
						<asp:controlparameter name="datedFrom" controlid="TextBoxDatedFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="Input" DefaultValue = "1/1/1753" />
						<asp:controlparameter name="datedUntil" controlid="TextBoxDatedUntil" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="Input" DefaultValue = "12/31/9999" />
						<asp:controlparameter name="sequenceOrderIDFrom" controlid="TextBoxSequenceOrderIDFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="Input" Defaultvalue="-1" />
						<asp:controlparameter name="sequenceOrderIDUntil" controlid="TextBoxSequenceOrderIDUntil" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="Input" Defaultvalue="2147483647" />
						<asp:controlparameter name="eventDateFrom" controlid="TextBoxEventDateFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="Input" DefaultValue = "1/1/1753" />
						<asp:controlparameter name="eventDateUntil" controlid="TextBoxEventDateUntil" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="Input" DefaultValue = "12/31/9999" />
					</selectparameters>
					<updateparameters>
						<asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="uri" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="title" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="keyword" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="commentary" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="uriReferrer" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="referrer" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="contactID" ConvertEmptyStringToNull=true Type="Int32" />
						<asp:parameter name="scriptureReference" ConvertEmptyStringToNull=true Type="string" />
						<asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
						<asp:parameter name="sequenceOrderID" ConvertEmptyStringToNull=true Type="Int32" />
					</updateparameters>
				</asp:SqlDataSource>
				<br/>
				<asp:GridView
					id="GridViewURI" 
					runat="server" 
					AllowPaging=True
					AllowSorting=True 
					AutoGenerateColumns=False
					AutoGenerateDeleteButton=True
					AutoGenerateEditButton=True
					AutoGenerateSelectButton=True        
					DataKeyNames="SequenceOrderID"
					DataSourceID="SqlDataSourceURIGridView"
					OnRowCommand="GridViewURI_RowCommand"        
					OnRowDeleting="GridViewURI_RowDeleting"
					OnRowUpdated="GridViewURI_RowUpdated"
					SelectedIndex=0
					ShowFooter=True        
			   >
					<HeaderStyle BackColor='#CCCC99'/>
					<RowStyle BackColor='#eeeeee'/>
					<AlternatingRowStyle BackColor='#ffffe8'/>
					<Columns>
						<asp:TemplateField HeaderText="URI" SortExpression="URI">
							<ItemTemplate>
								<asp:HyperLink  
								Runat="Server"
								id="HyperLinkGridViewURIItemTemplateURI" 
								NavigateUrl='<%# WordEngineering.ProtocolHelper.PrefixProtocol( Eval("URI").ToString() ) %>'
								Text='<%# Eval("URI") %>'
								Target="_blank"
								/>  
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox 
								Runat="Server"
								id="TextBoxGridViewURIEditItemTemplateURI" 
								Text='<%# Bind("URI") %>'
								/>
							</EditItemTemplate>          
							<FooterTemplate>
								<asp:TextBox 
								Runat="Server"
								id="TextBoxGridViewURIFooterTemplateURI"
								Text='<%# Bind("URI") %>'
								/>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField
						  HeaderText="Title"
						  SortExpression="Title"
						>
							<ItemTemplate>
								<asp:Label
								Runat="Server"
								id="LabelGridViewURIItemTemplateTitle" 
								Text='<%# Eval("Title") %>'
								/>
							</ItemTemplate>
							<EditItemTemplate>
							   <asp:TextBox Runat="Server" 
									id="TextBoxGridViewURIEditItemTemplateTitle" 
									Text='<%# Bind("Title") %>'
								/>
							</EditItemTemplate>
							<FooterTemplate>
								<asp:TextBox 
								Runat="Server"
								id="TextBoxGridViewURIFooterTemplateTitle"
								Text='<%# Bind("Title") %>'
								/>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Keyword" SortExpression="Keyword">
							<ItemTemplate>
								<asp:Label
								Runat="Server"
								id="LabelGridViewURIItemTemplateKeyword" 
								Text='<%# Eval("Keyword") %>'
								/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIEditItemTemplateKeyword" 
									Text='<%# Bind("Keyword") %>'
								/>
							</EditItemTemplate>
							<FooterTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIFooterTemplateKeyword"
									Text='<%# Bind("Keyword") %>'
								/>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Commentary" SortExpression="Commentary">
							<ItemTemplate>
								<asp:Label
								Runat="Server"
								id="LabelGridViewURIItemTemplateCommentary" 
								Text='<%# Eval("Commentary") %>'
								/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox 
								Runat="Server"
								id="TextBoxGridViewURIEditItemTemplateCommentary" 
								Text='<%# Bind("Commentary") %>'
								/>
							</EditItemTemplate>
							<FooterTemplate>
								<asp:TextBox 
								Runat="Server"
								id="TextBoxGridViewURIFooterTemplateCommentary"
								Text='<%# Bind("Commentary") %>'
								/>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="URIReferrer" SortExpression="URIReferrer">
							<ItemTemplate>
								<asp:Label
								Runat="Server"
								id="LabelGridViewURIItemTemplateURIReferrer" 
								Text='<%# Eval("URIReferrer") %>'
								/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIEditItemTemplateURIReferrer" 
									Text='<%# Bind("URIReferrer") %>'
								/>
							</EditItemTemplate>
							<FooterTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIFooterTemplateURIReferrer"
									Text='<%# Bind("URIReferrer") %>'
								/>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Referrer" SortExpression="Referrer">
							<ItemTemplate>
								<asp:Label
								Runat="Server"
								id="LabelGridViewURIItemTemplateReferrer" 
								Text='<%# Eval("Referrer") %>'
								/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIEditItemTemplateReferrer" 
									Text='<%# Bind("Referrer") %>'
								/>
							</EditItemTemplate>
							<FooterTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIFooterTemplateReferrer"
									Text='<%# Bind("Referrer") %>'
								/>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="ContactID" SortExpression="ContactID">
							<ItemTemplate>
								<asp:Label
								Runat="Server"
								id="LabelGridViewURIItemTemplateContactID" 
								Text='<%# Eval("ContactID") %>'
								/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIEditItemTemplateContactID" 
									Text='<%# Bind("ContactID") %>'
								/>
							</EditItemTemplate>
							<FooterTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIFooterTemplateContactID"
									Text='<%# Bind("ContactID") %>'
								/>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="ScriptureReference" SortExpression="ScriptureReference">
							<ItemTemplate>
								<asp:Label
								Runat="Server"
								id="LabelGridViewURIItemTemplateScriptureReference" 
								Text='<%# Eval("ScriptureReference") %>'
								/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIEditItemTemplateScriptureReference" 
									Text='<%# Bind("ScriptureReference") %>'
								/>
							</EditItemTemplate>
							<FooterTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIFooterTemplateScriptureReference"
									Text='<%# Bind("ScriptureReference") %>'
								/>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Dated" SortExpression="Dated">
						<ItemTemplate>
								<asp:Label
									Runat="Server"
									id="LabelGridViewURIItemTemplateDated" 
									Text='<%# Eval("Dated", "{0:yyyy-MM-dd}") %>'
								/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIEditItemTemplateDated" 
									Text='<%# Bind("Dated") %>'
								/>
							</EditItemTemplate>
							<FooterTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIFooterTemplateDated"
									Text='<%# Bind("Dated") %>'
								/>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="SequenceOrderID" SortExpression="SequenceOrderID">
							<ItemTemplate>
								<asp:Label
									Runat="Server"
									id="LabelGridViewURIItemTemplateSequenceOrderID" 
									Text='<%# Eval("SequenceOrderID") %>'
								/>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox 
									Runat="Server"
									id="TextBoxGridViewURIFooterTemplateSequenceOrderID"
									Text='<%# Bind("SequenceOrderID") %>'
								/>
								<asp:Button 
									Runat="Server"           
									ID="ButtonGridViewURIFooterTemplateAdd"
									CommandName="ButtonGridViewURIFooterTemplateAdd" 
									Text="Add"
								/>
							</FooterTemplate>
						</asp:TemplateField>
					</Columns>
					<pagersettings mode="Numeric" position="Bottom" pagebuttoncount="10" />
					<pagerstyle backcolor="LightBlue" height="30px" verticalalign="Bottom" horizontalalign="Center" />
			</asp:GridView>
		</td>
	</tr>
    <tr>
      <td align="center" colspan="2">
       <asp:Literal 
        id="LiteralFeedback" 
        runat="server" 
        EnableViewState=False
       />
      </td>
     </tr>    
    </tbody>    
   </table>
  </form>

<script language="javascript">
 document.forms[0].DropDownListTableName.focus();
</script>

     <script>
		//2015-02-19 http://stackoverflow.com/questions/4793955/how-to-add-a-confirm-delete-option-in-asp-net-gridview
		function confirmDelete()
		{
			var anchors=document.getElementsByTagName("a");
			for (var index = 0, count = anchors.length; index < count; ++index)
			{
				var currentElement = anchors[index];
				var elementName = currentElement.innerHTML;
				if (elementName === "Delete")
				{
					anchors[index].addEventListener
					(
						"click",
						function (event) 
						{ 
							if (!confirm("Are you sure you want to delete this record?"))
							{ 
								event.preventDefault(); 
							} 
						},
						false
					);					
				}	
			}	
		}
		
		window.addEventListener("load", confirmDelete, false);
	</script>

  </body>
</html>
