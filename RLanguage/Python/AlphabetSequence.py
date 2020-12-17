"""
2019-03-06  Created.
2019-03-05  https://realpython.com/python3-object-oriented-programming/
2018-03-07  https://stackoverflow.com/questions/2485466/pythons-equivalent-of-logical-and-in-an-if-statement
2019-06-11  https://www.brianheinold.net/python/A_Practical_Introduction_to_Python_Programming_Heinold.pdf
			Python class instance method __str__ versus C# ToString()
"""
class AlphabetSequence():
    # Initializer / Instance Attributes
    def __init__(self, word):
        self.word = word

    def __str__(self): #2019-06-11  https://www.brianheinold.net/python/A_Practical_Introduction_to_Python_Programming_Heinold.pdf
        return "AlphabetSequence Word: {} Index: {}".format(self.word, self.index())

    # instance method		
    def index(self):
        """
            Calculate sum of alphabets.
        """	
        asciiTotal = 0
        for c in self.word.upper():
            asciiIndex = ord(c)
            if (c >= 'A') and (c <= 'Z'):
                asciiTotal += asciiIndex - 64
        return asciiTotal
		
if __name__ == '__main__':
    import sys
    # Instantiate the AlphabetSequence object
    for i in range(1, len(sys.argv)):
        print(AlphabetSequence(sys.argv[i]))
