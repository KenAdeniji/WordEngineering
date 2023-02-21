# 2019-11-23T14:00:00 Created.
def userNameInfo():
	firstName = input("Please enter your first name:")
	lastName = input("Please enter your last name:")
	userName = firstName[0:1] + lastName[0:7]
	print(userName)
userNameInfo()
