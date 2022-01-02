#2022-01-02T03:14:00
"""
	http://index-of.es/Varios-2/Doing%20Math%20with%20Python.pdf
	python TemperatureConversion.py
	http://127.0.0.1:5000/?unit=celsius&quantity=100
	http://stackoverflow.com/questions/11774265/how-do-you-access-the-query-string-in-flask-routes
	https://stackoverflow.com/questions/67064101/python-temperature-class-converter-k-f-c
	
first = Temperature()
print(first)
first.kelvin = 0
print(first)
first.fahrenheit = 212
print(first)
first.celsius = 10
print(first)	
"""

class Temperature:
    def __init__(self):
        self.__kelvin = 273.15

    @property
    def kelvin(self):
        return self.__kelvin

    @property
    def celsius(self):
        return self.__kelvin - 273.15

    @property
    def fahrenheit(self):
        return (self.__kelvin - 273.15) * 9 / 5 + 32

    @kelvin.setter
    def kelvin(self,value):
        self.__kelvin = value

    @celsius.setter
    def celsius(self,value):
        self.__kelvin = value + 273.15

    @fahrenheit.setter
    def fahrenheit(self,value):
        self.__kelvin = (value - 32) * 5 / 9 + 273.15

    def __repr__(self):
        return f'Temperature(__kelvin={self.__kelvin})'

    def __str__(self):
        return f'{self.kelvin:.2f}\N{DEGREE SIGN}K/{self.celsius:.2f}\N{DEGREE SIGN}C/{self.fahrenheit:.2f}\N{DEGREE SIGN}F'

first = Temperature()
print(first)
first.kelvin = 0
print(first)
first.fahrenheit = 212
print(first)
first.celsius = 10
print(first)

from flask import Flask
from flask import request

app = Flask(__name__)

@app.route("/")
def temperatureConversion():
	unit = request.args.get("unit").lower()
	quantity = float(request.args.get("quantity"))

	first = Temperature()
	
	match unit:
		case "celsius":
			first.celsius = quantity
		case "fahrenheit":
			first.fahrenheit = quantity
		case "kelvin":
			first.kelvin = quantity
		#case _:
			# this is the default handler if none
			# of the above cases match.
		
	return(str(first))
	
if __name__ == "__main__":
    app.run()
