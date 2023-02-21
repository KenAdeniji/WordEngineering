<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="ContactCalendarBrowse.cs" 
        Inherits="EphraimTech.RemindME.frmContactCalendarBrowse" 
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
        BORDER-BOTTOM: black 1px solid;
        BORDER-LEFT: white 1px solid;
        BORDER-RIGHT: black 1px solid;
        BORDER-TOP: white 1px solid
    }


</style>  
 
          <IMG SRC='hor_divider_arctic.gif' 
               width='98%' 
               height='24'>
          
          <TABLE
                 background="background_arctic.gif"
                 border="0" 
                 cellpadding="0" 
                 cellspacing="0"
                 width="98%">                           
          

      
            <TR VALIGN='top'>
            
                <TD  VALIGN='top' align="left" width="20%">
                    <IMG SRC='left_image_arctic.jpg'>
                </TD>


				<td VALIGN='top' align="left" width="80%">
				
                               <asp:HyperLink 
                                id="idAnchorCover"
                                NavigateUrl="Cover.aspx"
                                Text="Return to Cover"
                                runat="server"/>				
				  									
                  <form id='frmCover' 
                        method='post' 
                        runat='server'
                        >
                        
                 <asp:Label id="labelMessage" runat="server" visible=false />                                           
                 <asp:Label id="labelSQL" runat="server" visible=false />                   
	                    
                 <div class='dialogContact' id='dialogContact'>
                 
                    Calendar Type
                                    
                        <asp:RadioButton
                             id="RadioButtonCalendarTypeSelectionDay" 
                             Text="Day"
                             GroupName="CalendarTypeSelection"
                             TextAlign="Right"
                             OnCheckedChanged="RadioCalendarDisplayTypeBtnClicked"                             
                             AutoPostBack="true"
                             runat="server"/>
                             
                        <asp:RadioButton
                             id="RadioButtonCalendarTypeSelectionWeek" 
                             Text="Week"
                             GroupName="CalendarTypeSelection"
                             TextAlign="Right"
                             OnCheckedChanged="RadioCalendarDisplayTypeBtnClicked"
                             AutoPostBack="true"                             
                             runat="server"/>                             
                             
                        <asp:RadioButton
                             id="RadioButtonCalendarTypeSelectionMonth" 
                             Text="Month"
                             GroupName="CalendarTypeSelection"
                             TextAlign="Right"
                             OnCheckedChanged="RadioCalendarDisplayTypeBtnClicked"                                                          
                             AutoPostBack="true"                             
                             runat="server"/>                                                          

                    <BR>
                    

                                                 
                    
                    <TABLE cellpadding='0' border='0' cellspacing='2'  width='100%'>    

                        
                        <TR>
                        
                            <TD ALIGN='left' VALIGN=TOP>
                            
                              <asp:Calendar 
                                   id="calendar" 
                                   runat="server"
                                   OnSelectionChanged="dateSelectionChanged"
                                   OnVisibleMonthChanged="dateSelectionMonthChanged"    
                                   OnDayRender="DayRender"
                                   >
                              </asp:Calendar>                            
                              
                            </TD>                                                    
                            
                            <TD ALIGN='left' VALIGN=TOP >

                              <asp:DataGrid 
                                   id="gridContactCalendarInfo"
                                   BorderColor="black"
                                   BorderWidth="1"
                                   CellPadding="3"
                                   AutoGenerateColumns="false"
                                   runat="server"
                                   font-size="8"                                                                                                         
                                   width='100%'>
                        
                                 <HeaderStyle 
                                     BackColor="Burlywood">
                                 </HeaderStyle>
                                 
                                 <columns>
                                 
    		                         <asp:BoundColumn 
    		                            HeaderText="Label" 
    		                            DataField="eventLabel"/> 
    		                         
    		                         <asp:BoundColumn 
    		                            HeaderText="Event" 
    		                            DataField="eventFormattedDispay"/>     		                         
   		                         
    		                         <asp:BoundColumn 
    		                            HeaderText="Status" 
    		                            DataField="statusCodeLiteral"/>     		                         
    		                               		                         
   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Edit" 		
                                	        Text="Edit" 
    		                                DataNavigateURLField="eventIdentifier"
    		                                DataNavigateURLFormatString="ContactEventEdit.aspx?ContactEventID={0}"> 	
   		                            </asp:HyperLinkColumn>   		    		                         
   		                            
   		                            
   		                             <asp:HyperLinkColumn 
        		                            HeaderText="Delete" 		
                                	        Text="Delete" 
    		                                DataNavigateURLField="eventIdentifier"
    		                                DataNavigateURLFormatString="ContactEventDelete.aspx?ContactEventID={0}"> 	
   		                            </asp:HyperLinkColumn>   	
								

                                 </columns>                        
                           		
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
