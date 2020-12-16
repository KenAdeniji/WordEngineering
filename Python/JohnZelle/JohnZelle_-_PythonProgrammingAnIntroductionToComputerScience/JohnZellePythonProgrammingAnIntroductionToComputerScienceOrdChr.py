# 2019-11-23T17:02:00 Created.
def ordChr():
	phrase = input("Please a phrase:")
	for current in phrase: 
		print(ord(current), end=" ")

ordChr()
