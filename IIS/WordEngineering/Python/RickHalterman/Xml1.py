"""
2019-07-21T19:30	https://python.cs.southern.edu/pythonbook/pythonbook.pdf
2019-07-21T19:30	https://www.py4e.com/code3/xml1.py
"""

if __name__ == '__main__':
	import xml.etree.ElementTree as ET

	data ='''<person><name>Chuck</name><phone type="intl">+1 734 303 4456</phone><email hide="yes" /></person>'''
	tree = ET.fromstring(data)
	print('Name:', tree.find('name').text)
	print('Attr:', tree.find('email').get('hide'))
