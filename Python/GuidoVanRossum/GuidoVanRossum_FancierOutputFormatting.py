# 2019-07-16 Fancier Output Formatting https://www.cse.unsw.edu.au/~en1811/python-docs/python-3.6.4-docs-pdf/tutorial.pdf
for x in range(1,11):
	print(repr(x).rjust(2),repr(x*x).rjust(3), end='')
	print(repr(x*x*x).rjust(4))
	
for x in range(1,11):
	print('{0:2d}{1:3d}{2:4d}'.format(x, x*x, x*x*x))	
	
print('We are the {} who say "{}!"'.format('knights','Ni'))

print('{0} and {1}'.format('spam','eggs'))

print('This {food} is {adjective}.'.format(food='spam', adjective='absolutely horrible'))

print('The story of {0}, {1}, and {other}.'.format('Bill','Manfred',other='Georg'))

contents = 'eels'
print('My hovercraft is full of{}.'.format(contents))

import math
print('The value of PI is approximately {0:.3f}.'.format(math.pi))

table={'Sjoerd':4127,'Jack':4098,'Dcab':7678}
for name, phone in table.items():
	print('{0:10}==>{1:10d}'.format(name, phone))
	
	