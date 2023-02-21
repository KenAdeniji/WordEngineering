"""
2019-03-08	https://www.geeksforgeeks.org/data-visualization-different-charts-python/
2019-03-08	pip install pandas
2019-03-08	pip install matplotlib
2019-03-09      pip install scipy
"""

# import pandas, matplotlib, scipy
import pandas as pd 
import matplotlib.pyplot as plt
import scipy.stats as st
import os

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

# create histogram for numeric data 
df.hist() 

# show plot 
plt.show() 
        

# Dataframe of previous code is used here 
  
# Plot the bar chart for numeric values 
# a comparison will be shown between 
df.plot.bar() 
  
# plot between 2 attributes 
plt.bar(df['Tribe'], df['FirstPopulation'])
plt.xlabel("Tribe") 
plt.ylabel("Census")
plt.show() 

df.describe()

#df['FirstPopulation'].value_counts()

y = list(df['FirstPopulation']) 
plt.boxplot(y) 
plt.show() 

#df.groupby(['Tribe', 'FirstPopulation']).mean()

st.f_oneway(df['FirstPopulation'], df['SecondPopulation'])

st.pearsonr(df['FirstPopulation'], df['SecondPopulation'])

#Prints the first 5 rows of a DataFrame as default
df.head()

# Prints no. of rows and columns of a DataFrame 
df.shape


# prints first 5 rows and every column which replicates df.head() 
df.iloc[0:5,:] 
# prints entire rows and columns 
df.iloc[:,:] 
# prints from 5th rows and first 5 columns 
df.iloc[5:,:5] 


# Prints the first 5 rows of SecondPopulation
# value  
df.loc[:5,"SecondPopulation"] 

# for computing correlations 
df.corr()

# computes numerical data ranks 
df.rank()


cwd = os.getcwd()
print(cwd)

# os.chdir(path)

# write data to csv file
df.to_csv('census_no_index.csv', index = False)
df.to_csv('census_with_index.csv', index = True)
