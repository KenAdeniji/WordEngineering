#2019-03-04	http://diveinto.org/python3/comprehensions.html

def directoryInfo():
	print(os.path.expanduser('~'))
	pathname = 'E:\WordEngineering\Python\diveinto.org\python3\Comprehensions.py'
	(dirname, filename) = os.path.split(pathname)
	print(dirname, filename)
	(shortname, extension) = os.path.splitext(filename)
	print(shortname, extension)
	os.chdir(dirname)
	directoryListing = glob.glob('*.py')
	metadata = os.stat(pathname)
	print(time.localtime(metadata.st_mtime))
	print(os.path.realpath(filename))
	s = '深入 Python'
	print(len(s))
	username = 'mark'
	password = 'PapayaWhip'
	print("{0}'s password is {1}".format(username, password))
	
if __name__ == '__main__':
	import glob
	import os
	import time
	directoryInfo()
	
	