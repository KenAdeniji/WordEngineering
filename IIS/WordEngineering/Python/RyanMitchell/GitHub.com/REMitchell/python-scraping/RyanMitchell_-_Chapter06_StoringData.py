#2019-04-14	https://github.com/REMitchell/python-scraping/blob/master/Chapter06_StoringData.ipynb
#2019-04-14	pip install bs4

from urllib.request import urlretrieve
from urllib.request import urlopen
from bs4 import BeautifulSoup

html = urlopen('http://www.pythonscraping.com')
bs = BeautifulSoup(html, 'html.parser')
#imageLocation = bs.find('a', {'id': 'logo'}).find('img')['src']
imageLocation = bs.find('img')['src']
print(imageLocation)
urlretrieve(imageLocation, 'logo.jpg')
