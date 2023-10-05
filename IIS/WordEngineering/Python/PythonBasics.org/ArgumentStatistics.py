"""
2022-08-08T21:09:00  	Created.	https://pythonbasics.org/list/
2022-08-08T21:35:00		https://www.w3schools.com/python/python_lists_add.asp
"""
if __name__ == '__main__':
	import sys
	elements = []
	for argumentIndex in range(1, len(sys.argv)):
		elements.append ( float( sys.argv[argumentIndex] ) )
	
	print( "All elements: ", elements )
	print( "First element: ", elements[0] )
	print( "Last element: ", elements[-1] )
	print( "Average elements: ", sum( elements ) / len( elements) )
	print( "Count elements: ", len( elements ) )
	print( "Minimum element: ", min( elements ) )
	print( "Maximum element: ", max( elements ) )
	print( "Sum elements: ", sum( elements ) )
	
	elements.sort() #Sorted - Ascending order
	print( "Sorted - Ascending order: ", elements )

	sortedDescendingOrder = list(reversed(elements))
	print( "Sorted - Descending order: ", sortedDescendingOrder )
	
	elements = elements[::-1]
	print( "Sorted - Descending order: ", elements )