#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    #region Widget definition
    [Help("http://msdn.microsoft.com/.../MyClass.html")]
    public partial class Widget
    {
        #region Methods
        [Help("http://msdn.microsoft.com/.../MyClass.html", Topic="Display")]
        public void Display(string text) { }
        #endregion
    }
    #endregion
}
#endregion