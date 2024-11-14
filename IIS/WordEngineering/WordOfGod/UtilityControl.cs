using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 ///<summary>UtilityControl http://steveorr.net/faq/ControlTreeRecursion.aspx</summary>
 public class UtilityControl
 {
  ///<summary>SetTextBoxBackColor</summary>
  public static void SetTextBoxBackColor(Control Page, Color clr)
  {
   foreach (Control ctrl in Page.Controls)
   {
    if (ctrl is TextBox)
    {
     ((TextBox)(ctrl)).BackColor = clr;
    }
    else 
    {
     if (ctrl.Controls.Count > 0)
     {
      SetTextBoxBackColor(ctrl, clr);
     }
    }
   }
  }//private void SetTextBoxBackColor(Control Page, Color clr)
 }//public class UtilityControl
}//namespace WordEngineering  
