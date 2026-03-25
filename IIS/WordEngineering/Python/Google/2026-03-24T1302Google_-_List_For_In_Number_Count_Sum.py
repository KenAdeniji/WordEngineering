"""
	2026-03-24T13:02:00 http://developers.google.com/edu/python/lists
    2026-03-24T13:08:00 Python for in... index #?
    2026-03-24T13:08:00...2026-03-24T13:19:00 http://stackoverflow.com/questions/522563/how-can-i-access-the-index-value-in-a-for-loop
    2026-03-24T13:33:00 python 2026-03-24T1302Google_-_List_For_In_Number_Count_Sum.py 25 50 100    
"""

import sys
from itertools import count

def stub():
    index=0;
    sum=0;
    for argvCurrent in sys.argv[1:]:
        sum += float(argvCurrent);
        print(f"[{index}]: {argvCurrent} {sum}");
        index += 1;
        
if __name__ == '__main__':
	stub()

