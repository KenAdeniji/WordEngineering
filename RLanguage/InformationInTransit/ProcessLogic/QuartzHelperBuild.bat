tlbimp %windir%\system32\quartz.dll /out:QuartzTypeLib.dll
csc /r:QuartzTypeLib.dll QuartzHelper.cs
QuartzHelper %windir%\clock.avi
