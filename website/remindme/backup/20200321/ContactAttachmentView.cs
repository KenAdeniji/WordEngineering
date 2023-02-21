

using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
//using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace DBImages
{
    /// <summary>
    /// Summary description for ViewImage.
    /// </summary>
    
    //http://www.meronek.com/meroneksoftware/articles.aspx?id=1
    //http://www.developerfusion.co.uk/show/3905/
    
    public class ViewImage : System.Web.UI.Page
    {

        String strDBConnection = null;
        OleDbConnection objConnection = null;
        OleDbCommand objDBCommand = null;
        
        //read configuration settings                                                                         
        protected void readConfigurationSettings()
        {
            strDBConnection = ConfigurationSettings.AppSettings["oleDBConnection.ConnectionString"];
        }             
        
        private void Page_Load(object sender, System.EventArgs e)
        {
            viewDocumentAttachment();
        }
    
        public void viewDocumentAttachment()
        {
            
            OleDbDataReader objDBReader = null;
                        
            readConfigurationSettings();       
       
			objConnection = new OleDbConnection(strDBConnection);            
			
			objDBCommand = new OleDbCommand();
			
			objDBCommand.Connection = objConnection;
			        
            objConnection.Open();			
            
            //get the image id from the url
            string ImageId = Request.QueryString["documentAttachmentIdentifier"];
            
            //build our query statement
            string sqlText =  " SELECT * "
                            + " FROM   dbo.documentAttachment "
                            + " WHERE  documentAttachmentIdentifier = '" + ImageId + "'" ;
            

            objDBCommand.CommandText = sqlText;
                                    
            //SqlCommand command = new SqlCommand( sqlText, connection);
            
            //open the database and get a datareader
            //connection.Open();
            
            //SqlDataReader dr = command.ExecuteReader();
            objDBReader = objDBCommand.ExecuteReader();
            
            if ( objDBReader.Read()) //yup we found our image
            {
                
                Response.ContentType = objDBReader["contentType"].ToString();
                
                //Response.Write( dr["img_name"] );
                                
                Response.BinaryWrite( (byte[]) objDBReader["attachment"] );
                
            }
            
            //connection.Close();
            objConnection.Close();
            
            
        } //viewDocumentAttachment()
        
    }
}