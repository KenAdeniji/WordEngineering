#2019-05-02 https://likegeeks.com/nlp-tutorial-using-python-nltk/
#2019-05-02 pip install nltk
#2019-05-02 https://stackoverflow.com/questions/22696961/beautifulsoup-lxml-and-html5lib-parsers-scraping-differences
import nltk
 
#nltk.download()

import urllib.request
response = urllib.request.urlopen('http://php.net/')
html = response.read()
print(html)

from bs4 import BeautifulSoup
#soup = BeautifulSoup(html,"html5lib")
soup = BeautifulSoup(html,"html.parser")
text = soup.get_text(strip=True)
print(text)

***
tokens = [t for t in text.split()]
print(tokens)
freq = nltk.FreqDist(tokens)
for key,val in freq.items():
    print(str(key) + ':' + str(val))
freq.plot(20, cumulative=False)
***

from nltk.corpus import stopwords
stopwords.words('english')
clean_tokens = tokens[:]
sr = stopwords.words('english')
for token in tokens:
    if token in stopwords.words('english'):
        clean_tokens.remove(token)
freq = nltk.FreqDist(clean_tokens)
for key,val in freq.items():
    print (str(key) + ':' + str(val))
	

 