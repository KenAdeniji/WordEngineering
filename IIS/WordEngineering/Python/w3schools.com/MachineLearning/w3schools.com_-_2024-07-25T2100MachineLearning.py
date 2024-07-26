'''
	2024-07-25T21:00:00	http://www.w3schools.com/python/python_ml_getting_started.asp
	2024-07-25T21:00:00	http://www.w3schools.com/python/python_ml_mean_median_mode.asp
	2024-07-25T21:38:00	http://stackoverflow.com/questions/18598012/how-to-read-in-a-command-line-as-floats
	2024-07-25T21:49:00	What does it involve... myself?
		I am learning how-to do machine learning by using the Python language.
		The 1st computing task is to determine the mean average?
		2024-07-25T21:54:00 Rather than to hardcode the list of numbers, I chose to specify this list of variables on the command-line.
		2024-07-25T21:56:00	This works, if there are only 1 set of input variables. When there are more than 1 set, then I could parse 1 string argument.
		2024-07-25T22:00:00	The HisWord table processes 1 record, each time. The other tables support more than 1 record.
		2024-07-25T22:06:00	My education and experience are not substantiated, each time I program in Python using numpy nor command-line.
			http://opensourcejobhub.com/blog/2024-open-source-professionals-job-survey-report
			2024-07-25T22:12:00 It is not knowing... it is how to apply it.
			Because I do data entry, backup, and HTML writing, every day, it comes naturally to me.
			2024-07-25T22:15:00	Programming Python is somebody's else invention.
				Dizzy sleepy. Urine.
				2024-07-25T22:17:00	Koinonia House Published on Jul 17, 2017. Chuck Missler. Akedah.
					http://youtube.com/watch?v=9uTXz9VHLXw
'''
import numpy
from scipy import stats #pip install scipy
import sys

commandlinearguments = [float(x) for x in sys.argv[1:]]

numpy_commandlinearguments_mean = numpy.mean(commandlinearguments)
print("Mean: ", numpy_commandlinearguments_mean)

numpy_commandlinearguments_median = numpy.median(commandlinearguments)
print("Median: ", numpy_commandlinearguments_median)

scipy_commandlinearguments_mode = stats.mode(commandlinearguments)
print("Mode: ", scipy_commandlinearguments_mode)

numpy_commandlinearguments_standard_deviation = numpy.std(commandlinearguments)
print("Standard deviation: ", numpy_commandlinearguments_standard_deviation)

numpy_commandlinearguments_variance = numpy.var(commandlinearguments)
print("Variance: ", numpy_commandlinearguments_variance)
