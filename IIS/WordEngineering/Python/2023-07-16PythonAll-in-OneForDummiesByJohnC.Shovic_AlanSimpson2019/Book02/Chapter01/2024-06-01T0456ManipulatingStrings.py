"""
	python 2024-06-01T0456ManipulatingStringsWithMethods.py what is your name?
"""
import sys
import string

string_methods = [len, min, max] 

def main():
	for string_method in string_methods:
		print( str(string_method) )
		for i in range(1, len(sys.argv)):	
			current_string = sys.argv[i]
			current_result = string_method(current_string)
			print(f"[{str(i)}] {sys.argv[i]} = {current_result}")
		print("");

if __name__ == '__main__':
	main()
	