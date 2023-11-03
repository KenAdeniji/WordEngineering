/*
GOTO Compile
2019-03-16T19:48:00	https://wiki.qt.io/Qt_for_Beginners
2019-03-16T19:48:00	http://www-cs.ccny.cuny.edu/~wolberg/cs221/qt/books/C++-GUI-Programming-with-Qt-4-1st-ed.pdf
2019-03-16T21:42:00	https://wiki.qt.io/Build_Standalone_Qt_Application_for_Windows
2019-03-16T22:05:00	https://wiki.qt.io/Build_Standalone_Qt_Application_for_Windows#Using_Microsoft_Visual_Studio

2019-03-17T09:56:00	cd "e:\WordEngineering\cpp\Qt\C++ GUI Programming with Qt 4. Jasmin Blanchette. Mark Summerfield\examples\chap01\hello"
2019-03-17T10:24:00	set include=e:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.13.26128\ATLMFC\include;e:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.13.26128\include;C:\Program Files (x86)\Windows Kits\NETFXSDK\4.6.1\include\um;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\ucrt;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\shared;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\um;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\winrt;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\cppwinrt;E:\Qt\5.13.0\winrt_x64_msvc2017\include;E:\Qt\5.13.0\winrt_x64_msvc2017\include\QtWidgets

2019-03-17T11:42:00	https://stackoverflow.com/questions/34453238/lnk1181-cannot-open-input-file-qt5-but-worked-when-compiled-from-batch
2019-03-17T12:37:00	https://stackoverflow.com/questions/49641364/vcruntime140-app-dll-not-included-in-the-microsoft-visual-c-2017-redistributab
:Compile 
cd "e:\WordEngineering\cpp\Qt\C++ GUI Programming with Qt 4. Jasmin Blanchette. Mark Summerfield\examples\chap01\hello"
set include=e:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.13.26128\ATLMFC\include;e:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.13.26128\include;C:\Program Files (x86)\Windows Kits\NETFXSDK\4.6.1\include\um;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\ucrt;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\shared;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\um;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\winrt;C:\Program Files (x86)\Windows Kits\10\include\10.0.16299.0\cppwinrt;E:\Qt\5.13.0\winrt_x64_msvc2017\include;E:\Qt\5.13.0\winrt_x64_msvc2017\include\QtWidgets
cl /MTd /EHsc /I "E:\QT\5.13.0\msvc2017_64\include" /Ox ^
E:\QT\5.13.0\msvc2017_64\lib\Qt5Widgets.lib E:\QT\5.13.0\msvc2017_64\lib\Qt5Core.lib E:\QT\5.13.0\msvc2017_64\lib\Qt5Gui.lib ^
hello.cpp
*/

/*
Include the definitions of the QApplication and QLabel classes.
For every Qt class, there is a header file with the same name (and capitalization)
as the class that contains the class's definition.
*/
#include <QApplication>
#include <QLabel>

int main(int argc, char *argv[])
{
	/*
		Creates a QApplication object to manage application-wide resources.
		The QApplication constructor requires argcandargv because 
		Qt supports a few command-line arguments of its own.	
	*/
	QApplication app(argc, argv);
	
	/*
		Creates a QLabel widget that displays "Hello Qt!”". 
		In Qt and Unix termi-nology, a widget is a visual element in a user interface.  
		The term stems from 341. Getting Started "window gadget" and is the equivalent 
		of both "control" and "container" in Win-dows terminology.  Buttons, menus, 
		scroll bars, and frames are all examples ofwidgets.  
		Widgets can contain other widgets; for example, an application window is 
		usually a widget that contains aQMenuBar, a fewQToolBars, aQStatusBar, and
		some other widgets. Most applications use aQMainWindowor aQDialogas the
		application window, but Qt is so flexible that any widget can be a window.

		In this example, the QLabel widget is the application window.	
	*/
	//QLabel *label = new QLabel("Hello Qt!");
	//QLabel *label = new QLabel("<h2><i>Hello</i><font color=red>Qt!</font></h2>");

	QLabel *label = new QLabel
	(
		argc == 1 ? "Hello Qt!" : argv[1]
	);

	/*
		Makes the label visible.  Widgets are always created hidden, so that we can
		customize them before showing them, thereby avoiding flicker.	
	*/
	label->show();
	
	/*
		Passes control of the application on to Qt.  At this point, the program en-ters the event loop. 
		This is a kind of stand-by mode where the program waitsfor user actions such as mouse clicks 
		and key presses.
		User actions generate events(also called "messages") to which the program can respond, usually 
		byexecuting one or more functions.  For example, when the user clicks a widget,a "mouse press"
		and a “mouse release” event are generated.  In this respect, GUI applications differ drastically 
		from conventional batch programs, whichtypically process input, produce results, and terminate 
		without human inter-vention.For simplicity, we don’t bother calling delete on the QLabel
		object at the end ofthemain()function.
		This memory leak is harmless in such a small program,since the memory will be reclaimed 
		by the operating system when the programterminates.	
	*/
	return app.exec();
}
