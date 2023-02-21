<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="queryActiveDirectory.cs" 
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
					Query Type
	   			</TD>					
	   			<TD>	   			
                    <asp:DropDownList 
                         id="cbQueryType" 
                         runat="server" 
                         OnSelectedIndexChanged="cbQueryTypeSelectionIndexChanged"
                         AutoPostBack="True">
                         
                             <asp:ListItem Value='1'>List Group Members</asp:ListItem>
                             <asp:ListItem Value='2'>List the groups that a user belongs to</asp:ListItem>
                             
                    </asp:DropDownList>					  	                         
	   			</TD>
	   		</TR>
	   		
	   		<TR>
	   			<TD>
    				<asp:Label 
    					id="LabelParameter1" 
    					Text="Parameter1"        					
    					runat="server" 
    					visible=true/>					  					       		  
	   			</TD>
	   			<TD>					
					<asp:TextBox 
						id="txtParameter1" 
						Columns="30" 
						MaxLength="40" 
						visible=true 
						runat="server"/>
				
											
                <asp:DropDownList 
                     id="cbParameter1" 
                     runat="server" 
                     AutoPostBack="False"/>
                         
	   			</TD>
	   		</TR>
	   			   			
        	<TR>	   			
	   			<TD colspan=2 align='right'>						   			                         
                         
				      <asp:Button 
				      	   id="ButtonQueryAD"
				           Text="Query Active Directory"
				           OnClick="QueryActiveDirectory"
				           runat="server"/>                         
					  	                         
	   			</TD>
	   		</TR>
	   			   		
        	<TR>
        		<TD COLSPAN=3 align='left'>
        			<asp:Label id="labelInfo" Text="" runat="server" ForeColor="Red" visible=true/>
        			<asp:Label id="labelSQL" Text="" runat="server" ForeColor="Red" visible=true/>        			
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
