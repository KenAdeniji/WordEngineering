$sqlInstance = connect-dbainstance -sqlInstance . -TrustServerCertificate

backup-dbadatabase -sqlInstance $sqlInstance -database IHaveDecidedToWorkOnAGradualImprovingSystem, URI, WordEngineering -path 'e:\temp'
