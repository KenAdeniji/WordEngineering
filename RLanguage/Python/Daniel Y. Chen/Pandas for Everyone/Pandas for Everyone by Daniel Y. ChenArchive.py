"""
2019-10-28	http://ptgmedia.pearsoncmg.com/images/9780134546933/samplepages/9780134546933_Sample.pdf
2019-10-28	pip install pandas
2019-10-28	pip install matplotlib
2019-03-09  pip install scipy
"""

# import pandas, matplotlib, scipy
import pandas as pd 
import matplotlib.pyplot as plt
import scipy.stats as st

# create 2D array of table given above 
data = [
		['Reuben', 46500, 43730], 
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
# show only the first few columns
print(df.iloc[:,0:2])

print(df.columns)

print(df.head())

print(df.tail())

print(df[df.FirstPopulation > 50000].head())