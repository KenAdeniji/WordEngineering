@echo off
REM for macOS change the semicolon (;) to a colon (:)
javac -cp ".;../libs/*" CreateCSVFileBibleBook.java
java -cp ".;../libs/*" CreateCSVFileBibleBook