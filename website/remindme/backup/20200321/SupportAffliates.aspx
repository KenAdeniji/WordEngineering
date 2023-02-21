<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>


<%@ Page
 
	Language="c#" 
        src="SupportAffliates.cs" 
        Inherits="EphraimTech.QuoteTopics" 
        EnableSessionState=True 
        
%>


<%

    

%>

            
<html>

<head>
<title>
Affliates
</title>

<script language="javascript">
 
    function deleteAffliateEntry(strAffliateID)
    {
    
        var bConfirm;
        
        bConfirm = confirm("Are you sure");
        
        if (bConfirm)
        {        
            
            strURL = "DBItemDelete.aspx" +
                     "?DBItemType=Affliate" +
                     "&DBItemEntryID=" + strAffliateID;
                     
            window.location.href = strURL;
            
        }
  

                    
    }
 
 </script>
</head>

<body>

    <asp:hyperlink 
     id="hyperLinkContactEdit" 
     runat=server
     Text="Contact Edit" 
     NavigateUrl="ContactEdit.aspx?mode=Restore"/>        	
     
     <BR>
	
<form 
	action="SupportAffliates.aspx" 
	method="post" 
	runat="server"
	>


    <!--
    	Subject ID is:	<asp:Label id="labelSubjectID" runat="server"/> <br>		
    	SQL is:	<asp:Label id="labelSQL" runat="server"/> <br>
   	    Message is:	<asp:Label id="labelMessage" runat="server"/> <br>
     --> 		


    	
    Page# : <b>	<asp:Label id="labelCurrentPageNumber" runat="server" visible=false/> </b>
     

    <strong>Affliates:</strong> <BR>


<BR>

<table width='80%'>

    <TR>
        <TD ALIGN=RIGHT>
        
                <asp:Label 
                     id="labelQuotesSubject" 
                     runat="server" 
                     text="Subject" 
                     visible="false"
                />        
        
                <asp:TextBox 
                   id=editQuoteSubject
                   AutoPostBack="False"
                   Columns="15"
                   MaxLength="1000"
                   Rows="1"
                   Wrap="True"
                   runat="server" 
                   visible="false"
                   />
                   
               <asp:Button
                   id=buttonAdd
                   Text="Add"
	 	           OnClick="buttonAddClicked"                       
                   runat="server"/>                   
        

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
   DataKeyField="affliation_code"
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
		   HeaderText="Affliate ID" 
		   DataField="affliation_code" 
		   SortExpression="name"
		   Visible="false"> 	
				
		</asp:BoundColumn>
		
		<asp:BoundColumn 
		   HeaderText="Affliate" 
		   DataField="affliation_name" 
		   SortExpression="name"> 	
				
		</asp:BoundColumn>
		
      <asp:EditCommandColumn
           ButtonType="LinkButton"
           CancelText="Cancel"
           EditText="Edit"
           HeaderText="Edit"
           UpdateText="Update"
           Visible="True"/>
           
     <asp:HyperLinkColumn 
            HeaderText="Delete" 		
	        Text="Delete" 
            DataNavigateURLField="affliation_code"
            DataNavigateURLFormatString="DBItemDelete.aspx?DBItemType=Affliate&DBItemEntryID={0}"
            > 	
    </asp:HyperLinkColumn>              
				
	</Columns>    
	

</asp:DataGrid>


</form>

</body>
</html>
