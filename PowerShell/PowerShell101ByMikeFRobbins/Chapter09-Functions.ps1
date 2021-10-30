<#
	2021-10-28T16:30:00 Created https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/09-functions?view=powershell-7.1
#>
function Get-MrPSVersion {
    $PSVersionTable.PSVersion
}
Get-MrPSVersion

# Function naming
# <ApprovedVerb>-<Prefix><SingularNoun>. Prefix is the name initials of the author.
Get-Verb | Sort-Object -Property Verb

Get-ChildItem -Path Function:\Get-*Version #Function PSDrive? Directory of functions?

Get-ChildItem -Path Function:\Get-*Version | Remove-Item #Remove from the PSDrive

function Test-MrParameter {

    param (
        $ComputerName
    )

    Write-Output $ComputerName

}

function Get-MrParameterCount {
    param (
        [string[]]$ParameterName
    )

    foreach ($Parameter in $ParameterName) {
        $Results = Get-Command -ParameterName $Parameter -ErrorAction SilentlyContinue

        [pscustomobject]@{
            ParameterName = $Parameter
            NumberOfCmdlets = $Results.Count
        }
    }
}

Get-MrParameterCount -ParameterName ComputerName, Computer, ServerName, Host, Machine

Get-Command -Name Test-MrParameter -Syntax

(Get-Command -Name Test-MrParameter).Parameters.Keys

function Test-MrCmdletBinding {

    [CmdletBinding()] #<<-- This turns a regular function into an advanced function
    param (
        $ComputerName
    )

    Write-Output $ComputerName

}

