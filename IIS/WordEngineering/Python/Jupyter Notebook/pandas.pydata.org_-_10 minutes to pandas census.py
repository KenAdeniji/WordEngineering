"""
	2019-11-07T06:41:00	https://pandas.pydata.org/pandas-docs/stable/getting_started/10min.html
"""
import pandas as pd

# create 2D array of table given above 
data = [['Reuben', 46500, 43730], 
		['Simeon', 59300, 22200], 
		['Gad', 45650, 40500],
                ['Judah', 74600, 76500],
                ['Issachar', 54400, 64300],
                ['Zebulun', 57400, 60500],
                ['Ephraim', 40500, 32500],
                ['Manasseh', 32200, 52700],
                ['Benjamin', 35400, 45600],
                ['Dan', 62700, 64400],
                ['Asher', 41500, 53400],
                ['Naphtali', 53400, 45400],
        ] 

# dataframe created with 
# the above data array 
df = pd.DataFrame(data, columns = ['Tribe', 'FirstPopulation', 
									'SecondPopulation'] ) 
print("All, head, tail")
print(df)
print(df.head(7))
print(df.tail(5))

print("Display the index, columns")
print(df.index)
print(df.columns)

print("Summary")
print(df.describe())

print("Transposing your data")
print(df.T)

print("Sorting by an axis")
print(df.sort_index(axis=1, ascending=False))

print("Sorting by value")
print(df.sort_values(by='FirstPopulation'))

print("Single column")
print(df['FirstPopulation'])

print("Row")
print(df[5:7])

print("Multi-axis by label")
print(df.loc[3:9, ['FirstPopulation', 'SecondPopulation']])

print("Column condition")
print(df[df['SecondPopulation'] > 50000])

print("Condition")
#print(df[df > 50000])
print(df[df['SecondPopulation'].isin([22200, 60500])])

print("Mean")
print(df.mean())

#pip install xlrd
#pip install openpyxl
import xlrd
df.to_excel('pandas.pydata.org_-_10 minutes to pandas census.xlsx', sheet_name='Sheet1')
