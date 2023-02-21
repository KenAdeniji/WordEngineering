<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<%@ Page
 
	Language="c#" 
        src="ContactAttachmentEdit.cs" 
        Inherits="EphraimTech.RemindME.frmContactAttachmentEdit" 
        EnableSessionState=True 

%>




<html>

<head>
<title>
Attachment Edit
</title>



<style>
.dialogTitleArchive
{
    BACKGROUND-COLOR: rgb(49,72,135);
    BORDER-BOTTOM: 1px;
    BORDER-LEFT: 1px;
    BORDER-RIGHT: 1px;
    BORDER-TOP: 1px;
    COLOR: white;
    FONT-SIZE: 14px;
    FONT-WEIGHT: 900;
    HEIGHT: 35px;
    PADDING-LEFT: 4px;
    PADDING-TOP: 10px;
    TEXT-ALIGN: left
}

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
    BACKGROUND-COLOR: lightgrey;
    BORDER-BOTTOM: black 1px solid;
    BORDER-LEFT: white 1px solid;
    BORDER-RIGHT: black 1px solid;
    BORDER-TOP: white 1px solid
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



// -->
</SCRIPT>


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
        
        //set focus to member Name        
        document.forms(0).editEventName.focus();        
        
    }
    //-->
    
</script>


<script LANGUAGE='javascript'>

    <!--
    
    


        
        }                                                    
    
    

    
    //-->
    
</script>    


<script LANGUAGE='javascript'>

    
</script>        

</head>

<body>

<IMG SRC='hor_divider_arctic.gif' 
   width='80%' 
   height='24'>

	<div class='dialogTitle' id='dialogTitle'>
	
	    Event Edit
	    
	</div>


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
                
            <TD>    

    			<div class='dialogTitle' id='dialogTitle' visible='true'>

    				<asp:Label 
    					id="labelContactName" 
    					runat="server" 
    					visible="true"  
    					ForeColor='green' 
    					Text="Joe"/> 	                    	

    				<asp:Label 
    					id="labelContactID" 
    					runat="server" 
    					visible="false"  
    					ForeColor='green' 
    					Text="Joe"/> 	                    	
    					
    			</div>                        

    <TABLE cellpadding='0' border='0' cellspacing='3'  width='100%'>      

    
        <form id="contactEventForm" 
              method="post" 
              runat="server">
        
          
          <TR BGCOLOR='#EEEEEE'>
          
              <TD COLSPAN=2 ALIGN=LEFT>
                
                    <asp:Label id="labelMessage" runat="server"  visible="false"/>
                    <asp:Label id="labelDebug" runat="server"  visible="false"/>
                                      
              </TD>
              
          </TR>        
                    
          <input id="hiddenContacAttachmentID"
                 type=hidden
                 runat="server">
                 
          <input id="hiddenURLReferer" 
                 type=hidden 
                 runat="server">                                                                                            


          <TR>
              <TD COLSPAN=1>
                File Name
              </TD>
              
              <TD>                        
                <input
                   id=editAttachmentFile
                   type=file
                   runat=server
                   />
              </TD>
          </TR>                    
          
          
          <TR>
              <TD COLSPAN=1>
                Attachment Name
              </TD>
              
              <TD>                        
                <asp:TextBox 
                   id=editAttachmentName
                   AutoPostBack="False"
                   Columns="60"
                   MaxLength="120"
                   runat="server" 
                   />
              </TD>
          </TR>          
          
          
          <TR>
              <TD COLSPAN=1>
                Attachment Description
              </TD>
              
              <TD>                        
                <asp:TextBox 
                   id=editAttachmentDescription
                   AutoPostBack="False"
                   Rows="3"                   
                   Columns="60"
                   MaxLength="1000"
                   runat="server" 
                   />
              </TD>
          </TR>          
                    
          <TR >              
              <TD COLSPAN=2 ALIGN="RIGHT">                        
              
                                 
                <asp:Button
                   id=buttonSave
                   Text="Save"
	 	           OnClick="buttonSaveClicked"                                          
                   runat="server"/>


                                      
                <asp:Button
                   id=buttonClose
                   Text="Cancel"
	 	           OnClick="buttonCloseClicked"                                          
                   runat="server"/>
        
              </TD>
              
          </TR>
                              
        </form>
    
      </TABLE>  
      
      </TD>
      
      </TR>
      
      </TABLE>  

</div>
</div>

</body>

</html>
