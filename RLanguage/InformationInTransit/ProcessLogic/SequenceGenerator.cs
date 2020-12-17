using System;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

/*
2017-09-02	https://stackoverflow.com/questions/21425546/how-to-generate-a-range-of-numbers-between-two-numbers-in-sql-server
csc.exe /target:library /out:SequenceGenerator.dll SequenceGenerator.cs
ALTER DATABASE WordEngineering SET TRUSTWORTHY ON;

DROP FUNCTION udf_SequenceGenerator
GO

DROP ASSEMBLY SequenceGenerator
GO

CREATE ASSEMBLY SequenceGenerator from 'E:\WordEngineering\InformationInTransit\ProcessLogic\SequenceGenerator.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION udf_SequenceGenerator(@start int, @end int)
RETURNS TABLE(i int)
AS EXTERNAL NAME [SequenceGenerator].[InformationInTransit.ProcessLogic.SequenceGenerator].[Generate]
GO

select * from dbo.udf_SequenceGenerator(5, 17)
*/
namespace InformationInTransit.ProcessLogic
{
   public sealed class SequenceGenerator
    {
        [SqlFunction(FillRowMethodName = "FillRow")]
        public static IEnumerable Generate(SqlInt32 start, SqlInt32 end)
        {
            int _start = start.Value;
            int _end = end.Value;
            for (int i = _start; i <= _end; i++)
                yield return i;
        }

        public static void FillRow(Object obj, out int i)
        {
            i = (int)obj;
        }

        private SequenceGenerator() { }
    }
}
