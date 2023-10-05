#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.IO;

using System.Speech.Synthesis;
#endregion

#region TextToSpeech Definition
public partial class TextToSpeech : System.Web.UI.Page
{
    #region Methods
    protected void Speak_Click(Object sender, EventArgs e)
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        speechSynthesizer.SpeakAsync(text.Text);
    }
    #endregion
}
#endregion
