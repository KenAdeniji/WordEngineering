<%@ Page
 
	Language="c#" 
        src="Top.cs" 
        Inherits="_default" 
        EnableSessionState=True
        
%>
<HTML>

<HEAD>
<TITLE>
Document Attachment [1]
</TITLE>


<script language='javascript'>

    function renderAttachment(strDocumentAttachmentIdentifier)
    {

        
        var strURLDestination; 
		
		//alert("hello");
		
       
        //if ((strReportID != null) && (strReportID != ''))
        {
        
            strURLDestination = "bottom.aspx";
            strURLDestination = strURLDestination + 
								"?documentAttachmentIdentifier=" 
								+ strDocumentAttachmentIdentifier;
								
			//strURLDestination = "http://www.cnn.com";								
								
			//alert(strURLDestination);					
            
            //alert('URL Destination is ' + strURLDestination);   
            
            //window.parent.frames("bottom").navigate(strURLDestination);

            {
                //window.parent.frames("bottom").navigate("blankframepage.htm");            
                //window.parent.frames("bottom").navigate(strURLDestination);
                window.parent.frames[1].location.href = strURLDestination;                               
            }                            
			
            
        }   
		
    
    }
    
</script>

</head>    



 <body 
  bgcolor="white" 
  leftmargin="0" 
  topmargin="0" 
  marginheight="0" 
  marginwidth="0"
  > 
 
    <table>
    
     <tr><td> 

      <form id='frmReport' 
            method='post' 
            runat='server'
			defaultFocus='txtMediaSearchTag'
			>          
            
			  <TABLE 
			  	 BORDER=0 
			  	 BGCOLOR='white' 
                 cellpadding='2' 
                 cellspacing='2'
                 >                           

					<TR><TD colspan=2>
						<TABLE BORDER=0 cellpadding='0' cellspacing='1' BGCOLOR='white'>	
						<TR>
							<TD COLSPAN=3 align='left'>
								<asp:Label id="LabelDebug" Text="" runat="server" ForeColor="Red" visible=false/>        		
								<asp:Label id="LabelInfo" Text="" runat="server" ForeColor="Red" visible=false/>
								<asp:Label id="LabelSQL" Text="" runat="server" ForeColor="Red" visible=true/>        			
							</TD>
						</TR>        
						
						</TABLE>
					</TD></TR>
             

					<TR>
						<TD>	
						
							Search Tag:
							<asp:TextBox 
							 ID="txtMediaSearchTag" 
							 maxlength="80"
							 RunAt="server" />
						
							<a id='idAnchorContactSearch' 
							   name='idAnchorContactSearch'
							   OnServerClick='AnchorSearchBtnClick'
							   runat='server'
							>	
								<img src='../images/contactus.gif' border=0>
							</a>                  							
						
						</TD>
						
						<TD>			 
						
							<a href='../cover.aspx' target=_parent>
								<img src='../back2.gif' border=0>
							</a> 

						</TD>						
					
					</TR>	
					
					
					<!--
					
						SqlDataSource.ProviderName Property 
							http://msdn2.microsoft.com/en-us/library/system.web.ui.webcontrols.sqldatasource.providername.aspx
							
					
					-->	
							
					<asp:SQLDataSource
						ID="SqlDataSourceAttachment"
						runat="server" 	
						SelectCommand="exec dbo.usp_getListofDocumentAttachments ?, ?"
						ConnectionString="<%$ ConnectionStrings:remindme %>" 
						ProviderName="<%$ ConnectionStrings:remindme.ProviderName %>"	
						> 
					
						<SelectParameters>
									
							<asp:SessionParameter 
								DefaultValue="" 
								Name="memberID" 
								SessionField="memberID" 
								/>	
	   
							<asp:ControlParameter 
								Name="searchTag" 
								ControlID="txtMediaSearchTag" 
								PropertyName="Text"
								DefaultValue=" "
								/>
							
						</SelectParameters>
						
						<UpdateParameters>
					
							<asp:Parameter Type="String" Name="mediaName"></asp:Parameter>
							<asp:Parameter Name="mediaID"></asp:Parameter>	
					
					
							
						</UpdateParameters>
					
						
						<DeleteParameters>
					
							<asp:Parameter Name="mediaID"></asp:Parameter>	
							
						</DeleteParameters>
						
					</asp:SQLDataSource>

					
					<TR>
						<TD  colspan=2>			 					
					
							<asp:gridview
							   id="gridMedia" 
							   DataSourceID="SqlDataSourceAttachment"
							   DataKeyNames="documentAttachmentIdentifier"
							   HeaderStyle-Font-Bold="True" 
							   runat="server" 
							   maintainviewstate="false" 
							   AutoGenerateColumns="false"
							   PageSize="20"
							   AllowEditing="true"   
							   AllowPaging="true"
							   AllowSorting="true"   
							   enableviewstate="true"
							   OnRowCommand="GridViewRowCommand"
								>
							   
							
								
								<HeaderStyle BackColor="Black" 
											 ForeColor="White">
								</HeaderStyle>
								
								<FooterStyle BackColor="#aaaadd">
								</FooterStyle>
								
								<RowStyle BackColor="#ffffe8">
								</RowStyle>
									
								<AlternatingRowStyle BackColor="#eeeeee">
								</AlternatingRowStyle>
								
							   
								<Columns> 
								
									<asp:BoundField 
										HeaderText="Media" 
										DataField="mediaID"
										ReadOnly="True"
										InsertVisible="False"			
										Visible="False"						
										> 	
										
									</asp:BoundField>			
										
									<asp:BoundField 
										HeaderText="Attachment Name" 
										DataField="attachmentName" 
										ReadOnly="False"									
										> 	
											
									</asp:BoundField>
									
									<asp:BoundField 
										HeaderText="Filename" 
										DataField="attachmentFilename" 
										ReadOnly="False"					
										Visible="False"																
										> 	
											
									</asp:BoundField>
									
									<asp:TemplateField  HeaderText="Select">
									
									<ItemTemplate>
									
									<asp:LinkButton 
										ID="LinkButton1" 
										CommandArgument='<%# Eval("documentAttachmentIdentifier") %>' 
										CommandName="Select" 
										runat="server"
										>
										Select
									</asp:LinkButton>
									
									</ItemTemplate>
									
									</asp:TemplateField>
									
									
							
							
								</Columns>    
								
							
							</asp:gridView>					
					
						</TD>
						
					</TR>						

            
				</TABLE>
        
	</FORM>        

    <td><tr>       
    </table>
    
    </body>          
             
</HTML>
