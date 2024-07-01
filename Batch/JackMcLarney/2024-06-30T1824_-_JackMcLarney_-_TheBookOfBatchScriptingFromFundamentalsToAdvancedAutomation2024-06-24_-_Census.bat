@ECHO OFF
REM 2024-06-30T18:24:00 http://www.google.com/books/edition/The_Book_of_Batch_Scripting/SfLNEAAAQBAJ?hl=en&gbpv=1
REM 2024-06-30T18:31:00 http://stackoverflow.com/questions/17605767/create-a-list-or-an-array-and-print-each-item-in-windows-batch

set firstCensus=46500;^
59300;^
45650;^
74600;^
54400;^
57400;^
40500;^
32200;^
35400;^
62700;^
41500;^
53400;

set total=0
(for %%a in (%firstCensus%) do (
   echo %%a
   set /A total=total + %%a
))
echo %total%
pause
