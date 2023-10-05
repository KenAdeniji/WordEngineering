using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InformationInTransit.ProcessLogic;

public partial class AlphabetSequence : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected int AlphabetSequenceIndex
    {
        set
        {
            alphabetSequenceIndex.Text = value.ToString();
        }
    }

    protected string Word
    {
        get
        {
            return word.Text.Trim();
        }
    }

    protected string ScriptureReference
    {
        set
        {
            scriptureReference.Text = value.ToString();
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
		int index = InformationInTransit.ProcessLogic.AlphabetSequence.Id(Word);
        AlphabetSequenceIndex = index;
		if (index == 0)
		{
			ScriptureReference = "";
			return;
		}	
        ScriptureReference = InformationInTransit.ProcessLogic.AlphabetSequence.ScriptureReference(index);
    }
}
