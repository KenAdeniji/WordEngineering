using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Security.AccessControl;


using InformationInTransit.ProcessLogic;

public partial class FileUpload_FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        foreach (File file in fileUpload.PostedFiles)
        {
            String saveFilename = SavePath + file.FileName;
            file.SaveAs(saveFilename);
        }
    }
    // Specify the path on the server to save the uploaded file to.
    public const String SavePath = @"c:\temp\uploads\";

}
