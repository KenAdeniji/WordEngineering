#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.SessionState;

using InformationInTransit.ProcessLogic;
#endregion

namespace InformationInTransit.UserInterface
{
    #region AppendImageCopyrightHandler definition
    public partial class AppendImageCopyrightHandler : IHttpHandler, IRequiresSessionState, IReadOnlySessionState 
    {
        #region Methods
        protected Bitmap AddCopyright(string imageFile, string copyright)
        {
            Bitmap bmp = new Bitmap(imageFile);
            Graphics g = Graphics.FromImage(bmp);

            //Define text alignment
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            //Create brushes for writing
            SolidBrush forecolor = new SolidBrush(System.Drawing.Color.PaleGreen);
            SolidBrush backcolor = new SolidBrush(System.Drawing.Color.Black);

            //To calculate writing co-ordinates, obtain the size of the text given font, typeface, and size.
            Font font = new Font("Verdana", 8);
            SizeF textSize = new SizeF();
            textSize = g.MeasureString(copyright, font);

            //Calculate the output rectangle and file.
            float x = ((float) bmp.Width - textSize.Width - 3);
            float y = ((float)bmp.Height - textSize.Height - 3);
            float width = ((float)x + textSize.Width);
            float height = ((float)y + textSize.Height);
            RectangleF textArea = new RectangleF(x, y, width, height);
            g.FillRectangle(backcolor, textArea);

            //Draw the text and free resources.
            g.DrawString(copyright, font, forecolor, textArea);
            forecolor.Dispose();
            backcolor.Dispose();
            font.Dispose();
            g.Dispose();

            return bmp;
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string imageUrl = (string)context.Request["url"];
            if (imageUrl == null)
            {
                context.Response.End();
                return;
            }
            string imageFile = context.Server.MapPath(imageUrl);
            if (!FileHelper.IsImageFile(imageFile))
            {
                context.Response.End();
                return;
            }
            string copyrightForImage = ConfigurationManager.AppSettings["copyrightForImage"];
            if (File.Exists(imageFile))
            {
                Bitmap bmp = AddCopyright(imageFile, copyrightForImage);
                context.Response.ContentType = "image/jpeg";
                bmp.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                bmp.Dispose();
            }
            else
            {
                context.Response.End();
                return;
            }
        }
        #endregion
    }
    #endregion
}
