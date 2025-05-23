<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Web.Security" %>

<%@ Page
 
	Language="c#" 
        src="CommunicationTypesEdit.cs" 
        Inherits="EphraimTech.RemindME.frmCommunicationTypesEdit" 
        EnableSessionState=True 
        
%>
<HTML>

<HEAD>
<TITLE>
RemindME - Communication Types Add/Edit
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
        //document.forms(0).cbCommunicationType.focus();        
        
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
               width='80%' 
               height='24'>
          
          <TABLE
                 background="background_arctic.gif"
                 border="0" 
                 cellpadding="0" 
                 cellspacing="0"
                 width="80%">                           
          

      
            <TR VALIGN='top'>
            
                <TD  VALIGN='top' align="left" width="20%">
                    <IMG SRC='left_image_arctic.jpg'>
                </TD>


					<td VALIGN='top' align="left" width="80%">
										

                        <div style='width:600;height:250;position:absolute;top:1px;left:1px;visibility:hidden;' 
                             id='EphraimWebDialog'>
                             
                        <div class='dialogBody' id='dialogBody'>

                        <div class='dialogTitle' id='dialogTitle'>

                            Add/Edit Communication Type
    
                        </div>
                        
                        

	                    <asp:Label id="labelSQL" runat="server" visible="false" /> 
	                    <asp:Label id="labelDebug" runat="server" visible="false" /> 
	                    <br>
	                    

                        <TABLE cellpadding='0' border='0' cellspacing='10'  width='60%'>    
                            
                                <form  id=frmCommunicationEdit 
                                       method="post" 
                                       runat="server">
                                       
                                    <input id="hiddenCommunicationTypeID" type=hidden runat="server">                                       
                                    
                                    <input id="hiddenURLCaller" type=hidden runat="server">                                                                           
                                    
                                    <TR>
                                    
                                        <TD COLSPAN=2 ALIGN='CENTER'>
                                        
                                        	<asp:Label
                                        	
                                        	     id="labelErrMessage" 
                                        	     ForeColor="red"
                                        	     Font-Name="Verdana"
                                        	     Font-Szie="10"
                                        	     runat="server" 
                                            	 />                            
                    
                                        </TD>                
                                        
                                    </TR>                                            	             
                                                                        
                                                    
                                    <TR>
                                        <TD COLSPAN=1 ALIGN='RIGHT'>
                                            Communication Type
                                        </TD>                
                                        <TD COLSPAN=1 ALIGN='LEFT'>
                                
                                        	<asp:TextBox
                                        	     id="txtCommunicationType" 
                                        	     text="" 
                                        	     MaxLength="40"
                                        	     Columns="40"                    	     
                                        	     runat="server" 
                                            	 />        
                                        </TD>
                                    </TR>                                            	             

                                    
                                    <TR>
                                    
                                        <TD COLSPAN=1 ALIGN='RIGHT'>
                                            Is Private
                                        </TD>                
                                    
                                        <TD COLSPAN=1 ALIGN='LEFT'>
                                
                                        	<asp:Checkbox
                                        	     id="chkIsPrivate" 
                                        	     runat="server" 
                                            	 />        
                                            	 
                                        </TD>
                                        
                                    </TR>                                            	                                         
                                    
                                    
                                    <TR>
                                    
                                        <TD COLSPAN=1 ALIGN='RIGHT'>
                                            Is Phone
                                        </TD>                
                                    
                                        <TD COLSPAN=1 ALIGN='LEFT'>
                                
                                        	<asp:Checkbox
                                        	     id="chkIsPhone" 
                                        	     runat="server" 
                                            	 />        
                                            	 
                                        </TD>
                                        
                                    </TR>                                            	                                         
                                    
                                    <TR>
                                    
                                        <TD COLSPAN=1 ALIGN='RIGHT'>
                                            Is Web Site
                                        </TD>                
                                    
                                        <TD COLSPAN=1 ALIGN='LEFT'>
                                
                                        	<asp:Checkbox
                                        	     id="chkIsWebSite" 
                                        	     runat="server" 
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
                                            	 />        
                                            	 
                                            	 
                                        	<asp:Button 
                                        		 type="submit" 
                                        	     id="btnDiscard" 
                                        	     text="Discard" 
                                        	     runat="server" 
                                        	 	 BackColor='BlanchedAlmond'
                                        	 	 ForeColor='Black'
                                        	 	 OnClick='DiscardBtnClicked'                                        	 	 
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
             
</HTML>