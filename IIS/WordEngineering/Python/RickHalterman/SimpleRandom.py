"""
2019-07-20T09:15	https://python.cs.southern.edu/pythonbook/pythonbook.pdf
2019-07-20T09:25	https://en.wikipedia.org/wiki/Mersenne_Twister
"""

if __name__ == '__main__':
	from random import randrange, seed
	seed(23) # Set random number seed
	for i in range(0, 100): # Print 100 random numbers
		print(randrange(1, 1001), end=' ')   # Range 1...1,000, inclusive
	print() # Print newine
	
	from random import choice
	for i in range(10):
		print(choice(("one", "two", "three", "four", "five", "six","seven", "eight", "nine", "ten")))