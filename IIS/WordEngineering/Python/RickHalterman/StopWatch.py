"""
2019-07-20T09:15	https://python.cs.southern.edu/pythonbook/pythonbook.pdf
"""

if __name__ == '__main__':
	from time import perf_counter
	print("Enter your name: ", end="")
	start_time = perf_counter()
	name = input()
	elapsed = perf_counter() - start_time
	print(name, "it took you", elapsed, "seconds to respond")
	
