<#
	2021-11-11T12:25:00 Created. https://powershellexplained.com/2017-01-13-powershell-variable-substitution-in-strings/?utm_source=blog&utm_medium=blog&utm_content=indexref
	2021-11-11T18:43:00 https://devblogs.microsoft.com/scripting/powertip-using-powershell-to-determine-if-path-is-to-file-or-folder/	
#>
Function Get-DirectoryFilePathInfo {
    [cmdletbinding()]
    [alias("gdf")]
    [OutputType("[string[]]")]
    Param(
        [Parameter(Position = 0, HelpMessage = "Specify the DirectoryFilePath")]
        [string]$DirectoryFilePath = 'c:\Windows'
    )
	"{0:yyyy-MM-dd}" -f (get-date)

	'Directory File Path: {0}' -f $DirectoryFilePath

	if ((Get-Item $DirectoryFilePath) -is [System.IO.DirectoryInfo])
	{
		Get-ChildItem -Path $DirectoryFilePath | SELECT Name, Mode, CreationTime, LastWriteTime
	}
	else
	{
		Get-Item $DirectoryFilePath | SELECT Mode, CreationTime, LastWriteTime
	}	
}
