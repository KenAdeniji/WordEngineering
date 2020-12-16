"""
	2020-05-09	https://developers.google.com/edu/python/strings
	2020-05-09	https://stackoverflow.com/questions/55807542/how-to-fix-nameerror-sys-not-defined
	2020-05-09	https://stackoverflow.com/questions/34791923/loop-over-sys-args
"""

import sys

def stub():
	for argvCurrent in sys.argv[1:]:
		print("Original Argument: ", argvCurrent);
		print("Lowercase: ", argvCurrent.lower())
		print("Uppercase: ", argvCurrent.upper())
	
if __name__ == '__main__':
	stub()
