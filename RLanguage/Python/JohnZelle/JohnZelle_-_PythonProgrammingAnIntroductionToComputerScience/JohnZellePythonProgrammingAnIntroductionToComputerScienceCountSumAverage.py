# 2019-11-22 https://www.geeksforgeeks.org/taking-multiple-inputs-from-user-in-python/
# 2019-11-22 https://www.geeksforgeeks.org/iterate-over-a-list-in-python/
def average():
	#score1, score2 = input("Enter two scores separated by a space:").split()
	#average = ( eval(score1) + eval(score2) ) / 2.0
	#print("Average: ", average)
	
	x = list(map(float, input("Enter a multiple value, separated by a space: ").split()))
	sum = 0
	for i in x:
		sum += i
	print("Count {}. Sum {}. Average {}.".format(len(x), sum, float(sum)/len(x)))	

average()
