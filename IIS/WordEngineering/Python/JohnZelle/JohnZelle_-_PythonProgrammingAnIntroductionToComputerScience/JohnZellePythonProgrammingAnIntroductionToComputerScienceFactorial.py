# 2019-11-22 Created.
def factorial():
	n = eval(input("Enter the Number:"))
	fact = 1 #fact = 1L
	for factor in range(n, 1, -1):
		fact *= factor
	print("The factorial is:", fact)
factorial()
