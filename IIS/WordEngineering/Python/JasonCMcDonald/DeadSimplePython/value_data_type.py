import sys

# 2023-10-13T18:53:00 http://stackoverflow.com/questions/1009860/how-can-i-read-and-process-parse-command-line-arguments

def command_line_arguments_type():
	"""
	type()
	isinstance()
	Returns
	-----
	"""
	index = 0
	length = len(sys.argv) - 1
	while index < length:
		index += 1
		arg = sys.argv[index]
		print(f"Index: [{index} of {length}] Value: {arg} Type: {type(arg)} isinstance of str: {isinstance(arg, str)} ")
	return

if __name__ == '__main__':	
   command_line_arguments_type()
