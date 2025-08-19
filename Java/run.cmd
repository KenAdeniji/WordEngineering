@ECHO OFF
REM java SQLDatabaseConnection -classpath .;mssql-jdbc-10.2.0.jre17.jar;mssql-jdbc_auth-10.2.0.x64.dll
Rem java SQLDatabaseConnection -classpath .;mssql-jdbc-12.8.1.jre11;mssql-jdbc_auth-12.8.1.x64.dll
set CLASSPATH =.;C:\Program Files\Microsoft JDBC Driver 12.8 for SQL Server\sqljdbc_12.8\enu\mssql-jdbc-12.8.0.jre11.jar;C:\Program Files\Microsoft JDBC Driver 12.8 for SQL Server\sqljdbc_12.8\enu\mssql-jdbc_auth-12.8.1.x64.dll;
rem set CLASSPATH =.;C:\Program Files\Microsoft JDBC Driver 12.8 for SQL Server\sqljdbc_12.8\enu\mssql-jdbc-12.8.0.jre11.jar;
javac SQLDatabaseConnection.java
java SQLDatabaseConnection -classpath .;mssql-jdbc-12.8.1.jre11;;mssql-jdbc_auth-12.8.1.x64.dll




