#2021-12-29T18:42:00
"""
	http://index-of.es/Varios-2/Doing%20Math%20with%20Python.pdf
	python ComplexMathematics.py
	http://127.0.0.1:5000/?firstReal=50&firstImaginary=5&secondReal=100&secondImaginary=25
	https://stackoverflow.com/questions/11774265/how-do-you-access-the-query-string-in-flask-routes
	
	https://stackoverflow.com/questions/2983139/assign-operator-to-variable-in-python
	https://stackoverflow.com/questions/54559395/how-to-store-and-use-mathematical-operators-as-python-variable?noredirect=1&lq=1
	.real .imag
The standard library’s cmath module (cmath for complex math) provides
access to a number of other specialized functions to work with complex
numbers.	
"""
from flask import Flask
from flask import request

app = Flask(__name__)

@app.route("/")
def complexMathematics():
	first = complex(int(request.args.get("firstReal")), int(request.args.get("firstImaginary")))
	second = complex(int(request.args.get("secondReal")), int(request.args.get("secondImaginary")))
	operators = ["+", "-", "*", "/", "**"]
	answer = ""
	for operator in operators:
		operation = str( eval( str(first)  + operator + str(second) ) )
		answer += str(first) + operator + str(second) + " = " + operation + "<br/>"
	return(answer)
	
if __name__ == "__main__":
    app.run()
