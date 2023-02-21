"""
	2020-05-09	https://developers.google.com/edu/python/lists
	2020-05-09	https://stackoverflow.com/questions/29558007/how-can-i-generate-a-list-of-consecutive-numbers/29558077
"""

import sys

def stub():
	start = 0 if (len(sys.argv) < 2) else int(sys.argv[1]);
	stop = 10 if (len(sys.argv) < 3) else int(sys.argv[2]);
	step = 1 if (len(sys.argv) < 4) else int(sys.argv[3]);

	digits = list(range(start, stop, step))

	for digit in digits[0:]:
		print("Current Digit: ", digit);
	
if __name__ == '__main__':
	stub()

