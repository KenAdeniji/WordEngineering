using System;
using System.Windows.Forms;
using System.Drawing;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
	
/*
	2018-12-11	Created.	https://www.dotnetperls.com/datagridview-tutorial
	2018-12-12	https://stackoverflow.com/questions/15153957/how-to-read-connection-string-from-a-config-file
*/
namespace InformationInTransit.WindowsForms
{
	public class BibleBookForm : Form    // inherits from System.Windows.Forms.Form
	{
		public BibleBookForm()
		{
			this.Size = new Size(600, 600);
			FillData();
		}
		
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new BibleBookForm());     // display the form
		}
		
        public void FillData()
        {
            // 1
            // Open connection
			ExeConfigurationFileMap Map = new ExeConfigurationFileMap();
			Map.ExeConfigFilename = AppConfig;
			Configuration configurationManager = 
				ConfigurationManager.OpenMappedExeConfiguration(Map , ConfigurationUserLevel.None);
			string connectionString =  
				configurationManager.ConnectionStrings.ConnectionStrings["Bible"].ToString();

			if (String.IsNullOrEmpty(connectionString))
			{
				connectionString = ConnectionString;
            }
			using 
			(
				SqlConnection sqlConnection = new SqlConnection
				(
					connectionString
				)
			)
            {
                sqlConnection.Open();
                // 2
                // Create new DataAdapter
                using 
				(
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
					(
						"SELECT * FROM BibleBook ORDER BY BookID", sqlConnection
					)
				)
                {
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    // 4
                    // Render data onto the screen
					
					DataGridView dataGridViewBibleBook = new DataGridView();
					dataGridViewBibleBook.Location = new Point(20, 20);
					dataGridViewBibleBook.Size = new Size(500, 500);
					dataGridViewBibleBook.Font = new Font("Arial", 12);
					this.Controls.Add(dataGridViewBibleBook);	// adding the control to the form
					
                    dataGridViewBibleBook.DataSource = dataTable;
                }
            }
		}

		public const String	AppConfig = "App.Config";	
		public const String	ConnectionString = 
			"Data Source=(local);Initial Catalog=Bible;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=600;Application Name=WordEngineering;MultipleActiveResultSets=True;";
	}
}
