"""
	2020-02-04	http://luccisun.webfactional.com/sbc/docs/FundamentalsofPythonFromFirstProgramsthroughDataStructures2009_KA_Lambert.pdf
"""
number = float(input("Enter the numeric grade:"))
if (number > 89):
	letter = "A"
elif(number > 79):
	letter = "B"
elif(number > 69):
	letter = "C"
else:
	letter = "F"
print(letter)
	
