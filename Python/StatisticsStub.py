#!/usr/bin/python

# 2016-11-13	https://docs.python.org/3/tutorial/controlflow.html#for-statements
# 2016-11-13	https://docs.python.org/3/tutorial/datastructures.html#more-on-lists
# 2016-11-13	http://stackoverflow.com/questions/1009860/command-line-arguments-in-python
# 2016-11-13	http://stackoverflow.com/questions/1094717/convert-a-string-to-integer-with-decimal-in-python
# 2016-11-13	https://hg.python.org/cpython/file/3.5/Lib/statistics.py
# 2016-11-13	http://stackoverflow.com/questions/39806822/numpy-for-windows-with-python-3-6 pip install numpy
# 2916-11-13	http://www.codemag.com/Article/1611081 Introduction to Data Science using Python by Wei-Meng Lee

# 2016-11-13    pip install pandas	

# import modules used here -- sys is a very standard one
import sys
import statistics #from Lib import statistics
import numpy as np

# import matplotlib.pyplot as plt 

import pandas as pd

# Gather our code in a main() function
def main():
   funcStatistices();
   funcPandas();

def funcPandas():
   series = pd.Series([1,2,3,4,5])
   print(series);

   dates1 = pd.date_range('20160525', periods=12)
   print(dates1)

   dates2 = pd.date_range('2016-05-01', periods=12, freq='M')
   print(dates2)   
   
   dates3 = pd.date_range('2016/05/17 09:00:00', periods=8, freq='H')
   print(dates3)

   data_frame = pd.DataFrame(np.random.randn(10,4), columns=list('ABCD')) 
   print(data_frame)

   days = pd.date_range('20150525', periods=10)
   data_frame = pd.DataFrame(np.random.randn(10,4), index=days, columns=list('ABCD'))
   print(data_frame)

   print(data_frame['A']) # prints column A

   # prints rows with index from 2015-05-25 to 2015-05-28
   print(data_frame['2015-05-25':'2015-05-28'])

   print(data_frame[2:5]) # prints row 3 through row 5

   print(data_frame.T)

   semester,grade = np.loadtxt("results.csv", unpack=True, delimiter=","); 

   print(semester,grade);   

def funcParseArguments():
   numbers = [];
   for index in range(1, len(sys.argv)):
       number = float(sys.argv[index]);
       numbers.append(number);	   
       print(index, sys.argv[index], numbers[index - 1]);
   return numbers;    	   
   
def funcStatistices():
   if (len(sys.argv) < 2):
       return;   
   numbers = funcParseArguments();
   print('Number of arguments:', len(numbers), 'arguments.');
   print('Argument List:', str(numbers));
   print('Mean: ', statistics.mean(numbers));
   print('Median: ', statistics.median(numbers));
   print('Mode: ', statistics.mode(numbers));
   
   nums = np.array(numbers) # rank 1 array
 
   even_nums = nums % 2 == 0
   
   print ('Even', nums[nums % 2 == 0])
  
# Standard boilerplate to call the main() function to begin
# the program.
if __name__ == '__main__':
    main()
	