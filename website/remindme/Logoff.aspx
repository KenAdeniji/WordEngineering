<%@ Import Namespace="System.Web.Security" %>

<html>
<body>


    <script language="C#" runat="server">


        protected void Page_Load(Object Sender, EventArgs evt)
        {
        
            String strRedirectURL = null;
            
        	//Store the URL that refered the page
	        strRedirectURL = Request.ServerVariables["HTTP_REFERER"];
            
            //Sign out
            System.Web.Security.FormsAuthentication.SignOut();
            
            //if Redirect URL is known, then sign out
            if (strRedirectURL != null)
            {
                Response.Redirect(strRedirectURL);
            }                
            
            Response.Write("Signed out " + "<BR>");                

        
        }                                        
                               

    </script>


    

   
</body>

</html>
