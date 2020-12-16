#2019-04-14 Created.
from urllib.request import urlopen

from bs4 import BeautifulSoup

class BeautifulSoupHelper:
#html = urlopen('http://www.pythonscraping.com/pages/page1.html')
#2019-04-11	https://github.com/REMitchell/python-scraping/blob/master/Chapter01_BeginningToScrape.ipynb
#2019-04-11	pip install bs4
#bs = BeautifulSoup(html.read(), 'html.parser')
#print(bs.h1)
  def __init__(self, source, parser):
    self.source = source
    self.parser = parser
    self.beautifulSoup = BeautifulSoup(self.source.open().read(), self.parser)

  def retrieve(self, tag):
    return self.beautifulSoup.tag

class Uri:
  def __init__(self, uri):
    self.uri = uri

  def open(self):
    return(urlopen(self.uri))

uri = Uri('http://pythonscraping.com/pages/page1.html')
html = uri.open()
print(html.read())

beautifulSoup = BeautifulSoupHelper(uri, 'html.parser')
print(beautifulSoup.source.uri)
print(beautifulSoup.parser)
print(beautifulSoup.beautifulSoup.title)
print(beautifulSoup.beautifulSoup.h1)
