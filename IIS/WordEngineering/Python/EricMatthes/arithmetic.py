"""
2022-08-05  Created. https://www.google.com/books/edition/Python_Crash_Course_2nd_Edition/w1v6DwAAQBAJ?hl=en&gbpv=1
2022-08-05  https://stackoverflow.com/questions/394809/does-python-have-a-ternary-conditional-operator/394814#394814
"""
if __name__ == '__main__':
	import sys
	first_number = float(sys.argv[1])
	second_number = float(sys.argv[2])
	result_set = f"\
Add (+): {first_number + second_number} \n\
Subtract (-): {first_number - second_number} \n\
Multiply (*): {first_number * second_number} \n\
Divide (/): {first_number / second_number} \n\
	"
	print(result_set)