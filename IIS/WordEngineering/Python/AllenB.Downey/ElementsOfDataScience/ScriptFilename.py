"""
2022-11-07T10:48:00 Created. https://allendowney.github.io/ElementsOfDataScience/04_loops.html
2022-11-07T10:48:00	https://stackoverflow.com/questions/4152963/get-name-of-current-script-in-python
"""
if __name__ == '__main__':
    import sys;
    import os; 	
    currentFilename = sys.argv[0];#Path(__file__).name
    fp = open(currentFilename)
    lines = 0
    words = 0	
    for content in fp:
       lines += 1
       words += len(content.split())	   
       print(content, end='')
    print()	   
    print(f'Filename {currentFilename} lines {lines} words {words}')