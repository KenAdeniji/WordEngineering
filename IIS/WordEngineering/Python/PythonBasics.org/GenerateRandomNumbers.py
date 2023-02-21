"""
2022-08-08T17:45:00  	Created.	https://pythonbasics.org/random-numbers/
"""
if __name__ == '__main__':
	import random
	# Create a random floating point number and print it.
	print(random.random())

	# pick a random whole number between 0 and 10.
	print(random.randrange(0,10))

	# pick a random floating point number between 0 and 10.
	print(random.uniform(0,10))
	