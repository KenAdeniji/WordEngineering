#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Runtime.InteropServices;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region PlatformInvokeHelper definition
    public static partial class PlatformInvokeHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            MessageBox(0, "Hello World", "Platform Invoke Sample", 0);
        }
        #endregion

        //The DllImportAttribute.CharSet Field field is set to Auto to let the target platform determine the character width and string marshaling. 
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr MessageBox
        (
            int hWnd,
            String text, 
            String caption,
            uint type
        );
    }
    #endregion
}
