"""
2019-05-29	https://www.oreilly.com/programming/free/files/a-whirlwind-tour-of-python.pdf
2019-03-08	pip install pandas
2019-05-29	Our subject to failure.
2019-07-19	https://pandas.pydata.org/pandas-docs/stable/getting_started/10min.html
"""

# import pandas
import pandas as pd 

if __name__ == '__main__':
	tribes = [
				"Reuben", "Simeon", "Gad", "Judah", "Issachar", "Zebulun",
				"Ephraim", "Manasseh", "Benjamin", "Dan", "Asher", "Naphtali"
			]

	firstCensus = [
		46500, 59300, 45650, 74600, 54400, 57400, 40500, 32200, 35400, 62700, 41500, 53400
	]

	secondCensus = [
		43730, 22200, 40500, 76500, 64300, 60500, 32500, 52700, 45600, 64400, 53400, 45400
	]

	df = pd.DataFrame(
		{
			"label": tribes + tribes,
			"value": firstCensus + secondCensus
		}
	)

	print(df['value'].sum())

	print(df.groupby('label').sum())

	print(df.head(12))
	print(df.tail(12))

	print(df.index)

	print(df.describe())
	
	print(df.T)
	
	print(df.sort_index(axis=1, ascending=False))
	
	print(df['value'])
	
	print(df[0:12])
	
	print(df.iloc[3:5, 0:1])
	