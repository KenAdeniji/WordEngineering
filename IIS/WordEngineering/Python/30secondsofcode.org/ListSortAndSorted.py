"""
2021-04-12  Created.	https://www.30secondsofcode.org/blog/s/python-sortedlist-vs-list-sort
"""
		
if __name__ == '__main__':
    import sys
    nums = [2, 3, 1, 5, 6, 4, 0]
    print(sorted(nums))   # [0, 1, 2, 3, 4, 5, 6]
    print(nums)           # [2, 3, 1, 5, 6, 4, 0]

    print(nums.sort())    # None
    print(nums)  