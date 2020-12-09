/*
using System;
using System.Web;

namespace InformationInTransit.ProcessLogic
{
    public partial class ConvertNumberToWordHandler : IHttpHandler
    {
      public void ProcessRequest(HttpContext context)
      {
         context.Response.ContentType = "text/plain";
 
         if (context.Request.HttpMethod == "GET")
         {
             Int64 int64;

             if (Int64.TryParse(context.Request.QueryString["number"], out int64))
             {
                 string word = NumberHelper.ConvertNumberToWord(int64);
                 context.Response.Write(word);
             }
         }
      }
 
      public Boolean IsReusable
      {
         get { return false; }
      }
   }
}
*/
