"""
2019-05-28  Created.
    https://www.oreilly.com/programming/free/files/a-whirlwind-tour-of-python.pdf
    https://stackoverflow.com/questions/1740726/turn-string-into-operator
    https://stackoverflow.com/questions/538346/iterating-each-character-in-a-string-using-python
"""
if __name__ == '__main__':
    import operator
    import sys
    
    firstNumber = float(sys.argv[1]); secondNumber = float(sys.argv[2]);
    ops =\
    { 
        '+' : operator.add,
        '-' : operator.sub,
        '*' : operator.mul,
        #'/' : operator.div,
        '%' : operator.mod,
        '^' : operator.xor,
    }    
    for operation in "+-*%":
        print("{} {} {} = {}".format(firstNumber,operation,secondNumber,ops[operation](firstNumber,secondNumber)))
        
