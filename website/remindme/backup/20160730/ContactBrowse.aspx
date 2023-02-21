<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="ContactBrowse.cs" 
        Inherits="EphraimTech.RemindME.frmContactBrowse" 
        EnableSessionState=True 
        
%>
<HTML>

<HEAD>
<TITLE>
Contact 
</TITLE>


</head>    


 <script language="javascript">
 
    function deleteCommunicationEntry(strContactCommunicationID)
    {
    
        var bConfirm;
        
        bConfirm = confirm("Are you sure");
        
        if (bConfirm)
        {        
            
            strURL = "ContactCommunicationDelete.aspx?ContactCommunicationID=" +
                     strContactCommunicationID;
                     
            strURL = "DBItemDelete.aspx" +
                     "?DBItemType=CommunicationItem" +
                     "&DBItemEntryID=" + strContactCommunicationID;
                                          
            window.location.href = strURL;
            
        }
  

                    
    }
 
 </script>

 <body 
  bgcolor="white" 
  leftmargin="0" 
  topmargin="0" 
  marginheight="0" 
  marginwidth="0"
  > 
  
<style>

    .dialogContact
    {
        BORDER-BOTTOM: black 2px solid;
        BORDER-LEFT: white 2px solid;
        BORDER-RIGHT: black 2px solid;
        BORDER-TOP: white 2px solid
    }


