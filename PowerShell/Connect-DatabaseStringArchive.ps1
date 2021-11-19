<#
	2021-11-19T13:13:00 Created. https://octopus.com/blog/sql-server-powershell
	2021-11-19T15:02:00 https://stackoverflow.com/questions/8423541/how-do-you-run-a-sql-server-query-from-powershell
#>
Function Connect-DatabaseString {
    [cmdletbinding()]
    [alias("cdb")]
    [OutputType("[string[]]")]
    Param(
        [Parameter(Position = 0, HelpMessage = "Specify the ConnectionString")]
        [string]$ConnectionString = "Driver={SQL Server};Server=localhost;Database=Master;Trusted_Connection=Yes;"
    )
	try
	{
$ServerName = "localhost"
$DatabaseName = "master"
$Query = "SELECT * FROM sysdatabases WHERE name like '%%'"

#Timeout parameters
$QueryTimeout = 120
$ConnectionTimeout = 30

#Action of connecting to the Database and executing the query and returning results if there were any.
$conn=New-Object System.Data.SqlClient.SQLConnection
$ConnectionString = "Server={0};Database={1};Integrated Security=True;Connect Timeout={2}" -f $ServerName,$DatabaseName,$ConnectionTimeout
$conn.ConnectionString=$ConnectionString
$conn.Open()
$cmd=New-Object system.Data.SqlClient.SqlCommand($Query,$conn)
$cmd.CommandTimeout=$QueryTimeout
$ds=New-Object system.Data.DataSet
$da=New-Object system.Data.SqlClient.SqlDataAdapter($cmd)
[void]$da.fill($ds)
$conn.Close()
$ds.Tables
	}
	catch
	{
		# We could not connect here
		# Notify there was an error connecting to the database
		$_
	}
}
