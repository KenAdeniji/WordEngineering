#Gather IP address information
#https://stackoverflow.com/questions/19529442/gather-ip-address-information

Get-WmiObject -Class Win32_NetworkAdapterConfiguration -Filter 'IPEnabled = True'

[System.Net.NetworkInformation.NetworkInterface]::GetAllNetworkInterfaces() `
    | ForEach-Object { $_.GetIPProperties() } `
    | Select-Object -ExpandProperty 'UnicastAddresses';