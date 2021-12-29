#2021-12-28T17:41:00
"""
	http://index-of.es/Varios-2/Doing%20Math%20with%20Python.pdf
	Find the factors of an integer
	python Factors.py
	http://127.0.0.1:5000?question=24
	https://stackoverflow.com/questions/11774265/how-do-you-access-the-query-string-in-flask-routes
"""
from flask import Flask
from flask import request
app = Flask(__name__)

@app.route("/")
def hello():
	question = int(request.args.get("question"))
	return factors(question)

def factors(question):
	answer = ""
	for iterator in range(1, question + 1):
		if ((question % iterator) == 0):
			if (answer != ""):
				answer += ", "
			answer += str(iterator)
	return answer		

if __name__ == "__main__":
    app.run()
	

