#2019-03-04	http://diveinto.org/python3/RegularExpressions.html

def regularExpression():
	s = '100 NORTH MAIN ROAD'
	s.replace('ROAD', 'RD.')
	s = '100 NORTH BROAD ROAD'
	abbreviation = re.sub('ROAD$', 'RD.', s)
	print("Fullname:", s)
	print("Abbreviation:", abbreviation);
	
if __name__ == '__main__':
	import re
	regularExpression()
	
	