import random as random_numberGenerator #Use the Python module random and give it an alias
random_number = random_numberGenerator.randint(1, 8) #Generate a random number
if random_number >= 1 and random_number <= 4:
	print("The random number was within the first half: ", random_number)
elif random_number >= 5 or random_number <= 8:
	print("The random number was within the second half: ", random_number);
else:
	print("The random number was out of the range: ", randon_number);