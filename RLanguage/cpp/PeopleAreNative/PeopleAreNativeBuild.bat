cl PeopleAreNative.cpp DateTimeHandler.cpp
cl.exe /D_USRDLL /D_WINDLL DateTimeHandler.cpp PeopleAreNative.cpp /MT /link /DLL /OUT:PeopleAreNative.dll
REM /LD