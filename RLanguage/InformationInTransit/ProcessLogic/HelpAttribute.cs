#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region HelpAttribute definition
    public partial class HelpAttribute : Attribute
    {
        #region Fields
        string url;
        string topic;
        #endregion

        #region Methods
        public HelpAttribute(string url)
        {
            this.url = url;
        }
        #endregion

        #region Properties
        public string Url
        {
            get { return url; }
        }

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        #endregion
    }
    #endregion
}
