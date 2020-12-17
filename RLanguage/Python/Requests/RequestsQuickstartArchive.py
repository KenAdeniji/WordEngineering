"""
	2019-11-21	
		pip install requests
		https://requests.kennethreitz.org/en/master/user/quickstart/#make-a-request
"""
import sys
import requests
r = requests.get('https://api.github.com/events')
print(r.status_code)
print(r.headers['content-type'])
print(r.encoding)
print(r.text)
print(r.json())
