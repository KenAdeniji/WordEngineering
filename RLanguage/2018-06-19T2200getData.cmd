setlocal
set "_server=localhost"
set "_fieldTerminator=;"
bcp  "select * from  bible..BibleBook"  queryout  2018-06-19T2200bibleBookRaw.txt -S %_server% -T -t %_fieldTerminator% -c 
copy 2018-06-19T2200bibleBookHeader.txt + 2018-06-19T2200bibleBookRaw.txt 2018-06-19T2200bibleBook.txt
endlocal

