"""
	2019-10-24	
		pip install requests
		https://requests.kennethreitz.org/en/master/
		https://realpython.com/python-requests/
"""
import sys
import requests
r = requests.get('https://api.github.com/user', auth=(sys.argv[1], sys.argv[2]))
print(r.status_code)
print(r.headers['content-type'])
print(r.encoding)
print(r.text)
print(r.json())
