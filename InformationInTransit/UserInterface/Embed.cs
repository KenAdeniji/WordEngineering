#region Using directives
using System;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

namespace InformationInTransit.UserInterface
{
    #region Embed definition
    [ToolboxData("<{0}:Embed runat=server></{0}:Embed>")]
    public partial class Embed : System.Web.UI.Control
    {
        #region Automatic Public Fields
        [
            Bindable(true), 
            Category("Appearance"),
            Description("URL to a sound file"),
            Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor))
        ]
        public string Src { get; set; }
        #endregion

        #region Methods
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder("<embed ");
            sb.Append("id='" + this.ClientID + "' ");
            sb.Append("name='" + this.ClientID + "' ");
            sb.Append("src='" + Src + "' ");
            sb.Append("/>");
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        #endregion
    }
    #endregion
}
