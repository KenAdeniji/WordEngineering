<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="ContactEdit.cs" 
        Inherits="EphraimTech.RemindME.frmContactEdit" 
        EnableSessionState=True 
        AutoEventWireup=True
        
%>
<HTML>

<HEAD>
<TITLE>
RemindME - Contact Edit
</TITLE>
    
<style>

.dialogTitle
{

    BORDER-BOTTOM: 0px;
    BORDER-LEFT: 0px;
    BORDER-RIGHT: 0px;
    BORDER-TOP: 01px;
    COLOR: white;
    FONT-SIZE: 14px;
    FONT-WEIGHT: 900;
    HEIGHT: 35px;
    PADDING-LEFT: 4px;
    PADDING-TOP: 10px;
    TEXT-ALIGN: left
}

.dialogBody
{
    BORDER-BOTTOM: black 0px solid;
    BORDER-LEFT: white 0px solid;
    BORDER-RIGHT: black 0px solid;
    BORDER-TOP: white 0px solid
}

.titleFont
{
    FONT-SIZE: 14px;
    FONT-WEIGHT: 900;
	COLOR: white;
}

</style>


<SCRIPT LANGUAGE="JavaScript" TYPE="text/javascript">
<!--

    // these are the scripts that are called in the links.
    
    var DHTML = (document.getElementById || document.all || document.layers);
    
    function invi(flag)
    {
    	if (!DHTML) return;
    	var x = getObj('text');
    	x.visibility = (flag) ? 'hidden' : 'visible'
    }
    

    
    
    function getObj(name)
    {
    	if (document.getElementById)
    	{
    		return document.getElementById(name).style;
    	}
    	else if (document.all)
    	{
    		return document.all[name].style;
    	}
    	else if (document.layers)
    	{
    		return document.layers[name];
    	}
    }
    
// -->
</SCRIPT>

<script LANGUAGE='javascript'>

    <!--
    

    
    function positionForm()
    {
    
        var strAppName;
        var bMSInternextExplorer = false;
        
        strAppName = window.navigator.appName;
        
        if (strAppName == "Microsoft Internet Explorer")
        {
            bMSInternextExplorer = true;        
        }
        
        if (bMSInternextExplorer == true)
        {    
    
            var dialogTop =0;
            var iLeft = 0;
            
            dialogTop=(document.body.clientHeight/2)-(EphraimWebDialog.offsetHeight/2);
            
            if (dialogTop < 5)
            {
                dialogTop = 5;
            }
    
            
            iLeft = (document.body.clientWidth/2) - (document.all.EphraimWebDialog.offsetWidth/2);
            document.all.EphraimWebDialog.style.top=dialogTop;
            document.all.EphraimWebDialog.style.left=iLeft;
            document.all.EphraimWebDialog.style.visibility='visible';
        }
        else
        {
        
            
            var iDialogLeft = 0;
            var iDialogTop = 0;

                        
            //get Client width
            iClientWidth = window.innerWidth;
            
            //get Client Height
            iClientHeight = window.innerHeight;
            

            objDialog = getObj("EphraimWebDialog");
            
            iDialogWidth = objDialog.width;
            iDialogHeight = objDialog.height;
            
            iDWidth = parseInt(iDialogWidth)
            iDHeight = parseInt(iDialogHeight)
            
            iDialogLeft = ( (iClientWidth - iDWidth) / 2);                        
            iDialogTop = ( (iClientHeight - iDHeight) / 2);            
            
            
            objDialog.top = iDialogTop;
            objDialog.left =iDialogLeft;
            objDialog.visibility='visible';                    
        
        
        }
        
        //set focus to first element
        document.forms(0).txtContact.focus();        
        
    }
    //-->
    
    
    
</script>


