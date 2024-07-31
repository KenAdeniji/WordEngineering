'''
	2024-07-23			http://convert-me.com
	2024-07-29T06:53:00...2024-07-29T07:31:00	Created.
	2024-07-25T21:00:00	http://www.w3schools.com/python/python_ml_getting_started.asp
	2024-07-27T08:40:00	http://www.w3schools.com/python/python_ml_multiple_regression.asp
	2024-07-27T08:59:00	pip install --force-reinstall numpy==1.26.4
'''
import pandas #pip install pandas
from sklearn import linear_model #pip install Scikit-learn

df = pandas.read_csv("ConversionTableTemperature.csv")

X = df[['Celsuis']]
y = df[['Fahrenheit','Kelvin']]

regr = linear_model.LinearRegression()
regr.fit(X, y)

predictedFahrenheitFreezingPoint = regr.predict([[0]])

print("0 degrees Celsuis (freezing point):", predictedFahrenheitFreezingPoint)

print(regr.coef_)

predictedFahrenheitBoilingPoint = regr.predict([[100]])

print("100 degrees Celsuis (boiling point):", predictedFahrenheitBoilingPoint) 
