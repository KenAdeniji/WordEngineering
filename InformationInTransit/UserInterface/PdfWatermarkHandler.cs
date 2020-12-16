#region Using directives
using System;
using System.Web;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
#endregion

namespace InformationInTransit.UserInterface
{
    #region PdfWatermarkHandler definition
    public class PdfWatermarkHandler : IHttpHandler
    {
        #region Methods
        /// <summary>
        /// Reads the requested pdf file, adds the watermark and streams the modified pdf file.
        /// </summary>
        public void ProcessRequest(HttpContext context)
        {
            MemoryStream outputStream = new MemoryStream();
            PdfReader pdfReader = new PdfReader(context.Request.PhysicalPath);
            int numberOfPages = pdfReader.NumberOfPages;
            PdfStamper pdfStamper = new PdfStamper(pdfReader, outputStream);
            PdfContentByte waterMarkContent;
            Image image = Image.GetInstance(context.Server.MapPath("~/Images/iTextSharp/Watermark.jpg"));
            image.SetAbsolutePosition(250, 300);
            for (int i = 1; i <= numberOfPages; i++)
            {
                waterMarkContent = pdfStamper.GetUnderContent(i);
                waterMarkContent.AddImage(image);
            }
            pdfStamper.Close();
            byte[] content = outputStream.ToArray();
            outputStream.Close();
            context.Response.ContentType = "application/pdf";
            context.Response.BinaryWrite(content);
            context.Response.End();
        }
        /// <summary>
        /// Marks the handler reusable across multiple requests
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
        #endregion
    }
    #endregion
}
