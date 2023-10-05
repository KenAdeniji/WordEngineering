"""
	2022-01-06T18:26:00	Created.
	2022-01-06T18:26:00 http://matplotlib.org/devdocs/gallery/user_interfaces/web_application_server_sgskip.html
	2022-01-07T05:00:00 Marker options are be o, *, x, +, :
		marker='*'
"""
import base64
from io import BytesIO

from flask import Flask
from matplotlib.figure import Figure

app = Flask(__name__)

@app.route("/")
def chartGraph():
    # Generate the figure **without using pyplot**.
	fig = Figure()
	bibleBooksTitlesList = ["Genesis", "Exodus", "Leviticus"]	
	bibleBooksChaptersList = [50, 40]
	bibleBooksChaptersList.append(27)
	fig.suptitle("Bible Books Chapters")
	fig.supxlabel('Books')
	fig.supylabel('Chapters')
	ax = fig.subplots()
	ax.plot(bibleBooksTitlesList, bibleBooksChaptersList, '*') 
	buf = BytesIO();
	fig.savefig(buf, format="png");
	data = base64.b64encode(buf.getbuffer()).decode("ascii");
	return f"<img src='data:image/png;base64,{data}'/>"
	
if __name__ == "__main__":
    app.run()
