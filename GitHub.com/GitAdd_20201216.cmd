setlocal

rem How do you loop through each line in a text file using a windows batch file?
rem https://stackoverflow.com/questions/155932/how-do-you-loop-through-each-line-in-a-text-file-using-a-windows-batch-file

set "_fileText=e:\temp\gitAdd_20201216.txt"

for /F "tokens=*" %%A in ('type "%_fileText%"') do git add "%%A"

endlocal
