"""
2022-12-14	http://codemag.com/Article/2212051/Using-the-Polars-DataFrame-Library
2022-12-14	pip install pandas
"""

# import polars
import polars as pl

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

	df = pl.DataFrame(
		{
			"label": tribes + tribes,
			"value": firstCensus + secondCensus
		}
	)

	#Display the types of each column
	print(df.dtypes)
	
	#Display the column names
	print(df.columns)
	
	#To get the content of the DataFrame as a list of tuples
	print(df.rows())
	
	#Selecting column(s) in Polars is straightforward - simply specify the column name using the select() method:
	print(df.select(
		'label'
	))
	
	print(df.select(
		['label', 'value']
	))
	
	print(df.select(
    pl.col(pl.Int64)  # all Int64 columns
	))

	#print(df.select(
    #pl.col(['label','value'])
    #.sort_by('value'))
	#)
	
	print(df.select(
    [pl.col(pl.Utf8)]
	))
	
	print(df.row(0))   # get the first row
	
	#print(df[:2])      # first 2 rows
	#print(df[[1,3]])   # second and fourth row
	
	print(df.filter(
		pl.col('label') == 'Simeon'
	))
	
	print(df.filter(
		(pl.col('label') == 'Judah') | (pl.col('label') == 'Gad'))
	)
	
	print
	(	
		df.filter(
		pl.col('label') == 'Reuben'
		).select(['label','value'])
	)