#       2019-07-16T21:47:00 https://www.cse.unsw.edu.au/~en1811/python-docs/python-3.6.4-docs-pdf/tutorial.pdf
class Complex():
    # Initializer / Instance Attributes
    def __init__(self, realpart, imagpart):
        self.r = realpart
        self.i = imagpart
        
    def __str__(self): #2019-06-11  https://www.brianheinold.net/python/A_Practical_Introduction_to_Python_Programming_Heinold.pdf
        return "Complex {0}, {1}j".format(self.r, self.i)

if __name__ == '__main__':
    import sys
    # Instantiate the Complex object
    x = Complex(3.0,-4.5)
    print(x)
