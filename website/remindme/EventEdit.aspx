<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<%@ Page
 
	Language="c#" 
        src="EventEdit.cs" 
        Inherits="EphraimTech.EventEdit" 
        EnableSessionState=True 
        
%>




<html>

<head>
<title>
Event Edit
</title>



<style>
.dialogTitle
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
        document.forms(0).editQuote.focus();        
        
    }
    //-->
    
</script>


<script LANGUAGE='javascript'>

    <!--
    
        function selectADay(iControlIndex)
        {
        
            var strCalendarPageBase = null;
            var strCalendarPage = null;            
            var strWindowAttributes = null;
            var strCallerWindowName = null;
            
            var iMonth = "";
            var iDay = "";
            var iYear = "";
            var strDate = "";
            
           
            if (iControlIndex == 1)
            {
                iMonth = QuotesEdit.ddlDateStartMonth.value;
                iDay = QuotesEdit.ddlDateStartDay.value;                
                iYear = QuotesEdit.ddlDateStartYear.value;                                
                strDate = iMonth + '/' + iDay + '/' + iYear;
            }
            else 
            {
                iMonth = QuotesEdit.ddlDateEndMonth.value;
                iDay = QuotesEdit.ddlDateEndDay.value;                
                iYear = QuotesEdit.ddlDateEndYear.value;                                
                strDate = iMonth + '/' + iDay + '/' + iYear;            
            }
            
            strCallerWindowName = "eventEditWin";
            strCalendarPageBase = "CalendarSelectADay.aspx";
            strCalendarPage = strCalendarPageBase + "?date="+strDate;
            
            strWindowAttributes = "dialogWidth:250px;dialogHeight:250px";
            
            strWindowAttributes = "height=400;width=80;";
            
            //window.showModalDialog(strCalendarPage,
            //                       "",
            //                       strWindowAttributes); 
                                   
            //window.showModalDialog(strCalendarPage);
            
            //alert('Calendar Info is ' + strCalendarPage);            

            window.open(strCalendarPage,
                        strCallerWindowName,
                        strWindowAttributes); 

        
        }
    
    //-->
    
</script>    


</head>

<body 
  onload="positionForm();";
  onresize='positionForm();';
  >


<div style='width:600;height:250;position:absolute;top:1px;left:1px;visibility:hidden;' id='EphraimWebDialog'>
<div class='dialogBody' id='dialogBody'>

<div class='dialogTitle' id='dialogTitle'>

    Event Edit
    
</div>


    <TABLE cellpadding='0' border='0' cellspacing='3'  width='100%'>      

    
        <form id="QuotesEdit" action="QuoteEdit.aspx" method="post" runat="server">
        
          
          <TR BGCOLOR='#EEEEEE'>
          
              <TD COLSPAN=2 ALIGN=LEFT>
                
                    <asp:Label id="labelMessage" runat="server" />
                  
              </TD>
              
          </TR>        
                    
          <input id="hiddenQuoteId"
                 type=hidden
                 runat="server">

          <TR>
              <TD COLSPAN=1>
                Event
              </TD>
              
              <TD>                        
                <asp:TextBox 
                   id=editEventName
                   AutoPostBack="False"
                   Columns="60"
                   MaxLength="1000"
                   Rows="7"
                   Wrap="True"
                   runat="server" 
                   />
              </TD>
          </TR>          
          
          
          <TR>
              <TD COLSPAN=1>
                Start Date
              </TD>
              
              <TD COLSPAN=1>              
              
                	<asp:DropDownList 
                	     id="ddlDateStartMonth"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                      
                	
                	<asp:DropDownList 
                	     id="ddlDateStartDay"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                      
                	
                	<asp:DropDownList 
                	     id="ddlDateStartYear"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	

                    <img name='DateStartPicker' 
                         src='images\picker.gif'
                         onClick='javascript:selectADay(1)'>
                	
                	&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                	
                	<asp:DropDownList 
                	     id="ddlTimeStartHour"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	                	
                	
                	
                	<asp:DropDownList 
                	     id="ddlTimeStartMinute"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	
                	
                	<asp:DropDownList 
                	     id="ddlTimeStartAMPM"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	                	

                	<asp:CheckBox
                	     id="chkAllDayEvent"  
                	     runat="server" 
	 	                 OnCheckedChanged="buttonAllDayEventClicked"                                       	     
                         AutoPostBack="True">
                	</asp:CheckBox>                                      	                	                	
                	
                	<i> All Day Event </i>
                	                	
              </TD>              

          </TR>              
          


          <TR>
              <TD COLSPAN=1>
                End Date
              </TD>
              
              <TD COLSPAN=1>              
              
                	<asp:DropDownList 
                	     id="ddlDateEndMonth"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                      
                	
                	<asp:DropDownList 
                	     id="ddlDateEndDay"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                      
                	
                	<asp:DropDownList 
                	     id="ddlDateEndYear"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	

                    <img name='DateEndPicker' 
                         src='images\picker.gif'
                         onClick='javascript:selectADay(2)'>                    
                    
                	
                	&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                	
                	<asp:DropDownList 
                	     id="ddlTimeEndHour"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	
                	
                	<asp:DropDownList 
                	     id="ddlTimeEndMinute"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	
                	
                	<asp:DropDownList 
                	     id="ddlTimeEndAMPM"  
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	                	
                	                	
                	                	
              </TD>              

          </TR>              
          
 
          <TR>
              <TD COLSPAN=1>
                Comment
              </TD>
              
              <TD>                        
                <asp:TextBox 
                   id=editQuote
                   AutoPostBack="False"
                   Columns="60"
                   MaxLength="1000"
                   Rows="4"
                   TextMode="Multiline"
                   Wrap="True"
                   runat="server" 
                   />
        
              </TD>
          </TR>
        

          
          <TR >              
              <TD COLSPAN=2 ALIGN="RIGHT">                        
              
              
               <asp:Button
                   id=buttonAddMore
                   Text="Save And Add More"
                   runat="server"/>
                                 
                <asp:Button
                   id=buttonSubmit
                   Text="Submit"
	 	           OnClick="buttonSubmitClicked"                                          
                   runat="server"/>
                   
                   
              
                <asp:Button
                   id=buttonDelete
                   Text="Delete"
                   runat="server"/>
        
              </TD>
          </TR>
                              
        </form>
    
      </TABLE>    

</div>
</div>

</body>

</html>
