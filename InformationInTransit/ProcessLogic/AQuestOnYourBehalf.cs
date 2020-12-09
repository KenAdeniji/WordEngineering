using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    ///     2015-07-30  A quest, on your behalf.
    /// </summary>
    public static partial class AQuestOnYourBehalf
    {
        public static void Main(string[] argv)
        {
			foreach(String argvCurrent in argv)
			{
				Query(argvCurrent);
			}	
        }

        public static DataSet Query(string question)
        {
            StringBuilder sb = new StringBuilder();
            question = question.Trim();
            foreach (char c in question)
	        {
                if (sb.Length > 0)
                {
                    sb.Append(" UNION ");
                }
				string searchReplace = c.ToString().Replace("'", "''");
                sb.AppendFormat(QuestionFormat, searchReplace);
	        }
            //System.Console.WriteLine(sb);
            DataSet resultSet = (DataSet)DataCommand.DatabaseCommand
                                (
                                    sb.ToString(),
                                    System.Data.CommandType.Text,
                                    DataCommand.ResultType.DataSet
                                );
            return resultSet;
        }

        public const string QuestionFormat = "SELECT '{0}' AS Character, ASCII('{0}') AS AsciiCode, COUNT(*) AS CharacterCount FROM Bible..Scripture where KingJamesVersion LIKE '%{0}%'";
    }
}
