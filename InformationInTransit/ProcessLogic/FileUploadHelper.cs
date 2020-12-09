using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InformationInTransit.ProcessLogic
{
    public static partial class FileUploadHelper
    {
        public static string SaveAs(FileUpload fileUpload)
        {
            return SaveAs(fileUpload, fileUpload.FileName, SavePath);
        }

        public static string SaveAs(FileUpload fileUpload, string filename)
        {
            return SaveAs(fileUpload, filename, SavePath);
        }

        public static string SaveAs
        (
            FileUpload fileUpload,
            string filename,
            string path
        )
        {
            // Append the name of the file to upload to the path.
            String saveFilename = path + filename;

            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (fileUpload.HasFile)
            {

                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                fileUpload.SaveAs(saveFilename);
            }
            return saveFilename;
        }
        // Specify the path on the server to save the uploaded file to.
        public const String SavePath = @"c:\temp\uploads\";
    }
}
