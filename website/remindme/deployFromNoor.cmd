rem xcopy \\10.0.4.6\d$\website \\10.0.4.1\e$\website /s /C /Y /D /I
rem xcopy \\10.0.4.6\d$\website \\10.0.4.4\e$\website /s /C /Y /D /I
rem xcopy \\harvest\e$\website\remindme \\10.0.4.7\e$\website\\remindme /s /C /Y /D /I  /Exclude:\\harvest\e$\website\exclude.txt
rem xcopy \\harvest\e$\website\remindme \\comfort\e$\DanielAdeniji\website\remindme /s /C /Y /D /I /Exclude:\\harvest\e$\website\exclude.txt

rem dadeniji commented out /Exclude:..\exclude.txt

rem xcopy \\noor.ephraimtech.com\e$\website\remindme \\harvest.ephraimtech.com\e$\website\remindme /s /C /Y /D /I  /Exclude:..\exclude.txt

rem xcopy \\noor.ephraimtech.com\e$\website\remindme \\comfort.ephraimtech.com\e$\DanielAdeniji\website\remindme /s /C /Y /D /I /Exclude:..\exclude.txt

xcopy \\noor.ephraimtech.com\e$\website\remindme \\harvest.ephraimtech.com\e$\website\remindme /s /C /Y /D /I 

rem change target folder from \\comfort.ephraimtech.com\e$\DanielAdeniji to \\comfort.ephraimtech.com\e$\personal\DanielAdeniji
rem xcopy \\noor.ephraimtech.com\e$\website\remindme \\comfort.ephraimtech.com\e$\DanielAdeniji\website\remindme /s /C /Y /D /I

xcopy \\noor.ephraimtech.com\e$\website\remindme \\comfort.ephraimtech.com\e$\personal\DanielAdeniji\website\remindme /s /C /Y /D /I