"""
    http://github.com/KenAdeniji/WordEngineering/blob/main/IIS/WordEngineering/Python/JakeVanderPlas/Python%20Data%20Science%20Handbook%20by%20Jake%20VanderPlas/Python%20Data%20Science%20Handbook%20by%20Jake%20VanderPlas%20Data%20Manipulation%20with%20Pandas.py
    2026-07-22T22:19:00 http://jakevdp.github.io/PythonDataScienceHandbook/03.00-introduction-to-pandas.html
    2026-07-22T22:19:00 http://www.w3schools.com/python/pandas/pandas_dataframes.asp
    2026-07-22T23:13:00 http://stackoverflow.com/questions/11350770/filter-pandas-dataframe-by-substring-criteria
    Numbers 26:4                Take the sum of the people, from twenty years old and upward; as the Lord commanded Moses and the children of Israel, which went forth out of the land of Egypt.
    Numbers 4:30, Luke 3:23     From thirty years old and upward even unto fifty years old shalt thou number them, every one that entereth into the service, to do the work of the tabernacle of the congregation.
    pip install pandas
"""
import pandas as pd

data = {
    "bookID": [1, 27, 43, 66],
    "bookTitle": ["Genesis", "Daniel", "John", "Revelation"],
    "bookAuthor": ["Moses", "Daniel", "John", "John"],
    "bookGroup": ["Pentateuch", "Major Prophet, Apocalyptic", "Gospel", "Apocalyptic"],
    "bookChapters": [50, 12, 21, 22]
}

#load data into a DataFrame object:
dataFrameBibleBooks = pd.DataFrame(data)

print(dataFrameBibleBooks.index)
print(dataFrameBibleBooks.columns)

print(dataFrameBibleBooks["bookGroup"] == "Gospel")
print(dataFrameBibleBooks[dataFrameBibleBooks["bookGroup"].str.contains("Apocalyptic")])