"""
2024-05-31T20:45:00 http://stackoverflow.com/questions/34794634/how-to-use-a-variable-as-function-name-in-python
python 2024-05-31T2032CalculatingNumbersWithFunctions.py 1 3 6]
Mozilla Firefox shutdown, exited, ended, aborted, closed.
"""
import sys
import math

math_functions = [abs, bin, hex, oct, math.factorial] 

def main():
	for math_function in math_functions:
		print( str(math_function) )
		for i in range(1, len(sys.argv)):	
			current_number = int(sys.argv[i])
			current_result = math_function(current_number)
			#print('[' + str(i) + ']', sys.argv[i], '=', current_result)
			print(f"[{str(i)}] {sys.argv[i]} = {current_result}")
		print("");

if __name__ == '__main__':
	main()
	