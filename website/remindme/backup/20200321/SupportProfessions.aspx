<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>


<%@ Page
 
	Language="c#" 
        src="SupportProfessions.cs" 
        Inherits="EphraimTech.RemindME.supportProfession" 
        EnableSessionState=True 
        
%>


<%

    

%>

            
<html>

<head>
<title>
Professions
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
	action="SupportProfessions.aspx" 
	method="post" 
	runat="server"
	>


    <!--
    	Subject ID is:	<asp:Label id="labelSubjectID" runat="server"/> <br>		
    	SQL is:	<asp:Label id="labelSQL" runat="server"/> <br>
   	    Message is:	<asp:Label id="labelMessage" runat="server"/> <br>
     --> 		


    	
    Page# : <b>	<asp:Label id="labelCurrentPageNumber" runat="server" visible=false/> </b>
     

    <strong>Professions:</strong> <BR>


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
   DataKeyField="profession_code"
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
		   HeaderText="Profession Code" 
		   DataField="profession_code" 
		   SortExpression="name"
		   Visible="false"> 	
				
		</asp:BoundColumn>
		
		<asp:BoundColumn 
		   HeaderText="Profession" 
		   DataField="description" 
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
            DataNavigateURLField="profession_code"
            DataNavigateURLFormatString="DBItemDelete.aspx?DBItemType=Profession&DBItemEntryID={0}"
            > 	
    </asp:HyperLinkColumn>              
				
	</Columns>    
	

</asp:DataGrid>


</form>

</body>
</html>