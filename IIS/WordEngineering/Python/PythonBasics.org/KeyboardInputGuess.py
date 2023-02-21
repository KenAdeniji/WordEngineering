"""
2022-08-08T17:51:00  	Created.	https://pythonbasics.org/keyboard-input/
2022-08-08T18:19:00		https://stackoverflow.com/questions/1662161/is-there-a-do-until-in-python
"""
if __name__ == '__main__':
	import random
	randomIntegerBetween1And100 = random.randrange(0,100)
	while True:
		print("Guess a number between 1 and 100? ", end='')
		guess = float( input() )
		if (randomIntegerBetween1And100 == guess):
			print("Guess is correct")
			break;
		elif (randomIntegerBetween1And100 > guess):
			print("Please enter a higher guess")
		else: 
			print("Please enter a lower guess")	
