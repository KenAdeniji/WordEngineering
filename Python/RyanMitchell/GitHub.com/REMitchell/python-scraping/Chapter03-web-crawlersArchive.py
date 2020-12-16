#2019-04-13	https://github.com/REMitchell/python-scraping/blob/master/Chapter03-web-crawlers.ipynb
#2019-04-13	pip install bs4

from urllib.request import urlopen
from bs4 import BeautifulSoup 

html = urlopen('http://www.htmlbible.com/kjv30/B01C022.htm')
bs = BeautifulSoup(html, 'html.parser')
for link in bs.find_all('a'):
    if 'href' in link.attrs:
        print(link.attrs['href'])

