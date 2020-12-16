"""
2019-07-20T09:15	https://python.cs.southern.edu/pythonbook/pythonbook.pdf
2019-07-20T14:54	https://www.py4e.com/code3/urlwords.py
"""

if __name__ == '__main__':
	import urllib.request, urllib.parse, urllib.error

	fhand = urllib.request.urlopen('http://data.pr4e.org/romeo.txt')

	counts = dict()
	for line in fhand:
		words = line.decode().split()
		for word in words:
			counts[word] = counts.get(word, 0) + 1
	print(counts)
