"""
2019-03-08	https://www.geeksforgeeks.org/exploratory-data-analysis-in-python/
2019-03-08	pip install pandas
"""

def dataAnalysis():
	import pandas as pd 
	Df = pd.read_csv("https://vincentarelbundock.github.io/Rdatasets/csv/car/Chile.csv") 
	Df.describe() 
	
if __name__ == '__main__':
	dataAnalysis()