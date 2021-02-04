using System;
using System.Windows.Forms;
using System.Drawing;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
	
/*
	2021-02-03	Created.
	2018-12-11	https://www.dotnetperls.com/datagridview-tutorial
	2018-12-12	https://stackoverflow.com/questions/15153957/how-to-read-connection-string-from-a-config-file
	2021-02-03T17:11:00	I am partially known.
	2021-02-03T17:32:00	What without the browser?
	2021-02-03T17:36:00	WinForms build. 
						How capable are you; on reliance?
	2021-02-03T17:39:00	I code using the NotePad++ editor, and compile using the command-line.
						What neutrality are new?
	2021-02-03T17:50:00	When I started AlphabetSequence, I learnt C#, SQL Server, XML. 
						When you are entrying a new form of yourself; how do you realize the people?
						To the acceptance; of something common.
						PowerSoft.
							How are you involve, in other?
							How are you involve, in other?
	2021-02-03T17:55:00	The technology, is how many people, you have gain.
							Nothing happens to the LORD, as co-incidence.
								Do you need to learn and falter.
								As I was building the AlphabetSequence web form; I wanted dynamic columns,
								because my database schema was changing.
								Can you be as many people as one?
	2021-02-03T18:01:00	Simplify; of the future.
							Can you be a database administrator and programmer, at the same time.
	2021-02-03T18:04:00	Kaz, Parramatta. Pauline Beshay visited.
							I have settled at my place; here is mine.
							Can we be regular; of one another?
							This life, I have chosen; for you alone.
	2021-02-03T18:04:00	Inserted into the Software table. BibleSearchForm.cs
							To love; in anticipation of time.
	2021-02-03T18:11:00	The Fugees. You paid for Pauline Beshay and her friends, by buying the ticket.
						We seem; to form a surrounding.	
						Those carrying the hope; are among others.
	2021-02-03T18:14:00	Africa Diaspora, DHC.
						To make one's end; as personal.
						We all need something to remember; here is my acceptance.
						We bring each other; as many as the rest.
	2021-02-03T18:14:00	Australia
							Noriko Yoshida versus biological mother.
							What I want; is the update of myself.
							This dream, I have chosen, alike.
							Where will you rely, on life?
							To live; as one part; of the other.
							To live; as part; of the other.
							Where has He chosen; to use an improve man?
							A few included of our part; is our future.
							Do I bring home; what is receptable to me?
	2021-02-03T18:28:00	GitHub status
							We welcome our detail; this is personal.
							The calling; on man; is to choose Himself (Genesis 28:22).
							The calling; is to choose Himself (Genesis 28:22).
							This is an investment; worth the person.
								The experience; of a personal life.
							A life spent; is indeed, worth living.
								E-mail grammar.
							European Union ... European Community.	
								We are still finding ourself; as we grow.
							Can you customize the date field; to local date?
	2021-02-03T18:56:00	Microsoft Windows versus Linux?
							Linux software are customized for Windows.
								The step; I threaded.
	2021-02-03T18:56:00	The preference for desire.
							This is how; I like to be; myself.
							In a personal world; there are no changing.
*/
namespace InformationInTransit.WindowsForms
{
	public class BibleSearchForm : Form    // inherits from System.Windows.Forms.Form
	{
		public BibleSearchForm()
		{
			this.Size = new Size(600, 600);
			FillData();
		}
		
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new BibleSearchForm());     // display the form
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
						"SELECT ScriptureReference, KingJamesVersion FROM Bible..Scripture_View ORDER BY VerseIDSequence",
						sqlConnection
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
