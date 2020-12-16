#region Using directives
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
#endregion

namespace InformationInTransit.UserInterface
{
    #region ThumbnailHandler definition
    public class ThumbnailHandler : IHttpHandler
    {
        private Regex _nameValidationExpression = new Regex(@"[^\w/]");
        private int _thumbnailSize = 150;

        #region Methods
        public void ProcessRequest(HttpContext context) 
        {
            string photoName = context.Request.QueryString["p"];
            if (_nameValidationExpression.IsMatch(photoName)) 
            {
                throw new HttpException(404, "Invalid photo name.");
            }
            string cachePath = Path.Combine(HttpRuntime.CodegenDir, photoName + ".png");
            if (File.Exists(cachePath)) 
            {
                OutputCacheResponse(context, File.GetLastWriteTime(cachePath));
                context.Response.WriteFile(cachePath);
                return;
            }
            string photoPath = context.Server.MapPath(@"~/Images/Bertrand Le Roy/" + photoName + ".jpg");
            Bitmap photo;
            try
            {
                photo = new Bitmap(photoPath);
            }
            catch (ArgumentException) 
            {
                throw new HttpException(404, "Photo not found.");
            }
            context.Response.ContentType = "image/png";
            int width, height;
            if (photo.Width > photo.Height) 
            {
                width = _thumbnailSize;
                height = photo.Height * _thumbnailSize / photo.Width;
            }
            else
            {
                width = photo.Width * _thumbnailSize / photo.Height;
                height = _thumbnailSize;
            }
            Bitmap target = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(target)) 
            {
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.DrawImage(photo, 0, 0, width, height);
                using (MemoryStream memoryStream = new MemoryStream()) 
                {
                    target.Save(memoryStream, ImageFormat.Png);
                    OutputCacheResponse(context, File.GetLastWriteTime(photoPath));
                    using (FileStream diskCacheStream = new FileStream(cachePath, FileMode.CreateNew)) 
                    {
                        memoryStream.WriteTo(diskCacheStream);
                    }
                    memoryStream.WriteTo(context.Response.OutputStream);
                }
            }
        }

        private static void OutputCacheResponse(HttpContext context, DateTime lastModified) 
        {
            HttpCachePolicy cachePolicy = context.Response.Cache;
            cachePolicy.SetCacheability(HttpCacheability.Public);
            cachePolicy.VaryByParams["p"] = true;
            cachePolicy.SetOmitVaryStar(true);
            cachePolicy.SetExpires(DateTime.Now + TimeSpan.FromDays(365));
            cachePolicy.SetValidUntilExpires(true);
            cachePolicy.SetLastModified(lastModified);
        }
 
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
