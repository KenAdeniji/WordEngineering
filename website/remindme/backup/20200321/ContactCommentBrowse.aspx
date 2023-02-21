<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="ContactCommentBrowse.cs" 
        Inherits="EphraimTech.RemindME.frmContactCommentBrowse" 
        EnableSessionState=True 
        
%>
<HTML>

<HEAD>
<TITLE>
Contact 
</TITLE>


</head>    



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
                                id="idAnchorContactBrowse"
                                NavigateUrl="ContactBrowse.aspx"
                                Text="Return to Contact"
                                runat="server"/>				
				  									
                  <form id='frmCover' 
                        method='post' 
                        runat='server'
                        action='Cover.aspx'
                        >
                        
                 <asp:Label id="labelSQL" runat="server" visible=false />                   
                 
                 		<div class='dialogTitle' id='dialogTitle'>

	                    	<asp:Label id="labelContactID" runat="server" visible="false" /> 
    
                        </div>                        

                        <div class='dialogTitle' id='dialogTitle'>

                    		<asp:Label id="labelContactName" runat="server" visible="true" ForeColor='green' /> 	                    	
    
                        </div>                                         
	                    
                 <div class='dialogContact' id='dialogContact'>

                  
                    
                    <TABLE cellpadding='0' border='0' cellspacing='10'  width='100%'>    

                       <TR>
                            <TD>

                               <asp:HyperLink 
                                id="idAnchorAddContactComment"
                                NavigateUrl="ContactCommentEdit.aspx"
                                Text="Add Contact Comment"
                                runat="server"/>
                                 
                            </TD>
                        </TR>                            

                        <TR>
                            <TD>

                              <asp:DataGrid 
                                   id="gridContactCommentInfo"
                                   BorderColor="black"
                                   BorderWidth="1"
                                   CellPadding="3"
                                   AutoGenerateColumns="false"
                                   runat="server"
                                   width='100%'>
                        
                                 <HeaderStyle 
                                     BackColor="Burlywood">
                                 </HeaderStyle>
                                 
                                 <columns>
                                 
    		                         <asp:BoundColumn 
    		                            HeaderText="Comment" 
    		                            DataField="Comment" 
    		                            SortExpression="Comment"/> 	                                 
    		                            
    		                         <asp:BoundColumn HeaderText="Date Created" 
    		                                          DataField="DateCreatedAsDate"/>     		                            
    		                         
    		                         <asp:BoundColumn HeaderText="Date Updated" 
    		                                          DataField="DateUpdatedAsDate"/>     		                                		                         
    		                         
   		                         
   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Edit" 		
                                	        Text="Edit" 
    		                                DataNavigateURLField="sequenceIdentifier"
    		                                DataNavigateURLFormatString="ContactCommentEdit.aspx?ContactCommentID={0}"> 	
   		                            </asp:HyperLinkColumn>   		    		                         
   		                            
   		                            
   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Delete" 		
                                	        Text="Delete" 
    		                                DataNavigateURLField="sequenceIdentifier"
    		                                DataNavigateURLFormatString="ContactCommentDelete.aspx?ContactCommentID={0}"
    		                                Visible="False"
    		                                > 	
   		                            </asp:HyperLinkColumn>   		    		                            		                                		                                
    		                                
									<asp:TemplateColumn HeaderText="Delete"
							            HeaderStyle-HorizontalAlign="center">
									            
							            <ItemTemplate>
							              <center>
							              	<a onclick="return confirm(&quot;Are you sure you want to make a delete this entry ?&quot;);" 
							              	   href='<%#"DBUpdate.aspx?DBItemType=ContactCommentItemDelete&DBItemEntryID=" + DataBinder.Eval(Container.DataItem, "sequenceIdentifier")%>'>
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
                                id="idAnchorAddContactCommentBottom"
                                NavigateUrl="ContactCommentEdit.aspx"
                                Text="Add Contact Comment"
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
