import csv
#The Gospel has met with opposition, what are we to do?
#19:05 How did God...reserve His judgment?
#19:06 What are meant... for the same?
#Open csv file with UTF-8 encoding, don't read in newline characters.
with open("ConqueringCSVFiles.csv", encoding="utf-8", newline="") as conqueringCSVFiles:
	#Create a CSV row counter and row reader
	reader = enumerate(csv.reader(conqueringCSVFiles))
	#Loop through one row at a time, i is counter, row is entire row
	for i, row in reader:
		print(i, row)
	print("Done")
	