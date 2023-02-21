#2019-04-11	https://github.com/REMitchell/python-scraping/blob/master/Chapter01_BeginningToScrape.ipynb
#2019-04-11	pip install bs4

from urllib.request import urlopen
from urllib.error import HTTPError
from urllib.error import URLError
from bs4 import BeautifulSoup

def getTitle(url):
    try:
        html = urlopen(url)
    except HTTPError as e:
        print("The server returned an HTTP error")
        return None
    except URLError as e:
        print("The server could not be found!")
        return None
    try:
        bsObj = BeautifulSoup(html.read(), "html.parser")
        title = bsObj.h1
    except AttributeError as e:
        return None
    return title

title = getTitle("http://www.pythonscraping.com/pages/page1.html")
if title == None:
    print("Title could not be found")
else:
    print(title)
