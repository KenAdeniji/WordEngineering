"""
2019-05-28  Created.
    https://stackoverflow.com/questions/46647744/checking-to-see-if-a-string-is-an-integer-or-float
2019-05-28T15:09  Those who understand success; are never made of it, they are made entirely in all. Inform to move.    
"""
class ArgumentType():
    # Initializer / Instance Attributes
    def __init__(self, passed):
        self.passed = passed

    # instance method
    def toString(self):
        return "Argument: {} Type: {}".format(self.passed, type(self.passed))

def parseEntry(entry):
    if entry.isdigit():
        entry = int(entry)
    elif entry.replace('.','',1).isdigit() and entry.count('.') < 2:
        entry = float(entry)
    return entry
    
if __name__ == '__main__':
    import sys
    # Instantiate the ArgumentType object
    # arguments = sys.argv[1].split(',')
    for i in range(1, len(sys.argv)):
        currentArgument = ArgumentType(parseEntry(sys.argv[i]))
        print(currentArgument.toString())
