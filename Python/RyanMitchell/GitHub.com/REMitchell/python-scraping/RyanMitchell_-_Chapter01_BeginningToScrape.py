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
        print("title: ", bsObj.title)
        print("title: ", "bsObj.howAreYou")
        print("word: ", bsObj.word.value)
        print("alphabetSequence: ", bsObj.alphabetSequence.innerHTML)
    except AttributeError as e:
        print(e);
        return None
    return

url = "http://e-comfort.ephraimtech.com/WordEngineering/WordUnion/GetAPage.html?word=Daniel";
title = getTitle(url)
