<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.URIMaintenancePage"
%>

<%@ Register Assembly="UtilityProtocol" Namespace="WordEngineering" TagPrefix="UtilityProtocol" %>

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

   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td colspan="2">
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
        DeleteCommand="EXEC uspURIDelete @tableName, @sequenceOrderId"
        InsertCommand="EXEC uspURIInsert @tableName, @sequenceOrderId, @dated, @uri, @title, @keyword"
        SelectCommand="EXEC uspURISelect @tableName, @sequenceOrderIdFrom, @sequenceOrderIdTo, @datedFrom, @datedTo, @uri, @title, @keyword"
        UpdateCommand="EXEC uspURIUpdate @tableName, @sequenceOrderId, @dated, @uri, @title, @keyword"
       >
        <deleteparameters>
         <asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
        </deleteparameters>
        <insertparameters>
         <asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:parameter name="uri" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="title" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="keyword" ConvertEmptyStringToNull=true Type="string" />
        </insertparameters>
        <selectparameters>
         <asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
         <asp:controlparameter name="sequenceOrderIdFrom" controlid="TextBoxSequenceOrderIdFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" Defaultvalue="-1" />
         <asp:controlparameter name="sequenceOrderIdTo" controlid="TextBoxSequenceOrderIdTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" Defaultvalue="2147483647" />
         <asp:controlparameter name="datedFrom" controlid="TextBoxDatedFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "1/1/1753" />
         <asp:controlparameter name="datedTo" controlid="TextBoxDatedTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "12/31/9999" />
         <asp:controlparameter name="uri" controlid="TextBoxURI" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" DefaultValue = "|" />
         <asp:controlparameter name="title" controlid="TextBoxTitle" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput"  DefaultValue = "|" />
         <asp:controlparameter name="keyword" controlid="TextBoxKeyword" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" DefaultValue = "|" />
        </selectparameters>
        <updateparameters>
         <asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:parameter name="uri" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="title" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="keyword" ConvertEmptyStringToNull=true Type="string" />
        </updateparameters>
       </asp:SqlDataSource>
       <asp:SqlDataSource
        ID="SqlDataSourceURIDetailsView" 
        Runat="server"
        ConnectionString="<%$ ConnectionStrings:URI %>"
        FilterExpression="SequenceOrderId='{0}'"
        DeleteCommand="EXEC uspURIDelete @tableName, @sequenceOrderId"
        InsertCommand="EXEC uspURIInsert @tableName, @sequenceOrderId, @dated, @uri, @title, @keyword"
        SelectCommand="EXEC uspURISelect @tableName, @sequenceOrderIdFrom, @sequenceOrderIdTo, @datedFrom, @datedTo, @uri, @title, @keyword"
        UpdateCommand="EXEC uspURIUpdate @tableName, @sequenceOrderId, @dated, @uri, @title, @keyword"
       >
        <FilterParameters>
         <asp:ControlParameter 
          Name="SequenceOrderId" 
          ControlId="GridViewURI" 
          PropertyName="SelectedValue"
         />
        </FilterParameters>
        <deleteparameters>
         <asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
        </deleteparameters>
        <insertparameters>
         <asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:parameter name="uri" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="title" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="keyword" ConvertEmptyStringToNull=true Type="string" />
        </insertparameters>
        <selectparameters>
         <asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
         <asp:controlparameter name="sequenceOrderIdFrom" controlid="TextBoxSequenceOrderIdFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" />
         <asp:controlparameter name="sequenceOrderIdTo" controlid="TextBoxSequenceOrderIdTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" />
         <asp:controlparameter name="datedFrom" controlid="TextBoxDatedFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
         <asp:controlparameter name="datedTo" controlid="TextBoxDatedTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
         <asp:controlparameter name="uri" controlid="TextBoxURI" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="title" controlid="TextBoxTitle" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="keyword" controlid="TextBoxKeyword" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
        </selectparameters>
        <updateparameters>
         <asp:controlparameter name="tableName" controlid="DropDownListTableName" propertyname="SelectedValue" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:parameter name="uri" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="title" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="keyword" ConvertEmptyStringToNull=true Type="string" />
        </updateparameters>
       </asp:SqlDataSource>

       <asp:GridView
        id="GridViewURI" 
        runat="server" 
        AllowPaging=True
        AllowSorting=True 
        AutoGenerateColumns=False
        AutoGenerateDeleteButton=True
        AutoGenerateEditButton=True
        AutoGenerateSelectButton=True        
        DataKeyNames="sequenceOrderId"
        DataSourceID="SqlDataSourceURIGridView"
        OnRowCommand="GridViewURI_RowCommand"        
        OnRowDeleting="GridViewURI_RowDeleting"
        OnRowUpdated="GridViewURI_RowUpdated"
        SelectedIndex=0
        ShowFooter=True        
       >
        <HeaderStyle
         BackColor='#CCCC99'/>

        <RowStyle
         BackColor='#eeeeee'/>
			
        <AlternatingRowStyle
         BackColor='#ffffe8'/>

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
           <asp:TextBox 
            Runat="Server"
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

         <asp:TemplateField
          HeaderText="Keyword"
          SortExpression="Keyword"
         >
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

         <asp:TemplateField
          HeaderText="Dated"
          SortExpression="Dated"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewURIItemTemplateDated" 
            Text='<%# Eval("Dated", "{0:d}") %>'
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

         <asp:TemplateField
          HeaderText="SequenceOrderId"
          SortExpression="SequenceOrderId"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewURIItemTemplateSequenceOrderId" 
            Text='<%# Eval("SequenceOrderId") %>'
           />
          </ItemTemplate>
