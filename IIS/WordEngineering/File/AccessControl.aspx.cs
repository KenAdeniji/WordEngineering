using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Security.AccessControl;


using InformationInTransit.ProcessLogic;

public partial class File_AccessControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void AccessControlEntries_Click(object sender, EventArgs e)
    {
        string filename = FileUploadHelper.SaveAs(fileUpload);

        AuthorizationRuleCollection accessControlList =
            AccessControlHelper.AccessControlList(filename);

        literal.Text = AccessControlHelper.AccessControlList
        (
            accessControlList,
            fileUpload.FileName,
            RecordSeparator,
            ColumnSeparator
        );
    }

    public const String RecordSeparator = "<hr/>";
    public const String ColumnSeparator = "<br/>";
    // Specify the path on the server to save the uploaded file to.
    public const String SavePath = @"c:\temp\uploads\";

}
