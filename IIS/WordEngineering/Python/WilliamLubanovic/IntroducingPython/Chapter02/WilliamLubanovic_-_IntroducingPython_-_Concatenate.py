pentateuch=[
	"Genesis",
	"Exodus",
	"Leviticus",
	"Numbers",
	"Deuteronomy",
	]

x = range(len(pentateuch)) 
concatenate = ""
for n in x: 
	if (concatenate != ""):
		concatenate += ", "
	concatenate += pentateuch[n]
print(concatenate)
	
