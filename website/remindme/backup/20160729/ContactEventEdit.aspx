<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<%@ Page
 
	Language="c#" 
        src="ContactEventEdit.cs" 
        Inherits="EphraimTech.RemindME.frmContactEventEdit" 
        EnableSessionState=True 

%>




<html>

<head>
<title>
Event Edit
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

    var iPageSelectSelectADayCaller;

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
    
    
        function selectComboBoxEntry(objComboBox,
                                     strValue)
        {
        
            var iIndex;
            var iNumberofComboBoxEntries;
            var strEntryValue;
            
            iNumberofComboBoxEntries = objComboBox.options.length;
            
            
            //alert('Number of entries is ' + iNumberofComboBoxEntries);
            
            for (iIndex = 0; iIndex < iNumberofComboBoxEntries; iIndex++) 
            {
            
                strEntryValue = objComboBox.options[iIndex].value;
                
                if (strValue == strEntryValue)
                {
                
                    objComboBox.options[iIndex].selected = true;
                    
                    //alert(objComboBox + ' match found at ' + iIndex);
                    
                    
                }
                

            }                    

        
        }                                                    
    
    
        function reflectChosenDates(strChosenDate,
                                    strChosenDateYear,
                                    strChosenDateMonth,
                                    strChosenDateDay)
        {
        
            var strMessage;
            
            strMessage = 'Chosen Date is ' + strChosenDate + ' ' +
                         'Chosen Date Year is ' + strChosenDateYear + ' ' +
                         'Chosen Date Month is ' + strChosenDateMonth + ' ' +                         
                         'Chosen Date Day is ' + strChosenDateDay + ' ' +                         
                         'Caller is ' +  iPageSelectSelectADayCaller;
                         
            //alert( strMessage );
            
            if ( iPageSelectSelectADayCaller == 1)
            {
            
                //alert('reflecting caller 1');
                
                selectComboBoxEntry(document.forms[0].ddlDateStartYear, strChosenDateYear);
                selectComboBoxEntry(document.forms[0].ddlDateStartMonth, strChosenDateMonth);
                selectComboBoxEntry(document.forms[0].ddlDateStartDay, strChosenDateDay);
                                            
            }
            else if ( iPageSelectSelectADayCaller == 2)
            {
            
                //alert('reflecting caller 2');
                            
                selectComboBoxEntry(document.forms[0].ddlDateEndYear, strChosenDateYear);
                selectComboBoxEntry(document.forms[0].ddlDateEndMonth, strChosenDateMonth);
                selectComboBoxEntry(document.forms[0].ddlDateEndDay, strChosenDateDay);
                                            
            }            
        }

    
        function selectADay(iCallerIndex)
        {
        
            var strCalendarPageBase = "";
            var strCalendarPage = "";            
            var strWindowAttributes = "";
            var strCallerWindowName = "";
            
            var iMonth = "";
            var iDay = "";
            var iYear = "";
            var strDate = "";
            
            var iWindowLeft;
            var iWindowTop;
            
            var objWindowCalendar;
            
            //save select a day caller
            iPageSelectSelectADayCaller = iCallerIndex;
           
            if (iCallerIndex == 1)
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
            
            iWindowWidth = 250;
            iWindowHeight = 250;
            
            //alert('width is ' + screen.width);
            //alert('height is ' + screen.height);
                       
            iWindowLeft = (screen.width - iWindowWidth) / 2;
            iWindowTop = (screen.height - iWindowHeight) / 2;

            strWindowAttributes = "";            
            strWindowAttributes = strWindowAttributes + "left="+iWindowLeft;            
            strWindowAttributes = strWindowAttributes + ",top="+iWindowTop;            
            strWindowAttributes = strWindowAttributes + ",width="+iWindowWidth;            
            strWindowAttributes = strWindowAttributes + ",height="+iWindowHeight;                        
            strWindowAttributes = strWindowAttributes + ",resizable=yes";                        
  
            //alert("Window Attributes is " + strWindowAttributes);
                                                
            objWindowCalendar = window.open(strCalendarPage,
                                            strCallerWindowName,
                                            strWindowAttributes); 
                        
            //set focus                        
            objWindowCalendar.focus();                                    

        
        }
    
    //-->
    
