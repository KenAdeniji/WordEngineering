#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
#endregion

namespace InformationInTransit.UserInterface
{
    #region HttpRequestHelper definition
    /// <summary>
    /// Although the ScriptManager has a property named IsInAsyncPostBack to determine an AJAX call, the control is scoped to the page it is contained in.  If writing code in a custom HTTP module, what if I need to know in the BeginRequest event whether the current request is AJAX or JSON?
    /// How nice it would be to simply ask the request if it is in the context of an AJAX or JSON call.  In Visual Studio 2008, I can do just that.  With extension methods, I can add two new behaviors to the HttpRequest object.  Here are my desired methods:
    /// </summary>
    public static partial class HttpRequestHelper
    {
        #region Methods
        public static bool IsJson(this HttpRequest request)
        {
            return request.ContentType.StartsWith("application/json",
                StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsAjax(this HttpRequest request)
        {
            return (request.Headers.Get("x-microsoftajax") ?? "")
                .Equals("delta=true", StringComparison.OrdinalIgnoreCase);
        }        
        #endregion
    }
    #endregion
}