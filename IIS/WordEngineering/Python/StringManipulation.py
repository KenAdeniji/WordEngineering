"""
2019-05-29  Created.	https://www.oreilly.com/programming/free/files/a-whirlwind-tour-of-python.pdf
2019-05-29	https://bytes.com/topic/python/answers/792283-calling-variable-function-name
	func = globals()["F" + temp]
	func("Hello", "World")
2019-05-29	https://stackoverflow.com/questions/3521715/call-a-python-method-by-name
	instance_of_foo=Foo()

	method_ref=getattr(Foo, 'bar')
	method_ref(instance_of_foo) # instance_of_foo becomes self

	instance_method_ref=getattr(instance_of_foo, 'bar')
	instance_method_ref() # instance_of_foo already bound into reference	
"""

if __name__ == '__main__':
    import sys
    # Instantiate the ArgumentType object
    for i in range(1, len(sys.argv)):
        currentArgument = sys.argv[i]
        print('[', i, ']: ', currentArgument)
        for manipulation in ["capitalize", "lower", "swapcase", "title", "upper"]:
            methodReference = getattr(str, manipulation)
            print("{}({}) = {}".format(manipulation, currentArgument, methodReference(currentArgument)))

