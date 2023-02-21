"""
	2019-07-19	https://matplotlib.org/tutorials/introductory/usage.html#sphx-glr-tutorials-introductory-usage-py
"""

if __name__ == '__main__':
	import matplotlib.pyplot as plt
	import numpy as np
	
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

	plt.plot(tribes, firstCensus, label="First Census")
	plt.plot(tribes, secondCensus, label="Second Census")
	
	plt.xlabel('Tribes')
	plt.ylabel('Census')

	plt.title("Simple Plot")

	plt.legend()
	
	plt.show()
	