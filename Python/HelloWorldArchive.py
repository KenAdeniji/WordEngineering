#!/usr/bin/python

# 2018-07-23	Created.

# Gather our code in a main() function
def main():
   print('Hello world.')
   print('17 / 3 = ', 17 / 3) # / Always returns a float
   print('17 // 3 = ', 17 // 3) # To do floor division and get an integer result (discarding any fractional result) you can use the // operator; to calculate the remainder you can use %
   print('17 % 3 = ', 17 % 3) #Remainder
   print('"Isn\'t," they said.')
   print('C:\some\name')  # here \n means newline!
   print(r'C:\some\name')  # If you don’t want characters prefaced by \ to be interpreted as special characters, you can use raw strings by adding an r before the first quote:

   print("""\
Usage: thingy [OPTIONS]
     -h                        Display this usage message
     -H hostname               Hostname to connect to
""")
	
   print(3 * 'un' + 'ium') #Strings can be concatenated (glued together) with the + operator, and repeated with *:
   
   word = 'Python'
   print('The first character in Python: ' + word[0])  # character in position 0
   print('The last character in Python: ' + word[-1])
   
   print(word[0:2])  # characters from position 0 (included) to 2 (excluded)
   print(word[:4] + word[4:]) #Note how the start is always included, and the end always excluded. This makes sure that s[:i] + s[i:] is always equal to s:
   
   print("The length of the word '" + word + "' is:", len(word))

   start_list = [5, 3, 1, 2, 4]
   squares = [x*x for x in start_list]
   print("Numbers: ", start_list);
   print("Squares: ", squares)
   
   print("squares[-3:]", squares[-3:])  # slicing returns a new list
   
   cubes = [pow(x, 3) for x in start_list]
   print("Cubes: ", cubes)

# Standard boilerplate to call the main() function to begin
# the program.
if __name__ == '__main__':
    main()
	