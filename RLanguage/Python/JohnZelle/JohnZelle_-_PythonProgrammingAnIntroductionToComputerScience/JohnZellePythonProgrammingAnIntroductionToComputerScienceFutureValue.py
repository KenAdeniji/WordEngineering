# 2019-11-22 Created.
# computes the actual purchasing power of the investment, taking inflation into account. The yearly rate of inflation will be a second input.
# The adjustment is given by this formula: principal = principal / (1+ inflation)
def futureValue():
		principal = eval(input("Enter the initial principal:"))
		apr = eval(input("Enter the annualized interest rate:"))
		term = eval(input("Enter the term:"))
		for i in range(term):
			principal = principal * (1 + apr)
		print("The amount in 10 years is:", principal)
futureValue()