</style>  
 
          <IMG SRC='hor_divider_arctic.gif' 
               width='90%' 
               height='24'>
          
          <TABLE
                 background="background_arctic.gif"
                 border="0" 
                 cellpadding="0" 
                 cellspacing="0"
                 width="90%">                           
          

      
            <TR VALIGN='top'>
            
                <TD  VALIGN='top' align="left" width="20%">
                    <IMG SRC='left_image_arctic.jpg'>
                </TD>


				<td VALIGN='top' align="left" width="80%">
				
                               <asp:HyperLink 
                                id="idAnchorCover"
                                NavigateUrl="Cover.aspx"
                                Text="List of Contacts"
                                runat="server"/>				
				  									
                  <form id='frmCover' 
                        method='post' 
                        runat='server'
                        action='Cover.aspx'
                        >
                        
                        
                        
                 <asp:Label id="labelSQL" runat="server" visible=false />                   
	                    
                 <div class='dialogContact' id='dialogContact'>
  
                    <TABLE cellpadding='0' border='0' cellspacing='0'  width='90%'>    
                        
                        <TR>
                            
                            <TD COLALIGN='Left' width=20%>
                            
                                <b> Contact </b>
                            </TD>
                            
                            <TD COLALIGN='Left' width=60%>
                                <b>
                                    <asp:Label id='labelContact' runat='server'/>
                                </b>                                    
                            </TD>                            

                            <TD>&nbsp</TD>                                                                           
                            
                         </TR>                            
                         
                         
                         <TR>
                            <TD>
                                Date of Birth
                            </TD>
                            
                            <TD>
                                <asp:Label id='labelContactDOB' runat='server'/>
                            </TD>        
                                                
                            <TD>&nbsp</TD>
                         </TR>                            
                                                  
                                                  
                         <TR>
                            <TD>
                                Affiliate
                            </TD>
                            
                            <TD>
                                <asp:Label id='labelContactAffliate' runat='server'/>
                            </TD>        
                                                
                            <TD>&nbsp</TD>
                         </TR>                            
                         
                                                                           
                         <TR>
                            <TD>
                                Profession
                            </TD>
                            
                            <TD>
                                <asp:Label id='labelContactProfession' runat='server'/>
                            </TD>                            
                         </TR>  
                                
                                
                         <TR>
                            <TD valign='TOP'>
                                Comment
                            </TD>
                            
                            <TD>
                                <asp:Label id='labelContactComment' runat='server'/>
                            </TD>                            
                            
                            <TD ALIGN='RIGHT'>
                            
                                <a id=hyperLinkEditCustomer HREF = "" runat=server><img src='edit.gif' border=0></a>
                                
                                &nbsp&nbsp&nbsp
                                
                                <a id=hyperLinkDeleteCustomer 
					               onclick="return confirm(&quot;Are you sure you want to make a delete this entry ?&quot;);"                                 
                                   HREF = ""
                                   runat=server> 
                                   <img src='close.gif' border=0>
                                </a>
                                                                
                            </TD>
                                                        
                         </TR>                                                                             
     
                     </TABLE>	
                     
                    </div>	                                        
                    
                    
                    <TABLE cellpadding='0' border='0' cellspacing='10'  width='100%'>    

                       <TR>
                            <TD>

                               <asp:HyperLink 
                                id="idAnchorAddContactCommunication"
                                NavigateUrl="ContactCommunicationEdit.aspx"
                                Text="Add Contact Communication"
                                runat="server"/>
                                 
                            </TD>
                        </TR>                            

                        <TR>
                            <TD>

                              <asp:DataGrid 
                                   id="gridContactCommunicationInfo"
                                   BorderColor="black"
                                   BorderWidth="1"
                                   CellPadding="3"
                                   AutoGenerateColumns="false"
                                   OnItemCreated="DataGridItemCreated"   		                            		    		                            		                                                               
                                   runat="server"
                                   font-size="8"                                                                      
                                   width='100%'
								   style="WORD-BREAK:break-normal"
								   >
                                 
                                 <HeaderStyle BackColor="#9FBCE3">                                 
                                 </HeaderStyle>
                                 
                                 <ItemStyle BackColor="#EEF2F7">
                                 </ItemStyle>
                                             
                                 <AlternatingItemStyle BackColor="#EEEEEE">                                 
                                 </AlternatingItemStyle>                                                                                                                                                      
                                 
                                 <columns>
                                 
    		                         <asp:BoundColumn 
    		                            HeaderText="Communication Type" 
    		                            DataField="CommunicationType" 
    		                            SortExpression="CommunicationType"/> 	                                 

    		                         <asp:BoundColumn 
    		                            HeaderText="Communicate" 
    		                            DataField="CommunicationDataFormatted" 
    		                            SortExpression="CommunicationData"
										/> 	                                 
    		                            
    		                         <asp:BoundColumn 
    		                            HeaderText="Comment" 
    		                            DataField="Comment"/> 
    		                            
    		                         <asp:BoundColumn HeaderText="DateCreated" DataField="DateCreated"/>     		                            
    		                         
    		                         <asp:BoundColumn HeaderText="DateUpdated" DataField="DateUpdated"/>     		                                		                         
    		                         
    		                         <asp:BoundColumn HeaderText="Active" DataField="activeLiteral"/>     		                                		                             		                         
    		                         
   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Edit" 		
                                	        Text="Edit" 
    		                                DataNavigateURLField="communicationIdentifier"
    		                                DataNavigateURLFormatString="ContactCommunicationEdit.aspx?ContactCommunicationID={0}"
       		                                Visible=False
       		                                > 	
   		                            </asp:HyperLinkColumn>   		    		                         
   		                            

   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Delete" 		
                                	        Text="Delete" 
    		                                DataNavigateURLField="communicationIdentifier"
    		                                DataNavigateURLFormatString="javascript:deleteCommunicationEntry('{0}')"
    		                                Visible=False
    		                                > 	
    		                                
   		                            </asp:HyperLinkColumn>   
   		                               		                            

   		                             <asp:ButtonColumn 
        		                            HeaderText="Delete" 		
                                	        Text="Delete" 
                                            ButtonType="PushButton"
                                            CommandName="Text"
                                            Visible=False>
   		                            </asp:ButtonColumn>   
   		                            
   		                            
									<asp:TemplateColumn HeaderText="Edit"
							            HeaderStyle-HorizontalAlign="center">
									            
							            <ItemTemplate>
							              <center>
							              	<a href='<%#"ContactCommunicationEdit.aspx?ContactCommunicationID=" + DataBinder.Eval(Container.DataItem, "communicationIdentifier")%>'>
							                <img src='images/edit.gif' border=0>
							                </a>
							              </center>
							            </ItemTemplate>
									            
						          </asp:TemplateColumn>
						          
						        
									<asp:TemplateColumn HeaderText="Activate/Deactivate"
							            HeaderStyle-HorizontalAlign="center">
									            
							            <ItemTemplate>
							              <center>
							              	<a href='<%#"DBUpdate.aspx?DBItemType=CommunicationItemActivateToggle&DBItemEntryID=" + DataBinder.Eval(Container.DataItem, "communicationIdentifier")%>'>
												Act/Dea
							                </a>
							              </center>
							            </ItemTemplate>
									            
						          </asp:TemplateColumn>
								  
                           		    
									<asp:TemplateColumn HeaderText="Delete"
							            HeaderStyle-HorizontalAlign="center">
									            
							            <ItemTemplate>
							              <center>
							              	<a onclick="return confirm(&quot;Are you sure you want to make a delete this entry ?&quot;);" 
							              	   href='<%#"DBUpdate.aspx?DBItemType=CommunicationItemDelete&DBItemEntryID=" + DataBinder.Eval(Container.DataItem, "communicationIdentifier")%>'>
							                <img src='images/close.gif' border=0>
							                </a>
							              </center>
							            </ItemTemplate>
									            
						          </asp:TemplateColumn>   		                               		                            


                                 </columns>                        
                           		
                              </asp:DataGrid>

                            </TD>                                                                                                        
                        </TR>
                        

                       <TR>
                            <TD>

                               <asp:HyperLink 
                                id="idAnchorAddContactAddress"
                                NavigateUrl="ContactAddressEdit.aspx"
                                Text="Add Contact Address"
                                runat="server"/>
                                 
                            </TD>
                        </TR>                                                    

                        <TR>
                            <TD>

                              <asp:DataGrid 
                                   id="gridContactAddressInfo"
                                   BorderColor="black"
                                   BorderWidth="1"
                                   CellPadding="3"
                                   AutoGenerateColumns="false"
                                   runat="server"
                                   font-size="8"                                   
                                   width='100%'>
                                 
                                 <HeaderStyle BackColor="#9FBCE3">
                                 </HeaderStyle>
                        
                                 <ItemStyle BackColor="#EEF2F7">
                                 </ItemStyle>
                                             
                                 <AlternatingItemStyle BackColor="#EEEEEE">                                 
                                 </AlternatingItemStyle>                                                                                                                     
                                 
                                 <columns>
                                 
    		                         <asp:BoundColumn 
    		                            HeaderText="Address" 
    		                            DataField="Address"/> 

    		                         <asp:BoundColumn 
    		                            HeaderText="City" 
    		                            DataField="City" 
    		                            SortExpression="City"/> 	                                 
    		                            
    		                         <asp:BoundColumn 
    		                            HeaderText="State" 
    		                            DataField="State"/> 
    		                            
    		                         <asp:BoundColumn 
    		                            HeaderText="Postal Code" 
    		                            DataField="postalCode"/>     		                            
    		                            
    		                         <asp:BoundColumn HeaderText="DateCreated" DataField="DateCreated"/>     		                            
    		                         
    		                         <asp:BoundColumn HeaderText="DateUpdated" DataField="DateUpdated"/>     		                                		                         
    		                         
    		                         <asp:BoundColumn HeaderText="Active" DataField="activeLiteral"/>     		                                		                             		                         
    		                         

   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Edit" 		
                                	        Text="Edit" 
    		                                DataNavigateURLField="addressIdentifier"
    		                                DataNavigateURLFormatString="ContactAddressEdit.aspx?ContactAddressID={0}" 	
    		                                Visible="False"
    		                                >
   		                            </asp:HyperLinkColumn>   		    		                         
   		                            
   		                            
   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Delete" 		
                                	        Text="Delete" 
    		                                DataNavigateURLField="addressIdentifier"
    		                                DataNavigateURLFormatString="ContactAddressDelete.aspx?ContactAddressID={0}"
    		                                Visible="False"    		                                
    		                                >
   		                            </asp:HyperLinkColumn>   		    		                            		                            
   		                            
									<asp:TemplateColumn HeaderText="Edit"
							            HeaderStyle-HorizontalAlign="center">
									            
							            <ItemTemplate>
							              <center>
							              	<a href='<%#"ContactAddressEdit.aspx?ContactAddressID=" + DataBinder.Eval(Container.DataItem, "addressIdentifier")%>'>
							                <img src='images/edit.gif' border=0>
							                </a>
							              </center>
							            </ItemTemplate>
									            
						          </asp:TemplateColumn>
						          
						        
                           		    
									<asp:TemplateColumn HeaderText="Delete"
							            HeaderStyle-HorizontalAlign="center">
									            
							            <ItemTemplate>
							              <center>
							              	<a onclick="return confirm(&quot;Are you sure you want to make a delete this entry ?&quot;);" 
							              	   href='<%#"DBUpdate.aspx?DBItemType=AddressItemDelete&DBItemEntryID=" + DataBinder.Eval(Container.DataItem, "addressIdentifier")%>'>
							                <img src='images/close.gif' border=0>
							                </a>
							              </center>
							            </ItemTemplate>
									            
						          </asp:TemplateColumn>   		                               		                            
						             		                            
   		                            
                                 </columns>                        
                           		
                              </asp:DataGrid>

                            </TD>
                         </TR>   
  
                         
                       <TR>
                            <TD>
                                
                               <asp:HyperLink 
                                id="idAnchorAddContactEvent"
                                NavigateUrl="ContactEventEdit.aspx"
                                Text="Add Contact Event"
                                runat="server"/>                                
                                 
                            </TD>
                        </TR>                                                      
                         
                        <TR>
                            <TD>                    
                              <asp:DataGrid 
                                   id="gridContactEventInfo"
                                   BorderColor="black"
                                   BorderWidth="1"
                                   CellPadding="3"
                                   AutoGenerateColumns="false"
                                   runat="server"
                                   font-size="8"                                                                      
                                   width='100%'>

                                 <HeaderStyle BackColor="#9FBCE3">
                                 </HeaderStyle>
                        
                                 <ItemStyle BackColor="#EEF2F7">
                                 </ItemStyle>
                                             
                                 <AlternatingItemStyle BackColor="#EEEEEE">                                 
                                 </AlternatingItemStyle>                                 
                                                                  
                                 <columns>
                                 
    		                         <asp:BoundColumn 
										HeaderText="Event"  
										DataField="eventName"
										/> 

									<asp:TemplateColumn
										HeaderText="Link" 
										>

										<ItemTemplate>		

										<!--
											
											 <asp:HyperLinkColumn 
													HeaderText="Link" 		
													Text="Link" 
													NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "eventLink") %>'
													Visible="True"
													Target="_blank"
													runat="server"												
													> 	
													
											</asp:HyperLinkColumn>   		    

										-->
										
										 <asp:HyperLink
												HeaderText="Link" 		
												Text="Link" 
												NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "eventLink") %>'
												Visible="True"
												Target="_blank"
												runat="server"
												> 	
										 </asp:HyperLink>   		    		                         																				
										
										</ItemTemplate>
										
									</asp:TemplateColumn>

			
																
    		                         <asp:BoundColumn 
										HeaderText="Status"  
										DataField="statusCodeLiteral"
										/>     		                         
										
    		                         <asp:BoundColumn 
										HeaderText="Start Date"  
										DataField="startDateAsMMDDYYYYAMPM"
										/> 
										
    		                         <asp:BoundColumn 
										HeaderText="End Date"  
										DataField="endDateAsMMDDYYYYAMPM"
										/> 
    		                             		                            
    		                         <asp:BoundColumn 
										HeaderText="Date Created" 
										DataField="dateCreatedAsMMDDYYYY"
										/>     		                            
    		                         
    		                         <asp:BoundColumn 
										HeaderText="Date Updated" 
										DataField="dateUpdatedAsMMDDYYYY"
										/>     		                                		                         
   		                         

   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Edit" 		
                                	        Text="Edit" 
    		                                DataNavigateURLField="eventIdentifier"
    		                                DataNavigateURLFormatString="ContactEventEdit.aspx?ContactEventID={0}"
    		                                Visible="False"
    		                                > 	
   		                            </asp:HyperLinkColumn>   		    		                         
   		                            
   		                            
   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Delete" 		
                                	        Text="Delete" 
    		                                DataNavigateURLField="eventIdentifier"
    		                                DataNavigateURLFormatString="ContactEventDelete.aspx?ContactEventID={0}"
       		                                Visible="False"
    		                                > 	
   		                            </asp:HyperLinkColumn>   		    		                            		                            
   		                            
									<asp:TemplateColumn HeaderText="Edit"
							            HeaderStyle-HorizontalAlign="center">
									            
							            <ItemTemplate>
							              <center>
							              	<a href='<%#"ContactEventEdit.aspx?ContactEventID=" + DataBinder.Eval(Container.DataItem, "eventIdentifier")%>'>
							                <img src='images/edit.gif' border=0>
							                </a>
							              </center>
							            </ItemTemplate>
									            
						          </asp:TemplateColumn>
						          
						        
                           		    
									<asp:TemplateColumn HeaderText="Delete"
							            HeaderStyle-HorizontalAlign="center">
									            
							            <ItemTemplate>
							              <center>
							              	<a onclick="return confirm(&quot;Are you sure you want to make a delete this entry ?&quot;);" 
							              	   href='<%#"DBUpdate.aspx?DBItemType=EventItemDelete&DBItemEntryID=" + DataBinder.Eval(Container.DataItem, "eventIdentifier")%>'>
							                <img src='images/close.gif' border=0>
							                </a>
							              </center>
							            </ItemTemplate>
									            
						          </asp:TemplateColumn>   		                               		                               		                            
   		                            
                                 </columns>                        
                           		
                              </asp:DataGrid>                    
                              
                            </TD>
                        </TR>                                                                                                                                           
     




                       <TR>
                            <TD>
                                
                               <asp:HyperLink 
                                id="idAnchorAddContactAttachment"
                                NavigateUrl="ContactAttachmentEdit.aspx"
                                Text="Add Contact Attachment"
                                runat="server"/>                                
                                 
                            </TD>
                        </TR>                                                      
                         
                        <TR>
                            <TD>                    
                              <asp:DataGrid 
                                   id="gridContactAttachmentInfo"
                                   BorderColor="black"
                                   BorderWidth="1"
                                   CellPadding="3"
                                   AutoGenerateColumns="false"
                                   runat="server"
                                   font-size="8"                                                                      
                                   width='100%'>

                                 <HeaderStyle BackColor="#9FBCE3">
                                 </HeaderStyle>
                        
                                 <ItemStyle BackColor="#EEF2F7">
                                 </ItemStyle>
                                             
                                 <AlternatingItemStyle BackColor="#EEEEEE">                                 
                                 </AlternatingItemStyle>                                 
                                                                  
                                 <columns>
    		                            
   		                             <asp:HyperLinkColumn 
        		                            HeaderText="View" 		
                                	        DataTextField="attachmentName" 
    		                                DataNavigateURLField="documentAttachmentIdentifier"
    		                                DataNavigateURLFormatString="ContactAttachmentView.aspx?documentAttachmentIdentifier={0}"
    		                                Visible="True"
    		                                Target="_blank"
    		                                > 	
   		                            </asp:HyperLinkColumn> 
   		                                		                            

    		                         <asp:BoundColumn 
    		                            HeaderText="Attachment File"  
    		                            DataField="attachmentFilename"/> 
   		                            
    		                         <asp:BoundColumn 
    		                            HeaderText="Date Attached"  
    		                            DataField="dateCreatedAsString"/> 
    		                               		                            
   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Delete" 		
                                	        Text="Delete" 
    		                                DataNavigateURLField="documentAttachmentIdentifier"
    		                                DataNavigateURLFormatString="DBUpdate.aspx?ContactEventID={0}"
       		                                Visible="False"
    		                                > 	
   		                            </asp:HyperLinkColumn>   		    		                            		                            
						        
                           		    
									<asp:TemplateColumn HeaderText="Delete"
							            HeaderStyle-HorizontalAlign="center">
									            
							            <ItemTemplate>
							              <center>
							              	<a onclick="return confirm(&quot;Are you sure you want to make a delete this entry ?&quot;);" 
							              	   href='<%#"DBUpdate.aspx?DBItemType=AttachmentItemDelete&DBItemEntryID=" + DataBinder.Eval(Container.DataItem, "documentAttachmentIdentifier")%>'>
							                <img src='images/close.gif' border=0>
							                </a>
							              </center>
							            </ItemTemplate>
									            
						          </asp:TemplateColumn>   		                               		                               		                            
   		                            
                                 </columns>                        
                           		
                              </asp:DataGrid>                    
                              
                            </TD>
                        </TR>                                                                                                                                           
     
     
     
                       <TR>
                            <TD>

                               <asp:HyperLink 
                                id="idAnchorBrowseContactComment"
                                NavigateUrl="ContactCommentBrowse.aspx"
                                Text="Contact Comment"
                                runat="server"/>
                                 
                            </TD>
                        </TR>                                                                        
                        
                        
                    </TABLE>	                    

                    
                  </form>                    

				</td>
               
            </TR>                  
            
            

            
            
   
          </TABLE>
          
    </body>          
             
</HTML>
