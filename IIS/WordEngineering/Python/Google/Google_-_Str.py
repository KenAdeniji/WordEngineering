"""
	2020-05-09	https://developers.google.com/edu/python/strings
	2020-05-09	https://stackoverflow.com/questions/55807542/how-to-fix-nameerror-sys-not-defined
	2020-05-09	https://stackoverflow.com/questions/34791923/loop-over-sys-args
    2026-03-24T12:38:00...2026-03-24T12:50:00   python Google_-_Str.py "  I  " "   am  " "     here    "
"""

import sys

def stub():
    for argvCurrent in sys.argv[1:]: #2026-03-24T12:38:00...2026-03-24T12:50:00 For each command-line argument, after the Python source filename specification.
        print("Original Argument: ", argvCurrent);
        print("Lowercase: ", argvCurrent.lower())
        print("Uppercase: ", argvCurrent.upper())
        print("Strip: ", argvCurrent.strip())
        print("Length: ", len(argvCurrent)) #2026-03-24T12:38:00...2026-03-24T12:50:00
	
if __name__ == '__main__':
	stub()
