#2022-01-06T13:59:00
"""
	http://index-of.es/Varios-2/Doing%20Math%20with%20Python.pdf
	python EvenOdd.py
	http://127.0.0.1:5000/?question=100
	result = ((question % 2) == 0) ? "Even" : "Odd" #Ternary operator. Not supported in Python.
	https://stackoverflow.com/questions/394809/does-python-have-a-ternary-conditional-operator
"""

from flask import Flask
from flask import request

app = Flask(__name__)

@app.route("/")
def evenOdd():
	question = int(request.args.get("question"))
	return("Even" if ((question % 2) == 0) else "Odd")
	
if __name__ == "__main__":
    app.run()
