#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.SessionState;
using System.IO;
#endregion

namespace InformationInTransit.UserInterface
{
    #region DataAccessHandler definition
    public class DataAccessHandler : IHttpHandler
    {

        #region Methods
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion
    }
    #endregion
}


