#2023-02-13	Created. http://github.s3.amazonaws.com/downloads/diveintomark/diveintopython3/dive-into-python3.pdf?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIA5BA2674WEWV2CIOD%2F20230209%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20230209T032644Z&X-Amz-Expires=300&X-Amz-SignedHeaders=host&X-Amz-Signature=af16fe2ffb50403a6b4d6a0d5b0a5de0e366054e075ba421d043ffbc66b11c14
"""
	http://127.0.0.1:5000
	http://127.0.0.1:5000/census
"""
import Census

from flask import Flask
app = Flask(__name__)

Census.Census.populate()

@app.route("/")
def hello():
    return "Hello World!"

@app.route('/census')
def census():
    return Census.Census.buildHTML()
