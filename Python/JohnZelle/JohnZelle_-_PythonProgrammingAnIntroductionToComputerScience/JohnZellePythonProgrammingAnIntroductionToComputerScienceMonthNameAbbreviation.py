# 2019-11-23T14:24:00 Created.

monthNameAbbreviation = [
	"January",
	"February",
	"March",
	"April",
	"May",
	"June",
	"July",
	"August",
	"September",
	"October",
	"November",
	"December"
]	
def monthInfo():
	monthID = eval(input("Please enter the number of the month:"))
	print("Name:", monthNameAbbreviation[monthID-1], " Abbreviation:", monthNameAbbreviation[monthID-1][:3])
monthInfo()
