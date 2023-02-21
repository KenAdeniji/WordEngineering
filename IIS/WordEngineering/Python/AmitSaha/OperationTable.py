#2021-12-30T16:42:00
"""
	http://index-of.es/Varios-2/Doing%20Math%20with%20Python.pdf
	python OperationTable.py
	http://127.0.0.1:5000/?fromVertical=1&untilVertical=12&stepVertical=1&fromHorizontal=1&untilHorizontal=12&stepHorizontal=1
	http://stackoverflow.com/questions/11774265/how-do-you-access-the-query-string-in-flask-routes
	
	http://stackoverflow.com/questions/2983139/assign-operator-to-variable-in-python
	http://stackoverflow.com/questions/54559395/how-to-store-and-use-mathematical-operators-as-python-variable?noredirect=1&lq=1
	
	http://en.wikipedia.org/wiki/Multiplication_table
	In the Python language range cannot be float.
"""
from flask import Flask
from fractions import Fraction
from flask import request

app = Flask(__name__)

@app.route("/")
def operationTable():
	fromVertical = float(request.args.get("fromVertical"))
	untilVertical = float(request.args.get("untilVertical"))
	stepVertical = float(request.args.get("stepVertical"))
	fromHorizontal = float(request.args.get("fromHorizontal"))
	untilHorizontal = float(request.args.get("untilHorizontal"))
	stepHorizontal = float(request.args.get("stepHorizontal"))
	operators = ["+", "-", "*", "/", "**"]
	resultSet = ""
	for operator in operators:
		resultSet += "<table>"
		horizontal = fromHorizontal

		resultSet += "<thead><tr>"
		resultSet += "<th>" + operator + "<th/>"
		while horizontal <= untilHorizontal:
			resultSet += "<th>" + str(horizontal) + "<th/>"
			horizontal += stepHorizontal
		resultSet += "</thead></tr>"

		resultSet += "<tbody><tr>"		
		vertical = fromVertical
		while vertical <= untilVertical:
			resultSet += "<tr>"
			resultSet += "<th>" + str(vertical) + "<th/>"
			horizontal = fromHorizontal
			while horizontal <= untilHorizontal:
				answer = str( eval( str(vertical) + operator + str(horizontal) ) )
				resultSet += "<td>" + answer + "<td/>"
				horizontal += stepHorizontal
			resultSet += "</tr>"	
			vertical += stepVertical
		resultSet += "</tbody></table>"
	return(resultSet)
	
if __name__ == "__main__":
    app.run()
