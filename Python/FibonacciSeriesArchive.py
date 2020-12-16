#!/usr/bin/python

# 	2019-02-18	Created. 
#	https://docs.python.org/2/tutorial/introduction.html
#	Fibonacci series. The sum of two elements defines the next
#	https://stackoverflow.com/questions/493386/how-to-print-without-newline-or-space

# 	Gather our code in a main() function
def main():
	a = 0
	b = 1
	while b < 1000:
		print(b, " ", end="")
		a = b
		b = a + b
		
# Standard boilerplate to call the main() function to begin
# the program.
if __name__ == '__main__':
    main()
	