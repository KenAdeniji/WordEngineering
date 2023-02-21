"""
2019-04-22 Created.	http://greenteapress.com/thinkpython/thinkpython.pdf
"""
def stub():
    english2spanish = dict()
    print(english2spanish)
    english2spanish['one'] = 'uno'
    print(english2spanish)
    english2spanish = {'one':'uno','two':'dos','three':'tres'}
    print(english2spanish)
    print(english2spanish['two'])
    print(len(english2spanish))
    print('one' in english2spanish) #Is a key?
    vals = english2spanish.values()
    print('uno' in vals)
if __name__ == '__main__':
    import sys
    stub()
