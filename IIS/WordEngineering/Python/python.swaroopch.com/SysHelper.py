"""
2019-10-24  Created.	https://python.swaroopch.com/modules.html
"""

def sysInfo():
    print('The command line arguments are:')
    for i in sys.argv:
        print(i)

    print('\n\nThe PYTHONPATH is', sys.path, '\n')    

if __name__ == '__main__':
    import sys
    sysInfo()
         
