setlocal

set "_service=MSSQLSERVER"

rem net pause  %_service% /y

net stop  %_service% /y

xcopy E:\SQLServerDataFiles \\noor\e$\sqlserverdatafiles /s /d /y

rem  net continue %_service% 

net start  %_service% /y

endlocal