#!/usr/bin/python

# 2018-07-24	Created.

import sys

# Gather our code in a main() function
def main():
	word = "Jesus wept."
	
	if len(sys.argv) > 1:
		word = sys.argv[1]
	else:
		word = input("Please enter the word: ")
		
	alphabetSequenceIndex = alphabetSequence(word)
	print("AlphabetSequenceIndex: ", alphabetSequenceIndex)
	
def alphabetSequence(word):
	alphabetSequenceIndex = 0;
	index = 0
	word = word.upper()
	length = len(word)
	
	while index < length:
		currentLetter = word[index]
		if currentLetter >= 'A' and currentLetter <= 'Z':
			asciiValue = ord(currentLetter)
			alphabetSequenceIndex += asciiValue - 64
		index = index + 1
		
	return alphabetSequenceIndex
	
# Standard boilerplate to call the main() function to begin
# the program.
if __name__ == '__main__':
    main()
	