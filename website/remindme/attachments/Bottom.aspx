<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="Bottom.cs" 
        Inherits="_defaultBottom" 
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
 
          
	   		<TABLE BORDER=0 cellpadding='0' cellspacing='1' BGCOLOR='#EFEFEF'>	
        	<TR>
        		<TD COLSPAN=3 align='left'>
        			<asp:Label id="labelInfo" Text="" runat="server" ForeColor="Red" visible=false/>
        			<asp:Label id="labelSQL" Text="" runat="server" ForeColor="Red" visible=false/>        			
        		</TD>
        	</TR>        
        	
        	</TABLE>

        			<asp:Label 
        			    id="labelCaption" 
        			    Text="Report Header" 
        			    runat="server" 
        			    ForeColor="Red" 
        			    visible=true/><br><br>

                          <asp:DataGrid 
                               id="gridReport"
                               BorderColor="black"
                               BorderWidth="1"
                               CellPadding="2"
                               AutoGenerateColumns="true"
                               ShowFooter="false"
                               font-size="8pt"
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


          
    </body>          
             
</HTML>
