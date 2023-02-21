"""
	2020-02-04	http://luccisun.webfactional.com/sbc/docs/FundamentalsofPythonFromFirstProgramsthroughDataStructures2009_KA_Lambert.pdf
"""
fahrenheitList = range(32, 213, 20)
for fahrenheit in fahrenheitList:
	print(fahrenheit, (fahrenheit - 32) * 5.0 / 9.0)
