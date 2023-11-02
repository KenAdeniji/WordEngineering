REM cl /EHsc /FoTakenFromHimAddedToHim.obj /LD /LDd Library/BusinessLogic/AlphabetSequence.cpp Library/BusinessLogic/UtilityHelper.cpp
REM lib /out:TakenFromHimAddedToHim.lib TakenFromHimAddedToHim.obj

REM cl /EHsc AlphabetSequenceConsole.cpp /link TakenFromHimAddedToHim.lib /out:TakenFromHimAddedToHim.exe 

cl /EHsc TakenFromHimAddedToHim.cpp Library\BusinessLogic\AlphabetSequence.cpp Library/BusinessLogic/UtilityHelper.cpp
