'''
	2024-07-25T21:00:00	http://www.w3schools.com/python/python_ml_getting_started.asp
	2024-07-27T08:40:00	http://www.w3schools.com/python/python_ml_multiple_regression.asp
	2024-07-27T08:59:00	pip install --force-reinstall numpy==1.26.4
'''
import pandas #pip install pandas
from sklearn import linear_model #pip install Scikit-learn

df = pandas.read_csv("w3schools.com_-_2024-07-27T0840MachineLearning_Data.csv")

X = df[['Weight', 'Volume']]
y = df['CO2']

regr = linear_model.LinearRegression()
regr.fit(X, y)

#predict the CO2 emission of a car where the weight is 2300kg, and the volume is 1300cm3:
predictedCO2 = regr.predict([[2300, 1300]])

print(predictedCO2)

print(regr.coef_)

predictedCO2 = regr.predict([[3300, 1300]])

print(predictedCO2) 