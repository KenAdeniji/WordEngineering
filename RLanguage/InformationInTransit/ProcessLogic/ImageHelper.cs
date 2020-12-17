#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.IO;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region ImageHelper definition
    public static partial class ImageHelper
    {
        #region Methods
        /// <example>
        /// byte[] imageBytes = GetImageBytesFromDB();
        /// Image myImage = imageBytes.ToImage();
        /// </example>
        public static Image ToImage(this byte[] bytes)
        {
            return Image.FromStream(new MemoryStream(bytes));
        }
        #endregion
    }
    #endregion
}

