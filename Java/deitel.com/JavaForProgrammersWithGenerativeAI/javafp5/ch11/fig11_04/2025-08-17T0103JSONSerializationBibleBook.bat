@echo off
REM for macOS change the semicolon (;) to a colon (:)
javac -cp ".;../libs/*" JSONSerializationBibleBook.java
java -cp ".;../libs/*" JSONSerializationBibleBook