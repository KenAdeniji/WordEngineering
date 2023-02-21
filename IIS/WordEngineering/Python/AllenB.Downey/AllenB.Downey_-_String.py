"""
2019-04-21 Created.	http://greenteapress.com/thinkpython/thinkpython.pdf
"""
def stub():
    fruit = 'banana'
    print(fruit[1]) #The second character.
    print(fruit[-1]) #The first character, from the right.
    print(fruit[len(fruit)-1]) #The last character.

    index = 0
    length = len(fruit)
    while index < len(fruit):
        letter = fruit[index]
        print(letter)
        index += 1
    for char in fruit:
        print(char)

    #In Robert McCloskey’s book Make Way for Ducklings, the names of the ducklings are Jack, Kack, Lack, Mack, Nack,Ouack, Pack, and Quack. 
    prefixes = ["J", "K", "L", "M", "N", "Ou", "P", "Qu"]
    suffix = "ack"

    for prefix in prefixes:
        print (prefix + suffix)

    nameSake = 'Monty Python'
    print(nameSake[6:12])

    print(fruit.upper())
    print(fruit.find('na', 1, 5))

    print('ana' in 'banana')

if __name__ == '__main__':
    import sys
    stub()