</script>    


<script LANGUAGE='javascript'>

    var bEndDateModified = false;
    var strContactEventID = "";    
    
    
    function getContactEventID()
    {
    
        var strContactEventID = "";    
            
        //Get contact event ID
        strContactEventID = document.forms[0].hiddenContactEventID.value;
        
        return strContactEventID;
        
    }
    
    
    
    function isContactEventNew(strContactEventID)
    {
    
        var bNewRecord = false;
            
        if (strContactEventID == undefined)
        {
            bNewRecord = true;
        }
        else
        {
            if (strContactEventID == "")
            {
                bNewRecord = true;                    
            }
            else
            {
                bNewRecord = false;                    
            }
        }
        
        return (bNewRecord);
    
    }
    
    function BeginDateModified()
    {
    
        var strContactEventID = "";
        var bNewRecord = false;
        var bSameDayEvent = false;
        
        //get Contact ID
        strContactEventID = getContactEventID();
        
        //is Contact Event New
        bNewRecord = isContactEventNew(strContactEventID)
        
        //alert("Same day event is " + document.forms(0).chkSameDayEvent.checked);
        
        bSameDayEvent = document.forms(0).chkSameDayEvent.checked;
        
        //alert("Begin Date Modified.  " +
        //      "Contact Event ID is " + 
        //      "[" + strContactEventID + "] " +
        //      "Record is new " + bNewRecord);

        //if end date has not been modified and same day event
        //then have end date reflect begin date        
        if ((bEndDateModified == false) && (bSameDayEvent == true))
        {
            //alert("Setting End Date");
            
            document.forms(0).ddlDateEndMonth.selectedIndex = 
                document.forms(0).ddlDateStartMonth.selectedIndex;

            document.forms(0).ddlDateEndDay.selectedIndex = 
                document.forms(0).ddlDateStartDay.selectedIndex;
                
            document.forms(0).ddlDateEndYear.selectedIndex = 
                document.forms(0).ddlDateStartYear.selectedIndex;                
        }
        
    
    }
    
    
    function EndDateModified()
    {
    
        //end date modified
        bEndDateModified = true;

    
    }    
    
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

    			</div>                        

    <TABLE cellpadding='0' border='0' cellspacing='3'  width='100%'>      

    
        <form id="contactEventForm" 
              method="post" 
              runat="server"
	    >
        
          
          <TR BGCOLOR='#EEEEEE'>
          
              <TD COLSPAN=2 ALIGN=LEFT>
                
                    <asp:Label id="labelMessage" runat="server"  visible="true"/>
                  
              </TD>
              
          </TR>        
                    
          <input id="hiddenContactEventID"
                 type=hidden
                 runat="server">
                 
          <input id="hiddenURLReferer" 
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
                         SelectionMode="Single"                	                     	     
                	     runat="server" 
                         AutoPostBack="False"
                         OnChange="BeginDateModified()"                         
                         >
                	</asp:DropDownList>                      
                	
                	<asp:DropDownList 
                	     id="ddlDateStartDay"  
                         SelectionMode="Single"                	                     	     
                	     runat="server" 
                         AutoPostBack="False"
                         OnChange="BeginDateModified()"                                                  
                    >
                	</asp:DropDownList>                      
                	
                	<asp:DropDownList 
                	     id="ddlDateStartYear"  
                         SelectionMode="Single"                	                     	     
                	     runat="server" 
                         AutoPostBack="False"
                         OnChange="BeginDateModified()"                                                  
                    >
                	</asp:DropDownList>                                      	

                    <img name='DateStartPicker' 
                         src='images\picker.gif'
                         onClick='javascript:selectADay(1)'>
                	
                	&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                	
                	<asp:DropDownList 
                	     id="ddlTimeStartHour"  
                         SelectionMode="Single"                	                     	     
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	                	
                	
                	
                	<asp:DropDownList 
                	     id="ddlTimeStartMinute"  
                         SelectionMode="Single"                	                     	     
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	
                	
                	<asp:DropDownList 
                	     id="ddlTimeStartAMPM"  
                         SelectionMode="Single"                	                     	     
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	                	

                	<asp:CheckBox
                	     id="chkSameDayEvent"  
                	     runat="server" 
	 	                 OnCheckedChanged="buttonSameDayEventClicked"                                       	     
                         AutoPostBack="True">
                	</asp:CheckBox>                                      	                	                	
                	
                	<i> Same Day Event </i>
                	                	
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
                         SelectionMode="Single"
                         AutoPostBack="False"
                         OnChange="EndDateModified()"
                    >
                	</asp:DropDownList>                      
                	
                	<asp:DropDownList 
                	     id="ddlDateEndDay"  
                	     runat="server" 
                         SelectionMode="Single"                	     
                         AutoPostBack="False"
                         OnChange="EndDateModified()"
                    >
                	</asp:DropDownList>                      
                	
                	<asp:DropDownList 
                	     id="ddlDateEndYear"  
                         SelectionMode="Single"                	     
                	     runat="server" 
                         AutoPostBack="False"
                         OnChange="EndDateModified()"
                    >
                	</asp:DropDownList>                                      	

                    <img name='DateEndPicker' 
                         src='images\picker.gif'
                         onClick='javascript:selectADay(2)'>                    
                    
                	
                	&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                	
                	<asp:DropDownList 
                	     id="ddlTimeEndHour"  
                         SelectionMode="Single"                	     
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	
                	
                	<asp:DropDownList 
                	     id="ddlTimeEndMinute" 
                         SelectionMode="Single"                	      
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	
                	
                	<asp:DropDownList 
                	     id="ddlTimeEndAMPM"  
                         SelectionMode="Single"                	     
                	     runat="server" 
                         AutoPostBack="False">
                	</asp:DropDownList>                                      	                	
                	
                	<asp:CheckBox
                	     id="chkAllDayEvent"  
                         SelectionMode="Single"                	     
                	     runat="server" 
	 	                 OnCheckedChanged="buttonAllDayEventClicked"                                       	     
                         AutoPostBack="True">
                	</asp:CheckBox>                                      	                	                	
                	
                	<i> All Day Event </i>                	
                	                	
                	                	
              </TD>              

          </TR>              
          
 
          <TR>
              <TD COLSPAN=1>
                Comment
              </TD>
              
              <TD>                        
                <asp:TextBox 
                   id=editEventComment
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

		  
          <TR style="visibility:hidden;display:none;">
              <TD COLSPAN=1>
                Link.0500PM
              </TD>
              
              <TD>                        
                <asp:TextBox 
                   id=editEventLink
                   AutoPostBack="False"
                   Columns="90"
                   MaxLength="1000"
                   Rows="7"
                   Wrap="True"
                   runat="server" 
                   />
              </TD>
          </TR>          
		  
          <TR>
              <TD COLSPAN=1>
                Status
              </TD>
              
              <TD>                        
                <asp:RadioButtonList
                   id=radioButtonEventStatus
                   AutoPostBack="False"
                   RepeatColumns=6
                   RepeatDirection="Horizontal"  
                   TextAlign="Right"
                   runat="server" 
                   >
                   
                      <asp:ListItem Text="Not Started" Value="1"/> 
                      <asp:ListItem Text="In Progress" Value="2"/> 
                      <asp:ListItem Text="Completed" Value="3"/> 
                      <asp:ListItem Text="postponed" Value="4"/> 
                      <asp:ListItem Text="Cancelled" Value="5"/>                       
                      <asp:ListItem Text="Missed" Value="6"/>                       
                                                                                        
                </asp:RadioButtonList>
        
              </TD>
          </TR>        

          
          <TR >              
              <TD COLSPAN=2 ALIGN="RIGHT">                        
              
              
               <asp:Button
                   id=buttonAddMore
                   Text="Save And Add More"
                   runat="server"/>
                                 
                <asp:Button
                   id=buttonSave
                   Text="Save"
	 	           OnClick="buttonSaveClicked"                                          
                   runat="server"/>

                <asp:Button
                   id=buttonDelete
                   Text="Delete"
	 	           OnClick="buttonDeleteClicked"                                                             
                   runat="server"/>
                                      
                <asp:Button
                   id=buttonClose
                   Text="Close"
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
