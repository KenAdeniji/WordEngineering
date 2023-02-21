<%@ Page
 
	Language="c#" 
        src="CalendarSelectADay.cs" 
        Inherits="EphraimTech.Utility.CalendarSelectADay" 
        EnableSessionState=True 
        
%>
<HTML>

<HEAD>
<TITLE>
Select A Day
</TITLE>


<script language='javascript'>

    function acceptSelectedDate()
    {
    
        var strSelectedDate;
        var strSelectedDateYear;        
        var strSelectedDateMonth;                
        var strSelectedDateDay;                
       
        strSelectedDate = document.forms[0].hiddenSelectedDate.value;
        strSelectedDateYear = document.forms[0].hiddenSelectedDateYear.value;
        strSelectedDateMonth = document.forms[0].hiddenSelectedDateMonth.value;
        strSelectedDateDay = document.forms[0].hiddenSelectedDateDay.value;
                                
        //opener.alert(strSelectedDate);
        
        opener.reflectChosenDates(strSelectedDate, 
                                  strSelectedDateYear, 
                                  strSelectedDateMonth,
                                  strSelectedDateDay);
        
        close();
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
  
<style>




</style>  

     
    <asp:Label id="labelMessage" runat="server" visible="false" />
				  									
      <form id='frmSelectADay' 
            method='post' 
            runat='server'
            >
            
            <input type='hidden' 
                   id='hiddenSelectedDate'
                   runat='server'>
                   
            <input type='hidden' 
                   id='hiddenSelectedDateYear'
                   runat='server'>            
                   
            <input type='hidden' 
                   id='hiddenSelectedDateMonth'
                   runat='server'>            
                   
            <input type='hidden' 
                   id='hiddenSelectedDateDay'
                   runat='server'>                                                         
            
          <table>  
          <tr>
          <td>  
            
              <asp:Calendar 
                   id="calendar" 
                   runat="server"
                   OnSelectionChanged="dateSelectionChanged"
                   >
              </asp:Calendar>
                         
          </td>
          </tr>                           
                
          <tr>
          <td align='right'>                           
              <asp:Button
                   id="buttonSave" 
                   runat="server"
                   text="Accept selected date"
                   >
              </asp:Button>                            
          </td>
          </tr>                           
                    
          </table>            
        
      </form>                    


          
    </body>          
             
</HTML>
