"""
2019-05-28  Created.
    https://www.oreilly.com/programming/free/files/a-whirlwind-tour-of-python.pdf
"""
class ArgumentType():
    # Initializer / Instance Attributes
    def __init__(self, passed):
        self.passed = passed

    # instance method
    def toString(self):
        return "Argument: {} cos: {} sin: {} tan: {}".format(self.passed, np.cos(self.passed), np.sin(self.passed), np.tan(self.passed))

if __name__ == '__main__':
    import numpy as np
    import sys
    # Instantiate the ArgumentType object
    for i in range(1, len(sys.argv)):
        currentArgument = ArgumentType(float(sys.argv[i]))
        print(currentArgument.toString())
