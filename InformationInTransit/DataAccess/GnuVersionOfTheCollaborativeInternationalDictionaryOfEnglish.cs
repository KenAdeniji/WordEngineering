using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace WordEngineering
{
	public static partial class GnuVersionOfTheCollaborativeInternationalDictionaryOfEnglish
	{
		static GnuVersionOfTheCollaborativeInternationalDictionaryOfEnglish()
		{
            SqlConnection = new SqlConnection(ConnectionString);
            SqlConnection.Open();
		}
		
		public static void Main(string[] argv)
		{
			string hw = null;
			string def = null;
			
			foreach(string filename in argv)
			{
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.DtdProcessing = DtdProcessing.Parse;
				
				// Create an XML reader for this file.
				using (XmlReader reader = XmlReader.Create(filename, settings))
				{
					while (reader.Read())
					{
						// Only detect start elements.
						if (reader.IsStartElement())
						{
							switch (reader.Name)
							{
								case "p":
									Write(hw, def);
									break;
								case "hw":
									if (reader.Read())
									{
										hw = reader.Value.Trim();
									}
									break;
								case "def":
									if (reader.Read())
									{
										def = reader.Value.Trim();
									}
									break;
							}//switch
						}//if (reader.IsStartElement())
					}//while (reader.Read())
					
				}////using
			}//foreach
		}//Main
		
		public static void Write(string hw, string def)
		{
			if (hw == null || def == null) { return; }
			
			hw = hw.Replace("'", "''");
 			hw = hw.Replace("*", "");
			hw = hw.Replace("`", "");
			hw = hw.Replace("\"", "");
			hw = hw.Replace("-", "");			
			
			def = def.Replace("'", "''");
 			def = def.Replace("*", "");
			def = def.Replace("`", "");
			def = def.Replace("\"", "");
			
			string sql = String.Format
			(
				DictionaryWriteFormat,
				hw,
				def
			);
			
            SqlCommand sqlCommand = new SqlCommand(sql, SqlConnection);
			try
			{
				sqlCommand.ExecuteNonQuery();
			}
			catch (Exception) {};
		}
		
		public const string ConnectionString = "Data Source=(local);Initial Catalog=Master;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=60;";
		public const string DictionaryWriteFormat = "INSERT INTO Dictionary..GnuVersionOfTheCollaborativeInternationalDictionaryOfEnglish(hw, def) Values ('{0}', '{1}')";

		public static SqlConnection SqlConnection = null;
		
	}//GnuVersionOfTheCollaborativeInternationalDictionaryOfEnglish
}//WordEngineering
