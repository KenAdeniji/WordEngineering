"""
2019-06-07  Created.  https://www.brianheinold.net/python/A_Practical_Introduction_to_Python_Programming_Heinold.pdf
"""
		
if __name__ == '__main__':
    import sys
    # Check for prime?
    num = int(input('Enter number:'))
    flag = 0
    for i in range(2,num):
        if num % i == 0:
            flag = 1
            break
        if flag == 1:
            break
			
    if flag == 1:
        print('Not prime')
    else:
        print('Prime')	

