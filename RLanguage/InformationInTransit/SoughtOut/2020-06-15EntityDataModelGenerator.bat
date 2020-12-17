rem @ECHO OFF
setlocal

REM https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/edm-generator-edmgen-exe?redirectedfrom=MSDN
set "_connectionString=Data Source=(local);Initial Catalog=SoughtOut;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=600;Application Name=WordEngineering;MultipleActiveResultSets=True;"

EdmGen /mode:FullGeneration /project:SoughtOut /provider:System.Data.SqlClient /connectionstring:"%_connectionString%" /entitycontainer:SoughtOutEntities /namespace:SoughtOutModel

endlocal
