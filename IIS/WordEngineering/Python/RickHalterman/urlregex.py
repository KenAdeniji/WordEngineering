"""
2019-07-20T09:15	https://python.cs.southern.edu/pythonbook/pythonbook.pdf
2019-07-20T14:54	https://www.py4e.com/code3/urlregex.py
"""

if __name__ == '__main__':
	# Search for link values within URL input
	import urllib.request, urllib.parse, urllib.error
	import re
	import ssl # Ignore SSL certificate errors
	ctx=ssl.create_default_context()
	ctx.check_hostname=False
	ctx.verify_mode=ssl.CERT_NONE
	url=input('Enter - ')
	html=urllib.request.urlopen(url).read()
	links=re.findall(b'href="(http[s]?://.*?)"', html)
	for link in links:
		print(link.decode())
		