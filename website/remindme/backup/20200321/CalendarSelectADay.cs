namespace EphraimTech.Utility
{

    
    using System;
    using System.Collections;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;        
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Web.Security;
    using System.Text;    //StringBuilder    
    using System.Configuration;            


    public class CalendarSelectADay : System.Web.UI.Page
    {
       
	   protected Label labelMessage;
	   protected Calendar calendar;	   
	   protected Button buttonSave;	   
	   
	   protected HtmlInputHidden hiddenSelectedDate;
	   protected HtmlInputHidden hiddenSelectedDateYear;
	   protected HtmlInputHidden hiddenSelectedDateMonth;
	   protected HtmlInputHidden hiddenSelectedDateDay;	   
	   	   	   	   
	   private String strDate = null;
       	   

       protected void Page_Load(Object Sender, EventArgs evt)
       {
       
            //parse passed in data
            getPassedInData();
            
            //reflect passed in Data
            reflectPassedInData();
            
            buttonSave.Attributes["onFocus"] = "javaScript:acceptSelectedDate()";
            
       }                                               
        

        
       protected void Page_UnLoad(Object Sender, EventArgs evt)
       {
            

        
       }
       
       
                      
       private void getPassedInData()
       {
       
            //get date
            strDate = Request["Date"];      

       
       }    
       
       
       
       private void reflectPassedInData()
       {
       
            System.DateTime objDate;
            
            try
            {
            
            
                labelMessage.Text = "Joe"  + "[" + strDate + "]";
                
                objDate = new System.DateTime();                            
                
                objDate = System.DateTime.Parse(strDate);
                
                labelMessage.Text = "Date is " + "[" + objDate.ToShortDateString() + "]";                
                
                calendar.SelectedDate = objDate;
                
                calendar.VisibleDate = objDate;                
                
            }
            catch(Exception ex)
            {
                labelMessage.Text = "Errored " + ex.ToString();
            }                            
       
       }           
                      

        protected void dateSelectionChanged(Object sender, EventArgs e) 
        {
        
             String strSelectedDate;
             
             strSelectedDate = calendar.SelectedDate.ToShortDateString();
                
             labelMessage.Text = strSelectedDate;
             
             hiddenSelectedDate.Value = strSelectedDate;
             hiddenSelectedDateYear.Value = calendar.SelectedDate.Year + "";
             hiddenSelectedDateMonth.Value = calendar.SelectedDate.Month + "";
             hiddenSelectedDateDay.Value = calendar.SelectedDate.Day + "";                          
             
        }

        
    }


}