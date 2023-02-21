<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="ReportActual.cs" 
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

      <asp:DataGrid 
           id="gridReport"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="2"
           AutoGenerateColumns="true"
           font-size="8"                                                                                                     
           runat="server"
           enableviewstate="false">

         <HeaderStyle 
             BackColor="Burlywood">
         </HeaderStyle>
   		
      </asp:DataGrid>


          
    </body>          
             
</HTML>
