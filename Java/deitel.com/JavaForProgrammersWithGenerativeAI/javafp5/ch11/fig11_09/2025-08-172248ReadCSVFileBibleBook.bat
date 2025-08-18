@echo off
REM for macOS change the semicolon (;) to a colon (:)
javac -cp ".;../libs/*" ReadCSVFileBibleBook.java
java -cp ".;../libs/*" ReadCSVFileBibleBook