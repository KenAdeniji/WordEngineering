"""
2019-03-06	Created.
2019-03-05	https://realpython.com/python3-object-oriented-programming/
2018-03-07      https://stackoverflow.com/questions/2485466/pythons-equivalent-of-logical-and-in-an-if-statement
"""
class AlphabetSequence():
    # Initializer / Instance Attributes
    def __init__(self, word):
        self.word = word

    # instance method		
    def index(self):
        asciiTotal = 0
        for c in self.word.upper():
            asciiIndex = ord(c)
            if (c >= 'A') and (c <= 'Z'):
                asciiTotal += asciiIndex - 64
        return asciiTotal
		
    # instance method
    def toString(self):
        return "AlphabetSequence Word: {} Index: {}".format(self.word, self.index())
		
if __name__ == '__main__':
    import sys
    # Instantiate the AlphabetSequence object
    for i in range(1, len(sys.argv)):
        currentArgument = AlphabetSequence(sys.argv[i])
        print (currentArgument.toString());
	
