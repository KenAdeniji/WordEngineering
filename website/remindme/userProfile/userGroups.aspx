<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="userGroups.cs" 
        Inherits="PeopleSoft.ITDBA.reportWriter.frmReport" 
        EnableSessionState=True
        
%>
<HTML>

 <head>
 	<title>
 		Report
	</title> 	
 </head> 
 <body 
  bgcolor="white" 
  leftmargin="0" 
  topmargin="0" 
  marginheight="0" 
  marginwidth="0"
  > 
 
  <form id='frmAddTelcoItem' 
        method='post' 
        runat='server'>           
                  
	   		<TABLE BORDER=0 cellpadding='0' cellspacing='1' BGCOLOR='#EFEFEF'>	
	   		<TR>
	   			<TD>
					Group &nbsp&nbsp&nbsp	        		  
                    <asp:DropDownList 
                         id="cbADGroup" 
                         runat="server" 
                         AutoPostBack="False"/>
                         
				      <asp:Button 
				      	   id="ButtonGetGroupMembers"
				           Text="Get Group Members"
				           OnClick="ButtonGetGroupMembersClick"
				           runat="server"/>                         
					  	                         
	   			</TD>
	   		</TR>
        	<TR>
        		<TD COLSPAN=3 align='left'>
        			<asp:Label id="labelInfo" Text="" runat="server" ForeColor="Red" visible=false/>
        			<asp:Label id="labelSQL" Text="" runat="server" ForeColor="Red" visible=false/>        			
        		</TD>
        	</TR>        
        	
        	</TABLE>


                          <asp:DataGrid 
                               id="gridReport"
                               BorderColor="black"
                               BorderWidth="1"
                               CellPadding="2"
                               AutoGenerateColumns="true"
                               ShowFooter="false"
                               font-size="10pt"
                               runat="server">
                    
                             <HeaderStyle 
                                 BackColor="Burlywood">
                             </HeaderStyle>
                             
                             <AlternatingItemStyle 
                              BackColor="#eeeeee">
                             </AlternatingItemStyle>
                             
                                 
                             <PagerStyle Mode="NumericPages"
                                         HorizontalAlign="Right">
                             </PagerStyle>
                             
                       		
                          </asp:DataGrid>


  </form>                     
  
    </body>          
             
</HTML>