<%--
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewURIEditItemTemplateSequenceOrderId" 
            Text='<%# Bind("SequenceOrderId") %>'
           />
          </EditItemTemplate>
--%>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewURIFooterTemplateSequenceOrderId"
            Text='<%# Bind("SequenceOrderId") %>'
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
        <pagersettings mode="Numeric"
         position="Bottom"           
         pagebuttoncount="10"
        />
        <pagerstyle backcolor="LightBlue"
         height="30px"
         verticalalign="Bottom"
         horizontalalign="Center"
        />
       </asp:GridView>
      </td>
     </tr>
     <tr>
      <td>
       <asp:DetailsView 
        id="DetailsViewURI" 
        runat="server" 
        AllowPaging=True
        AllowSorting=True 
        AutoGenerateRows=False
        AutoGenerateDeleteButton=True
        AutoGenerateEditButton=True
        AutoGenerateInsertButton=True        
        AutoGenerateSelectButton=True
        DataKeyNames="sequenceOrderId"
        DataSourceID="SqlDataSourceURIDetailsView"
        OnItemInserted="DetailsViewURI_ItemInserted"
        OnItemUpdated="DetailsViewURI_ItemUpdated"
       >
        <Fields>

         <asp:TemplateField
          ConvertEmptyStringToNull=True
          HeaderText="URI"
          SortExpression="URI"
         >
          <ItemTemplate>
           <asp:HyperLink  
            Runat="Server"
            id="HyperLinkDetailsViewURIItemTemplateURI" 
            NavigateUrl='<%# UtilityProtocol.PrefixProtocol( Eval("URI").ToString() ) %>'
            Text='<%# Eval("URI") %>'
            Target="_blank"
           />  
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox
            Runat="Server"
            id="TextBoxDetailsViewURIEditItemTemplateURI" 
            Text='<%# Bind("URI") %>'
           />
          </EditItemTemplate>          
         </asp:TemplateField>

         <asp:BoundField ConvertEmptyStringToNull=True DataField="Title"            HeaderText="Title:"            ReadOnly=False />
         <asp:BoundField ConvertEmptyStringToNull=True DataField="Keyword"          HeaderText="Keyword:"          ReadOnly=False />
         <asp:BoundField ConvertEmptyStringToNull=True DataField="Dated"            HeaderText="Dated:"            ReadOnly=False DataFormatString="{0:d}" />
         <asp:BoundField ConvertEmptyStringToNull=True DataField="SequenceOrderId"  HeaderText="SequenceOrderId:"  ReadOnly=False  />
        </Fields>
       </asp:DetailsView> 
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
 </body>
</html>

<script language="javascript">
 document.forms[0].DropDownListTableName.focus();
</script>
