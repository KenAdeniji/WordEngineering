rem xcopy \\10.0.4.6\d$\website \\10.0.4.1\e$\website /s /C /Y /D /I
rem xcopy \\10.0.4.6\d$\website \\10.0.4.4\e$\website /s /C /Y /D /I
xcopy \\harvest\e$\website\remindme \\10.0.4.7\e$\website\\remindme /s /C /Y /D /I  /Exclude:\\harvest\e$\website\exclude.txt
xcopy \\harvest\e$\website\remindme \\comfort\e$\DanielAdeniji\website\remindme /s /C /Y /D /I /Exclude:\\harvest\e$\website\exclude.txt