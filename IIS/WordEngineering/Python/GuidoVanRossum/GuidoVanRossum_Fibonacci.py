# 2019-07-15 Fibonacci numbers module https://www.cse.unsw.edu.au/~en1811/python-docs/python-3.6.4-docs-pdf/tutorial.pdf
def fib(n): # write Fibonacci series up to n
	a, b = 0, 1
	while b < n:
		print(b, end=' ')
		a, b = b, a+b
	print()
	
def fib2(n): # return Fibonacci series up to n
	result = []
	a, b = 0, 1
	while b < n:
		result.append(b)
		a, b = b, a + b
	return result
