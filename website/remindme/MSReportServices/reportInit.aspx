<%@ Page
 
	Language="c#" 
        src="reportInit.cs" 
        Inherits="PeopleSoft.ITDBA.reportWriter.frmReport" 
        EnableSessionState=True
        
%>
<HTML>

<HEAD>
	<TITLE>
		Clear Report Cache v1.01
	</TITLE>
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
            runat='server'>          

            
       	<TR><TD>
	   		<TABLE BORDER=0 cellpadding='0' cellspacing='1' BGCOLOR='white'>	
        	<TR>
        		<TD COLSPAN=3 align='left'>
        			<asp:Label id="LabelInfo" Text="" runat="server" ForeColor="Red" visible=true/>
        			<asp:Label id="LabelSQL" Text="" runat="server" ForeColor="Red" visible=true/>        			
        		</TD>
        	</TR>        
        	
        	</TABLE>
        </TD></TR>

        
	</FORM>        

    <td><tr>       
    </table>
    
    </body>          
             
</HTML>
