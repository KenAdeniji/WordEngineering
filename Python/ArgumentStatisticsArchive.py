"""
    2019-06-08 Created.	brianheinold.net/python/A_Practical_Introduction_to_Python_Programming_Heinold.pdf	
    2019-06-08 https://stackoverflow.com/questions/4426663/how-to-remove-the-first-item-from-a-list
    2019-06-08 https://stackoverflow.com/questions/1614236/in-python-how-do-i-convert-all-of-the-items-in-a-list-to-floats
"""    
if __name__ == '__main__':
    import sys
    sys.argv.pop(0) #Remove python file name.
    numbers = [float(i) for i in sys.argv]
    print("Average:", sum(numbers) / len(numbers))
    print("Count:", len(numbers))
    print("Maximum:", max(numbers))
    print("Minimum:", min(numbers))
    print("Sum:", sum(numbers))
