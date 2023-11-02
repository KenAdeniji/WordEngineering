cl /EHsc /FoTakenFromHimAddedToHim.obj /LD /LDd Library/ProcessLogic/AlphabetSequence.cpp
lib /out:TakenFromHimAddedToHim.lib TakenFromHimAddedToHim.obj

REM cl /EHsc AlphabetSequenceConsole.cpp /link TakenFromHimAddedToHim.lib /out:TakenFromHimAddedToHim.exe 

cl /EHsc TakenFromHimAddedToHim.cpp Library\ProcessLogic\AlphabetSequence.cpp
