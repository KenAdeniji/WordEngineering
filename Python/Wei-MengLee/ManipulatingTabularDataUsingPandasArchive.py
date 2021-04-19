#!/usr/bin/python

# 2021-04-05	Created.

import sys
import pandas as pd

# Gather our code in a main() function
def main():
	series = creatingASeriesUsingASpecifiedIndex()
	dates = specifyingADatetimeRangeAsTheIndexOfASeries()
	
def creatingASeriesUsingASpecifiedIndex():
	series = pd.Series([50,40,27], index=[1,2,3])
	print(series)
	print(series[2]) # 3  - based on the position of the index
	return series
	
#def specifyingADatetimeRangeAsTheIndexOfASeries():
def specifyingADatetimeRangeAsTheIndexOfASeries():
	libraDates = pd.date_range('20210923', periods=30, freq='D')
	print(libraDates)
	return libraDates
	
# Standard boilerplate to call the main() function to begin
# the program.
if __name__ == '__main__':
    main()
	