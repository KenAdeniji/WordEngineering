///<remarks>
///2018-05-10	http://www.itprotoday.com/microsoft-sql-server/undocumented-dbcc-commands
///2018-05-10	http://extremeexperts.com/sql/articles/ListDBCCCommands.aspx
///</remarks>
namespace InformationInTransit.ProcessCode
{
	public static partial class DBCCDatabaseConsoleCommandBalindaWindow
	{
		public static string[] DBCCDatabaseConsoleCommand =
		{
			"dbcc dbinfo with tableresults, no_infomsgs",
			"dbcc memorystatus",
			"dbcc stackdump"
		};	
	}
}
