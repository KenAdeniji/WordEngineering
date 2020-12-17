#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
#endregion

namespace InformationInTransit.UserInterface
{
    #region DatabaseImageHandler definition
    public partial class DatabaseImageHandler : IHttpHandler
    {
        #region Public Methods
        public void ProcessRequest(HttpContext context)
        {
            int id = -1;
            bool parseReturnValue = Int32.TryParse(context.Request["id"], out id);
            if (!parseReturnValue)
            {
                context.Response.End();
            }
            string connectionString = ConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
            string commandText = "SELECT Photo FROM Employees WHERE EmployeeID = @ID";
            byte[] image = null;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlConnection.Open();
                image = (byte[])sqlCommand.ExecuteScalar();
                sqlConnection.Close();

                if (image != null)
                {
                    context.Response.ContentType = "image/jpeg";
                    context.Response.OutputStream.Write(image, 78, image.Length);
                }
            }
        }
        #endregion

        #region Public Properties
        public bool IsReusable
        {
            get { return true; }
        }
        #endregion
    }
    #endregion
}
