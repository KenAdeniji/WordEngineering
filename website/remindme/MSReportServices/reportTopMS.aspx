<%@ Page
 
	Language="c#" 
        src="ReportTopMS.cs" 
        Inherits="PeopleSoft.ITDBA.reportWriter.frmReportMS" 
        EnableSessionState=True
        
%>
<HTML>

<HEAD>
<TITLE>
MS Report Services 1.0
</TITLE>


<script language='javascript'>

    function generateReport(iChkInaNewWindow, strReportType)
    {

        var strReportID;
        var strReportType;
        var boolChkInaNewWindow = false;
        
        var strURLDestination; 
        
        //alert('Number of forms is ' + document.forms.length);
        //alert('Name of form is ' + document.forms[0].name);
        //alert('Check box is ' + document.forms[0].chkInaNewWindow);        
                
        //strReportID = document.forms[0].cbReportID.value;
        //strReportType = document.forms[0].cbReportType.value;        
        //boolChkInaNewWindow = document.frmReport.chkInaNewWindow.checked;   
        
        strReportID = "1";
        //strReportType = "1";
        //boolChkInaNewWindow = true;
       
        if ((strReportID != null) && (strReportID != ''))
        {
        
            strURLDestination = "reportMS.aspx";
            strURLDestination = strURLDestination + "?reporttype=" + strReportType;
            
            //alert('URL Destination is ' + strURLDestination);   
            
            //window.parent.frames("bottom").navigate(strURLDestination);

            if (iChkInaNewWindow == 1)
            {
                window.open(strURLDestination);
            }
            else
            {
                //window.parent.frames("bottom").navigate("blankframepageMS.htm");            
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
            runat='server'>          
            
			  <TABLE 
			  	 BORDER=0 
			  	 BGCOLOR='white' 
                 cellpadding='2' 
                 cellspacing='2'
                 >                           

        	<TR><TD>
    	   		<TABLE BORDER=0 cellpadding='0' cellspacing='1' BGCOLOR='white'>	
            	<TR>
            		<TD COLSPAN=3 align='left'>
					
            			<asp:Label 
							id="LabelDebug" 
							Text="" 
							runat="server" 
							ForeColor="Pink" 
							visible=false
							/>        		
							
            			<asp:Label 
							id="LabelInfo" 
							Text="" 
							runat="server" 
							ForeColor="Brown" 
							visible=false
							/>
							
            			<asp:Label 
							id="LabelSQL" 
							Text="" 
							runat="server" 
							ForeColor="Red" 
							visible=false
							/>        	

            			<asp:Label 
							id="labelTrail" 
							Text="Trail..." 
							runat="server" 
							ForeColor="Blue" 
							visible=false
							/>        	
							
            		</TD>
            	</TR>        
            	
            	</TABLE>
            </TD></TR>
                            
            <TR>
            
            
            
                <TD COLSPAN=3>
                
       			  <TABLE BORDER=0 cellpadding='0' cellspacing='2' BGCOLOR='white'>	
       			  
       			  <TR><TD>
       			  
                    Report
                
                    <asp:DropDownList 
                         id="cbReportID" 
                         OnSelectedIndexChanged="reportSelected"                         
                         runat="server" 
                         AutoPostBack="True" 
                    >                   
                    
                    
                    </asp:DropDownList>

                

                    
                   	<asp:CheckBox
                	     id="chkInaNewWindow"  
                	     runat="server"
                	     text="In a new window" 
                         AutoPostBack="False"
						 Visible="false"
						 >
                	</asp:CheckBox>         
                	
                    <a href='../cover.aspx' target=_parent>
                        <img src='../back2.gif' border=0
						>
					</a>  
					
                  
                  </TD></TR>  
                  
       			  </TABLE>                    
       			  
                </TD>                                                    
            </TR>                        
            
   
            
        <TR>
        
        	<TD align=left>
        	
			  <TABLE BORDER=0 cellpadding='0' cellspacing='2' BGCOLOR='white'>	
        		
        		  <TR>
        		  
	        		  <TD>	
		        		<asp:Label id="LabelParameter1" Text="Parameter1" runat="server" ForeColor="Black" visible=true/>				
					  </TD>
	        		  <TD>			        		
						<asp:TextBox id="textParameter1" Columns="10" MaxLength="40"  visible=true runat="server"/>
	                    <asp:DropDownList 
	                         id="cbParameter1" 
	                         runat="server" 
	                         AutoPostBack="False"/>	        		  		        		
					  </TD>
					  					  	
	        		  <TD>	
		        		<asp:Label id="LabelParameter2" Text="Parameter2" runat="server" ForeColor="Black" visible=true/>				
					  </TD>
	        		  <TD>			        		
						<asp:TextBox id="textParameter2" Columns="10" MaxLength="40"  visible=true runat="server"/>
	                    <asp:DropDownList 
	                         id="cbParameter2" 
	                         runat="server" 
	                         AutoPostBack="False"/>	        		  		        								
					  </TD>
	        		  
	        		  <TD>		
		        		<asp:Label id="LabelParameter3" Text="Parameter3" runat="server" ForeColor="Black" visible=true/>				
					  </TD>
	        		  <TD>						   	        		
						<asp:TextBox id="textParameter3" Columns="10" MaxLength="40"  visible=true runat="server"/>
	                    <asp:DropDownList 
	                         id="cbParameter3" 
	                         runat="server" 
	                         AutoPostBack="False"/>	        		  		        								
					  </TD>
					  
				  </TR>							  
					  
				  <TR>							  					  
	        		  <TD>	
		        		<asp:Label id="LabelParameter4" Text="Parameter4" runat="server" ForeColor="Black" visible=true/>				
					  </TD>
	        		  <TD>			        		
						<asp:TextBox id="textParameter4" Columns="10" MaxLength="40"  visible=true runat="server"/>
	                    <asp:DropDownList 
	                         id="cbParameter4" 
	                         runat="server" 
	                         AutoPostBack="False"/>	        		  		        								
					  </TD>
					  	
	        		  <TD>	
		        		<asp:Label id="LabelParameter5" Text="Parameter5" runat="server" ForeColor="Black" visible=true/>				
					  </TD>
	        		  <TD>			        		
						<asp:TextBox id="textParameter5" Columns="10" MaxLength="40"  visible=true runat="server"/>
	                    <asp:DropDownList 
	                         id="cbParameter5" 
	                         runat="server" 
	                         AutoPostBack="False"/>	        		  		        								
					  </TD>
	        		  
	        		  <TD>		
		        		<asp:Label id="LabelParameter6" Text="Parameter6" runat="server" ForeColor="Black" visible=true/>				
					  </TD>
	        		  <TD>						   	        		
						<asp:TextBox id="textParameter6" Columns="10" MaxLength="40"  visible=true runat="server"/>
	                    <asp:DropDownList 
	                         id="cbParameter6" 
	                         runat="server" 
	                         AutoPostBack="False"/>	        		  		        								
					  </TD>					  
				  
				  </TR>		
				  
				  
				
        		</TABLE>				
				
        	</TD>        	
        	
        </TR>        
            
        <TR>
        	<TD COLSPAN=3 align=right>
        	
        	<asp:Button 
        		 type="button" 
        	     id="btnQueryHidden" 
        	     text="hiddenBtnClick" 
        	     runat="server" 
        	     visible="false"
        	 	 BackColor='BlanchedAlmond'
        	 	 ForeColor='Black' />        	
        	
        	<asp:Button 
        		 type="button" 
        	     id="btnQuery" 
        	     text="Get Report" 
        	     runat="server" 
        	     OnClick="BtnGetReportClicked"
        	 	 ForeColor='Black' />


            <A 
				href="javascript:void(0)"
				onclick="window.parent.bottom.focus(); print();"
				Visible="false"	
                runat="server"				
				>
				
                <IMG 
					alt="print page" 
					border=0  
					src="..\images\Printer\printer.jpg"
					Visible="false"
				>                
            </A>
        	 	 
        	 	 
            </TD>
        </TR>                        
            
   
        </TABLE>
        
	</FORM>        

    <td><tr>       
    </table>
    
    </body>          
             
</HTML>
