#2019-04-11	https://github.com/REMitchell/python-scraping/blob/master/Chapter02-AdvancedHTMLParsing.ipynb
#2019-04-11	pip install bs4
#2019-04-12     https://stackoverflow.com/questions/50533363/python-beautifulsoup-getting-attribute-value

from urllib.request import urlopen
from urllib.error import HTTPError
from urllib.error import URLError
from bs4 import BeautifulSoup

def getWarAndPeace(url):
    try:
        html = urlopen(url)
    except HTTPError as e:
        print("The server returned an HTTP error")
        return
    except URLError as e:
        print("The server could not be found!")
        return
    try:
        bs = BeautifulSoup(html.read(), "html.parser")
        
        nameList = bs.findAll('span', {'class': 'green'})
        #for name in nameList:
            #print(name.get_text())
            
        titles = bs.find_all(['h1', 'h2','h3','h4','h5','h6'])
        print([title for title in titles])

        allText = bs.find_all('span', {'class':{'green', 'red'}})
        for text in allText:
            print("text: ", text.get_text(), " class:",  text["class"])

        nameList = bs.find_all(text='the prince')
        print(len(nameList))
    except AttributeError as e:
        return
    return

def getPage3():
    html = urlopen('http://www.pythonscraping.com/pages/page3.html')
    bs = BeautifulSoup(html, 'html.parser')

    for child in bs.find('table',{'id':'giftList'}).children:
        print(child)

    for sibling in bs.find('table', {'id':'giftList'}).tr.next_siblings:
        print(sibling)

    print(bs.find('img',
              {'src':'../img/gifts/img1.jpg'})
      .parent.previous_sibling.get_text())
    
    return

#getWarAndPeace("http://www.pythonscraping.com/pages/warandpeace.html")
getPage3()