</head>    



 <body 
  bgcolor="white" 
  leftmargin="0" 
  topmargin="0" 
  marginheight="0" 
  marginwidth="0"
  onload="positionForm();";
  onresize='positionForm();';  
  > 
 
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
            
                <TD  VALIGN='top' align="left" width="20%">
                    <IMG SRC='left_image_arctic.jpg'>
                </TD>


					<td VALIGN='top' align="left" width="80%">
										

                        <div style='width:700;height:300;position:absolute;top:1px;left:1px;visibility:hidden;' 
                             id='EphraimWebDialog'>
                             
                        <div class='dialogBody' id='dialogBody'>
                        
                   	       <asp:HyperLink
                   	          id="hyperLinkContactBrowse"
							  Text="Return"                   	          
                 			  runat="server">
               			   </asp:HyperLink>         			  
						     
                        </div>

                        <div class='dialogTitle' id='dialogTitle'>

                            Add/Edit Contact Info
    
                        </div>
                        
                        

	                    <asp:Label id="labelSQL" runat="server" visible="false" /> 
	                    <asp:Label id="labelDebug" runat="server" visible="false" /> 
	                    <br>
	                    

                        <TABLE cellpadding='0' border='0' cellspacing='10'  width='90%'>    
                            
                                <form  id=frmContactEdit 
                                       method="post" 
                                       runat="server"
                               	       enableviewstate="true"                                  	 	 
                                       >
                                       
                                   
                                   

                                    <TR>
                                    
                                    
                                        <TD COLSPAN=1 ALIGN='RIGHT'>
                                            Contact
                                        </TD>                
                                        <TD COLSPAN=1 ALIGN='LEFT'>
                                
                                        	<asp:TextBox
                                        	     id="txtContact" 
                                        	     text="" 
                                        	     MaxLength="80"
                                        	     Columns="60" 
                                        	     runat="server" 
                                            	 />        
                                        </TD>
                                    </TR>                                            	             
                                                                        
                                    
                                    <TR>
                                        <TD COLSPAN=1 ALIGN='RIGHT'>
                                            Affiliate
                                        </TD>                
                                        
                                        <TD COLSPAN=1 ALIGN='LEFT'>
                                
	                                        <asp:DropDownList 
	                                             id="cbAffliate" 
	                                             runat="server" 
	                                             AutoPostBack="False" 
	                                        />                                
	                                        
                                   	       <a id="htmlAnchorManageAffliates" OnServerClick="htmlAnchorManageListClick" runat="server"><img src='edit.gif' border=0></a>	  
	                                            
                                        </TD>
                                    </TR>                                            	             
                                                                        
                                                    
                                    <TR>
                                        <TD COLSPAN=1 ALIGN='RIGHT'>
                                            Profession
                                        </TD>                
                                        
                                        <TD COLSPAN=1 ALIGN='LEFT'>
                                
	                                        <asp:DropDownList 
	                                             id="cbProfession" 
	                                             runat="server" 
	                                             AutoPostBack="False" 
	                                        />  
	                                        
                                   	       <a id="htmlAnchorManageProfessions"
                                 			  OnServerClick="htmlAnchorManageListClick"
                                 			  runat="server"><img src='edit.gif' border=0>
                               			</a>         			  	                                                                                            
	                                        
                                        </TD>
                                    </TR>                                            	             


                                    <TR>
                                        <TD COLSPAN=1 ALIGN='RIGHT'>
                                            Date of Birth
                                        </TD>                
                                        
                                        <TD COLSPAN=1 ALIGN='LEFT'>
                                
	                                        <asp:TextBox
	                                             id="txtDOB" 
	                                             runat="server" 
	                                             AutoPostBack="False" 
	                                        />                                
	                                    

                                        </TD>
                                        
                                        
                                    </TR>    
                                    
                                    <TR>
                                        <TD COLSPAN=1 ALIGN='RIGHT'>
                                            Comment
                                        </TD>                
                                        
                                        <TD COLSPAN=1 ALIGN='LEFT'>
                                
                                        	<asp:TextBox
                                        	     id="txtComment" 
                                        	     text="" 
                                        	     MaxLength="255"
                                        	     Columns="40"                    	     
                                        	     runat="server" 
                                        	     TextMode="MultiLine"                   	     
                                        	     Rows="6"                                        	     
                                            	 />        
	                                        
                                        </TD>
                                    </TR>                                            	             

                                    
                                    <TR>
                                    
                                        <TD COLSPAN=2 ALIGN='RIGHT'>
                                
                                        	<asp:Button 
                                        	     type="submit" 
                                        	     id="btnSave" 
                                        	     text="Save" 
                                        	     runat="server" 
                                        	     BackColor='BlanchedAlmond'
                                        	     ForeColor='Black'
                                        	     OnClick='SaveBtnClicked'      
                                        	     AutoPostBack="True"                                 	 	 
                                            	 />        
                                            	 
                                            	 

                                            	                                             	 
                                        </TD>
                                        
                                    </TR>                                            	 
                    
                                                    
                                </form>                	 
                                	 
                    	
                        </TABLE>	
        
             
                        </div>
                        </div>



					</td>
               
            </TR>                  
            
            
   
          </TABLE>

</BODY>


<script language='jscript'>

    function CSValidateDOB(source, auguments)
    {
    
    
        try
        {
            //t = Date.parse(auguments.Value);
            
            //alert('Date is ' + '[' + auguments.Value + ']' +  t);
            
            auguments.IsValid = true;        

            
        }
        catch(e)
        {
            auguments.IsValid = false;
            auguments.IsValid = true;        
        }
        
        auguments.IsValid = true;        
        
      
    
    }
    

</script>
             
</HTML>