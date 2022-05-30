@Echo off
csc /recurse:*.cs /reference:"E:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\ReferenceAssemblies\v4.0\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll" /nowarn:162,168,219,618,649 /unsafe
