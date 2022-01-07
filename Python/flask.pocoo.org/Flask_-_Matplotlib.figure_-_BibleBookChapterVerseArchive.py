"""
	2022-01-07T18:26:00	Created. http://index-of.es/Varios-2/Doing%20Math%20with%20Python.pdf
	2022-01-07T18:26:00 http://matplotlib.org/devdocs/gallery/user_interfaces/web_application_server_sgskip.html
	2022-01-07T05:00:00 Marker options are be o, *, x, +, :
		marker='*'

SELECT BookID, MAX(ChapterID) AS Chapters, COUNT(*) AS Verses
FROM Bible..Scripture
WHERE BookID <= 3
GROUP BY BookID
ORDER BY BookID

BookID      Chapters    Verses
----------- ----------- -----------
1           50          1533
2           40          1213
3           27          859
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
	bibleBooksVersesList = [1533, 1213, 859]
	fig.suptitle("Bible Books Groups")
	fig.supxlabel('Books')
	fig.supylabel('Chapters and Verses')
	ax = fig.subplots()
	ax.plot(bibleBooksTitlesList, bibleBooksChaptersList, '*') 
	ax.plot(bibleBooksTitlesList, bibleBooksVersesList, '+') 
	buf = BytesIO();
	fig.savefig(buf, format="png");
	data = base64.b64encode(buf.getbuffer()).decode("ascii");
	return f"<img src='data:image/png;base64,{data}'/>"
	
if __name__ == "__main__":
    app.run()
