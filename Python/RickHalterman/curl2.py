"""
2019-07-20T09:15	https://python.cs.southern.edu/pythonbook/pythonbook.pdf
2019-07-20T14:54	https://www.py4e.com/code3/curl2.py
"""

if __name__ == '__main__':
	import urllib.request, urllib.parse, urllib.error

	img = urllib.request.urlopen('http://data.pr4e.org/cover3.jpg')
	fhand = open('cover3.jpg', 'wb')
	size = 0
	while True:
		info = img.read(100000)
		if len(info) < 1: break
		size = size + len(info)
		fhand.write(info)

	print(size, 'characters copied.')
	fhand.close()
