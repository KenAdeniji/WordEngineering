"""
2022-08-08T11:43:00  	Created.	https://pythonbasics.org/strings/ 
2022-08-08T12:40:00		http://www.w3schools.com/python/ref_string_format.asp
"""
if __name__ == '__main__':
	import sys
	for argumentIndex in range(1, len(sys.argv)):
		currentArgument = sys.argv[argumentIndex];
		currentLength = len(currentArgument)
		for positionIndex in range(0, currentLength):
			currentInfo = "[{0}][{1}]: {2}".format(argumentIndex, positionIndex, currentArgument[positionIndex])
			print(currentInfo)
		