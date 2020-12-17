#2019-04-14	https://github.com/REMitchell/python-scraping/blob/master/Chapter07_ReadingDocuments.ipynb
#2019-04-11	pip install bs4

from urllib.request import urlopen
from bs4 import BeautifulSoup

textPage = urlopen('http://www.pythonscraping.com/pages/warandpeace/chapter1.txt')
#print(textPage.read())

textPage = urlopen(
             'http://www.pythonscraping.com/pages/warandpeace/chapter1-ru.txt')
#print(str(textPage.read(), 'utf-8'))

html = urlopen("http://en.wikipedia.org/wiki/Python_(programming_language)")
bs = BeautifulSoup(html, "html.parser")
content = bs.find("div", {"id":"mw-content-text"}).get_text()
content = bytes(content, "UTF-8")
content = content.decode("UTF-8")
print(content)
