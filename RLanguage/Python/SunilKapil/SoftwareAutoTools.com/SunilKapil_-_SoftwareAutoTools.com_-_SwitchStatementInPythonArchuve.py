#2019-09-05 https://softwareautotools.com/2018/09/02/switch-statement-in-python/

"""
let say you have function which accept different parameter and take different actions on that example:
"""

def calculateIf(first_num, second_num, method):
    if method == 'add':
        return first_num + second_num
    elif method == 'minus':
        return first_num - second_num
    elif method == 'divide':
        return first_num//second_num
    elif method == 'multiply':
        return first_num * second_num
    else:
        return 'Wrong Input'

print(calculateIf(12, 10, 'minus'))