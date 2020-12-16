GOTO Compile
2019-03-16T19:48:00	https://wiki.qt.io/Qt_for_Beginners
2019-03-16T19:48:00	http://www-cs.ccny.cuny.edu/~wolberg/cs221/qt/books/C++-GUI-Programming-with-Qt-4-1st-ed.pdf
2019-03-16T21:42:00	https://wiki.qt.io/Build_Standalone_Qt_Application_for_Windows
2019-03-16T22:05:00	https://wiki.qt.io/Build_Standalone_Qt_Application_for_Windows#Using_Microsoft_Visual_Studio

2019-03-17T11:42:00	https://stackoverflow.com/questions/34453238/lnk1181-cannot-open-input-file-qt5-but-worked-when-compiled-from-batch
2019-03-17T12:37:00	https://stackoverflow.com/questions/49641364/vcruntime140-app-dll-not-included-in-the-microsoft-visual-c-2017-redistributab
:Compile 
REM 2019-03-17
cd "e:\WordEngineering\cpp\Qt\C++ GUI Programming with Qt 4. Jasmin Blanchette. Mark Summerfield\examples\chap01\hello"
set include=e:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.13.26128\ATLMFC\include;e:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.13.26128\include;C:\Program Files (x86)\Windows Kits\NETFXSDK\4.6.1\include\um;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\ucrt;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\shared;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\um;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\winrt;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\cppwinrt;E:\Qt\5.13.0\msvc2017_64\include;E:\Qt\5.13.0\winrt_x64_msvc2017\include\QtWidgets
cl /MTd /EHsc /I "E:\QT\5.13.0\msvc2017_64\include" /Ox ^
E:\QT\5.13.0\msvc2017_64\lib\Qt5Widgets.lib E:\QT\5.13.0\msvc2017_64\lib\Qt5Core.lib E:\QT\5.13.0\msvc2017_64\lib\Qt5Gui.lib ^
quit.cpp
