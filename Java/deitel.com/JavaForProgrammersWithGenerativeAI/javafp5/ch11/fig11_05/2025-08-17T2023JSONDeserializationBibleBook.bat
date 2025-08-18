@echo off
REM for macOS change the semicolon (;) to a colon (:)
javac -cp ".;../libs/*" JSONDeserializationBibleBook.java
java -cp ".;../libs/*" JSONDeserializationBibleBook