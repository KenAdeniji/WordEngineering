"""
2019-07-20T09:15	https://python.cs.southern.edu/pythonbook/pythonbook.pdf
2019-07-20T14:54	https://www.py4e.com/code3/urllink2.py
2019-07-20T21:59	www.crummy.com
2020-01-26T20:54	pip3 install beautifulsoup4
"""

if __name__ == '__main__':
	# To run this, you can install BeautifulSoup
	# https://pypi.python.org/pypi/beautifulsoup4

	# Or download the file
	# http://www.py4e.com/code3/bs4.zip
	# and unzip it in the same directory as this file

	import urllib.request, urllib.parse, urllib.error
	from bs4 import BeautifulSoup
	import ssl

	# Ignore SSL certificate errors
	ctx = ssl.create_default_context()
	ctx.check_hostname = False
	ctx.verify_mode = ssl.CERT_NONE

	url = input('Enter - ')
	html = urllib.request.urlopen(url, context=ctx).read()
	soup = BeautifulSoup(html, 'html.parser')

	# Retrieve all of the anchor tags
	tags = soup('a')
	for tag in tags:
		# Look at the parts of a tag
		print('TAG:', tag)
		print('URL:', tag.get('href', None))
		print('Contents:', tag.contents[0])
		print('Attrs:', tag.attrs)