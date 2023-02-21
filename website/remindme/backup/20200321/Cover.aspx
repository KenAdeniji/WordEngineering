<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="Cover.cs" 
        Inherits="EphraimTech.RemindME.frmCover" 
        EnableSessionState=True 
        
%>
<HTML>

<HEAD>
<TITLE>
Cover
</TITLE>


</head>    



 <body 
  bgcolor="white" 
  leftmargin="0" 
  topmargin="0" 
  marginheight="0" 
  marginwidth="0"
  > 
 
          <IMG SRC='hor_divider_arctic.gif' 
               width='80%' 
               height='24'>
               
		  <asp:Label id="labelMemberName" runat="server" visible="false" />               
          
          <TABLE
                 background="background_arctic.gif"
                 border="0" 
                 cellpadding="0" 
                 cellspacing="0"
                 width="80%">                           
          

      
            <TR VALIGN='top'>
            
                <TD  VALIGN='top' align="left" width="20%" colspan=2>
                    <IMG SRC='left_image_arctic.jpg'>
                </TD>


				<td VALIGN='top' align="left" width="80%">
									
                  <form id='frmCover' 
                        method='post' 
                        runat='server'
                        action='Cover.aspx'
						defaultFocus='txtContactSearchTag'
						defaultButton='idAnchorContactSearch'
                        >
                  
                              
                    <TABLE cellpadding='0' border='0' cellspacing='10'  width='100%'>    


                    <TR> 
						<TD colspan=2>
							<asp:Label 
								id="labelInfo" 
								runat="server" 
								visible="false"
								value="Info" 
								/> <br>
						</TD> 
					</TR>	                    

					<TR> 
						<TD colspan=2>
							<asp:Label 
								id="labelSortInformation" 
								runat="server" 
								visible="false"
								value="Info" 
								/> <br>
						</TD> 
					</TR>	                    

					
                    <TR> 
						<TD colspan=2>
							<asp:Label 
								id="labelOrderBy" 
								runat="server" 
								visible="false" 
								value="Order By"
								/> 
								<br>
						</TD> 						
					</TR>	                    
                    
                    <TR> <TD colspan=2>
	                    <asp:Label 
							id="labelSQL" 
							runat="server" 
							visible="false" /> 
							<br>
                    </TD> </TR>	                    

                    
                        <TR>
                        
                            <TD>
                            
                                    <a href='ContactEdit.aspx?mode=Add'>
										Add Contact
									</a>  
                                    
                                    &nbsp&nbsp&nbsp                               
                                    
                                    <a href='ContactCalendarBrowse.aspx'>
										Calendar
									</a>

                                    &nbsp&nbsp&nbsp                               
                                    
                                    <a href='Attachments/frameAttachment.aspx'>
										Attachments
									</a>
                                    &nbsp&nbsp&nbsp   
                                                                        
                                    <a href='reports/ReportFrame.aspx'>
										Reports
									</a>                                                                     
									
									&nbsp&nbsp&nbsp   
                                                                        
                                    <a href='MSReportServices/ReportFrame.aspx'>
										MS Report Services
									</a>          									
                          
                                   
                            </TD>            
                            
                            <TD align='right'>                                                                                                                                                            
                            
                                     <i> Search for Contact </i>
                                     
                                    <asp:TextBox 
                                     ID="txtContactSearchTag" 
                                     maxlength="15"
                                     RunAt="server" />

								  <asp:ImageButton 
									id="idAnchorContactSearch" 
									runat="server"
									ImageUrl="contactus.gif"
                                    OnClick="AnchorBtnClick" />	
                                    
                            </TD>                            
                            
                        </TR>                             
	                    
                        <TR>
                        
                            <TD  colspan=2>
                        
                                 <a id='idAnchorNameA' OnServerClick="AnchorBtnClick" runat=server>A</a> &nbsp
                                 <a id='idAnchorNameB' OnServerClick="AnchorBtnClick" runat=server>B</a> &nbsp                        
                                 <a id='idAnchorNameC' OnServerClick="AnchorBtnClick" runat=server>C</a> &nbsp
                                 <a id='idAnchorNameD' OnServerClick="AnchorBtnClick" runat=server>D</a> &nbsp                        
                                 <a id='idAnchorNameE' OnServerClick="AnchorBtnClick" runat=server>E</a> &nbsp
                                 <a id='idAnchorNameF' OnServerClick="AnchorBtnClick" runat=server>F</a> &nbsp                        
                                 <a id='idAnchorNameG' OnServerClick="AnchorBtnClick" runat=server>G</a> &nbsp
                                 <a id='idAnchorNameH' OnServerClick="AnchorBtnClick" runat=server>H</a> &nbsp                                 
                                 <a id='idAnchorNameI' OnServerClick="AnchorBtnClick" runat=server>I</a> &nbsp                        
                                 <a id='idAnchorNameJ' OnServerClick="AnchorBtnClick" runat=server>J</a> &nbsp
                                 <a id='idAnchorNameK' OnServerClick="AnchorBtnClick" runat=server>K</a> &nbsp                        
                                 <a id='idAnchorNameL' OnServerClick="AnchorBtnClick" runat=server>L</a> &nbsp
                                 <a id='idAnchorNameM' OnServerClick="AnchorBtnClick" runat=server>M</a> &nbsp
                                 <a id='idAnchorNameN' OnServerClick="AnchorBtnClick" runat=server>N</a> &nbsp                        
                                 <a id='idAnchorNameO' OnServerClick="AnchorBtnClick" runat=server>O</a> &nbsp
                                 <a id='idAnchorNameP' OnServerClick="AnchorBtnClick" runat=server>P</a> &nbsp                        
                                 <a id='idAnchorNameQ' OnServerClick="AnchorBtnClick" runat=server>Q</a> &nbsp
                                 <a id='idAnchorNameR' OnServerClick="AnchorBtnClick" runat=server>R</a> &nbsp
                                 <a id='idAnchorNameS' OnServerClick="AnchorBtnClick" runat=server>S</a> &nbsp
                                 <a id='idAnchorNameT' OnServerClick="AnchorBtnClick" runat=server>T</a> &nbsp                        
                                 <a id='idAnchorNameU' OnServerClick="AnchorBtnClick" runat=server>U</a> &nbsp
                                 <a id='idAnchorNameV' OnServerClick="AnchorBtnClick" runat=server>V</a> &nbsp                        
                                 <a id='idAnchorNameW' OnServerClick="AnchorBtnClick" runat=server>W</a> &nbsp
                                 <a id='idAnchorNameX' OnServerClick="AnchorBtnClick" runat=server>X</a> &nbsp
                                 <a id='idAnchorNameY' OnServerClick="AnchorBtnClick" runat=server>Y</a> &nbsp                        
                                 <a id='idAnchorNameZ' OnServerClick="AnchorBtnClick" runat=server>Z</a> &nbsp                              
                                 
                                 <a id='idAnchorNameAll' OnServerClick="AnchorAllBtnClick" runat=server>All</a>
                                 &nbsp                              
                                 
                            </TD>
                            
     
                        </TR>

						
                        <TR>
                        
                            <TD colspan=2>

                              <asp:dataGrid
                                   id="gridContact"
                                   BorderColor="black"
                                   BorderWidth="1"
                                   CellPadding="3"
                                   AutoGenerateColumns="false"
                                   runat="server"
                                   width='100%'
								   AllowSorting="True"
								   onSortCommand="gridContactSortEvent"

                                   >
                        
                                 <HeaderStyle BackColor="#9FBCE3">
                                 </HeaderStyle>
                        
                                 <ItemStyle BackColor="#EEF2F7">
                                 </ItemStyle>
                                             
                                 <AlternatingItemStyle BackColor="#F5F9FD">
                                 </AlternatingItemStyle>
                                                                                          
	                             <Columns>                         
                        
                               		<asp:HyperLinkColumn 
                                
                                		     HeaderText="Contact" 		
                                		     Text="Contact" 
                                             DataTextField="Contact"
                                             DataNavigateUrlField="ContactIdentifier"
                                             DataNavigateUrlFormatString="ContactBrowse.aspx?ContactID={0}"
											 SortExpression="Contact"                                                 
                                             >       
                            				
                           		    </asp:HyperLinkColumn>   		                        
                           		
                           		
		                            <asp:BoundColumn 
		                                HeaderText="Affiliate" 
		                                DataField="Affliate" 
		                                SortExpression="Affliate"
										> 	
	
				
		                            </asp:BoundColumn>
		                            
		                            
		                            <asp:BoundColumn 
		                                HeaderText="Profession" 
		                                DataField="Profession" 
		                                SortExpression="Profession"> 	
	
				
		                            </asp:BoundColumn>		                            

		                            <asp:BoundColumn 
		                                HeaderText="Created On" 
		                                DataField="dateCreatedAsDay" 
		                                SortExpression="dateCreated"> 	
	
				
		                            </asp:BoundColumn>
									
									<asp:TemplateColumn
		                                HeaderText="Created On" 									
										SortExpression="dateCreated"
										Visible="False"
									>
    
										<ItemTemplate>
											<asp:label 
												id="dateCreatedFormattedAsDay" 
												runat="server" 
												text='<%# Eval("dateCreated", "{0:d}") %>' 
											/>
										</ItemTemplate>
										
									</asp:TemplateColumn>									
									
	                             </Columns>                                                    		
                           		
                           		
                              </asp:DataGrid>
                                
                                            	 
                                                                       

                            </TD>
                            
                         </TR>                            
     
                    </TABLE>	


                              
                  </form>                    

				</td>
               
            </TR>                  
            
            
   
          </TABLE>
          

          
    </body>          
             
</HTML>
