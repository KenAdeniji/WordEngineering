setlocal
set "_fileText=e:\WordEngineering\GitHub.com\gitrm2020-12-16T1957.txt"
for /F "tokens=*" %%A in ('type "%_fileText%"') do git rm "%%A"
endlocal
