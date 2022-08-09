"""
2022-08-08T17:35:00  	Created.	https://pythonbasics.org/split/
"""
if __name__ == '__main__':
	import sys
	for argumentIndex in range(1, len(sys.argv)):	
		print( sys.argv[ argumentIndex ].split() )