#region Using directives
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Web.SessionState;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
#endregion

#region LiveWebSignupReturn definition
public partial class LiveWebSignupReturn : System.Web.UI.Page
{
   string result = "";
   string userId = "";
   protected override void OnLoad(EventArgs e)
   {
      if (!IsPostBack)
      {
         // Go through and extract the returned QueryString values.
         NameValueCollection returnParams = Request.QueryString;

         for (int i = 0; i < returnParams.AllKeys.Length; i++)
         {
            String nextKey = returnParams.AllKeys[i];
            if (nextKey == "result")
               result = returnParams[i];
            else if (nextKey == "id")
               userId = returnParams[i];
         }
         // If the result is success, save values to session.
         if ((result == "Accepted") && (userId != null))
         {
            // Save result data to the session.
            Session["Result"] = result;
            Session["Id"] = userId;
            
            // Display the result data.
            lblReturn.Text = "Result: " + result + ", User ID: " + userId;
         }
         // If the result does not succeed, display an error.
         else if (result != "Accepted")
         {
            if (result == "Declined")
               lblReturn.Text = "[" + result + "]" + " User permissions were declined.";
            else if (result == "NoPrivacyUrl")
               lblReturn.Text = "[" + result + "]" + " No privacy URL was supplied.";
         }
      }
   }
}
#endregion
