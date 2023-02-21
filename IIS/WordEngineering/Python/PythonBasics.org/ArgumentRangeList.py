"""
2022-08-10T18:00:00  	Created.	https://pythonbasics.org/range-function/
"""
if __name__ == '__main__':
	import sys
	elements = []
	for argumentIndex in range(1, len(sys.argv)):
		elements.append ( int( sys.argv[argumentIndex] ) )
	
	forNextStart = 0
	forNextStop = 1
	forNextIncrement = 1
	
	elementsLength = len( elements )
	match elementsLength:
		case 1:
			forNextStop = elements[0]
		case 2:
			forNextStart = elements[0]
			forNextStop = elements[1]
		case 3:
			forNextStart = elements[0]
			forNextStop = elements[1]
			forNextIncrement = elements[2]
		case _:
			pass
			
	listRange = list( range( forNextStart, forNextStop, forNextIncrement ) )
	print( listRange )
	