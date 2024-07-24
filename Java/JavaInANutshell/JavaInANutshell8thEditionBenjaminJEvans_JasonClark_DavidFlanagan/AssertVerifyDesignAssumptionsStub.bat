@ECHO OFF
REM 2024-07-24T04:11:00 Created.
goto run
Javac AssertVerifyDesignAssumptions.java
:run
REM Enable asserts
Java -ea AssertVerifyDesignAssumptions
REM Disable asserts
Java -da AssertVerifyDesignAssumptions