"""
2019-08-22	Created.
2019-05-29  https://www.oreilly.com/programming/free/files/a-whirlwind-tour-of-python.pdf
2019-05-29	https://bytes.com/topic/python/answers/792283-calling-variable-function-name
"""

if __name__ == '__main__':
   import sys
   for i in range(1, len(sys.argv)):
       currentArgument = sys.argv[i]
       print('[', i, ']: ', currentArgument);
       object_methods = ["isdigit", "isalpha", "lower", "upper"]
       for manipulation in object_methods:
           methodReference = getattr(str, manipulation)
           print("{}({}) = {}".format(manipulation, currentArgument, methodReference(currentArgument)))