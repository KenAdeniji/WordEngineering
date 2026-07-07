'''
2026-07-04T18:00:00
http://codemag.com/Article/1611081
Introduction to Data Science using Python
By Wei-Meng Lee
Published in: CODE Magazine: 2016 - November/December
Publication Date: October 21, 2016
Last updated: May 8, 2026 
2026-07-04T18:13:00
Separated according design.
Separated according to design.
In Australia, I did not get into politics.
    As the politician for Campsie whose office is on Beamish Street pointed out, he is a nephew of a politician, and both the Labor and Liberal parties worked together.
    I worshiped at Parramatta Christian Center, a multicultural church, which is of the Assemblies of God denomination.
    I was invited to Villawood Detention Center, 2026-07-04T18:31:00 because I am an African descent migrant.
'''
import numpy as np

listIsACollectionOfValues = [1, "Genesis", 22 / 7, True]
print(listIsACollectionOfValues)

print(listIsACollectionOfValues[2])   # 3.14  To access the items in a list, you use an index (starting at 0):

list5BooksOfMosesPentateuch = [50, 40, 27, 36, 34]

array5BooksOfMosesPentateuch = np.array(list5BooksOfMosesPentateuch) # rank 1 array
print(array5BooksOfMosesPentateuch)

array5BooksOfMosesPentateuch_even_nums_boolean_flag = array5BooksOfMosesPentateuch % 2 == 0
print(array5BooksOfMosesPentateuch_even_nums_boolean_flag)

array5BooksOfMosesPentateuch_even_nums = array5BooksOfMosesPentateuch[array5BooksOfMosesPentateuch_even_nums_boolean_flag]
print(array5BooksOfMosesPentateuch_even_nums)
