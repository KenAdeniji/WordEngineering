# 2020-02-16 Created.
from sys import argv
def main():
	argumentCount = len(argv)
	if (argumentCount > 1):
		filename = argv[1]
	else:	
		filename = input("Enter the filename:")
	infile = open(filename, "r")
	print(infile.read())
main()
