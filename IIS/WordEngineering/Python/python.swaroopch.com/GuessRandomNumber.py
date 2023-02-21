"""
2019-10-24  Created.	https://python.swaroopch.com/functions.html
"""

def guessNumber(randomNumberGenerated):
    numberGuessed = False
    while not numberGuessed:
        guess = int(input("Guess the number: "))
        if guess == randomNumberGenerated:
            numberGuessed = True
        elif guess < randomNumberGenerated:
            print(guess, "is lower than the number")
        else:
            print(guess, "is higher than the number")
    else:		
        print(guess, "is the number")

if __name__ == '__main__':
     import random 
     import sys
     lowestNumber = 1
     highestNumber = 100
     if (len(sys.argv)) > 1 :
         lowestNumber = int(sys.argv[1])
         highestNumber = int(sys.argv[2])
     randomNumberGenerated = random.randint(lowestNumber, highestNumber + 1)
     guessNumber(randomNumberGenerated)
         
