"""
2019-04-22 Created.	http://greenteapress.com/thinkpython/thinkpython.pdf
"""
def stub():
    print(string.punctuation)
    for i in range(10):
        x = random.random()
        print(x)
    print(random.randint(5, 10)) #Generate a random integer between 5 and 10.
    t = [1, 2, 3]
    print(random.choice(t))
    
if __name__ == '__main__':
    import random
    import string
    import sys
    stub()
