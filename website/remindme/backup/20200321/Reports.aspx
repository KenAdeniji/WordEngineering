<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="Reports.cs" 
        Inherits="EphraimTech.RemindME.frmReport" 
        EnableSessionState=True 
        
%>
<HTML>

<HEAD>
<TITLE>
Reports
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
            
      

				<td VALIGN='top' align="left" width="80%">
				
				  									
                  <form id='frmReport' 
                        method='post' 
                        runat='server'>
                        
                        
                        
                <asp:Label 
                    id="labelSQL" 
                    runat="server" 
                    visible=false />                   
	                    
                    
                    
                <TABLE cellpadding='0' border='0' >    
                
                    <TR>
                    
                        <TD>
                           <a href='Cover.aspx?mode=Add'>Cover</a>  
                        </TD>
                        
                    </TR>                                             
                
                
                    <TR>
                    
                        <TD>
                            Report
                        </TD>
                        
                        <TD>
                
                            <asp:DropDownList 
                                 id="cbReport" 
                                 runat="server" 
                                 AutoPostBack="False" 
                            />                                
                            
                        	<asp:Button 
                        		 type="submit" 
                        	     id="btnQuery" 
                        	     text="Get Report" 
                        	     runat="server" 
                        	 	 BackColor='BlanchedAlmond'
                        	 	 ForeColor='Black'
                        	 	 OnClick='QueryBtnClicked' />                                    
                            
                        </TD>
                                                                
                    </TR>                        
                   
                    </TABLE>                

                <TABLE cellpadding='0' border='0' cellspacing='10'>    

                    <TR>
                        <TD>

                          <asp:DataGrid 
                               id="gridReport"
                               BorderColor="black"
                               BorderWidth="1"
                               CellPadding="2"
                               AutoGenerateColumns="true"
                               font-size="8"                                                                                                     
                               runat="server">
                    
                             <HeaderStyle 
                                 BackColor="Burlywood">
                             </HeaderStyle>
                       		
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
