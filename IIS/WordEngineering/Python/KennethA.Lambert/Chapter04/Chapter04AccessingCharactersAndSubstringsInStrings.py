"""
	2020-02-05	http://luccisun.webfactional.com/sbc/docs/FundamentalsofPythonFromFirstProgramsthroughDataStructures2009_KA_Lambert.pdf
	2020-02-05	https://stackoverflow.com/questions/37896386/how-to-get-file-extension-correctly
"""
hiThere = "Hi there!"
print(hiThere, "length is", len(hiThere))
print(hiThere, "The first substring is", hiThere[0])
print(hiThere, "The last substring is", hiThere[len(hiThere)-1])	

fileList = ["myFile.txt", "myProgram.exe", "yourFile.txt"]
for filename in fileList:
	extension = filename.split('.')[-1]
	print(filename, extension)
	