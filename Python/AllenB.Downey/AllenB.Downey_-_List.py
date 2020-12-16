"""
2019-04-22 Created.	http://greenteapress.com/thinkpython/thinkpython.pdf
"""
def stub():
    cheeses = ['Cheddar','Edam','Gouda']

    numbers = [1,2,3,4,5]
    multiplied = [None] * 5
    multiplier = 5
    for i in range(len(numbers)):
        multiplied[i] = numbers[i] * multiplier
        print(i, numbers[i], multiplier, multiplied[i])
    print(sum(multiplied))

    alphabets = ['a','b','c']
    alphabets.append('d')
    print(alphabets)
    
    alphabets.extend(['e', 'f'])
    print(alphabets)

    alphabets = ['d','c','e','b','a']
    alphabets.sort()
    print(alphabets)

    t = ['a','b','c']
    x = t.pop(1) #Remove this index, 1. If you don't specify the index, the last element is removed.
    print(t)

    t = ['a','b','c']
    del t[1] #If you don’t need the removed value, you can use the del operator:
    print(t)    

    #If you know the element you want to remove (but not the index), you can use remove
    t = ['a','b','c']
    t.remove('b')
    print(t)

    s = 'spam'
    t = list(s) #Split the string s, into a character array.
    print(t)

    s = 'pining for the fjords'
    t = s.split() #Split string into words.
    print(t)

    s = 'spam-spam-spam'
    delimiter = '-'
    t = s.split(delimiter)
    print(t)
    
if __name__ == '__main__':
    import sys
    stub()
