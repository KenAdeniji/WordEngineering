"""
	2022-01-07T05:58:00	Created.
	2022-01-06T18:26:00 http://matplotlib.org/devdocs/gallery/user_interfaces/web_application_server_sgskip.html
	2022-01-07T05:00:00 Marker options are be o, *, x, +, :
		marker='*'
	2022-01-07T05:00:00 WhatSaithTheScripture.com/Voice/The.Coming.Prince.html
	2022-01-07T05:00:00	http://en.wikipedia.org/wiki/Siege_of_Jerusalem_(70_CE)
	
	historicalEvent = ["Commandment", "Cut off", "Siege Jerusalem-", "-Siege Jerusalem", "Birth"]
	dated = [datetime.datetime(445, 3, 14), datetime.datetime(32, 4, 6)]
	dated.append(datetime.datetime(70, 4, 14))
	dated.append(datetime.datetime(70, 9, 8))
	dated.append(datetime.datetime(1, 12, 25))
	
	2022-01-07T07:00:00 http://www.w3schools.com/python/python_datetime.asp
"""

import datetime

import base64
from io import BytesIO

from flask import Flask
from matplotlib.figure import Figure

app = Flask(__name__)

@app.route("/")
def chartGraph():
    # Generate the figure **without using pyplot**.
	fig = Figure()

	historicalEvent = ["Against you", "Out of Egypt", "Date of Birth"]

	dated = [datetime.datetime(1997, 12, 31)]
	dated.append(datetime.datetime(1998, 5, 8)) #Out of Egypt
	dated.append(datetime.datetime(1967, 10, 15)) #Date of Birth
	
	#y_values = [datetime.datetime.strptime(d,"%m/%d/%Y").date() for d in dated]	
	
	fig.suptitle("Historical Events")
	fig.supxlabel('Event')
	fig.supylabel('Date')
	ax = fig.subplots()
	ax.plot(historicalEvent, dated, '*') 
	
	buf = BytesIO();
	fig.savefig(buf, format="png");
	data = base64.b64encode(buf.getbuffer()).decode("ascii");
	return f"<img src='data:image/png;base64,{data}'/>"
	
if __name__ == "__main__":
    app.run()
