<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>


<%@ Page
 
	Language="c#" 
        src="SupportCommunicationTypes.cs" 
        Inherits="EphraimTech.supportCommunicationTypes" 
        EnableSessionState=True 
        
%>


<%

    

%>

            
<html>

<head>
<title>
Communication Types
</title>

<script language="javascript">
 
    function deleteCommunicationTypeEntry(strCommunicationTypeID)
    {
    
        var bConfirm;
        
        bConfirm = confirm("Are you sure");
        
        if (bConfirm)
        {        
            
            strURL = "DBItemDelete.aspx" +
                     "?DBItemType=CommunicationType" +
                     "&DBItemEntryID=" + strCommunicationTypeID;
                     
            window.location.href = strURL;
            
        }
  

                    
    }
 
 </script>
</head>

<body>

    <asp:hyperlink 
     id="hyperLinkContactEdit" 
     runat=server
     Text="Communicate Edit" 
     NavigateUrl="ContactCommunicationEdit.aspx?mode=Restore"/>        	
     
     <BR>
	
<form method="post" runat="server">


    <!--
    	Subject ID is:	<asp:Label id="labelSubjectID" runat="server"/> <br>		
    	SQL is:	<asp:Label id="labelSQL" runat="server"/> <br>
   	    Message is:	<asp:Label id="labelMessage" runat="server"/> <br>
     --> 		


    	
    Page# : <b>	<asp:Label id="labelCurrentPageNumber" runat="server" visible=false/> </b>
     

    <strong>Communication Types:</strong> <BR>


<BR>

<table width='80%'>

    <TR>
        <TD ALIGN=RIGHT>
                            
				<i> Search 
				</i>
				 
				<asp:TextBox 
				 ID="txtCommunicationTypeSearchTag" 
				 maxlength="15"
				 RunAt="server" />

			  <asp:ImageButton 
				id="idAnchorCommunicationTypeSearch" 
				runat="server"
				ImageUrl="contactus.gif"
				OnClick="AnchorCommunicationTypeSearchBtnClick" 
				/>	
        
                <asp:Label 
                     id="labelQuotesSubject" 
                     runat="server" 
                     text="Subject" 
                     visible="false"
                />        
                   
                <asp:hyperlink 
                 id="hyperLinkCommunicationTypeAdd" 
                 runat=server
                 Text="Add" 
                 NavigateUrl="CommunicationTypesEdit.aspx"/>        	                     
        

        </TD>
    </TR>
            
</table>

<asp:DataGrid 
   id="nameDataGrid" 
   HeaderStyle-Font-Bold="True" 
   runat="server" 
   maintainviewstate="false" 
   AutoGenerateColumns="false"
   Font-Size="10pt"
   PageSize="40"
   AllowPaging = "true"
   AllowSorting = "false"   
   left="100px"
   Width="80%"
   OnPageIndexChanged="onPageIndexChangedNamesGrid"
   OnEditCommand="GridEdit"
   OnCancelCommand="GridCancel"
   OnUpdateCommand="GridUpdate"
   DataKeyField="id"
   OnItemDataBound="gridItemDataBound"
>
   

    <PagerStyle Mode="NumericPages"
                HorizontalAlign="Right">
    </PagerStyle>
    
    <HeaderStyle BackColor="Black" 
                 ForeColor="White">
    </HeaderStyle>
    
    <FooterStyle BackColor="#aaaadd">
    </FooterStyle>
    
    <ItemStyle BackColor="#ffffe8">
    </ItemStyle>
        
    <AlternatingItemStyle BackColor="#eeeeee">
    </AlternatingItemStyle>
   
	<Columns> 

		
		<asp:BoundColumn 
		   HeaderText="Communication Type" 
		   DataField="comm_type" 
		   SortExpression="name"> 	
				
		</asp:BoundColumn>
           
     <asp:HyperLinkColumn 
            HeaderText="Edit" 		
	        Text="Edit" 
            DataNavigateURLField="id"
            DataNavigateURLFormatString="CommunicationTypesEdit.aspx?CommunicationTypeID={0}"
            Visible="True"
            > 	           
           
    </asp:HyperLinkColumn>              
               
     <asp:HyperLinkColumn 
            HeaderText="Delete" 		
	        Text="Delete" 
            DataNavigateURLField="id"
            DataNavigateURLFormatString="DBItemDelete.aspx?DBItemType=CommunicationType&DBItemEntryID={0}"
            Visible="True"
            > 	
            
    </asp:HyperLinkColumn>              
				
	</Columns>    
	

</asp:DataGrid>


</form>

</body>
</html>
