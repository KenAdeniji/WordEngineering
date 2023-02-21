"""
2022-08-08T17:24:00  	Created.	https://pythonbasics.org/join/
2022-08-08T17:28:00		https://stackoverflow.com/questions/23706152/except-first-item-in-list-python
"""
if __name__ == '__main__':
	import sys
	joinedArguments = ", ".join( sys.argv[1:] )
	print( joinedArguments )