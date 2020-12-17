@ECHO OFF
REM 2020-09-01 https://learningintheopen.org/2020/08/31/golang-package-denisenkom-go-mssqldb/
git clone https://github.com/denisenkom/go-mssqldb
cd go-mssqldb
go install
go list ... | find "go-mssqldb"