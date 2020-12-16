"""
2019-07-20T09:15	https://python.cs.southern.edu/pythonbook/pythonbook.pdf
2019-07-20T14:54	http://www.py4e.com/code3/urllib1.py
"""

if __name__ == '__main__':
	import urllib.request

	fhand = urllib.request.urlopen('http://data.pr4e.org/romeo.txt')
	for line in fhand:
		print(line.decode().strip())
