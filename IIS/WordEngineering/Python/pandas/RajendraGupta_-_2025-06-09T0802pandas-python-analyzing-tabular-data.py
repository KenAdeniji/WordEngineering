'''
	2025-06-09T08:02:00 http://www.mssqltips.com/sqlservertip/8110/pandas-python-analyzing-tabular-data/
'''
import pandas #pip install pandas
print("Pandas version", pandas.__version__)

#Pandas Series
#One-dimensional array
pentateuch5BooksByMosesData = ["Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy"]
#Pandas data frame default indexing starts with 0,1,2, and so on. You can create a Pandas series with a custom index as well.
pentateuch5BooksByMosesIndex = ["1st book: beginning", "2nd book: a going out; a departure or emigration, usually of a large number of people", "3rd book: law of priests", "4th book: census", "5th book: remembrance"]
sPentateuch5BooksByMoses = pandas.Series(pentateuch5BooksByMosesData, index=pentateuch5BooksByMosesIndex)
print(sPentateuch5BooksByMoses)

majorProphetsChaptersData = [66, 52, 48, 12]
sMajorProphetsChapters = pandas.Series(majorProphetsChaptersData)

gospelsChaptersData = [28, 16, 24, 21]
sGospelsChapters = pandas.Series(gospelsChaptersData)

print("Chapters in the major prophets books, and Gospels")
print(sMajorProphetsChapters, sGospelsChapters)

print("Sum the chapters in the major prophets books, and Gospels")
print(sMajorProphetsChapters + sGospelsChapters)

print("Sum the chapters in the major prophets books, Gospels... mean, median, standard deviation, min, max")
print(sMajorProphetsChapters.sum(), sGospelsChapters.sum())

print("Indexing and Slicing")
print("The Pandas series elements start with index position 0. You can access an element based on its indexing position.")

#http://stackoverflow.com/questions/522563/how-can-i-access-the-index-value-in-a-for-loop
for idx, x in enumerate(majorProphetsChaptersData):
    print(idx, x)

apocalypticBooksData = [
    ["Daniel", "Prophet", "Daniel", 12, "Old Testament"],
    ["Revelation", "Apostle", "John", 22, "New Testament"]
]
    
dfApocalypticBooks = pandas.DataFrame(apocalypticBooksData, columns=["BookTitle", "AuthorTitle", "AuthorName", "Chapters", "Testament"])
print(dfApocalypticBooks);

#Unto whom the prince of the eunuchs gave names: for he gave unto Daniel the name of Belteshazzar; and to Hananiah, of Shadrach; and to Mishael, of Meshach; and to Azariah, of Abednego. Daniel 1:7

hebrewToBabylonianNames = {
    "hebrewName": ["Daniel", "Hananiah", "Mishael", "Azariah"],
    "babylonianName": ["Belteshazzar", "Shadrach", "Meshach", "Abednego"]
}    

# Create and print DataFrame
dfHebrewToBabylonianNames = pandas.DataFrame(hebrewToBabylonianNames)
print(dfHebrewToBabylonianNames)

#This function returns the first n number of rows from the dataframe. For example, specify df.head(1) to get the first row. If we do not specify a value, it returns the first five rows from the dataframe by default. 
print(dfHebrewToBabylonianNames.head(3))

#The next function returns the n number of rows from the bottom. For example, df.tail(n) returns the last two rows from the dataframe. It returns the last five rows if no value is specified in the tail() function. 
print(dfHebrewToBabylonianNames.tail(3))

#Get a Specific Row from the Dataframe
#The df.head() and df.tail() returns rows from the top or bottom of the dataframe. However, suppose you need a specific row based on its index position. You can use the df.loc[index] function. For example, suppose we need to get the second row from the dataframe:
print(dfHebrewToBabylonianNames.loc[1])

#Boolean Indexing
#Suppose we have a large employee dataframe, but we are interested in only those employees whose age is greater than 30 years. In this case, we can use the Boolean indexing shown below.
print(dfHebrewToBabylonianNames[dfHebrewToBabylonianNames["hebrewName"]=="Azariah"])

#This function returns helpful information about the data in the dataframe. For example, as seen below, it returns count, mean, standard deviation, minimum, 25th percentile,50th percentile,75th percentile, and maximum value.
print(dfApocalypticBooks.describe())

#This is another function, and it returns data frame details, such as the data types, size, total number of columns, count of non-null values for each column, index range of the dataframe, showing the starting and ending index values, and memory usage.
print(dfApocalypticBooks.info())

#We can specify the columns required in the output to fetch those columns instead of all the columns. For example, if your dataframe consists of 50 columns, and you need three columns in the output, you can specify those columns by name.
print(dfApocalypticBooks["BookTitle"])
print(dfApocalypticBooks[["AuthorTitle", "AuthorName"]])

#Add a New Column in the Existing Dataframe

dfApocalypticBooks.insert(3,"Where",["Babylon", "Island of Patmos"]) #Column index position, column name, values
print(dfApocalypticBooks)
