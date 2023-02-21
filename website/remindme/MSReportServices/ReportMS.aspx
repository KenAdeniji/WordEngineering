<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Register 
	Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" 
	%>

<%@ Page
		Language="c#" 
        src="ReportMS.cs" 
        Inherits="PeopleSoft.ITDBA.reportWriter.frmReport" 
        EnableSessionState=True
		EnableViewState=True

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

  <form
		runat='server'
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
        			    Text="" 
        			    runat="server" 
        			    ForeColor="Red" 
						Visible="True"												
						/>

        			<asp:Label 
        			    id="labelReportName" 
        			    Text="" 
        			    runat="server" 
        			    ForeColor="Olive"
						Visible="True"						
						/>						
						
        			<asp:Label 
        			    id="labelErrLog" 
        			    Text="" 
        			    runat="server" 
        			    ForeColor="Red" 
						Visible="True"
						/>

					    <rsweb:ReportViewer 
					        ShowPrintButton="True"
					        ID="reportViewer" 
					        runat="server"   
					        SizeToReportContent="true" 
					        Font-Names="Verdana" 
					        Font-Size="8pt"
					        ShowDocumentMapButton="false"
					        ShowZoomControl="false"
							width="100%"
							>
					    </rsweb:ReportViewer>

  </form>
          
    </body>          
             
</HTML>
