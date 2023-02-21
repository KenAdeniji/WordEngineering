#2021-12-29T07:01:00
"""
	http://index-of.es/Varios-2/Doing%20Math%20with%20Python.pdf
	python FractionMathematics.py
	http://127.0.0.1:5000/?first=50/10&second=100/25
	https://stackoverflow.com/questions/11774265/how-do-you-access-the-query-string-in-flask-routes
	
	add = str(first + second)
	divide = str(first / second)
	multiply = str(first * second)
	power = str(first ** second)
	subtract = str(first - second)
	answer = "Add: " + add + " Divide: " + divide + " Multiply: " + multiply + " Power: " + power + " Subtract: " + subtract
	
	https://stackoverflow.com/questions/2983139/assign-operator-to-variable-in-python
	https://stackoverflow.com/questions/54559395/how-to-store-and-use-mathematical-operators-as-python-variable?noredirect=1&lq=1
"""
from flask import Flask
from fractions import Fraction
from flask import request

app = Flask(__name__)

@app.route("/")
def fractionMathematics():
	first = Fraction(request.args.get("first"))
	second = Fraction(request.args.get("second"))
	operators = ["+", "-", "*", "/", "**"]
	answer = ""
	for operator in operators:
		operation = str( eval( str(first) + operator + str(second) ) )
		answer += str(first) + operator + str(second) + " = " + operation + "<br/>"
	return(answer)
	
if __name__ == "__main__":
    app.run()
