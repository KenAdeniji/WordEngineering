<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="Reportframetop.cs" 
        Inherits="EphraimTech.RemindME.frmReport" 
        EnableSessionState=False
        
%>
<HTML>

<HEAD>
<TITLE>
Reports
</TITLE>


<script language='javascript'>

    function generateReport()
    {

        var strReportID;
        var strReportType;
        var boolChkInaNewWindow = false;
        
        var strURLDestination; 
        
        strReportID = document.forms[0].cbReportID.value;
        strReportType = document.forms[0].cbReportType.value;        
        boolChkInaNewWindow = document.forms[0].chkInaNewWindow.checked;   
        
       
        if ((strReportID != null) && (strReportID != ''))
        {
        
            strURLDestination = "reportActual.aspx?reportid="+strReportID;
            strURLDestination = strURLDestination + "&reporttype=" + strReportType;
            
            //alert('URL Destination is ' + strURLDestination);   
            
            //window.parent.frames("bottom").navigate(strURLDestination);

            if (boolChkInaNewWindow)
            {
                window.open(strURLDestination);
            }
            else
            {
                window.parent.frames("bottom").navigate(strURLDestination);
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
 
          
          <TABLE
                 border="0" 
                 cellpadding="0" 
                 cellspacing="0"
                 width="90%">                           
    				
				  									
                  <form id='frmReport' 
                        method='post' 
                        runat='server'>
                        
  
                    
                    <TR>
                    
                        <TD>
                            Report
                        
                            <asp:DropDownList 
                                 id="cbReportID" 
                                 runat="server" 
                                 AutoPostBack="False" 
                            >                   
                            
                            
                            </asp:DropDownList>


                        
                            Extract Type
                                                    
                            <asp:DropDownList 
                                 id="cbReportType" 
                                 runat="server" 
                                 AutoPostBack="False" 
                            >                   
                        
                                <asp:ListItem>HTML</asp:ListItem>
                                <asp:ListItem>Excel</asp:ListItem>
                                <asp:ListItem>Word</asp:ListItem>
                                                            
                            </asp:DropDownList>
                            
                           	<asp:CheckBox
                        	     id="chkInaNewWindow"  
                        	     runat="server"
                        	     text="In a new window" 
                                 AutoPostBack="False">
                        	</asp:CheckBox>                                       
                                                    
                        	<asp:Button 
                        		 type="button" 
                        	     id="btnQuery" 
                        	     text="Get Report" 
                        	     runat="server" 
                        	 	 BackColor='BlanchedAlmond'
                        	 	 ForeColor='Black' />
                        	
                            <a href='cover.aspx' target=_parent>
                                <img src='back2.gif' border=0>
                            </a>                                
                                                        
                        </TD>
                        
                                                                
                    </TR>                        
                    
                    
                </form>                    

				</td>
               
            </TR>                  
            
   
          </TABLE>
          

                   


          </TABLE>
          
    </body>          
             
</HTML>
