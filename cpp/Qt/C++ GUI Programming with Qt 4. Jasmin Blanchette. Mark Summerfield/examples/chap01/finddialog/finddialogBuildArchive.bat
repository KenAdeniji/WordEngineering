set include=e:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.13.26128\ATLMFC\include;e:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.13.26128\include;C:\Program Files (x86)\Windows Kits\NETFXSDK\4.6.1\include\um;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\ucrt;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\shared;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\um;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\winrt;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\cppwinrt;E:\Qt\5.13.0\msvc2017_64\include;E:\Qt\5.13.0\winrt_x64_msvc2017\include\QtWidgets
goto make
cl /MTd /EHsc /I "E:\QT\5.13.0\msvc2017_64\include" /Ox ^
E:\QT\5.13.0\msvc2017_64\lib\Qt5Widgets.lib E:\QT\5.13.0\msvc2017_64\lib\Qt5Core.lib E:\QT\5.13.0\msvc2017_64\lib\Qt5Gui.lib ^
main.cpp finddialog.cpp

:make
qmake finddialog.pro
qmake finddialog.pro
nmake
