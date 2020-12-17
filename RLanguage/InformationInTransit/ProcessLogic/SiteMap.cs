#region Using directives
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region SiteMap definition
    public static partial class SiteMap
    {
        #region Methods
        public static void Main(string[] argv)
        {
            GenerateSiteMap(argv);
        }

        public static void GenerateSiteMap(params string[] argv)
        {
            string siteMapFile = argv.Length == 0 ? SiteMapFile : argv[0];
            XmlTextWriter writer = new XmlTextWriter(siteMapFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");

            SqlConnection con = new SqlConnection(DatabaseConnectionString);
            string sql = @"SELECT * FROM URISiteMap ORDER BY Dated";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                IDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string loc = dataReader["URI"].ToString();
                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", loc);
                    writer.WriteElementString("changefreq", "monthly");
                    writer.WriteEndElement(); // url
                }
                dataReader.Close();
            }
            catch (SqlException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            writer.WriteEndElement();// urlset        
            writer.Close();
        }
        #endregion

        #region Constants
        public const string DatabaseConnectionString = "Data Source=(local);Initial Catalog=URI;Persist Security Info=True;Integrated Security=SSPI;";
        public const string SiteMapFile = @"sitemap.xml";
        #endregion
    }
    #endregion
}
